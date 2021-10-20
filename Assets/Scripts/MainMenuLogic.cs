using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
	private MainMenuUI _ui;
	private AdUI _adUi;
	private AdManager _ad;
	private AudioManager _audio;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private LevelManager _level;

	private bool _allowExit;

	// UI - Front

	private void SetupFront()
	{
		string label = "Start";
		int loadColor = 0;
		int loadAlphabet = 0;
		int loadMap = 0;

		if (_data.GetLevelStar(0, 0, 0) != 0)
		{
			label = "Continue";
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
				_ui.SetActiveSettings(true);
				_ui.SetEnableSettingsButton(false);

				if (_data.GetAudio() == 1)
				{
					_ui.SetActiveSettingsAudioOnButton(true);
					_ui.SetActiveSettingsAudioOffButton(false);
				}
				else
				{
					_ui.SetActiveSettingsAudioOnButton(false);
					_ui.SetActiveSettingsAudioOffButton(true);
				}

				_ui.AnimateSettingsBoardEnter
				(
					()=>
					{
						_ui.SetEnableSettingsButton(true);
					}
				);
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
		#if (BUILD_ANDROID_DEBUG || BUILD_ANDROID_RELEASE)
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
					_ui.SetActiveCloudOnceMessage(2);
				}
				else
				{
					_ui.SetActiveCloudOnceSignInButton(true);
					_ui.SetActiveCloudOnceSignOutButton(false);
					_ui.SetInteractableCloudOnceSignInButton(true);
					_ui.SetInteractableCloudOnceFunctionalButton(false);
					_ui.SetActiveCloudOnceMessage(3);
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

	public void OnBottomLanguageButtonPressed()
	{
		_audio.PlayButtonPressed();

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
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_ui.SetActiveCloudOnceGooglePlayLabel(false);
			_ui.SetActiveCloudOnceGameCenterLabel(true);
		}
		else
		{
			_ui.SetActiveCloudOnceGooglePlayLabel(true);
			_ui.SetActiveCloudOnceGameCenterLabel(false);
		}

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
			_ui.SetActiveCloudOnceMessage(2);
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(3);
		}
	}

	private void OnCloudOnceSignInFailed()
	{
		_cloudOnce.UnsubscribeSignedInChanged(OnCloudOnceSignedInChanged);
		_cloudOnce.UnsubscribeSignInFailed(OnCloudOnceSignInFailed);

		OnCloudOnceSignedOut();
		_ui.SetActiveCloudOnceMessage(4);
	}

	private void OnCloudSaveComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudSaveComplete(OnCloudSaveComplete);

		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);

		if (success)
		{
			_ui.SetActiveCloudOnceMessage(8);
		}
		else
		{
			_ui.SetActiveCloudOnceMessage(10);
		}
	}

	private void OnCloudLoadComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudLoadComplete(OnCloudLoadComplete);

		if (success)
		{
			_cloudOnce.LoadCloudToData();
			_ui.SetActiveCloudOnceMessage(9);
		}
		else
		{
			_ui.SetActiveCloudOnceMessage(11);
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
			_ui.SetActiveCloudOnceMessage(2);
		}
		else
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);
			_ui.SetActiveCloudOnceMessage(0);

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
		_ui.SetActiveCloudOnceMessage(1);

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
					_ui.SetActiveCloudOnceMessage(3);
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
			_ui.SetActiveCloudOnceMessage(6);

			_cloudOnce.SubscribeCloudSaveComplete(OnCloudSaveComplete);
			_cloudOnce.SaveDataToCloud();
			_cloudOnce.Save();
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(3);
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
			_ui.SetActiveCloudOnceMessage(7);

			_cloudOnce.SubscribeCloudLoadComplete(OnCloudLoadComplete);
			_cloudOnce.Load();
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(3);
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
			_ui.SetActiveCloudOnceMessage(2);
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(3);
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

			_ui.SetActiveCloudOnceMessage(2);
		}
		else
		{
			OnCloudOnceSignedOut();
			_ui.SetActiveCloudOnceMessage(3);
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

	// UI - Settings

	private void SetupSettings()
	{
		_ui.SetActiveSettings(false);
	}

	public void OnSettingsAudioOnPressed()
	{
		_data.SetAudio(0);
		_audio.SetEnable(false);

		_ui.SetActiveSettingsAudioOnButton(false);
		_ui.SetActiveSettingsAudioOffButton(true);

		_ui.AnimateSettingsAudioOffButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnSettingsAudioOffPressed()
	{
		_data.SetAudio(1);
		_audio.SetEnable(true);

		_audio.PlayButtonPressed();

		_ui.SetActiveSettingsAudioOnButton(true);
		_ui.SetActiveSettingsAudioOffButton(false);

		_ui.AnimateSettingsAudioOnButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnSettingsCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableSettingsButton(false);

		_ui.AnimateSettingsBoardExit
		(
			()=>
			{
				_allowExit = true;

				_ui.SetActiveSettings(false);

				_ui.SetEnableFrontButton(true);
				_ui.SetEnableBottomButton(true);
				_ui.SetEnableRewardsOpenButton(true);
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
		bool continuationReward = false;
		int rewardDay = 1;

		Debug.Log("today.DayOfYear:" + today.DayOfYear);
		Debug.Log("lastDay.DayOfYear:" + lastDay.DayOfYear);
		Debug.Log("lastDay:" + lastDay);
		Debug.Log("dayCount:" + dayCount);

		if (today.DayOfYear == lastDay.DayOfYear
			&& today.Year == lastDay.Year)
		{
			rewardClaimed = true;
		}
		else
		{
			if (lastDay.Month == 12 && lastDay.Day == 31
					&& today.Month == 1 && today.Day == 1
					&& (today.Year == lastDay.Year + 1))
			{
				continuationReward = true;
			}
			else if (today.DayOfYear == lastDay.DayOfYear + 1)
			{
				continuationReward = true;
			}

			if (continuationReward == true)
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
			_cloudOnce.IncrementHint(1);

			_cloudOnce.Save();

			_rewardClaimed = true;
		}
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
				_ui.SetActiveRewards(true);
				_ui.SetEnableRewardsCloseButton(false);
				_ui.SetEnableRewardsDayButton(false);

				for (int i = 1; i <= 3; i++)
				{
					if (i <= _rewardDay)
					{
						_ui.SetActiveRewardsDayClaimed((i - 1), true);
					}
					else
					{
						_ui.SetActiveRewardsDayClaimed((i - 1), false);
					}
				}

				_ui.AnimateRewardsBoardEnter
				(
					()=>
					{
						_ui.SetEnableRewardsCloseButton(true);
						_ui.SetEnableRewardsDayButton(false);
					}
				);
			}
		);
	}

	public void OnRewardsCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableRewardsCloseButton(false);
		_ui.SetEnableRewardsDayButton(false);

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

	// UI - Ad Success
	// This is used specificcally for daily rewards

	private void SetupAdSuccess()
	{
		_adUi.SetActiveAdSuccess(false);
	}

	public void OnAdSuccessCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdSuccessButton(false);
		_adUi.AnimateAdSuccessCloseButtonPressed
		(
			()=>
			{
				_adUi.AnimateAdSuccessBoardExit
				(
					()=>
					{
						_adUi.SetActiveAdSuccess(false);

						_ui.SetActiveRewards(true);
						_ui.SetEnableRewardsCloseButton(false);
						_ui.SetEnableRewardsDayButton(false);

						for (int i = 1; i <= 3; i++)
						{
							if (i <= _rewardDay)
							{
								_ui.SetActiveRewardsDayClaimed((i - 1), true);
							}
							else
							{
								_ui.SetActiveRewardsDayClaimed((i - 1), false);
							}
						}

						_ui.AnimateRewardsBoardEnter
						(
							()=>
							{
								_ui.SetEnableRewardsCloseButton(true);
								_ui.SetEnableRewardsDayButton(false);
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
						_ui.SetEnableRewardsOpenButton(false);
					}
				);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("MainMenuUI").GetComponent<MainMenuUI>();
		_adUi = GameObject.Find("AdUI").GetComponent<AdUI>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

	private void Start()
	{
		SetupFront();
		SetupBottom();
		SetupCloudOnce();
		SetupSettings();
		SetupRewards();
		SetupAdSuccess();
		SetupExit();

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
					ClaimReward();

		                        _adUi.SetActiveAdSuccess(true);
                		        _adUi.SetAdSuccessItem("hint");
		                        _adUi.SetActiveAdSuccessCount(false);
		                        _adUi.SetActiveAdSuccessItem(false);
                		        _adUi.SetEnableAdSuccessButton(false);

					if (_rewardDay <= 2)
					{
	                		        _adUi.SetAdSuccessCountValue("+1");
					}
					else
					{
	                		        _adUi.SetAdSuccessCountValue("+2");
					}

					_audio.PlayRewardReceived();

		                        _adUi.AnimateAdSuccessBoardEnter
                		        (
                                		()=>
		                                {
                		                        _adUi.SetActiveAdSuccessItem(true);
                                		        _adUi.SetActiveAdSuccessCount(true);
		                                        _adUi.AnimateAdSuccessItemEnter
                		                        (
                                		                ()=>
		                                                {
                		                                        _adUi.SetEnableAdSuccessButton(true);
                                		                }
		                                        );
                		                }
		                        );
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
