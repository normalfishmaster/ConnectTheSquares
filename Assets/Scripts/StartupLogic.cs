using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupLogic : MonoBehaviour
{
	// Event Callbacks

	private void OnDataInitComplete()
	{
		EventManager.UnsubscribeDataInitCompleteEvent(OnDataInitComplete);
		SceneManager.LoadScene("MainMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		EventManager.SubscribeDataInitCompleteEvent(OnDataInitComplete);
	}
}
