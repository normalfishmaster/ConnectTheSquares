using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
	private MainMenuUI _ui;
	private DataManager _data;
	private LevelManager _level;
	private AudioManager _audio;
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

		_ui.SetFrontContinueButtonLabel(label);
		_ui.SetFrontContinueLevel(loadColor, loadAlphabet, loadMap);
	}

	public void OnFrontContinueButtonPressed()
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

		_audio.PlayContinuePressed();

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateFrontContinueButtonPressed
		(
			()=>
			{
				_ui.AnimateFrontExit
				(
					()=>
					{
						SceneManager.LoadScene("LevelScene");
					}
				);
			}
		);
	}

	public void OnFrontLevelsButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateFrontLevelsButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("LevelMenuScene");
			}
		);
	}

	public void OnFrontSettingsButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateFrontSettingsButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnFrontStoreButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateFrontStoreButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("StoreScene");
			}
		);
	}

	// UI - Bottom

	private void SetupBottom()
	{
		#if (BUILD_ANDROID_DEBUG || BUILD_ANDROID_RELEASE)
			_ui.SetActiveBottomGameCenter(false);
		#else
			_ui.SetActiveBottomGooglePlay(false);
		#endif

		_ui.SetEnableBottomButton(true);
	}

	public void OnBottomGooglePlayButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateBottomGooglePlayButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnBottomGameCenterButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateBottomGameCenterButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnBottomRateButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateBottomRateButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnBottomLanguageButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateBottomLanguageButtonPressed
		(
			()=>
			{
			}
		);
	}

	// UI - Exit

	private void SetupExit()
	{
		_ui.SetEnableExitButton(false);
		_ui.SetActiveExit(false);
	}

	public void OnExitButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetActiveExit(true);
		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateExitBoardEnter
		(
			()=>
			{
				_ui.SetEnableExitButton(true);
			}
		);
	}

	public void OnExitYesButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableExitButton(false);

		_ui.AnimateExitYesButtonPressed
		(
			()=>
			{
				_ui.AnimateExitBoardExit
				(
					()=>
					{
						Application.Quit();
					}
				);
			}
		);
	}

	public void OnExitNoButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableExitButton(false);

		_ui.AnimateExitNoButtonPressed
		(
			()=>
			{
				_ui.AnimateExitBoardExit
				(
					()=>
					{
						_ui.SetActiveExit(false);
						_ui.SetEnableFrontButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("MainMenuUI").GetComponent<MainMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
	}

	private void Start()
	{
		SetupFront();
		SetupBottom();
		SetupExit();

		_audio.PlayFrontButtonEnter();

		_ui.SetEnableFrontButton(false);
		_ui.AnimateFrontEnter
		(
			()=>
			{
				_ui.SetEnableFrontButton(true);
			}
		);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnExitButtonPressed();
		}
	}
}
