using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuLogic : MonoBehaviour
{
	private LevelMenuUI _ui;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private FrameRateManager _frameRate;
	private LevelManager _level;
	private AudioManager _audio;

	// Estimated scroll duration
	private const float FRAME_RATE_CHANGE_DELAY = 1.0f;

	private int _menuColor;

	// UI - Background

	private void SetupBackground()
	{
		_ui.SetBackgroundColor(_cloudOnce.GetBackgroundColor());
	}

	// UI - Level

	private const float LEVEL_ANIMATE_PANEL_ENTER_TIME = 0.3f;
	private const float LEVEL_ANIMATE_PERCENTAGE_ANIMATE_TIME = 0.3f;

	private void SetupLevel()
	{
		int numColor = _level.GetNumColor();

		_ui.SetLevelSize(numColor);

		for (int i = 0; i < numColor; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);

			if (numAlphabet == 1)
			{
				float starA = (float)(_cloudOnce.GetCollectedAlphabetStar(i, 0));
				float starATotal = (float)(_level.GetTotalAlphabetStars(i, 0));
				string moves = "Moves:  2 - 4";

				_ui.AddLevelSingle(i, moves, (starA / starATotal) * 100.0f);
			}
			else
			{
				float starA = (float)(_cloudOnce.GetCollectedAlphabetStar(i, 0));
				float starATotal = (float)(_level.GetTotalAlphabetStars(i, 0));

				float starB = (float)(_cloudOnce.GetCollectedAlphabetStar(i, 1));
				float starBTotal = (float)(_level.GetTotalAlphabetStars(i, 1));

				float starC = (float)(_cloudOnce.GetCollectedAlphabetStar(i, 2));
				float starCTotal = (float)(_level.GetTotalAlphabetStars(i, 2));

				int move = 4 + i;
				string moves = "Moves:  " + move.ToString();

				_ui.AddLevelTriple(i, moves, (starA / starATotal) * 100.0f, (starB / starBTotal) * 100.0f, (starC / starCTotal) * 100.0f);
			}
		}
	}

	public void OnLevelButtonPressed(int color, int alphabet)
	{
		_frameRate.setHighFrameRate();

		_audio.PlayButtonPressed();

		_ui.SetEnableLevelButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateLevelButtonPressed(color, alphabet,
			()=>
			{
				_data.SetMenuColor(color);
				_data.SetMenuAlphabet(alphabet);
				SceneManager.LoadScene("MapMenuScene");
			}
		);
	}

	// UI - Bottom

	public void OnBottomBackButtonPressed()
	{
		_frameRate.setHighFrameRate();

		_audio.PlayButtonPressed();

		_ui.SetEnableLevelButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateBottomBackButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("MainMenuScene");
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("LevelMenuUI").GetComponent<LevelMenuUI>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_frameRate = GameObject.Find("FrameRateManager").GetComponent<FrameRateManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}

        private void Start()
        {
		_menuColor = _data.GetMenuColor();

		SetupBackground();
		SetupLevel();

		_frameRate.setHighFrameRate();

		_ui.SetEnableLevelButton(false);
		_ui.AnimateLevelEnter
		(
			()=>
			{
				_ui.SetEnableLevelButton(true);
				_ui.AnimateLevelPercentage
				(
					()=>
					{
						_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
					}
				);
			}
		);
        }

	private void Update()
	{
		if (Input.touchCount != 0)
		{
			_frameRate.setHighFrameRate();

	                Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Ended)
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}

			return;
		}
	}
}
