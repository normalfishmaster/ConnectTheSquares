using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
	private MainMenuUI _ui;
	private DataManager _data;
	private LevelManager _level;
	private AdManager _ad;

	// UI - Front

	private void SetupFront()
	{
		if (_data.GetLastColor() == _data.GetLastColorDefault())
		{
			_ui.SetFrontContinueText("Start");
		}
		else
		{
			_ui.SetFrontContinueText("Continue");
		}

		_ui.SetEnableFrontButtons(true);
	}

	public void DoFrontContinueButtonPressed()
	{
		int color = 0;
		int alphabet = 0;
		int map = 0;

		if (_data.GetLastColor() != _data.GetLastColorDefault())
		{
			color = _data.GetLastColor();
			alphabet = _data.GetLastAlphabet();
			map = _data.GetLastMap();
		}

		_data.SetMenuColor(color);
		_data.SetMenuAlphabet(alphabet);
		_data.SetMenuMap(map);

		SceneManager.LoadScene("LevelScene");
	}

	public void DoFrontLevelsButtonPressed()
	{
		SceneManager.LoadScene("ColorMenuScene");
	}

	public void DoFrontSettingsButtonPressed()
	{
	}

	public void DoFrontStoreButtonPressed()
	{
	}

	public void DoFrontLeaderboardButtonPressed()
	{
	}

	public void DoFrontNoAdsButtonPressed()
	{
	}

	public void DoFrontLanguageButtonPressed()
	{
	}

	public void DoFrontDailyRewardsButtonPressed()
	{
	}

	// UI Events - Exit

	private void SetupExit()
	{
		_ui.SetActiveExitPanel(false);
	}

	public void DoExitYesButtonPressed()
	{
		Application.Quit();
	}

	public void DoExitNoButtonPressed()
	{
		_ui.SetActiveExitPanel(false);
		_ui.SetEnableFrontButtons(true);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("MainMenuUI").GetComponent<MainMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
	}

	private void Start()
	{
		SetupFront();
		SetupExit();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_ui.SetActiveExitPanel(true);
			_ui.SetEnableFrontButtons(false);
		}
	}
}
