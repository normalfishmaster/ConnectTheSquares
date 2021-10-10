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
		EventManager.UnsubscribeDataInitCompleteEvent(OnDataInitComplete);

		if (_data.GetUnlockAllLevels() == 1)
		{
			int numColor = _level.GetNumColor();

			for (int i = 0; i < numColor; i++)
			{
				int numAlphabet = _level.GetNumAlphabet(i);

				for (int j = 0; j < numAlphabet; j++)
				{
					int numMap = _level.GetNumMap(i, j);

					for (int k = 0; k < numMap; k++)
					{
						_data.SetLevelLock(i, j, k, 0);
					}
				}
			}
		}

		_dataInitComplete = true;
	}

	private void OnCloudOnceInitComplete()
	{
		_cloudOnceInitComplete = true;
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
			SceneManager.LoadScene("MainMenuScene");
		}
	}
}
