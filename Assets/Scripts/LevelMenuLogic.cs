using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuLogic : MonoBehaviour
{
	private LevelMenuUI _ui;
	private DataManager _data;
	private LevelManager _level;

	private int _menuColor;

	// UI - Level

	private void SetupLevel()
	{
		int numColor = _level.GetNumColor();

		_ui.SetLevelSize(numColor);

		for (int i = 0; i < numColor; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);

			if (numAlphabet == 1)
			{
				float starA = (float)(_data.GetAlphabetStar(i, 0));
				float starATotal = (float)(_data.GetAlphabetStarTotal(i, 0));
				string moves = "Moves:  2 - 4";

				_ui.AddLevelSingle(i, moves, (starA / starATotal) * 100.0f);
			}
			else
			{
				float starA = (float)(_data.GetAlphabetStar(i, 0));
				float starATotal = (float)(_data.GetAlphabetStarTotal(i, 0));

				float starB = (float)(_data.GetAlphabetStar(i, 1));
				float starBTotal = (float)(_data.GetAlphabetStarTotal(i, 1));

				float starC = (float)(_data.GetAlphabetStar(i, 2));
				float starCTotal = (float)(_data.GetAlphabetStarTotal(i, 2));

				int move = 4 + i;
				string moves = "Moves:  " + move.ToString();

				_ui.AddALevelTriple(i, moves, (starA / starATotal) * 100.0f, (starB / starBTotal) * 100.0f, (starC / starCTotal) * 100.0f);
			}
		}

		_ui.AnimateLevelEnter();
	}

	public void DoLevelButtonPressed(int color, int alphabet)
	{
		_data.SetMenuColor(color);
		_data.SetMenuAlphabet(alphabet);
		SceneManager.LoadScene("MapMenuScene");
	}

	// UI - Back

	public void DoBackButtonPressed()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("LevelMenuUI").GetComponent<LevelMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

        private void Start()
        {
		_menuColor = _data.GetMenuColor();

		SetupLevel();
        }
}
