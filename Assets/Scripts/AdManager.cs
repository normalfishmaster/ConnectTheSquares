using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class AdManager : MonoBehaviour
{
	private static AdManager _instance = null;

	private static InterstitialAd _interstitial = null;
	private static InterstitialAd _interstitialVideo = null;
	private static RewardedAd _rewarded = null;

	public enum RewardStatus
	{
		None,
		Fail,
		Success
	}

	private RewardStatus _rewardStatus = RewardStatus.None;

	// Interstitial Ad

	private void RequestInterstitial()
	{
		#if BUILD_ANDROID_RELEASE
			string adUnitId = "ca-app-pub-8756652981399458/1129742826";
		#elif BUILD_ANDROID_DEBUG
			string adUnitId = "ca-app-pub-3940256099942544/1033173712";
		#else
			#error "Unknown build configuration"
		#endif

		if (_interstitial != null)
		{
			_interstitial.Destroy();
		}

		_interstitial = new InterstitialAd(adUnitId);
		_interstitial.OnAdFailedToLoad += OnInterstitialAdFailedToLoad;
		_interstitial.OnAdClosed += OnInterstitialAdClosed;

		AdRequest request = new AdRequest.Builder().Build();
		_interstitial.LoadAd(request);
	}

	private void OnInterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("OnInterstitialAdFailedToLoad: " + args.LoadAdError.GetMessage());
		RequestInterstitial();
	}

	private void OnInterstitialAdClosed(object sender, EventArgs args)
	{
		RequestInterstitial();
	}

	public int ShowInterstitial()
	{
		if (_interstitial.IsLoaded())
		{
			_interstitial.Show();
			return 0;
		}
		else
		{
			return -1;
		}
	}

	// Interstitial Video Ad

	private void RequestInterstitialVideo()
	{
		#if BUILD_ANDROID_RELEASE
			string adUnitId = "ca-app-pub-8756652981399458/9899955768";
		#elif BUILD_ANDROID_DEBUG
			string adUnitId = "ca-app-pub-3940256099942544/8691691433";
		#else
			#error "Unknown build configuration"
		#endif

		if (_interstitialVideo != null)
		{
			_interstitialVideo.Destroy();
		}

		_interstitialVideo = new InterstitialAd(adUnitId);
		_interstitialVideo.OnAdFailedToLoad += OnInterstitialVideoAdFailedToLoad;
		_interstitialVideo.OnAdClosed += OnInterstitialVideoAdClosed;

		AdRequest request = new AdRequest.Builder().Build();
		_interstitialVideo.LoadAd(request);
	}

	private void OnInterstitialVideoAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("OnInterstitialVideoAdFailedToLoad: " + args.LoadAdError.GetMessage());
		RequestInterstitialVideo();
	}

	private void OnInterstitialVideoAdClosed(object sender, EventArgs args)
	{
		RequestInterstitialVideo();
	}

	public int ShowInterstitialVideo()
	{
		if (_interstitialVideo.IsLoaded())
		{
			_interstitialVideo.Show();
			return 0;
		}
		else
		{
			return -1;
		}
	}

	// Rewarded Ad

	private void RequestRewarded()
	{
		#if BUILD_ANDROID_RELEASE
			string adUnitId = "ca-app-pub-8756652981399458/3001173793";
		#elif BUILD_ANDROID_DEBUG
			string adUnitId = "ca-app-pub-3940256099942544/5224354917";
		#else
			#error "Unknown build configuration"
		#endif

		if (_rewarded != null)
		{
			_rewarded.Destroy();
		}

		_rewarded = new RewardedAd(adUnitId);
		_rewarded.OnAdFailedToLoad += OnRewardedAdFailedToLoad;
		_rewarded.OnAdClosed += OnRewardedAdClosed;
		_rewarded.OnAdFailedToShow += OnRewardedAdFailedToShow;
		_rewarded.OnAdClosed += OnRewardedAdClosed;
		_rewarded.OnUserEarnedReward += OnRewardedUserEarnedReward;

		AdRequest request = new AdRequest.Builder().Build();
		_rewarded.LoadAd(request);
	}

	private void OnRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("OnRewardedAdFailedToLoad: " + args.LoadAdError.GetMessage());
		RequestRewarded();
	}

	private void OnRewardedAdFailedToShow(object sender, EventArgs args)
	{
		_rewardStatus = RewardStatus.Fail;
		RequestRewarded();
	}

	private void OnRewardedAdClosed(object sender, EventArgs args)
	{
		if (_rewardStatus != RewardStatus.Success)
		{
			// User closed ad before reward has been succesfully awarded
			_rewardStatus = RewardStatus.Fail;
		}
		RequestRewarded();
	}

	private void OnRewardedUserEarnedReward(object sender, Reward args)
	{
		_rewardStatus = RewardStatus.Success;
		RequestRewarded();
	}

	public int ShowRewarded()
	{
		if (_rewarded.IsLoaded())
		{
			_rewarded.Show();
			return 0;
		}
		else
		{
			return -1;
		}
	}

	public RewardStatus GetRewardStatus()
	{
		return _rewardStatus;
	}

	public void ClearRewardStatus()
	{
		_rewardStatus = RewardStatus.None;
	}

	// Initialization complete callback

	private void RequestAll()
	{
		RequestInterstitial();
		RequestInterstitialVideo();
		RequestRewarded();
	}

	private void OnHandleInitComplete(InitializationStatus initstatus)
	{
		// Callbacks from GoogleMobileAds are not guaranteed to be called on main thread.
		// We use MobileAdsEventExecutor to schedule these calls on the next Update() loop.
		MobileAdsEventExecutor.ExecuteInUpdate(RequestAll);
	}

	// Unity Lifecycle

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
	}

	private void Start()
	{
		// Enable Child Directed Treatment for Ads
		RequestConfiguration requestConfiguration = new RequestConfiguration.Builder()
			.SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.True)
			.build();

		MobileAds.SetRequestConfiguration(requestConfiguration);

		MobileAds.Initialize(OnHandleInitComplete);
	}
}
