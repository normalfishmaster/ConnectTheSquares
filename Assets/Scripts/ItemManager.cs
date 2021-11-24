using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
	private static ItemManager _instance;
	private static DataManager _data;
	private static CloudOnceManager _cloudOnce;

	public Sprite _itemRemoveAds;
	public Sprite _itemUnlockAllLevels;

	public static int NUM_ITEM = 2;

	public static int REMOVE_ADS = 0;
	public static int UNLOCK_ALL_LEVELS = 1;

	public bool IsItemUnlocked(int itemNumber)
	{
		if (itemNumber == REMOVE_ADS)
		{
			return _cloudOnce.GetRemoveAds();
		}
		else if (itemNumber == UNLOCK_ALL_LEVELS)
		{
			return _cloudOnce.GetUnlockAllLevels();
		}

		return false;
	}

	public void SetItemUnlocked(int itemNumber, bool unlock)
	{
		if (itemNumber == REMOVE_ADS)
		{
			_cloudOnce.SetRemoveAds(unlock);
		}
		else if (itemNumber == UNLOCK_ALL_LEVELS)
		{
			_cloudOnce.SetUnlockAllLevels(unlock);
		}
		_cloudOnce.Save();
	}

	public Sprite GetItemSprite(int itemNumber)
	{
		if (itemNumber == REMOVE_ADS)
		{
			return _itemRemoveAds;
		}
		else if (itemNumber == UNLOCK_ALL_LEVELS)
		{
			return _itemUnlockAllLevels;
		}

		return _itemRemoveAds;
	}

	// Unity Lifecyle

	private void Awake()
	{
		// Singleton implementation
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);

		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
	}
}
