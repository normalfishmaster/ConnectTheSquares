using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupLogic : MonoBehaviour
{
	private DataManager _data;
	private CloudOnceManager _cloudOnce;
	private LevelManager _level;

	private bool _dataInitComplete;
	private bool _cloudOnceInitComplete;
	private bool _cloudOnceLoadComplete;
	private bool _cloudOnceSaveComplete;

	// InitComplete Callbacks

	private void OnDataInitComplete()
	{
		_data.UnsubscribeInitComplete(OnDataInitComplete);
		_dataInitComplete = true;
	}

	private void OnCloudOnceInitComplete()
	{
		_cloudOnce.UnsubscribeInitComplete(OnCloudOnceInitComplete);
		_cloudOnceInitComplete = true;
	}

	// Cloud Load

	private void OnCloudLoadComplete(bool success)
	{
                _cloudOnce.UnsubscribeCloudLoadComplete(OnCloudLoadComplete);

		if (success)
		{
			_cloudOnce.LoadCloudToData();
		}

		_cloudOnceLoadComplete = true;
	}

	// Cloud Save

	private void OnCloudSaveComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudSaveComplete(OnCloudSaveComplete);
		_cloudOnceSaveComplete = true;
	}

	// Co-routine to delay and load MainMenuScene
	// A delay is needed before loading the MainMenuScene to allow all the Google Play
	// initialization to complete and to avoid any lags in MainMenuScene.
	// (Note: This is a solution to fix the front enter audio lag in MainMenuScene)

	public float _loadDelay;
	private bool _loadDelayStarted;

	IEnumerator DelayAndLoadMainMenu()
	{
		yield return new WaitForSeconds(_loadDelay);
	}

	// Test

	private void RunTestSequence()
	{
/*
		_data.DeleteAll();
		_cloudOnce.DeleteAll();
		_data.InitializeData();

		_cloudOnce.IncrementHint(100);

		_data.DeleteAll();
		_cloudOnce.DeleteAll();
		_data.InitializeData();
		_data.SetBlockMetalUnlocked(1);
*/
	}

	// Load States

	enum LoadState
	{
		WAIT,
		LOAD_CLOUD,
		SAVE_CLOUD,
		DELAY_BEFORE_EXIT,
	}

	LoadState _loadState;

	public void DoLoadStateWait()
	{
		if (_dataInitComplete && _cloudOnceInitComplete)
		{
			if (_cloudOnce.IsSignedIn())
			{
				_cloudOnce.SubscribeCloudLoadComplete(OnCloudLoadComplete);
				_cloudOnce.Load();

				_loadState = LoadState.LOAD_CLOUD;
			}
			else
			{
				_loadState = LoadState.DELAY_BEFORE_EXIT;
			}
		}
	}

	public void DoLoadStateLoadCloud()
	{
		if (_cloudOnceLoadComplete)
		{
			_cloudOnce.SubscribeCloudSaveComplete(OnCloudSaveComplete);

			_cloudOnce.SaveDataToCloud();
			_cloudOnce.Save();

			_loadState = LoadState.SAVE_CLOUD;
		}
	}

	public void DoLoadStateSaveCloud()
	{
		if (_cloudOnceSaveComplete)
		{
			_loadState = LoadState.DELAY_BEFORE_EXIT;
		}
	}

	public void DoLoadStateDelayBeforeExit()
	{
		StartCoroutine(DelayAndLoadMainMenu());

		RunTestSequence();

		if (_data.GetLevelStar(0, 0, 0) == 0)
		{
			_data.SetMenuColor(0);
			_data.SetMenuAlphabet(0);
			_data.SetMenuMap(0);

			SceneManager.LoadScene("LevelScene");
		}
		else
		{
			SceneManager.LoadScene("MainMenuScene");
		}
	}

	// Unity Lifecycle

	private void Awake()
	{
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		Application.targetFrameRate = 300;

		_dataInitComplete = false;
		_data.SubscribeInitComplete(OnDataInitComplete);

		_cloudOnceInitComplete = false;
		_cloudOnce.SubscribeInitComplete(OnCloudOnceInitComplete);

		_cloudOnceLoadComplete = false;
		_cloudOnceSaveComplete = false;

		_loadState = LoadState.WAIT;
	}

	private void Update()
	{
		if (_loadState == LoadState.WAIT)
		{
			DoLoadStateWait();
		}
		else if (_loadState == LoadState.LOAD_CLOUD)
		{
			DoLoadStateLoadCloud();
		}
		else if (_loadState == LoadState.SAVE_CLOUD)
		{
			DoLoadStateSaveCloud();
		}
		else if (_loadState == LoadState.DELAY_BEFORE_EXIT)
		{
			DoLoadStateDelayBeforeExit();
		}
	}
}
