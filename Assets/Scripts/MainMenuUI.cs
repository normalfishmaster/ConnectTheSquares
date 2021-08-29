using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	private MainMenuLogic _logic;
	private LevelManager _level;

	public delegate void AnimateComplete();

	// Front

	private GameObject _canvasPanel;
	private GameObject _frontPanel;
	private GameObject _frontContinuePanel;
	private GameObject _frontLevelsPanel;
	private GameObject _frontSettingsPanel;
	private GameObject _frontStorePanel;

	private Button _frontContinueButton;
	private Button _frontLevelsButton;
	private Button _frontSettingsButton;
	private Button _frontStoreButton;
	private Button _frontDailyRewardsButton;

	private Text _frontContinueLabelText;
	private Text _frontContinueLevelText;

	private void FindFrontGameObject()
	{
		_canvasPanel = GameObject.Find("/Canvas");
		_frontPanel = GameObject.Find("/Canvas/Front");

		_frontContinuePanel = GameObject.Find("/Canvas/Front/Continue");
		_frontLevelsPanel = GameObject.Find("/Canvas/Front/Levels");
		_frontSettingsPanel = GameObject.Find("/Canvas/Front/Settings");
		_frontStorePanel = GameObject.Find("/Canvas/Front/Store");

		_frontContinueButton = GameObject.Find("/Canvas/Front/Continue").GetComponent<Button>();
		_frontLevelsButton = GameObject.Find("/Canvas/Front/Levels").GetComponent<Button>();
		_frontSettingsButton = GameObject.Find("/Canvas/Front/Settings").GetComponent<Button>();
		_frontStoreButton = GameObject.Find("/Canvas/Front/Store").GetComponent<Button>();

		_frontContinueLabelText = GameObject.Find("/Canvas/Front/Continue/Label").GetComponent<Text>();
		_frontContinueLevelText = GameObject.Find("/Canvas/Front/Continue/Level").GetComponent<Text>();

		_frontDailyRewardsButton = GameObject.Find("/Canvas/DailyRewards").GetComponent<Button>();
	}

	public void SetEnableFrontButton(bool enable)
	{
		_frontContinueButton.enabled = enable;
		_frontLevelsButton.enabled = enable;
		_frontSettingsButton.enabled = enable;
		_frontStoreButton.enabled = enable;
		_frontDailyRewardsButton.enabled = enable;
	}

	public void SetFrontContinueLabel(string text)
	{
		_frontContinueLabelText.text = text;
	}

	public void SetFrontContinueLevel(int color, int alphabet, int map)
	{
		string str = _level.GetColorString(color) + " - " + _level.GetAlphabetString(alphabet) + " - " + _level.GetMapString(map);
		_frontContinueLevelText.text = str;
	}

	public void AnimateFrontEnter(AnimateComplete callback)
	{
		float width = _canvasPanel.GetComponent<CanvasScaler>().referenceResolution.x;
		Vector2 diff = new Vector3(-1 * width, 0.0f);

		RectTransform continueRt = (RectTransform)_frontContinuePanel.transform;
		RectTransform levelsRt = (RectTransform)_frontLevelsPanel.transform;
		RectTransform settingsRt = (RectTransform)_frontSettingsPanel.transform;
		RectTransform storeRt = (RectTransform)_frontStorePanel.transform;

		continueRt.anchoredPosition += diff;
		levelsRt.anchoredPosition += diff;
		settingsRt.anchoredPosition += diff;
		storeRt.anchoredPosition += diff;

		LeanTween.cancel(continueRt);
		LeanTween.cancel(levelsRt);
		LeanTween.cancel(settingsRt);
		LeanTween.cancel(storeRt);

		LeanTween.moveLocalX(_frontContinuePanel, 0.0f, 0.3f).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalX(_frontLevelsPanel, 0.0f, 0.3f).setEase(LeanTweenType.easeOutQuad).setDelay(0.15f);
		LeanTween.moveLocalX(_frontSettingsPanel, 0.0f, 0.3f).setEase(LeanTweenType.easeOutQuad).setDelay(0.30f);
		LeanTween.moveLocalX(_frontStorePanel, 0.0f, 0.3f).setEase(LeanTweenType.easeOutQuad).setDelay(0.45f).setOnComplete(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateFrontExit(AnimateComplete callback)
	{
		float width = _canvasPanel.GetComponent<CanvasScaler>().referenceResolution.x;

		RectTransform continueRt = (RectTransform)_frontContinuePanel.transform;
		RectTransform levelsRt = (RectTransform)_frontLevelsPanel.transform;
		RectTransform settingsRt = (RectTransform)_frontSettingsPanel.transform;
		RectTransform storeRt = (RectTransform)_frontStorePanel.transform;

		LeanTween.cancel(continueRt);
		LeanTween.cancel(levelsRt);
		LeanTween.cancel(settingsRt);
		LeanTween.cancel(storeRt);

		LeanTween.moveLocalX(_frontContinuePanel, width, 0.3f).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalX(_frontLevelsPanel, width, 0.3f).setEase(LeanTweenType.easeOutQuad).setDelay(0.15f);
		LeanTween.moveLocalX(_frontSettingsPanel, width, 0.3f).setEase(LeanTweenType.easeOutQuad).setDelay(0.30f);
		LeanTween.moveLocalX(_frontStorePanel, width, 0.3f).setEase(LeanTweenType.easeOutQuad).setDelay(0.45f).setOnComplete(
			()=>
			{
				callback();
			}
		);
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

	public void OnFrontDailyRewardsButtonPressed()
	{
		_logic.DoFrontDailyRewardsButtonPressed();
	}


	// Bottom

	private GameObject _bottomGooglePlayPanel;
	private GameObject _bottomGameCenterPanel;

	private Button _bottomGooglePlayButton;
	private Button _bottomGameCenterButton;
	private Button _bottomNoAdsButton;
	private Button _bottomLanguageButton;

	private void FindBottomGameObject()
	{
		_bottomGooglePlayPanel = GameObject.Find("/Canvas/Bottom/GooglePlay");
		_bottomGameCenterPanel = GameObject.Find("/Canvas/Bottom/GameCenter");

		_bottomGooglePlayButton = GameObject.Find("/Canvas/Bottom/GooglePlay/Button").GetComponent<Button>();
		_bottomGameCenterButton = GameObject.Find("/Canvas/Bottom/GameCenter/Button").GetComponent<Button>();
		_bottomNoAdsButton = GameObject.Find("/Canvas/Bottom/NoAds/Button").GetComponent<Button>();
		_bottomLanguageButton = GameObject.Find("/Canvas/Bottom/Language/Button").GetComponent<Button>();
	}

	public void SetActiveBottomGooglePlayPanel(bool active)
	{
		_bottomGooglePlayPanel.SetActive(active);
	}

	public void SetActiveBottomGameCenterPanel(bool active)
	{
		_bottomGameCenterPanel.SetActive(active);
	}

	public void SetEnableBottomButton(bool enable)
	{
		_bottomGooglePlayButton.enabled = enable;
		_bottomGameCenterButton.enabled = enable;
		_bottomNoAdsButton.enabled = enable;
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

	private GameObject _exitPanel;

	private void FindExitGameObject()
	{
		_exitPanel = GameObject.Find("/Canvas/Exit");
	}

	public void SetActiveExitPanel(bool active)
	{
		_exitPanel.SetActive(active);
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

		FindFrontGameObject();
		FindBottomGameObject();
		FindExitGameObject();
        }
}
