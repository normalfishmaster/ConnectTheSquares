using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	LevelLogic _logic;
	LevelManager _level;

	// Top

	Text _topNameFullText;

	Text _topStarObtainedText;

	Text _topMoveUserText;
	Text _topMoveBestText;

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

	// Controls

	Button _controlsUndoButton;
	Button _controlsResetButton;

	private void FindControlsGameObject()
	{
		_controlsUndoButton = GameObject.Find("/Canvas/Controls/Undo").GetComponent<Button>();
		_controlsResetButton = GameObject.Find("/Canvas/Controls/Reset").GetComponent<Button>();
	}

	public void OnControlsUndoButtonPressed()
	{
		_logic.DoControlsUndoButtonPressed();
	}

	public void OnControlsResetButtonPressed()
	{
		_logic.DoControlsResetButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindTopGameObject();
		FindControlsGameObject();
	}
}
