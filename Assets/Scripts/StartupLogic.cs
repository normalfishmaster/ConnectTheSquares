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

	// InitComplete Callbacks

	private void OnDataInitComplete()
	{
		_data.UnsubscribeInitComplete(OnDataInitComplete);
		_dataInitComplete = true;
	}

	private void OnCloudOnceInitComplete()
	{
		_cloudOnce.UnsubscribeInitComplete(OnCloudOnceInitComplete);

		if (_cloudOnce.IsSignedIn())
		{
			_cloudOnce.SubscribeCloudLoadComplete(OnCloudLoadComplete);
			_cloudOnce.Load();
		}
		else
		{
			_cloudOnceInitComplete = true;
		}
	}

	// Cloud Load

	private void OnCloudLoadComplete(bool success)
	{
                _cloudOnce.UnsubscribeCloudLoadComplete(OnCloudLoadComplete);

		if (success)
		{
			_cloudOnce.LoadCloudToData();
		}

		_cloudOnce.SaveDataToCloud();
		_cloudOnce.Save();

		_cloudOnceInitComplete = true;
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
		SceneManager.LoadScene("MainMenuScene");
	}

	// Test

	private void RunTestSequence()
	{
		_data.DeleteAll();
		_data.InitializeData();
		_cloudOnce.DeleteAll();
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
	}

	private void Update()
	{
		if (_dataInitComplete && _cloudOnceInitComplete)
		{
			if (_loadDelayStarted == false)
			{
				RunTestSequence();

				_loadDelayStarted = true;
				StartCoroutine(DelayAndLoadMainMenu());
			}
		}
	}
}
