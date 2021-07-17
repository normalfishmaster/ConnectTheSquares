using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	LevelLogic _logic;

	// Top

	Text _topMoveUserText;
	Text _topMoveBestText;

	private void FindTopGameObject()
	{
		_topMoveUserText = GameObject.Find("/Canvas/Top/Move/User").GetComponent<Text>();
		_topMoveBestText = GameObject.Find("/Canvas/Top/Move/Best").GetComponent<Text>();
	}

	public void SetTopMoveUser(int move)
	{
		_topMoveUserText.text = move.ToString();
	}

	public void SetTopMoveBest(int move)
	{
		_topMoveBestText.text = move.ToString();
	}

	// Control

	Button _controlUndoButton;
	Button _controlResetButton;

	private void FindControlGameObject()
	{
		_controlUndoButton = GameObject.Find("/Canvas/Control/Undo").GetComponent<Button>();
		_controlResetButton = GameObject.Find("/Canvas/Control/Reset").GetComponent<Button>();
	}

	public void OnControlUndoButtonPressed()
	{
		_logic.DoControlUndoButtonPressed();
	}

	public void OnControlResetButtonPressed()
	{
		_logic.DoControlResetButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
		FindTopGameObject();
		FindControlGameObject();
	}
}
