using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	private LevelLogic _logic;
	private LevelManager _level;

	// Top

	private Text _topNameFullText;

	private Text _topStarObtainedText;

	private Text _topMoveUserText;
	private Text _topMoveBestText;

	private void FindTopGameObject()
	{
		_topNameFullText = GameObject.Find("/Canvas/Top/Name/Full").GetComponent<Text>();

		_topStarObtainedText = GameObject.Find("/Canvas/Top/Star/Obtained").GetComponent<Text>();

		_topMoveUserText = GameObject.Find("/Canvas/Top/Move/User").GetComponent<Text>();
		_topMoveBestText = GameObject.Find("/Canvas/Top/Move/Best").GetComponent<Text>();
	}

	public void SetTopNameFull(int color, int alphabet, int map)
	{
		_topNameFullText.text = _level.GetColorString(color) +
				" - " + _level.GetAlphabetString(alphabet) +
				" - " + _level.GetMapString(map);
	}

	public void SetTopStarObtained(int star)
	{
		_topStarObtainedText.text = star.ToString();
	}

	public void SetTopMoveUser(int move)
	{
		_topMoveUserText.text = move.ToString();
	}

	public void SetTopMoveBest(int move)
	{
		_topMoveBestText.text = move.ToString();
	}

	// Hint

	private GameObject _hintPanel;
	private Text _hintDirectionText;

	private void FindHintGameObject()
	{
		_hintPanel = GameObject.Find("/Canvas/Hint");
		_hintDirectionText = GameObject.Find("/Canvas/Hint/Direction").GetComponent<Text>();
	}

	public void SetActiveHintPanel(bool active)
	{
		_hintPanel.SetActive(active);
	}

	public void SetHintDirection(char direction)
	{
		_hintDirectionText.text = direction.ToString();
	}

	// Control

	private Button _controlPauseButton;
	private Button _controlUndoButton;
	private Button _controlResetButton;
	private Button _controlHintButton;
	private Button _controlAdButton;

	private GameObject _controlHint;
	private GameObject _controlAd;

	private Text _controlHintText;

	private void FindControlGameObject()
	{
		_controlPauseButton = GameObject.Find("/Canvas/Control/Pause").GetComponent<Button>();
		_controlUndoButton = GameObject.Find("/Canvas/Control/Undo").GetComponent<Button>();
		_controlResetButton = GameObject.Find("/Canvas/Control/Reset").GetComponent<Button>();
		_controlHintButton = GameObject.Find("/Canvas/Control/Hint").GetComponent<Button>();
		_controlAdButton = GameObject.Find("/Canvas/Control/Ad").GetComponent<Button>();

		_controlHint = GameObject.Find("/Canvas/Control/Hint");
		_controlAd = GameObject.Find("/Canvas/Control/Ad");

		_controlHintText = GameObject.Find("/Canvas/Control/Hint/Text").GetComponent<Text>();
	}

	public void SetEnableControlButton(bool enable)
	{
		_controlPauseButton.enabled = enable;
		_controlUndoButton.enabled = enable;
		_controlResetButton.enabled = enable;
		_controlHintButton.enabled = enable;
		_controlAdButton.enabled = enable;
	}

	public void SetInteractableControlButton(bool interactable)
	{
		_controlPauseButton.interactable = interactable;
		_controlUndoButton.interactable = interactable;
		_controlResetButton.interactable = interactable;
		_controlHintButton.interactable = interactable;
		_controlAdButton.interactable = interactable;
	}

	public void SetActiveControlHint(bool active)
	{
		_controlHint.SetActive(active);
	}

	public void SetActiveControlAd(bool active)
	{
		_controlAd.SetActive(active);
	}

	public void SetControlHintCount(int hint)
	{
		_controlHintText.text = "Hint\n(" + hint + ")";
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

	public void OnControlHintButtonPressed()
	{
		_logic.DoControlHintButtonPressed();
	}

	public void OnControlAdButtonPressed()
	{
		_logic.DoControlAdButtonPressed();
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

	public void OnPauseResumeButtonPressed()
	{
		_logic.DoPauseResumeButtonPressed();
	}

	// Win

	private GameObject _winPanel;
	private Text _winStarText;
	private Button _winNextButton;

	public void FindWinGameObject()
	{
		_winPanel = GameObject.Find("/Canvas/Win");
		_winStarText = GameObject.Find("/Canvas/Win/Star").GetComponent<Text>();
		_winNextButton = GameObject.Find("/Canvas/Win/Next").GetComponent<Button>();
	}

	public void SetActiveWinPanel(bool active)
	{
		_winPanel.SetActive(active);
	}

	public void SetWinStar(int star)
	{
		_winStarText.text = star.ToString();
	}

	public void SetInteractableWinNextButton(bool interactable)
	{
		_winNextButton.interactable = interactable;
	}

	public void OnWinAdButtonPressed()
	{
		_logic.DoWinAdButtonPressed();
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
