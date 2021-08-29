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
		string label = "Start";
		int loadColor = 0;
		int loadAlphabet = 0;
		int loadMap = 0;

		if (_data.GetLastColor() != _data.GetLastColorDefault())
		{
			label = "Continue";
			loadColor = _data.GetLastColor();
			loadAlphabet = _data.GetLastAlphabet();
			loadMap = _data.GetLastMap();
		}

		_ui.SetFrontContinueLabel(label);
		_ui.SetFrontContinueLevel(loadColor, loadAlphabet, loadMap);

		_ui.SetEnableFrontButton(false);
		_ui.AnimateFrontEnter(EnableFrontButton);
	}

	private void EnableFrontButton()
	{
		_ui.SetEnableFrontButton(true);
	}

	private void LoadLevelScene()
	{
		SceneManager.LoadScene("LevelScene");
	}

	private void LoadLevelMenuScene()
	{
		SceneManager.LoadScene("LevelMenuScene");
	}

	public void DoFrontContinueButtonPressed()
	{
		int loadColor = 0;
		int loadAlphabet = 0;
		int loadMap = 0;

		if (_data.GetLastColor() != _data.GetLastColorDefault())
		{
			loadColor = _data.GetLastColor();
			loadAlphabet = _data.GetLastAlphabet();
			loadMap = _data.GetLastMap();
		}

		_data.SetMenuColor(loadColor);
		_data.SetMenuAlphabet(loadAlphabet);
		_data.SetMenuMap(loadMap);

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateFrontExit(LoadLevelScene);
	}

	public void DoFrontLevelsButtonPressed()
	{
		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateFrontExit(LoadLevelMenuScene);
	}

	public void DoFrontSettingsButtonPressed()
	{
	}

	public void DoFrontStoreButtonPressed()
	{
	}

	public void DoFrontDailyRewardsButtonPressed()
	{
	}

	// UI - Bottom

	private void SetupBottom()
	{
		#if (BUILD_ANDROID_DEBUG || BUILD_ANDROID_RELEASE)
			_ui.SetActiveBottomGameCenterPanel(false);
		#else
			_ui.SetActiveBottomGooglePlayPanel(false);
		#endif

		_ui.SetEnableBottomButton(true);
	}

	public void DoBottomGooglePlayButtonPressed()
	{
	}

	public void DoBottomGameCenterButtonPressed()
	{
	}

	public void DoBottomNoAdsButtonPressed()
	{
	}

	public void DoBottomLanguageButtonPressed()
	{
	}

	// UI - Exit

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
		_ui.SetEnableFrontButton(true);
		_ui.SetEnableBottomButton(true);
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
		SetupBottom();
		SetupExit();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_ui.SetActiveExitPanel(true);
			_ui.SetEnableFrontButton(false);
			_ui.SetEnableBottomButton(false);
		}
	}
}
