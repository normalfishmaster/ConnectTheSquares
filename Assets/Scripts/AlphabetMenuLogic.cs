using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetMenuLogic : MonoBehaviour
{
	private AlphabetMenuUI _ui;
	private DataManager _data;
	private LevelManager _level;

	private int _menuColor;

	// UI - Alphabet

	private void SetupAlphabet()
	{
		int numAlphabet = _level.GetNumAlphabet(_menuColor);

		_ui.SetAlphabetSize(numAlphabet);

		for (int i = 0; i < numAlphabet; i++)
		{
			int numMap = _level.GetNumMap(_menuColor, i);
			int numStar = 0;

			for (int j = 0; j < numMap; j++)
			{
				numStar += _data.GetLevelStar(_menuColor, i, j);
			}

			_ui.AddAlphabet(_menuColor, i, numStar);
		}
	}

	public void DoAlphabetButtonPressed(int alphabet)
	{
		_data.SetMenuAlphabet(alphabet);
		SceneManager.LoadScene("MapMenuScene");
	}

	// UI - Top

	private void SetupTop()
	{
		_ui.SetTopColor(_menuColor);
	}

	// UI - Back

	public void DoBackButtonPressed()
	{
		SceneManager.LoadScene("ColorMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("AlphabetMenuUI").GetComponent<AlphabetMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

        private void Start()
        {
		_menuColor = _data.GetMenuColor();

		SetupAlphabet();
		SetupTop();
        }
}
