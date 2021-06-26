using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogic : MonoBehaviour
{
	private TestUI _ui;
	private DataManager _data;
	private AdManager _ad;

	// UI Events - Data

	public void DoDataIntGetButtonPressed(string key)
	{
		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
			return;
		}

		Debug.Log(key + ": " + _data.GetIntByKey(key));
	}

	public void DoDataIntSetButtonPressed(string key, string value)
	{
		int valueInt;

		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
			return;
		}

		try
		{
			valueInt = Convert.ToInt32(value);
		}
		catch
		{
			Debug.Log(value + ": Invalid value");
			return;
		}

		_data.SetIntByKey(key, valueInt);
	}

	public void DoDataFloatGetButtonPressed(string key)
	{
		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
			return;
		}

		Debug.Log(key + ": " + _data.GetFloatByKey(key));
	}

	public void DoDataFloatSetButtonPressed(string key, string value)
	{
		float valueFloat;

		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
			return;
		}

		try
		{
			valueFloat = Convert.ToSingle(value);
		}
		catch
		{
			Debug.Log(value + ": Invalid value");
			return;
		}

		_data.SetFloatByKey(key, valueFloat);
	}

	public void DoDataStringGetButtonPressed(string key)
	{
		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
			return;
		}

		Debug.Log(key + ": " + _data.GetStringByKey(key));
	}

	public void DoDataStringSetButtonPressed(string key, string value)
	{
		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
			return;
		}

		_data.SetStringByKey(key, value);
	}

	public void DoDataAllDumpButtonPressed()
	{
		if (_data.CheckAudio())
		{
			Debug.Log(_data.GetAudioKey() + ": " + _data.GetAudio());
		}
		else
		{
			Debug.Log(_data.GetAudioKey() + ": Uninitialized");
		}

		if (_data.CheckHint())
		{
			Debug.Log(_data.GetHintKey() + ": " + _data.GetHint());
		}
		else
		{
			Debug.Log(_data.GetHintKey() + ": Uninitialized");
		}

		if (_data.CheckAdFree())
		{
			Debug.Log(_data.GetAdFreeKey() + ": " + _data.GetAdFree());
		}
		else
		{
			Debug.Log(_data.GetAdFreeKey() + ": Uninitialized");
		}
	}

	public void DoDataAllDeleteButtonPressed()
	{
		_data.DeleteAll();
	}

	public void DoDataAllReinitButtonPressed()
	{
		_data.DeleteAll();

		_data.InitAudio();
		_data.InitHint();
		_data.InitAdFree();
	}

	// UI Events - Ad

	public void DoAdInterstitialButtonPressed()
	{
		if (_ad.ShowInterstitial() != 0)
		{
			Debug.Log("Showing interstitial ad failed");
		}
	}

	public void DoAdInterstitialVideoButtonPressed()
	{
		if (_ad.ShowInterstitialVideo() != 0)
		{
			Debug.Log("Showing interstitial video ad failed");
		}
	}

	public void DoAdRewardedButtonPressed()
	{
		_ad.ClearRewardStatus();
		if (_ad.ShowRewarded() != 0)
		{
			Debug.Log("Showing rewarded ad failed");
		}
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("TestUI").GetComponent<TestUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
	}

	private void Update()
	{
		AdManager.RewardStatus rewardStatus;

		rewardStatus = _ad.GetRewardStatus();
		if (rewardStatus != AdManager.RewardStatus.None)
		{
			if (rewardStatus == AdManager.RewardStatus.Fail)
			{
				Debug.Log("Rewarded ad failed to reward user");
			}
			else if (rewardStatus == AdManager.RewardStatus.Success)
			{
				Debug.Log("Rewarded ad successfully rewarded user");
			}

			_ad.ClearRewardStatus();
		}
	}
}
