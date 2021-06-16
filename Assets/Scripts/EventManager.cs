using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	// DataInitCompleteEvent
	// This event is used exclusively in the Startup scene to wait for
	// DataManager to finish initializing all data values.

	public delegate void DataInitCompleteEvent();
	private static event DataInitCompleteEvent _onDataInitComplete;

	public static void SubscribeDataInitCompleteEvent(DataInitCompleteEvent callback)
	{
		_onDataInitComplete += callback;
	}

	public static void TriggerDataInitCompleteEvent()
	{
		if (_onDataInitComplete != null)
		{
			_onDataInitComplete();
		}
	}
}
