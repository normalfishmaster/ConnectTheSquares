using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	private MainMenuLogic _logic;
	private LevelManager _level;

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

		LeanTween.moveLocalX(_frontContinue, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalX(_frontLevels, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_EXIT_DELAY);
		LeanTween.moveLocalX(_frontSettings, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_EXIT_DELAY * 2);
		LeanTween.moveLocalX(_frontStore, width, FRONT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeOutQuad).setDelay(FRONT_ANIMATE_EXIT_DELAY * 3).setOnComplete(
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

	public void OnFrontContinueButtonPressed()
	{
		_logic.DoFrontContinueButtonPressed();
	}

	public void OnFrontLevelsButtonPressed()
	{
		_logic.DoFrontLevelsButtonPressed();
	}

	public void OnFrontSettingsButtonPressed()
	{
		_logic.DoFrontSettingsButtonPressed();
	}

	public void OnFrontStoreButtonPressed()
	{
		_logic.DoFrontStoreButtonPressed();
	}

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomGooglePlay;
	private GameObject _bottomGooglePlayButton;
	private GameObject _bottomGameCenter;
	private GameObject _bottomGameCenterButton;

	private GameObject _bottomNoAds;
	private GameObject _bottomNoAdsButton;

	private GameObject _bottomLanguage;
	private GameObject _bottomLanguageButton;

	private void FindBottomGameObject()
	{
		_bottomGooglePlay = GameObject.Find("/Canvas/Bottom/GooglePlay");
		_bottomGooglePlayButton = GameObject.Find("/Canvas/Bottom/GooglePlay/Button");

		_bottomGameCenter = GameObject.Find("/Canvas/Bottom/GameCenter");
		_bottomGameCenterButton = GameObject.Find("/Canvas/Bottom/GameCenter/Button");

		_bottomNoAds = GameObject.Find("/Canvas/Bottom/NoAds");
		_bottomNoAdsButton = GameObject.Find("/Canvas/Bottom/NoAds/Button");

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
		_bottomNoAdsButton.GetComponent<Button>().enabled = enable;
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

	public void AnimateBottomNoAdsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomNoAdsButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateBottomLanguageButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomLanguageButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnBottomGooglePlayButtonPressed()
	{
		_logic.DoBottomGooglePlayButtonPressed();
	}

	public void OnBottomGameCenterButtonPressed()
	{
		_logic.DoBottomGameCenterButtonPressed();
	}

	public void OnBottomNoAdsButtonPressed()
	{
		_logic.DoBottomNoAdsButtonPressed();
	}

	public void OnBottomLanguageButtonPressed()
	{
		_logic.DoBottomLanguageButtonPressed();
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

	public void OnExitYesButtonPressed()
	{
		_logic.DoExitYesButtonPressed();
	}

	public void OnExitNoButtonPressed()
	{
		_logic.DoExitNoButtonPressed();
	}

        // Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("MainMenuLogic").GetComponent<MainMenuLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindCanvasGameObject();
		FindFrontGameObject();
		FindBottomGameObject();
		FindExitGameObject();
        }
}
