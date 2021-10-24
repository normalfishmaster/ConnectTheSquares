using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	private AudioManager _audio;
	private LevelManager _level;

	// Background

	public Sprite[] _backgroundSprite;

	private GameObject _background;

	private void FindBackgroundGameObject()
	{
		_background = GameObject.Find("/Background/Color");
	}

	public void SetBackgroundColor(int color)
	{
		_background.GetComponent<Image>().sprite = _backgroundSprite[color];
	}

	// Canvas

	private GameObject _canvas;

	private void FindCanvasGameObject()
	{
		_canvas = GameObject.Find("/Canvas");
	}

	// Front

	public float FRONT_ANIMATE_ENTER_DURATION;
	public float FRONT_ANIMATE_ENTER_DELAY;

	public float FRONT_ANIMATE_EXIT_DURATION;
	public float FRONT_ANIMATE_EXIT_DELAY;

	public float FRONT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float FRONT_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _front;

	private GameObject _frontContinue;
	private GameObject _frontContinueButton;
	private GameObject _frontContinueButtonLabel;
	private GameObject _frontContinueLevel;

	private GameObject _frontLevels;
	private GameObject _frontLevelsButton;

	private GameObject _frontSettings;
	private GameObject _frontSettingsButton;

	private GameObject _frontStore;
	private GameObject _frontStoreButton;

	private void FindFrontGameObject()
	{
		_front = GameObject.Find("/Canvas/Front");

		_frontContinue = GameObject.Find("/Canvas/Front/Continue");
		_frontContinueButton = GameObject.Find("/Canvas/Front/Continue/Button");
		_frontContinueButtonLabel = GameObject.Find("/Canvas/Front/Continue/Button/Label");
		_frontContinueLevel = GameObject.Find("/Canvas/Front/Continue/Level");

		_frontLevels = GameObject.Find("/Canvas/Front/Levels");
		_frontLevelsButton = GameObject.Find("/Canvas/Front/Levels/Button");

		_frontSettings = GameObject.Find("/Canvas/Front/Settings");
		_frontSettingsButton = GameObject.Find("/Canvas/Front/Settings/Button");

		_frontStore = GameObject.Find("/Canvas/Front/Store");
		_frontStoreButton = GameObject.Find("/Canvas/Front/Store/Button");
	}

	public void SetEnableFrontButton(bool enable)
	{
		_frontContinueButton.GetComponent<Button>().enabled = enable;
		_frontLevelsButton.GetComponent<Button>().enabled = enable;
		_frontSettingsButton.GetComponent<Button>().enabled = enable;
		_frontStoreButton.GetComponent<Button>().enabled = enable;
	}

	public void SetFrontContinueButtonLabel(string text)
	{
		_frontContinueButtonLabel.GetComponent<Text>().text = text;
	}

	public void SetFrontContinueLevel(int color, int alphabet, int map)
	{
		string str = _level.GetColorString(color) + " - " + _level.GetAlphabetString(alphabet) + " - " + _level.GetMapString(map);
		_frontContinueLevel.GetComponent<Text>().text = str;
	}

	public void AnimateFrontEnter(Animate.AnimateComplete callback)
	{
		float width = _canvas.GetComponent<CanvasScaler>().referenceResolution.x;
		Vector2 diff = new Vector3(-1 * width, 0.0f);

		RectTransform continueRt = (RectTransform)_frontContinue.transform;
		RectTransform levelsRt = (RectTransform)_frontLevels.transform;
		RectTransform settingsRt = (RectTransform)_frontSettings.transform;
		RectTransform storeRt = (RectTransform)_frontStore.transform;

		continueRt.anchoredPosition += diff;
		levelsRt.anchoredPosition += diff;
		settingsRt.anchoredPosition += diff;
		storeRt.anchoredPosition += diff;

		LeanTween.cancel(continueRt);
		LeanTween.cancel(levelsRt);
		LeanTween.cancel(settingsRt);
		LeanTween.cancel(storeRt);

		LeanTween.moveLocalX(_frontContinue, 0.0f, FRONT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalX(_frontLevels, 0.0f, FRONT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_ENTER_DELAY);
		LeanTween.moveLocalX(_frontSettings, 0.0f, FRONT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_ENTER_DELAY * 2);
		LeanTween.moveLocalX(_frontStore, 0.0f, FRONT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_ENTER_DELAY * 3).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateFrontExit(Animate.AnimateComplete callback)
	{
		float width = _canvas.GetComponent<CanvasScaler>().referenceResolution.x;

		RectTransform continueRt = (RectTransform)_frontContinue.transform;
		RectTransform levelsRt = (RectTransform)_frontLevels.transform;
		RectTransform settingsRt = (RectTransform)_frontSettings.transform;
		RectTransform storeRt = (RectTransform)_frontStore.transform;

		LeanTween.cancel(continueRt);
		LeanTween.cancel(levelsRt);
		LeanTween.cancel(settingsRt);
		LeanTween.cancel(storeRt);

		LeanTween.moveLocalX(_frontContinue, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setOnStart
		(
			()=>
			{
				_audio.PlayFrontButtonExit();
			}
		);

		LeanTween.moveLocalX(_frontLevels, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_EXIT_DELAY).setOnStart
		(
			()=>
			{
				_audio.PlayFrontButtonExit();
			}
		);

		LeanTween.moveLocalX(_frontSettings, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_EXIT_DELAY * 2).setOnStart
		(
			()=>
			{
				_audio.PlayFrontButtonExit();
			}
		);

		LeanTween.moveLocalX(_frontStore, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_EXIT_DELAY * 3).setOnStart
		(
			()=>
			{
				_audio.PlayFrontButtonExit();
			}
		)
		.setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateFrontContinueButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_frontContinueButton, FRONT_ANIMATE_BUTTON_PRESSED_SCALE, FRONT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateFrontLevelsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_frontLevelsButton, FRONT_ANIMATE_BUTTON_PRESSED_SCALE, FRONT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateFrontSettingsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_frontSettingsButton, FRONT_ANIMATE_BUTTON_PRESSED_SCALE, FRONT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateFrontStoreButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_frontStoreButton, FRONT_ANIMATE_BUTTON_PRESSED_SCALE, FRONT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomGooglePlay;
	private GameObject _bottomGooglePlayButton;
	private GameObject _bottomGameCenter;
	private GameObject _bottomGameCenterButton;

	private GameObject _bottomRate;
	private GameObject _bottomRateButton;

	private GameObject _bottomLanguage;
	private GameObject _bottomLanguageButton;

	private void FindBottomGameObject()
	{
		_bottomGooglePlay = GameObject.Find("/Canvas/Bottom/GooglePlay");
		_bottomGooglePlayButton = GameObject.Find("/Canvas/Bottom/GooglePlay/Button");

		_bottomGameCenter = GameObject.Find("/Canvas/Bottom/GameCenter");
		_bottomGameCenterButton = GameObject.Find("/Canvas/Bottom/GameCenter/Button");

		_bottomRate = GameObject.Find("/Canvas/Bottom/Rate");
		_bottomRateButton = GameObject.Find("/Canvas/Bottom/Rate/Button");

		_bottomLanguage = GameObject.Find("/Canvas/Bottom/Language");
		_bottomLanguageButton = GameObject.Find("/Canvas/Bottom/Language/Button");
	}

	public void SetActiveBottomGooglePlay(bool active)
	{
		_bottomGooglePlay.SetActive(active);
	}

	public void SetActiveBottomGameCenter(bool active)
	{
		_bottomGameCenter.SetActive(active);
	}

	public void SetEnableBottomButton(bool enable)
	{
		_bottomGooglePlayButton.GetComponent<Button>().enabled = enable;
		_bottomGameCenterButton.GetComponent<Button>().enabled = enable;
		_bottomRateButton.GetComponent<Button>().enabled = enable;
		_bottomLanguageButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateBottomGooglePlayButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomGooglePlayButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateBottomGameCenterButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomGameCenterButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateBottomRateButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomRateButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateBottomLanguageButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomLanguageButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// CloudOnce

	public float CLOUD_ONCE_ANIMATE_BOARD_ENTER_DURATION;
	public float CLOUD_ONCE_ANIMATE_BOARD_EXIT_DURATION;

	public float CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE;
	public float CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _cloudOnce;
	private GameObject _cloudOnceBoard;

	private GameObject _cloudOnceGooglePlayLabel;
	private GameObject _cloudOnceGameCenterLabel;

	private GameObject _cloudOnceSignIn;
	private GameObject _cloudOnceSignOut;
	private GameObject _cloudOnceLoad;
	private GameObject _cloudOnceSave;
	private GameObject _cloudOnceAchievements;
	private GameObject _cloudOnceLeaderboard;
	private GameObject _cloudOnceClose;

	private GameObject _cloudOnceSignInButton;
	private GameObject _cloudOnceSignOutButton;
	private GameObject _cloudOnceLoadButton;
	private GameObject _cloudOnceSaveButton;
	private GameObject _cloudOnceAchievementsButton;
	private GameObject _cloudOnceLeaderboardButton;
	private GameObject _cloudOnceCloseButton;

	private GameObject _cloudOnceMessageSigningIn;
	private GameObject _cloudOnceMessageSigningOut;
	private GameObject _cloudOnceMessageSignedIn;
	private GameObject _cloudOnceMessageSignedOut;
	private GameObject _cloudOnceMessageSignInFailed;
	private GameObject _cloudOnceMessageSignOutFailed;
	private GameObject _cloudOnceMessageSavingData;
	private GameObject _cloudOnceMessageLoadingData;
	private GameObject _cloudOnceMessageDataSaved;
	private GameObject _cloudOnceMessageDataLoaded;
	private GameObject _cloudOnceMessageSaveDataFailed;
	private GameObject _cloudOnceMessageLoadDataFailed;

	private void FindCloudOnceGameObject()
	{
		_cloudOnce = GameObject.Find("/Canvas/CloudOnce");
		_cloudOnceBoard = GameObject.Find("/Canvas/CloudOnce/Board");

		_cloudOnceGooglePlayLabel = GameObject.Find("/Canvas/CloudOnce/Board/GooglePlayLabel");
		_cloudOnceGameCenterLabel = GameObject.Find("/Canvas/CloudOnce/Board/GameCenterLabel");

		_cloudOnceSignIn = GameObject.Find("/Canvas/CloudOnce/Board/SignIn");
		_cloudOnceSignOut = GameObject.Find("/Canvas/CloudOnce/Board/SignOut");
		_cloudOnceLoad = GameObject.Find("/Canvas/CloudOnce/Board/Load");
		_cloudOnceSave = GameObject.Find("/Canvas/CloudOnce/Board/Save");
		_cloudOnceAchievements = GameObject.Find("/Canvas/CloudOnce/Board/Achievements");
		_cloudOnceLeaderboard = GameObject.Find("/Canvas/CloudOnce/Board/Leaderboard");
		_cloudOnceClose = GameObject.Find("/Canvas/CloudOnce/Board/Close");

		_cloudOnceSignInButton = GameObject.Find("/Canvas/CloudOnce/Board/SignIn/Button");
		_cloudOnceSignOutButton = GameObject.Find("/Canvas/CloudOnce/Board/SignOut/Button");
		_cloudOnceLoadButton = GameObject.Find("/Canvas/CloudOnce/Board/Load/Button");
		_cloudOnceSaveButton = GameObject.Find("/Canvas/CloudOnce/Board/Save/Button");
		_cloudOnceAchievementsButton = GameObject.Find("/Canvas/CloudOnce/Board/Achievements/Button");
		_cloudOnceLeaderboardButton = GameObject.Find("/Canvas/CloudOnce/Board/Leaderboard/Button");
		_cloudOnceCloseButton = GameObject.Find("/Canvas/CloudOnce/Board/Close/Button");

		_cloudOnceMessageSigningIn = GameObject.Find("/Canvas/CloudOnce/Board/MessageSigningIn");
		_cloudOnceMessageSigningOut = GameObject.Find("/Canvas/CloudOnce/Board/MessageSigningOut");
		_cloudOnceMessageSignedIn = GameObject.Find("/Canvas/CloudOnce/Board/MessageSignedIn");
		_cloudOnceMessageSignedOut = GameObject.Find("/Canvas/CloudOnce/Board/MessageSignedOut");
		_cloudOnceMessageSignInFailed = GameObject.Find("/Canvas/CloudOnce/Board/MessageSignInFailed");
		_cloudOnceMessageSignOutFailed = GameObject.Find("/Canvas/CloudOnce/Board/MessageSignOutFailed");
		_cloudOnceMessageSavingData = GameObject.Find("/Canvas/CloudOnce/Board/MessageSavingData");
		_cloudOnceMessageLoadingData = GameObject.Find("/Canvas/CloudOnce/Board/MessageLoadingData");
		_cloudOnceMessageDataSaved = GameObject.Find("/Canvas/CloudOnce/Board/MessageDataSaved");
		_cloudOnceMessageDataLoaded = GameObject.Find("/Canvas/CloudOnce/Board/MessageDataLoaded");
		_cloudOnceMessageSaveDataFailed = GameObject.Find("/Canvas/CloudOnce/Board/MessageSaveDataFailed");
		_cloudOnceMessageLoadDataFailed = GameObject.Find("/Canvas/CloudOnce/Board/MessageLoadDataFailed");
	}

	public void SetActiveCloudOnce(bool active)
	{
		_cloudOnce.SetActive(active);
	}

	public void SetActiveCloudOnceGooglePlayLabel(bool active)
	{
		_cloudOnceGooglePlayLabel.SetActive(active);
	}

	public void SetActiveCloudOnceGameCenterLabel(bool active)
	{
		_cloudOnceGameCenterLabel.SetActive(active);
	}

	public void SetActiveCloudOnceSignInButton(bool active)
	{
		_cloudOnceSignIn.SetActive(active);
	}

	public void SetActiveCloudOnceSignOutButton(bool active)
	{
		_cloudOnceSignOut.SetActive(active);
	}

	public void SetEnableCloudOnceButton(bool enable)
	{
		_cloudOnceSignInButton.GetComponent<Button>().enabled = enable;
		_cloudOnceSignOutButton.GetComponent<Button>().enabled = enable;
		_cloudOnceLoadButton.GetComponent<Button>().enabled = enable;
		_cloudOnceSaveButton.GetComponent<Button>().enabled = enable;
		_cloudOnceAchievementsButton.GetComponent<Button>().enabled = enable;
		_cloudOnceLeaderboardButton.GetComponent<Button>().enabled = enable;
		_cloudOnceCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void SetInteractableCloudOnceSignInButton(bool interactable)
	{
		_cloudOnceSignInButton.GetComponent<Button>().interactable = interactable;
		_cloudOnceSignOutButton.GetComponent<Button>().interactable = interactable;

		if (interactable == false)
		{
			_cloudOnceSignInButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
			_cloudOnceSignOutButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
		}
		else
		{
			_cloudOnceSignInButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			_cloudOnceSignOutButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	public void SetInteractableCloudOnceFunctionalButton(bool interactable)
	{
		_cloudOnceLoadButton.GetComponent<Button>().interactable = interactable;
		_cloudOnceSaveButton.GetComponent<Button>().interactable = interactable;
		_cloudOnceAchievementsButton.GetComponent<Button>().interactable = interactable;
		_cloudOnceLeaderboardButton.GetComponent<Button>().interactable = interactable;

		if (interactable == false)
		{
			_cloudOnceLoadButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
			_cloudOnceSaveButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
			_cloudOnceAchievementsButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
			_cloudOnceLeaderboardButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
		}
		else
		{
			_cloudOnceLoadButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			_cloudOnceSaveButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			_cloudOnceAchievementsButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			_cloudOnceLeaderboardButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	public void SetInteractableCloudOnceCloseButton(bool interactable)
	{
		_cloudOnceCloseButton.GetComponent<Button>().interactable = interactable;

		if (interactable == false)
		{
			_cloudOnceCloseButton.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
		}
		else
		{
			_cloudOnceCloseButton.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	public void SetActiveCloudOnceMessage(int index)
	{
		_cloudOnceMessageSigningIn.SetActive(false);
		_cloudOnceMessageSigningOut.SetActive(false);
		_cloudOnceMessageSignedIn.SetActive(false);
		_cloudOnceMessageSignedOut.SetActive(false);
		_cloudOnceMessageSignInFailed.SetActive(false);
		_cloudOnceMessageSignOutFailed.SetActive(false);
		_cloudOnceMessageSavingData.SetActive(false);
		_cloudOnceMessageLoadingData.SetActive(false);
		_cloudOnceMessageDataSaved.SetActive(false);
		_cloudOnceMessageDataLoaded.SetActive(false);
		_cloudOnceMessageSaveDataFailed.SetActive(false);
		_cloudOnceMessageLoadDataFailed.SetActive(false);

		if (index == 0)
		{
			_cloudOnceMessageSigningIn.SetActive(true);
		}
		else if (index == 1)
		{
			_cloudOnceMessageSigningOut.SetActive(true);
		}
		else if (index == 2)
		{
			_cloudOnceMessageSignedIn.SetActive(true);
		}
		else if (index == 3)
		{
			_cloudOnceMessageSignedOut.SetActive(true);
		}
		else if (index == 4)
		{
			_cloudOnceMessageSignInFailed.SetActive(true);
		}
		else if (index == 5)
		{
			_cloudOnceMessageSignOutFailed.SetActive(true);
		}
		else if (index == 6)
		{
			_cloudOnceMessageSavingData.SetActive(true);
		}
		else if (index == 7)
		{
			_cloudOnceMessageLoadingData.SetActive(true);
		}
		else if (index == 8)
		{
			_cloudOnceMessageDataSaved.SetActive(true);
		}
		else if (index == 9)
		{
			_cloudOnceMessageDataLoaded.SetActive(true);
		}
		else if (index == 10)
		{
			_cloudOnceMessageSaveDataFailed.SetActive(true);
		}
		else if (index == 11)
		{
			_cloudOnceMessageLoadDataFailed.SetActive(true);
		}
	}

	public void AnimateCloudOnceBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_cloudOnce, _cloudOnceBoard, CLOUD_ONCE_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateCloudOnceBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_cloudOnce, _cloudOnceBoard, CLOUD_ONCE_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateCloudOnceSignInButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceSignInButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateCloudOnceSignOutButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceSignOutButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateCloudOnceLoadButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceLoadButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateCloudOnceSaveButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceSaveButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateCloudOnceAchivementsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceAchievementsButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateCloudOnceLeaderboardButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceLeaderboardButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateCloudOnceCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_cloudOnceCloseButton, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_SCALE, CLOUD_ONCE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Settings

	public float SETTINGS_ANIMATE_BOARD_ENTER_DURATION;
	public float SETTINGS_ANIMATE_BOARD_EXIT_DURATION;

	public float SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE;
	public float SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _settings;
	private GameObject _settingsBoard;

	private GameObject _settingsAudioOn;
	private GameObject _settingsAudioOff;
	private GameObject _settingsClose;

	private GameObject _settingsAudioOnButton;
	private GameObject _settingsAudioOffButton;
	private GameObject _settingsCloseButton;

	private void FindSettingsGameObject()
	{
		_settings = GameObject.Find("/Canvas/Settings");
		_settingsBoard = GameObject.Find("/Canvas/Settings/Board");

		_settingsAudioOn = GameObject.Find("/Canvas/Settings/Board/AudioOn");
		_settingsAudioOff = GameObject.Find("/Canvas/Settings/Board/AudioOff");
		_settingsClose = GameObject.Find("/Canvas/Settings/Board/Close");

		_settingsAudioOnButton = GameObject.Find("/Canvas/Settings/Board/AudioOn/Button");
		_settingsAudioOffButton = GameObject.Find("/Canvas/Settings/Board/AudioOff/Button");
		_settingsCloseButton = GameObject.Find("/Canvas/Settings/Board/Close/Button");
	}

	public void SetActiveSettings(bool active)
	{
		_settings.SetActive(active);
	}

	public void SetEnableSettingsButton(bool enable)
	{
		_settingsAudioOnButton.GetComponent<Button>().enabled = enable;
		_settingsAudioOffButton.GetComponent<Button>().enabled = enable;
		_settingsCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void SetActiveSettingsAudioOnButton(bool active)
	{
		_settingsAudioOn.SetActive(active);
	}

	public void SetActiveSettingsAudioOffButton(bool active)
	{
		_settingsAudioOff.SetActive(active);
	}

	public void AnimateSettingsBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_settings, _settingsBoard, SETTINGS_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateSettingsBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_settings, _settingsBoard, SETTINGS_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateSettingsAudioOnButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsAudioOnButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsAudioOffButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsAudioOffButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsCloseButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Rewards

	public float REWARDS_ANIMATE_BOARD_ENTER_DURATION;
	public float REWARDS_ANIMATE_BOARD_EXIT_DURATION;

	public float REWARDS_ANIMATE_BUTTON_PRESSED_SCALE;
	public float REWARDS_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _rewards;
	private GameObject _rewardsBoard;

	private GameObject _rewardsOpen;
	private GameObject _rewardsClose;

	private GameObject _rewardsOpenButton;
	private GameObject _rewardsCloseButton;

	private GameObject[] _rewardsDay;
	private GameObject[] _rewardsDayButton;
	private GameObject[] _rewardsDayClaimed;
	private GameObject[] _rewardsDayUnclaimed;

	private void FindRewardsGameObject()
	{
		_rewards = GameObject.Find("/Canvas/Rewards");
		_rewardsBoard = GameObject.Find("/Canvas/Rewards/Board");

		_rewardsOpen = GameObject.Find("/Canvas/RewardsOpen");
		_rewardsClose = GameObject.Find("/Canvas/Rewards/Board/Close");

		_rewardsOpenButton = GameObject.Find("/Canvas/RewardsOpen/Button");
		_rewardsCloseButton = GameObject.Find("/Canvas/Rewards/Board/Close/Button");

		_rewardsDay = new GameObject[3];
		_rewardsDayButton = new GameObject[3];
		_rewardsDayClaimed = new GameObject[3];
		_rewardsDayUnclaimed = new GameObject[3];

		for (int i = 0; i < 3; i++)
		{
			int day = i + 1;

			_rewardsDay[i] = GameObject.Find("/Canvas/Rewards/Board/Day" + day);
			_rewardsDayButton[i] = GameObject.Find("/Canvas/Rewards/Board/Day" + day + "/Button");
			_rewardsDayClaimed[i] = GameObject.Find("/Canvas/Rewards/Board/Day" + day + "/Button/Claimed");
			_rewardsDayUnclaimed[i] = GameObject.Find("/Canvas/Rewards/Board/Day" + day + "/Button/Unclaimed");
		}
	}

	public void SetActiveRewards(bool active)
	{
		_rewards.SetActive(active);
	}

	public void SetEnableRewardsOpenButton(bool enable)
	{
		_rewardsOpenButton.GetComponent<Button>().enabled = enable;
	}

	public void SetEnableRewardsDayButton(bool enable)
	{
		for (int i = 0; i < 3; i++)
		{
			_rewardsDayButton[i].GetComponent<Button>().enabled = enable;
		}
	}

	public void SetActiveRewardsDayClaimed(int day, bool active)
	{
		_rewardsDayClaimed[day].SetActive(active);
		_rewardsDayUnclaimed[day].SetActive(!active);
	}

	public void SetEnableRewardsCloseButton(bool enable)
	{
		_rewardsCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateRewardsBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_rewards, _rewardsBoard, REWARDS_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateRewardsBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_rewards, _rewardsBoard, REWARDS_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateRewardsOpenButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_rewardsOpenButton, REWARDS_ANIMATE_BUTTON_PRESSED_SCALE, REWARDS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateRewardsCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_rewardsCloseButton, REWARDS_ANIMATE_BUTTON_PRESSED_SCALE, REWARDS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Exit

	public float EXIT_ANIMATE_BOARD_ENTER_DURATION;
	public float EXIT_ANIMATE_BOARD_EXIT_DURATION;

	public float EXIT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float EXIT_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _exit;
	private GameObject _exitBoard;

	private GameObject _exitYes;
	private GameObject _exitYesButton;

	private GameObject _exitNo;
	private GameObject _exitNoButton;

	private void FindExitGameObject()
	{
		_exit = GameObject.Find("/Canvas/Exit");
		_exitBoard = GameObject.Find("/Canvas/Exit/Board");

		_exitYes = GameObject.Find("/Canvas/Exit/Board/Yes");
		_exitYesButton = GameObject.Find("/Canvas/Exit/Board/Yes/Button");

		_exitNo = GameObject.Find("/Canvas/Exit/Board/No");
		_exitNoButton = GameObject.Find("/Canvas/Exit/Board/No/Button");
	}

	public void SetActiveExit(bool active)
	{
		_exit.SetActive(active);
	}

	public void SetEnableExitButton(bool enable)
	{
		_exitYesButton.GetComponent<Button>().enabled = enable;
		_exitNoButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateExitBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_exit, _exitBoard, EXIT_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateExitBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_exit, _exitBoard, EXIT_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateExitYesButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_exitYesButton, EXIT_ANIMATE_BUTTON_PRESSED_SCALE, EXIT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateExitNoButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_exitNoButton, EXIT_ANIMATE_BUTTON_PRESSED_SCALE, EXIT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

        // Unity Lifecycle

	private void Awake()
	{
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();

		FindBackgroundGameObject();
		FindCanvasGameObject();
		FindFrontGameObject();
		FindBottomGameObject();
		FindCloudOnceGameObject();
		FindSettingsGameObject();
		FindRewardsGameObject();
		FindExitGameObject();
        }
}
