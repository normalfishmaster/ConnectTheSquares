using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorMenuLogic : MonoBehaviour
{
	private ColorMenuUI _ui;
	private DataManager _data;
	private LevelManager _level;

	// Color

	private void SetupColor()
	{
		int numColor = _level.GetNumColor();

		_ui.SetupColorSize(numColor);

		for (int i = 0; i < numColor; i++)
		{

			int currentStar = 0;
			int totalStar = 0;

			int numAlphabet = _level.GetNumAlphabet(i);

			for (int j = 0; j < numAlphabet; j++)
			{
				int numMap = _level.GetNumMap(i, j);

				for (int k = 0; k < numMap; k++)
				{
					currentStar += _data.GetLevelStar(i, j, k);
					totalStar += 3;
				}
			}

			float percentage = (float)(currentStar) / (float)(totalStar);
			_ui.AddColor(i, percentage);
		}
	}

	public void DoColorButtonPressed(int color)
	{
		_data.SetMenuColor(color);
		SceneManager.LoadScene("AlphabetMenuScene");
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
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

	private void Start()
	{
		SetupColor();
	}
}
