using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	private LevelLogic _logic;
	private LevelManager _level;

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

	public void SetTopStar(int star)
	{
		for (int i = 0; i < 3; i++)
		{
			if (i < star)
			{
				_topStarPanel[i].SetActive(true);
			}
			else
			{
				_topStarPanel[i].SetActive(false);
			}
		}
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
	private GameObject[] _winStarPanel;

	private Button _winNextButton;

	public void FindWinGameObject()
	{
		_winPanel = GameObject.Find("/Canvas/Win");

		_winStarPanel = new GameObject[3];

		for (int i = 0; i < 3; i++)
		{
			_winStarPanel[i] = GameObject.Find("/Canvas/Win/Panel/Star/Star" + i);
		}

		_winNextButton = GameObject.Find("/Canvas/Win/Panel/Next/Button").GetComponent<Button>();
	}

	public void SetActiveWinPanel(bool active)
	{
		_winPanel.SetActive(active);
	}

	public void SetWinStar(int star)
	{
		for (int i = 0; i < 3; i++)
		{
			if (i < star)
			{
				_winStarPanel[i].SetActive(true);
			}
			else
			{
				_winStarPanel[i].SetActive(false);
			}
		}
	}

	public void SetInteractableWinNextButton(bool interactable)
	{
		_winNextButton.interactable = interactable;
	}

	public void OnWinHintButtonPressed()
	{
		_logic.DoWinHintButtonPressed();
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
		FindPauseGameObject();
		FindWinGameObject();
		FindAdLoadGameObject();
		FindAdSuccessGameObject();
		FindAdAbortGameObject();
		FindAdFailGameObject();
	}
}
