using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
	private MainMenuUI _ui;
	private AdManager _ad;
	private AudioManager _audio;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private LevelManager _level;

	private bool _canExit;

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

		_canExit = false;

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

		_canExit = false;

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

		_canExit = false;

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

		_ui.SetEnableBottomButton(false);
	}

	public void OnBottomGooglePlayButtonPressed()
	{
		_audio.PlayButtonPressed();

		_canExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateBottomGooglePlayButtonPressed
		(
			()=>
			{
				_ui.SetActiveGooglePlay(true);
				_ui.SetEnableGooglePlayButton(false);

				if (_cloudOnce.IsSignedIn())
				{
					_ui.SetActiveGooglePlaySignInButton(false);
					_ui.SetActiveGooglePlaySignOutButton(true);
					_ui.SetInteractableGooglePlayFunctionalButtons(true);
				}
				else
				{
					_ui.SetActiveGooglePlaySignInButton(true);
					_ui.SetActiveGooglePlaySignOutButton(false);
					_ui.SetInteractableGooglePlayFunctionalButtons(false);				}


				_ui.AnimateGooglePlayBoardEnter
				(
					()=>
					{
						_ui.SetEnableGooglePlayButton(true);
					}
				);
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

	// CloudOnce

	private void OnCloudOnceSignInComplete()
	{
		if (Application.platform != RuntimePlatform.IPhonePlayer)
		{
			OnGooglePlaySignInComplete();
		}
	}

	private void OnCloudOnceSignOutComplete()
	{
		if (Application.platform != RuntimePlatform.IPhonePlayer)
		{
			OnGooglePlaySignOutComplete();
		}
	}

	// UI - GooglePlay

	private void SetupGooglePlay()
	{
		_ui.SetEnableGooglePlayButton(false);
		_ui.SetActiveGooglePlay(false);
		_ui.SetInteractableGooglePlayFunctionalButtons(false);

		_cloudOnce.SubscribeSignInComplete(OnCloudOnceSignInComplete);
		_cloudOnce.SubscribeSignOutComplete(OnCloudOnceSignOutComplete);
	}

	private void OnGooglePlaySignInComplete()
	{
		_ui.SetActiveGooglePlaySignInButton(false);
		_ui.SetActiveGooglePlaySignOutButton(true);
		_ui.SetInteractableGooglePlayFunctionalButtons(true);
	}

	private void OnGooglePlaySignOutComplete()
	{
		_ui.SetActiveGooglePlaySignInButton(true);
		_ui.SetActiveGooglePlaySignOutButton(false);
		_ui.SetInteractableGooglePlayFunctionalButtons(false);
	}

	public void OnGooglePlaySignInButtonPressed()
	{
		_audio.PlayButtonPressed();

//		_ui.SetEnableGooglePlayButton(false);

		_ui.AnimateGooglePlaySignInButtonPressed
		(
			()=>
			{
				_cloudOnce.SignIn();
			}
		);
	}

	public void OnGooglePlaySignOutButtonPressed()
	{
		_audio.PlayButtonPressed();

//		_ui.SetEnableGooglePlayButton(false);

		_ui.AnimateGooglePlaySignOutButtonPressed
		(
			()=>
			{
				_cloudOnce.SignOut();
			}
		);
	}

	public void OnGooglePlayLoadButtonPressed()
	{
		_audio.PlayButtonPressed();

//		_ui.SetEnableGooglePlayButton(false);

		_ui.AnimateGooglePlayLoadButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnGooglePlaySaveButtonPressed()
	{
		_audio.PlayButtonPressed();

//		_ui.SetEnableGooglePlayButton(false);

		_ui.AnimateGooglePlaySaveButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnGooglePlayAchievementsButtonPressed()
	{
		_audio.PlayButtonPressed();

//		_ui.SetEnableGooglePlayButton(false);

		_ui.AnimateGooglePlayAchivementsButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnGooglePlayLeaderboardButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateGooglePlayLeaderboardButtonPressed
		(
			()=>
			{
				int totalStars = 0;

				for (int i = 0; i < _level.GetNumColor(); i++)
				{
					totalStars += _data.GetColorStar(i);
				}

				_cloudOnce.SubmitLeaderboardHighScore(totalStars);

				_cloudOnce.ShowLeaderboard();
			}
		);
	}

	public void OnGooglePlayCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableGooglePlayButton(false);

		_ui.AnimateGooglePlayCloseButtonPressed
		(
			()=>
			{
				_ui.AnimateGooglePlayBoardExit
				(
					()=>
					{
						_canExit = true;

						_ui.SetActiveGooglePlay(false);

						_ui.SetEnableFrontButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
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
		if (_canExit == false)
		{
			return;
		}

		_canExit = false;

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
						_canExit = true;

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
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		_canExit = false;
	}

	private void Start()
	{
		SetupFront();
		SetupBottom();
		if (Application.platform != RuntimePlatform.IPhonePlayer)
		{
			SetupGooglePlay();
		}
		SetupExit();

		_audio.PlayFrontButtonEnter();

		_canExit = false;

		_ui.SetEnableFrontButton(false);
		_ui.SetEnableBottomButton(false);
		_ui.AnimateFrontEnter
		(
			()=>
			{
				_canExit = true;
				_ui.SetEnableFrontButton(true);
				_ui.SetEnableBottomButton(true);
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
