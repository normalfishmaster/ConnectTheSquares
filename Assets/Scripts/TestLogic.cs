using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogic : MonoBehaviour
{
	private TestUI _ui;
	private DataManager _data;
	private AdManager _ad;

	// UI Events - Data

	public void DoDataGetButtonPressed()
	{
		string key;
		string value;

		key = _ui.GetDataKeyText();

		if (_data.CheckByKey(key) == false)
		{
			Debug.Log(key + ": Uninitialized");
		}

		value = _data.GetByKey(key);
		Debug.Log(key + ": " + value);
	}

	public void DoDataSetButtonPressed()
	{
		string key;
		string value;

		key = _ui.GetDataKeyText();
		value = _ui.GetDataValueText();

		if (_data.SetByKey(key, value) != 0)
		{
			Debug.Log(value + ": Invalid key or value");
		}
	}

	public void DoDataDumpAllButtonPressed()
	{
		if (_data.CheckAudio())
		{
			Debug.Log(DataManager.AUDIO_KEY + ": " + _data.GetAudio());
		}
		else
		{
			Debug.Log(DataManager.AUDIO_KEY + ": Uninitialized");
		}

		if (_data.CheckHint())
		{
			Debug.Log(DataManager.HINT_KEY + ": " + _data.GetHint());
		}
		else
		{
			Debug.Log(DataManager.HINT_KEY + ": Uninitialized");
		}

		if (_data.CheckAdFree())
		{
			Debug.Log(DataManager.ADFREE_KEY + ": " + _data.GetAdFree());
		}
		else
		{
			Debug.Log(DataManager.ADFREE_KEY + ": Uninitialized");
		}
	}

	public void DoDataDeleteAllButtonPressed()
	{
		_data.DeleteAll();
	}

	public void DoDataResetAllButtonPressed()
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
