using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorMenuLogic : MonoBehaviour
{
	private ColorMenuUI _ui;

	// Color

	public void DoColorButtonPressed(string color)
	{
	}

	// Back

	public void DoBackButtonPressed()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("ColorMenuUI").GetComponent<ColorMenuUI>();
	}
}
