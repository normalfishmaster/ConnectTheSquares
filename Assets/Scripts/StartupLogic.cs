using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupLogic : MonoBehaviour
{
	// Event Callbacks

	private void DataInitCompleteCallback()
	{
		EventManager.UnsubscribeDataInitCompleteEvent(DataInitCompleteCallback);
		SceneManager.LoadScene("TestScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		EventManager.SubscribeDataInitCompleteEvent(DataInitCompleteCallback);
	}
}
