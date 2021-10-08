using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupLogic : MonoBehaviour
{
	private DataManager _data;
	private LevelManager _level;

	// Event Callbacks

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

		SceneManager.LoadScene("MainMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		Application.targetFrameRate = 300;
		EventManager.SubscribeDataInitCompleteEvent(OnDataInitComplete);
	}
}
