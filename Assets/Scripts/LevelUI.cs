using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	private LevelLogic _logic;
	private LevelManager _level;

	public delegate void AnimateComplete();

	// Top

	private Text _topColorText;

	private GameObject _topAlphabetAPanel;
	private GameObject _topAlphabetBPanel;
	private GameObject _topAlphabetCPanel;

	private Text _topMapText;

	private Text _topMoveCurrentText;
	private Text _topMoveTargetText;
	private Text _topMoveBestText;

	private GameObject[] _topStarPanel;

	private void FindTopGameObject()
	{
		_topColorText = GameObject.Find("/Canvas/Top/Color/Label").GetComponent<Text>();

		_topAlphabetAPanel = GameObject.Find("/Canvas/Top/Alphabet/A");
		_topAlphabetBPanel = GameObject.Find("/Canvas/Top/Alphabet/B");
		_topAlphabetCPanel = GameObject.Find("/Canvas/Top/Alphabet/C");

		_topMapText = GameObject.Find("/Canvas/Top/Map/Map").GetComponent<Text>();

		_topMoveCurrentText = GameObject.Find("/Canvas/Top/Move/Current").GetComponent<Text>();
		_topMoveTargetText = GameObject.Find("/Canvas/Top/Move/Target").GetComponent<Text>();
		_topMoveBestText = GameObject.Find("/Canvas/Top/Move/Best").GetComponent<Text>();

		_topStarPanel = new GameObject[3];

		for (int i = 0; i < 3; i++)
		{
			_topStarPanel[i] = GameObject.Find("/Canvas/Top/Star/Star" + i);
		}
	}

	public void SetTopColor(int color)
	{
		_topColorText.text = _level.GetColorString(color);
	}

	public void SetTopAlphabet(int alphabet)
	{
		string str = _level.GetAlphabetString(alphabet);

		_topAlphabetAPanel.SetActive(false);
		_topAlphabetBPanel.SetActive(false);
		_topAlphabetCPanel.SetActive(false);

		if (str == "A")
		{
			_topAlphabetAPanel.SetActive(true);
		}
		else if (str == "B")
		{
			_topAlphabetBPanel.SetActive(true);
		}
		else if (str == "C")
		{
			_topAlphabetCPanel.SetActive(true);
		}
	}

	public void SetTopMap(int map)
	{
		_topMapText.text = map.ToString();
	}

	public void SetTopMoveCurrent(int current)
	{
		_topMoveCurrentText.text = current.ToString();
	}

	public void SetTopMoveTarget(int target)
	{
		_topMoveTargetText.text = target.ToString();
	}

	public void SetTopMoveBest(int best)
	{
		_topMoveBestText.text = best.ToString();
	}

	public void SetActiveTopStar(int star, bool active)
	{
		_topStarPanel[star].SetActive(active);
	}

	// Hint

	private GameObject _hintPanel;

	private GameObject _hintUpPanel;
	private GameObject _hintDownPanel;
	private GameObject _hintLeftPanel;
	private GameObject _hintRightPanel;

	private void FindHintGameObject()
	{
		_hintPanel = GameObject.Find("/Canvas/Hint");
		_hintUpPanel = GameObject.Find("/Canvas/Hint/Up");
		_hintDownPanel = GameObject.Find("/Canvas/Hint/Down");
		_hintLeftPanel = GameObject.Find("/Canvas/Hint/Left");
		_hintRightPanel = GameObject.Find("/Canvas/Hint/Right");
	}

	public void SetActiveHintPanel(bool active)
	{
		_hintPanel.SetActive(active);
	}

	public void SetHintDirection(char direction)
	{
		char directionUpper = char.ToUpper(direction);

		_hintUpPanel.SetActive(false);
		_hintDownPanel.SetActive(false);
		_hintLeftPanel.SetActive(false);
		_hintRightPanel.SetActive(false);

		if (directionUpper == 'U')
		{
			_hintUpPanel.SetActive(true);
		}
		else if (directionUpper == 'D')
		{
			_hintDownPanel.SetActive(true);
		}
		else if (directionUpper == 'L')
		{
			_hintLeftPanel.SetActive(true);
		}
		else if (directionUpper == 'R')
		{
			_hintRightPanel.SetActive(true);
		}
	}

	// Control

	private Button _controlHintAdButton;
	private Button _controlHintOnButton;
	private Button _controlHintOffButton;
	private Button _controlPauseButton;
	private Button _controlUndoButton;
	private Button _controlResetButton;

	private GameObject _controlHintAdPanel;
	private GameObject _controlHintOnPanel;
	private GameObject _controlHintOffPanel;

	private Text _controlHintOnText;
	private Text _controlHintOffText;

	private void FindControlGameObject()
	{
		_controlHintAdButton = GameObject.Find("/Canvas/ControlL/HintAd/Button").GetComponent<Button>();
		_controlHintOnButton = GameObject.Find("/Canvas/ControlL/HintOn/Button").GetComponent<Button>();
		_controlHintOffButton = GameObject.Find("/Canvas/ControlL/HintOff/Button").GetComponent<Button>();
		_controlPauseButton = GameObject.Find("/Canvas/ControlL/Pause/Button").GetComponent<Button>();
		_controlUndoButton = GameObject.Find("/Canvas/ControlR/Undo/Button").GetComponent<Button>();
		_controlResetButton = GameObject.Find("/Canvas/ControlR/Reset/Button").GetComponent<Button>();

		_controlHintAdPanel = GameObject.Find("/Canvas/ControlL/HintAd");
		_controlHintOffPanel = GameObject.Find("/Canvas/ControlL/HintOff");
		_controlHintOnPanel = GameObject.Find("/Canvas/ControlL/HintOn");

		_controlHintOnText = GameObject.Find("/Canvas/ControlL/HintOn/Label").GetComponent<Text>();
		_controlHintOffText = GameObject.Find("/Canvas/ControlL/HintOff/Label").GetComponent<Text>();
	}

	public void SetEnableControlButton(bool enable)
	{
		_controlHintAdButton.enabled = enable;
		_controlHintOnButton.enabled = enable;
		_controlHintOffButton.enabled = enable;
		_controlPauseButton.enabled = enable;
		_controlUndoButton.enabled = enable;
		_controlResetButton.enabled = enable;
	}

	public void SetInteractableControlButton(bool interactable)
	{
		_controlHintAdButton.interactable = interactable;
		_controlHintOnButton.interactable = interactable;
		_controlHintOffButton.interactable = interactable;
		_controlPauseButton.interactable = interactable;
		_controlUndoButton.interactable = interactable;
		_controlResetButton.interactable = interactable;
	}

	public void SetActiveControlHintAdPanel(bool active)
	{
		_controlHintAdPanel.SetActive(active);
	}

	public void SetActiveControlHintOnPanel(bool active)
	{
		_controlHintOnPanel.SetActive(active);
	}

	public void SetActiveControlHintOffPanel(bool active)
	{
		_controlHintOffPanel.SetActive(active);
	}

	public void SetControlHintCount(int hint)
	{
		string text = "Hint (" + hint + ")";

		_controlHintOnText.text = text;
		_controlHintOffText.text = text;
	}

	public void OnControlPauseButtonPressed()
	{
		_logic.DoControlPauseButtonPressed();
	}

	public void OnControlUndoButtonPressed()
	{
		_logic.DoControlUndoButtonPressed();
	}

	public void OnControlResetButtonPressed()
	{
		_logic.DoControlResetButtonPressed();
	}

	public void OnControlHintAdButtonPressed()
	{
		_logic.DoControlHintAdButtonPressed();
	}

	public void OnControlHintOnButtonPressed()
	{
		_logic.DoControlHintOnButtonPressed();
	}

	public void OnControlHintOffButtonPressed()
	{
		_logic.DoControlHintOffButtonPressed();
	}

	// Go

	private GameObject _goPanel;
	private GameObject _goBannerBlackPanel;
	private GameObject _goBannerYellowPanel;
	private GameObject _goLabelPanel;

	private void FindGoGameObject()
	{
		_goPanel = GameObject.Find("/Canvas/Go");
		_goBannerBlackPanel = GameObject.Find("/Canvas/Go/BannerBlack");
		_goBannerYellowPanel = GameObject.Find("/Canvas/Go/BannerYellow");
		_goLabelPanel = GameObject.Find("/Canvas/Go/Label");
	}

	public void SetActiveGoPanel(bool enable)
	{
		_goPanel.SetActive(enable);
	}

	public void AnimateGoEnterAndExit(float bannerEnterExitTime, float labelEnterExitTime,
				float bannerEnterDelay, float labelEnterDelay, float labelExitDelay,
				AnimateComplete callback)
	{
		RectTransform rectTransform;
		Vector3 pos;
		float width;

		// Animate Banner Black

		rectTransform = (RectTransform)_goBannerBlackPanel.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x - width, pos.y, pos.z);

		LeanTween.cancel(_goBannerBlackPanel);
		LeanTween.moveLocalX(_goBannerBlackPanel, 0.0f, bannerEnterExitTime).setEase(LeanTweenType.easeOutSine)
				.setDelay(bannerEnterDelay);
		LeanTween.moveLocalX(_goBannerBlackPanel, pos.x + width, bannerEnterExitTime).setEase(LeanTweenType.easeOutSine)
				.setDelay(bannerEnterDelay + bannerEnterExitTime + +labelEnterDelay + labelEnterExitTime + labelExitDelay + labelEnterExitTime);

		// Animate Banner Yellow

		rectTransform = (RectTransform)_goBannerYellowPanel.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x + width, pos.y, pos.z);

		LeanTween.cancel(_goBannerYellowPanel);
		LeanTween.moveLocalX(_goBannerYellowPanel, 0.0f, bannerEnterExitTime).setEase(LeanTweenType.easeOutSine)
				.setDelay(bannerEnterDelay);
		LeanTween.moveLocalX(_goBannerYellowPanel, pos.x - width, bannerEnterExitTime).setEase(LeanTweenType.easeOutSine)
				.setDelay(bannerEnterDelay + bannerEnterExitTime + +labelEnterDelay + labelEnterExitTime + labelExitDelay + labelEnterExitTime);

		// Animate Label

		rectTransform = (RectTransform)_goLabelPanel.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x - width, pos.y, pos.z);

		LeanTween.cancel(_goLabelPanel);
		LeanTween.moveLocalX(_goLabelPanel, 0.0f, labelEnterExitTime).setEase(LeanTweenType.easeOutSine)
				.setDelay(bannerEnterDelay + bannerEnterExitTime + labelEnterDelay);
		LeanTween.moveLocalX(_goLabelPanel, pos.x + width, bannerEnterExitTime).setEase(LeanTweenType.easeOutSine)
				.setDelay(bannerEnterDelay + bannerEnterExitTime + labelEnterDelay + labelEnterExitTime + labelExitDelay)
				.setOnComplete(
					()=>
					{
						callback();
					}
				);
	}

	// Pause

	private GameObject _pausePanel;

	public void FindPauseGameObject()
	{
		_pausePanel = GameObject.Find("/Canvas/Pause");
	}

	public void SetActivePausePanel(bool active)
	{
		_pausePanel.SetActive(active);
	}

	public void OnPauseMenuButtonPressed()
	{
		_logic.DoPauseMenuButtonPressed();
	}

	public void OnPauseHintAdButtonPressed()
	{
		_logic.DoPauseHintAdButtonPressed();
	}

	public void OnPauseResumeButtonPressed()
	{
		_logic.DoPauseResumeButtonPressed();
	}

	// Win

	private GameObject _winPanel;
	private GameObject _winBoardPanel;
	private GameObject[] _winStarPanel;

	private Button _winHintAdButton;
	private Button _winMenuButton;
	private Button _winResetButton;
	private Button _winNextButton;

	int _winNumStar;

	public void FindWinGameObject()
	{
		_winPanel = GameObject.Find("/Canvas/Win");
		_winBoardPanel = GameObject.Find("/Canvas/Win/Board");
		_winStarPanel = new GameObject[3];

		for (int i = 0; i < 3; i++)
		{
			_winStarPanel[i] = GameObject.Find("/Canvas/Win/Board/Star/Star" + i);
		}

		_winHintAdButton = GameObject.Find("/Canvas/Win/Board/HintAd/Button").GetComponent<Button>();
		_winMenuButton = GameObject.Find("/Canvas/Win/Board/Menu/Button").GetComponent<Button>();
		_winResetButton = GameObject.Find("/Canvas/Win/Board/Reset/Button").GetComponent<Button>();
		_winNextButton = GameObject.Find("/Canvas/Win/Board/Next/Button").GetComponent<Button>();
	}

	public void SetActiveWinPanel(bool active)
	{
		_winPanel.SetActive(active);
	}

	public void SetActiveWinStarPanel(int star, bool active)
	{
		_winStarPanel[star].SetActive(active);
	}

	private void AnimateWinStarEnterSingle(int star, float enterTime, AnimateComplete callback)
	{
		_winStarPanel[star].SetActive(true);

		LeanTween.cancel(_winStarPanel[star]);

		// X and Y

		float height = ((RectTransform)(_winBoardPanel.transform)).rect.height * 0.4f;
		float width = ((RectTransform)(_winBoardPanel.transform)).rect.width * 0.4f;

		if (star == 0)
		{
			width *= -1;
		}
		else if (star == 1)
		{
			width = 0;
		}

		Vector3 pos = ((RectTransform)_winStarPanel[star].transform).anchoredPosition;
		((RectTransform)_winStarPanel[star].transform).anchoredPosition = new Vector3(pos.x + width, pos.y + height, pos.z);

		LeanTween.moveLocalX(_winStarPanel[star], pos.x, enterTime).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalY(_winStarPanel[star], pos.y, enterTime).setEase(LeanTweenType.easeOutQuad);

		// Scale

		_winStarPanel[star].transform.localScale = Vector3.one * 5.0f;

		LeanTween.scale(_winStarPanel[star], Vector3.one, enterTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				SetActiveTopStar(star, true);
				callback();
			}
		);
	}

	public void AnimateWinStarEnter(int star, float enterTime, AnimateComplete callback)
	{
		if (star == 1)
		{
			AnimateWinStarEnterSingle(0, enterTime, callback);
		}
		else if (star == 2)
		{
			AnimateWinStarEnterSingle(0, enterTime,
				()=>
				{
					AnimateWinStarEnterSingle(1, enterTime, callback);
				}
			);
		}
		else if (star == 3)
		{
			AnimateWinStarEnterSingle(0, enterTime,
				()=>
				{
					AnimateWinStarEnterSingle(1, enterTime,
						()=>
						{
							AnimateWinStarEnterSingle(2, enterTime, callback);
						}
					);
				}
			);
		}
	}

	public void AnimateWinBoardEnter(float enterTime, AnimateComplete callback)
	{
		float height = ((RectTransform)(_winPanel.transform)).rect.height;

		RectTransform rectTransform = (RectTransform)_winBoardPanel.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y + height, pos.z);

		LeanTween.cancel(_winBoardPanel);
		LeanTween.moveLocalY(_winBoardPanel, 0.0f, enterTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void SetInteractableWinButton(bool interactable)
	{
		_winHintAdButton.interactable = interactable;
		_winMenuButton.interactable = interactable;
		_winResetButton.interactable = interactable;
	}

	public void SetInteractableWinNextButton(bool interactable)
	{
		_winNextButton.interactable = interactable;
	}

	public void OnWinHintAdButtonPressed()
	{
		_logic.DoWinHintAdButtonPressed();
	}

	public void OnWinMenuButtonPressed()
	{
		_logic.DoWinMenuButtonPressed();
	}

	public void OnWinReplayButtonPressed()
	{
		_logic.DoWinReplayButtonPressed();
	}

	public void OnWinNextButtonPressed()
	{
		_logic.DoWinNextButtonPressed();
	}

	// Ad - Load

	private GameObject _adLoadPanel;

	private void FindAdLoadGameObject()
	{
		_adLoadPanel = GameObject.Find("/Canvas/AdLoad");
	}

	public void SetActiveAdLoadPanel(bool active)
	{
		_adLoadPanel.SetActive(active);
	}

	// Ad - Success

	private GameObject _adSuccessPanel;

	private void FindAdSuccessGameObject()
	{
		_adSuccessPanel = GameObject.Find("/Canvas/AdSuccess");
	}

	public void SetActiveAdSuccessPanel(bool active)
	{
		_adSuccessPanel.SetActive(active);
	}

	public void OnAdSuccessCloseButtonPressed()
	{
		_logic.DoAdSuccessCloseButtonPressed();
	}

	// Ad - Abort

	private GameObject _adAbortPanel;

	private void FindAdAbortGameObject()
	{
		_adAbortPanel = GameObject.Find("/Canvas/AdAbort");
	}

	public void SetActiveAdAbortPanel(bool active)
	{
		_adAbortPanel.SetActive(active);
	}

	public void OnAdAbortCloseButtonPressed()
	{
		_logic.DoAdAbortCloseButtonPressed();
	}

	// Ad - Fail

	private GameObject _adFailPanel;

	private void FindAdFailGameObject()
	{
		_adFailPanel = GameObject.Find("/Canvas/AdFail");
	}

	public void SetActiveAdFailPanel(bool active)
	{
		_adFailPanel.SetActive(active);
	}

	public void OnAdFailCloseButtonPressed()
	{
		_logic.DoAdFailCloseButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindTopGameObject();
		FindHintGameObject();
		FindControlGameObject();
		FindGoGameObject();
		FindPauseGameObject();
		FindWinGameObject();
		FindAdLoadGameObject();
		FindAdSuccessGameObject();
		FindAdAbortGameObject();
		FindAdFailGameObject();
	}
}
