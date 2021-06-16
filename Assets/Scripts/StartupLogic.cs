using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupLogic : MonoBehaviour
{
	// Event Callbacks

	private void DataInitCompleteCallback()
	{
	}

	// Unity Lifecycle

	private void Awake()
	{
		EventManager.SubscribeDataInitCompleteEvent(DataInitCompleteCallback);
	}
}
