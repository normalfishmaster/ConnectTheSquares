using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
	private MainMenuUI _ui;
	private AdManager _ad;
	private AudioManager _audio;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private LevelManager _level;
	private MessageManager _message;

	private bool _allowExit;

	// UI - Background

	private void SetupBackground()
	{
		_ui.SetBackgroundColor(_data.GetBackgroundColor());
	}

	// UI - Front

	private void SetupFront()
	{
		string label = "START";
		int loadColor = 0;
		int loadAlphabet = 0;
		int loadMap = 0;

		if (_data.GetLevelStar(0, 0, 0) != 0)
		{
			label = "CONTINUE";
			loadColor = _cloudOnce.GetLastColor();
			loadAlphabet = _cloudOnce.GetLastAlphabet();
			loadMap = _cloudOnce.GetLastMap();
		}

		_ui.SetFrontContinueButtonLabel(label);
		_ui.SetFrontContinueLevel(loadColor, loadAlphabet, loadMap);
	}

	public void OnFrontContinueButtonPressed()
	{
		int loadColor = 0;
		int loadAlphabet = 0;
		int loadMap = 0;

		if (_data.GetLevelStar(0, 0, 0) != 0)
		{
			loadColor = _cloudOnce.GetLastColor();
			loadAlphabet = _cloudOnce.GetLastAlphabet();
			loadMap = _cloudOnce.GetLastMap();
		}

		_data.SetMenuColor(loadColor);
		_data.SetMenuAlphabet(loadAlphabet);
		_data.SetMenuMap(loadMap);

		_audio.PlayContinuePressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateFrontContinueButtonPressed
		(
			()=>
			{
				_ui.AnimateFrontExit
				(
					()=>
					{
						SceneManager.LoadScene("LevelScene");
					}
				);
			}
		);
	}

	public void OnFrontLevelsButtonPressed()
	{
		_audio.PlayButtonPressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateFrontLevelsButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("LevelMenuScene");
			}
		);
	}

	public void OnFrontSettingsButtonPressed()
	{
		_audio.PlayButtonPressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateFrontSettingsButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("SettingsScene");
			}
		);
	}

	public void OnFrontStoreButtonPressed()
	{
		_audio.PlayButtonPressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateFrontStoreButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("StoreScene");
			}
		);
	}

	// UI - Bottom

	private void SetupBottom()
	{
		#if UNITY_ANDROID
			_ui.SetActiveBottomGameCenter(false);
		#else
			_ui.SetActiveBottomGooglePlay(false);
		#endif

		_ui.SetEnableBottomButton(false);
	}

	public void OnBottomGooglePlayButtonPressed()
	{
		_audio.PlayButtonPressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateBottomGooglePlayButtonPressed
		(
			()=>
			{
				_ui.SetActiveCloudOnce(true);
				_ui.SetEnableCloudOnceButton(false);

				if (_cloudOnce.IsSignedIn())
				{
					_ui.SetActiveCloudOnceSignInButton(false);
					_ui.SetActiveCloudOnceSignOutButton(true);
					_ui.SetInteractableCloudOnceSignInButton(true);
					_ui.SetInteractableCloudOnceFunctionalButton(true);
					_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_IN);
				}
				else
				{
					_ui.SetActiveCloudOnceSignInButton(true);
					_ui.SetActiveCloudOnceSignOutButton(false);
					_ui.SetInteractableCloudOnceSignInButton(true);
					_ui.SetInteractableCloudOnceFunctionalButton(false);
					_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
				}

				_ui.AnimateCloudOnceBoardEnter
				(
					()=>
					{
						_ui.SetEnableCloudOnceButton(true);
					}
				);
			}
		);
	}

	public void OnBottomGameCenterButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateBottomGameCenterButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnBottomRateButtonPressed()
	{
		_audio.PlayButtonPressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateBottomRateButtonPressed
		(
			()=>
			{
				if (Application.platform == RuntimePlatform.IPhonePlayer)
				{
				}
				else
				{
					Application.OpenURL("market://details?id=com.normalfish.connectthesquares");
				}
				_ui.SetEnableFrontButton(true);
				_ui.SetEnableBottomButton(true);
				_ui.SetEnableRewardsOpenButton(true);
			}
		);
	}

	int count = 0;

	public void OnBottomLanguageButtonPressed()
	{
		_audio.PlayButtonPressed();
/*
		count += 1;
		if (count >= 5)
			count = 0;

		_ui.SetBackgroundColor(count);
*/
		_ui.AnimateBottomLanguageButtonPressed
		(
			()=>
			{
			}
		);

	}

	// UI - CloudOnce

	private void SetupCloudOnce()
	{
		#if UNITY_ANDROID
			_ui.SetActiveCloudOnceGooglePlayLabel(true);
			_ui.SetActiveCloudOnceGooglePlayImage(true);
			_ui.SetActiveCloudOnceGameCenterLabel(false);
			_ui.SetActiveCloudOnceGameCenterImage(false);
		#else
			_ui.SetActiveCloudOnceGooglePlayLabel(false);
			_ui.SetActiveCloudOnceGooglePlayImage(false);
			_ui.SetActiveCloudOnceGameCenterLabel(true);
			_ui.SetActiveCloudOnceGameCenterImage(true);
		#endif

		_ui.SetEnableCloudOnceButton(false);
		_ui.SetActiveCloudOnce(false);
		_ui.SetInteractableCloudOnceFunctionalButton(false);
	}

	private void OnCloudOnceSignedIn()
	{
		_ui.SetActiveCloudOnceSignInButton(false);
		_ui.SetActiveCloudOnceSignOutButton(true);
		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	private void OnCloudOnceSignedOut()
	{
		_ui.SetActiveCloudOnceSignInButton(true);
		_ui.SetActiveCloudOnceSignOutButton(false);
		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(false);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	private void OnCloudOnceSignedInChanged(bool isSignedIn)
	{
		_cloudOnce.UnsubscribeSignedInChanged(OnCloudOnceSignedInChanged);
		_cloudOnce.UnsubscribeSignInFailed(OnCloudOnceSignInFailed);

		if (isSignedIn)
		{
			OnCloudOnceSignedIn();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_IN);
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
		}
	}

	private void OnCloudOnceSignInFailed()
	{
		_cloudOnce.UnsubscribeSignedInChanged(OnCloudOnceSignedInChanged);
		_cloudOnce.UnsubscribeSignInFailed(OnCloudOnceSignInFailed);

		OnCloudOnceSignedOut();
		_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGN_IN_FAILED);
	}

	private void OnCloudSaveComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudSaveComplete(OnCloudSaveComplete);

		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);

		if (success)
		{
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.DATA_SAVED);
		}
		else
		{
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SAVE_DATA_FAILED);
		}
	}

	private void OnCloudLoadComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudLoadComplete(OnCloudLoadComplete);

		if (success)
		{
			_cloudOnce.LoadCloudToData();
			_ui.SetBackgroundColor(_data.GetBackgroundColor());
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.DATA_LOADED);
		}
		else
		{
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.LOAD_DATA_FAILED);
		}

		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	public void OnCloudOnceSignInButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			OnCloudOnceSignedIn();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_IN);
		}
		else
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNING_IN);

			_cloudOnce.SubscribeSignedInChanged(OnCloudOnceSignedInChanged);
			_cloudOnce.SubscribeSignInFailed(OnCloudOnceSignInFailed);

			_cloudOnce.SignIn();
		}

		_ui.AnimateCloudOnceSignInButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceSignOutButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetInteractableCloudOnceSignInButton(false);
		_ui.SetInteractableCloudOnceFunctionalButton(false);
		_ui.SetInteractableCloudOnceCloseButton(false);
		_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNING_OUT);

		_ui.AnimateCloudOnceSignOutButtonPressed
		(
			()=>
			{
				if (_cloudOnce.IsSignedIn())
				{
					_cloudOnce.SubscribeSignedInChanged(OnCloudOnceSignedInChanged);
					_cloudOnce.SignOut();
				}
				else
				{
					OnCloudOnceSignedOut();
					_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
				}
			}
		);
	}

	public void OnCloudOnceSaveButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SAVING_DATA);

			_cloudOnce.SubscribeCloudSaveComplete(OnCloudSaveComplete);
			_cloudOnce.SaveDataToCloud();
			_cloudOnce.Save();
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
		}

		_ui.AnimateCloudOnceSaveButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceLoadButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.LOADING_DATA);

			_cloudOnce.SubscribeCloudLoadComplete(OnCloudLoadComplete);
			_cloudOnce.Load();
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
		}

		_ui.AnimateCloudOnceLoadButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceAchievementsButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			_cloudOnce.ShowAchievements();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_IN);
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
		}

		_ui.AnimateCloudOnceAchivementsButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceLeaderboardButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			int totalStars = 0;

			for (int i = 0; i < _level.GetNumColor(); i++)
			{
				totalStars += _data.GetColorStar(i);
			}

			_cloudOnce.SubmitLeaderboardHighScore(totalStars);
			_cloudOnce.ShowLeaderboard();

			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_IN);
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(MainMenuUI.CloudOnceMessage.SIGNED_OUT);
		}

		_ui.AnimateCloudOnceLeaderboardButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableCloudOnceButton(false);

		_ui.AnimateCloudOnceCloseButtonPressed
		(
			()=>
			{
				_ui.AnimateCloudOnceBoardExit
				(
					()=>
					{
						_allowExit = true;

						_ui.SetActiveCloudOnce(false);

						_ui.SetEnableFrontButton(true);
						_ui.SetEnableBottomButton(true);
						_ui.SetEnableRewardsOpenButton(true);
					}
				);
			}
		);
	}

	// UI - Rewards

	private bool _rewardClaimed;
	private int _rewardDay;
	private DateTime _rewardToday;

	private void SetupRewards()
	{
		DateTime today = DateTime.Now;
		DateTime lastDay = _cloudOnce.GetRewardsLastDateTime();
		int dayCount = _cloudOnce.GetRewardsDayCount();
		bool rewardClaimed = false;
		int rewardDay = 1;

		if (today.DayOfYear == lastDay.DayOfYear
			&& today.Year == lastDay.Year)
		{
			rewardClaimed = true;
			rewardDay = dayCount;
		}
		else
		{
			if (lastDay.Month == 12 && lastDay.Day == 31
					&& today.Month == 1 && today.Day == 1
					&& (today.Year == lastDay.Year + 1))
			{
				rewardDay = dayCount + 1;
			}
			else if (today.Year == lastDay.Year
					&& today.DayOfYear == lastDay.DayOfYear + 1)
			{
				rewardDay = dayCount + 1;
			}
			else
			{
				rewardDay = 1;
			}
		}

		_rewardClaimed = rewardClaimed;
		_rewardDay = rewardDay;
		_rewardToday = today;

		_ui.SetActiveRewards(false);
	}

	private void ClaimReward()
	{
		if (_rewardClaimed == false)
		{
			// From testing, it seems that increment hint needs to come
			// after SetRewards or else the rewards parameters will not
			// be saved.

			_cloudOnce.SetRewardsLastDateTime(_rewardToday);
			_cloudOnce.SetRewardsDayCount(_rewardDay);

			if (_rewardDay >= 3)
			{
				_cloudOnce.IncrementHint(2);
			}
			else
			{
				_cloudOnce.IncrementHint(1);
			}

			_cloudOnce.Save();

			_rewardClaimed = true;
		}
	}

	public void OpenRewards()
	{
		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.SetActiveRewards(true);
		_ui.SetEnableRewardsCloseButton(false);

		for (int i = 0; i < 3; i++)
		{
			_ui.AnimateRewardsDaySunburstRotate(i);
		}

		for (int i = 1; i <= 3; i++)
		{
			_ui.SetActiveRewardsDayGet((i - 1), false);

			if (i < _rewardDay)
			{
				_ui.SetActiveRewardsDayClaimed((i - 1), true);
			}
			else
			{
				_ui.SetActiveRewardsDayClaimed((i - 1), false);
			}
		}

		if (_rewardClaimed)
		{
			_ui.SetActiveRewardsDayClaimed((_rewardDay - 1), true);
		}
		else
		{
			_ui.SetActiveRewardsDayGet((_rewardDay - 1), true);
			_ui.SetEnableRewardsDayGetButton((_rewardDay - 1), false);
			_ui.AnimateRewardsDayGetLabel(_rewardDay - 1);
		}

		_ui.AnimateRewardsBoardEnter
		(
			()=>
			{
				_ui.SetEnableRewardsCloseButton(true);
				_ui.SetEnableRewardsDayGetButton((_rewardDay - 1), true);
			}
		);
	}


	public void OnRewardsOpenButtonPressed()
	{
		_audio.PlayButtonPressed();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateRewardsOpenButtonPressed
		(
			()=>
			{
				OpenRewards();
			}
		);
	}

	public void OnRewardsCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableRewardsCloseButton(false);

		for (int i = 0; i < 3; i++)
		{
			_ui.SetEnableRewardsDayGetButton(i, false);
		}

		_ui.AnimateRewardsCloseButtonPressed
		(
			()=>
			{
				_ui.AnimateRewardsBoardExit
				(
					()=>
					{
						_ui.SetActiveRewards(false);

						_allowExit = true;
						_ui.SetEnableFrontButton(true);
						_ui.SetEnableBottomButton(true);
						_ui.SetEnableRewardsOpenButton(true);
					}
				);
			}
		);
	}

	public void OnRewardsDayGetButtonPressed(int day)
	{
		ClaimReward();

		_audio.PlayButtonPressed();

		_ui.SetEnableRewardsCloseButton(false);
		_ui.SetEnableRewardsDayGetButton(day - 1, false);

		_ui.AnimateRewardsDayGetButtonPressed(day - 1,
			()=>
			{
				_ui.AnimateRewardsBoardExit
				(
					()=>
					{
						_audio.PlayRewardReceived();

						_ui.SetActiveRewards(false);

						if (_rewardDay >= 3)
						{
							_message.SetHintCount(2);
						}
						else
						{
							_message.SetHintCount(1);
						}

						_message.SetActiveHint(true);
						_message.SetEnableHintBackButton(false);
						_message.AnimateHintEnter
						(
							()=>
							{
								_message.SetEnableHintBackButton(true);
							}
						);
					}
				);
			}
		);
	}

	// UI - Exit

	private void SetupExit()
	{
		_ui.SetEnableExitButton(false);
		_ui.SetActiveExit(false);
	}

	public void OnExitButtonPressed()
	{
		if (_allowExit == false)
		{
			return;
		}

		_allowExit = false;

		_audio.PlayButtonPressed();

		_ui.SetActiveExit(true);
		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_ui.AnimateExitBoardEnter
		(
			()=>
			{
				_ui.SetEnableExitButton(true);
			}
		);
	}

	public void OnExitYesButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableExitButton(false);

		_ui.AnimateExitYesButtonPressed
		(
			()=>
			{
				_ui.AnimateExitBoardExit
				(
					()=>
					{
						Application.Quit();
					}
				);
			}
		);
	}

	public void OnExitNoButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableExitButton(false);

		_ui.AnimateExitNoButtonPressed
		(
			()=>
			{
				_ui.AnimateExitBoardExit
				(
					()=>
					{
						_ui.SetActiveExit(false);

						_allowExit = true;
						_ui.SetEnableFrontButton(true);
						_ui.SetEnableBottomButton(true);
						_ui.SetEnableRewardsOpenButton(true);
					}
				);
			}
		);
	}

	// Message - Hint

	private void SetupMessageHint()
	{
		_message.SetActiveHint(false);
	}

	public void OnMessageHintBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_message.SetEnableHintBackButton(false);

		_message.AnimateHintBackButtonPressed
		(
			()=>
			{
				_message.AnimateHintExit
				(
					()=>
					{
						_message.SetActiveHint(false);

						_allowExit = true;

						_ui.SetEnableFrontButton(true);
						_ui.SetEnableBottomButton(true);
						_ui.SetEnableRewardsOpenButton(true);
					}
				);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("MainMenuUI").GetComponent<MainMenuUI>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_message = GameObject.Find("MessageManager").GetComponent<MessageManager>();
	}

	private void Start()
	{
		SetupBackground();
		SetupFront();
		SetupBottom();
		SetupCloudOnce();
		SetupRewards();
		SetupExit();
		SetupMessageHint();

		_allowExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.SetEnableRewardsOpenButton(false);

		_audio.PlayFrontButtonEnter();

		_ui.AnimateFrontEnter
		(
			()=>
			{
				if (_rewardClaimed == false)
				{
					OpenRewards();
				}
				else
				{
					_allowExit = true;
					_ui.SetEnableFrontButton(true);
					_ui.SetEnableBottomButton(true);
					_ui.SetEnableRewardsOpenButton(true);
				}
			}
		);

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnExitButtonPressed();
		}
	}
}
