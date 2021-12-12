using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupLogic : MonoBehaviour
{
	private StartupUI _ui;
	private DataManager _data;
	private CloudOnceManager _cloudOnce;
	private LevelManager _level;

	private GameObject _dummy;

	private bool _dataInitComplete;
	private bool _cloudOnceInitComplete;
	private bool _cloudOnceLoadComplete;
	private bool _cloudOnceSaveComplete;

	public float LOAD_DELAY;

	// Loading

	private void SetupLoading()
	{
		_ui.ResetLoadingSlider();
	}

	// InitComplete Callbacks

	private void OnDataInitComplete()
	{
		_data.UnsubscribeInitComplete(OnDataInitComplete);
		_dataInitComplete = true;

		if (_cloudOnceInitComplete)
		{
			_ui.AnimateLoadingSlider(60f, ()=>{});
		}
		else
		{
			_ui.AnimateLoadingSlider(40f, ()=>{});
		}
	}

	private void OnCloudOnceInitComplete()
	{
		_cloudOnce.UnsubscribeInitComplete(OnCloudOnceInitComplete);
		_cloudOnceInitComplete = true;

		if (_dataInitComplete)
		{
			_ui.AnimateLoadingSlider(60f, ()=>{});
		}
		else
		{
			_ui.AnimateLoadingSlider(40f, ()=>{});
		}
	}

	// Cloud Load

	private void OnCloudLoadComplete(bool success)
	{
                _cloudOnce.UnsubscribeCloudLoadComplete(OnCloudLoadComplete);
		_cloudOnce.SanitizeCloudVariables();

		_cloudOnceLoadComplete = true;

		_ui.AnimateLoadingSlider(80f, ()=>{});
	}

	// Cloud Save

	private void OnCloudSaveComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudSaveComplete(OnCloudSaveComplete);
		_cloudOnceSaveComplete = true;

		LoadScene();
	}

	// Test

	private void RunTestSequence()
	{

/*



		int numColor = _level.GetNumColor();

		for (int i = 0; i < numColor; i++)
		{
			int alphabet = _level.GetNumAlphabet(i);

			for (int j = 0; j < alphabet; j++)
			{
				for (int k = 0; k < 58; k++)
				{
					_cloudOnce.SetLevelStar(i, j, k, 3);

				}
			}
		}


		_cloudOnce.IncrementHint(100);

		_cloudOnce.DeleteAll();
		_data.DeleteAll();
		_data.InitializeData();
		_cloudOnce.IncrementHint(100);


		_cloudOnce.DeleteAll();
		_data.DeleteAll();
		_data.InitializeData();


		_data.SetBlockMetalUnlocked(1);
*/
	}

	// Load Scene

	private void LoadScene()
	{
		_ui.AnimateLoadingSlider(100f,
			()=>
			{
				LeanTween.delayedCall(_dummy, LOAD_DELAY, ()=>{}).setOnComplete
				(
					()=>
					{
						RunTestSequence();

						if (_cloudOnce.GetLevelStar(0, 0, 0) == 0)
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
				);
			}
		);
	}

	// Load States

	private enum LoadState
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
				LoadScene();
				_loadState = LoadState.DELAY_BEFORE_EXIT;
			}
		}
	}

	public void DoLoadStateLoadCloud()
	{
		if (_cloudOnceLoadComplete)
		{
			_cloudOnce.SubscribeCloudSaveComplete(OnCloudSaveComplete);
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
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("StartupUI").GetComponent<StartupUI>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		_dummy = GameObject.Find("StartupUI");

		_dataInitComplete = false;
		_data.SubscribeInitComplete(OnDataInitComplete);

		_cloudOnceInitComplete = false;
		_cloudOnce.SubscribeInitComplete(OnCloudOnceInitComplete);

		_cloudOnceLoadComplete = false;
		_cloudOnceSaveComplete = false;

		_loadState = LoadState.WAIT;
	}

	private void Start()
	{
		SetupLoading();
		_ui.AnimateLoadingSlider(10f, ()=>{});
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
