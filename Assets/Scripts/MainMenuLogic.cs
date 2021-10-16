using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
				_ui.SetActiveCloudOnce(true);
				_ui.SetEnableCloudOnceButton(false);

				if (_cloudOnce.IsSignedIn())
				{
					_ui.SetActiveCloudOnceSignInButton(false);
					_ui.SetActiveCloudOnceSignOutButton(true);
					_ui.SetInteractableCloudOnceSignInButton(true);
					_ui.SetInteractableCloudOnceFunctionalButton(true);
				}
				else
				{
					_ui.SetActiveCloudOnceSignInButton(true);
					_ui.SetActiveCloudOnceSignOutButton(false);
					_ui.SetInteractableCloudOnceSignInButton(true);
					_ui.SetInteractableCloudOnceFunctionalButton(false);
				}

				_ui.AnimateCloudOnceBoardEnter
				(
					()=>
					{
						_ui.SetEnableCloudOnceButton(true);
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

	// UI - CloudOnce

	private void SetupCloudOnce()
	{
		_ui.SetEnableCloudOnceButton(false);
		_ui.SetActiveCloudOnce(false);
		_ui.SetInteractableCloudOnceFunctionalButton(false);
	}

	private void OnCloudOnceSignedIn()
	{
		_ui.SetActiveCloudOnceSignInButton(false);
		_ui.SetActiveCloudOnceSignOutButton(true);
		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	private void OnCloudOnceSignedOut()
	{
		_ui.SetActiveCloudOnceSignInButton(true);
		_ui.SetActiveCloudOnceSignOutButton(false);
		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(false);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	private void OnCloudOnceSignedInChanged(bool isSignedIn)
	{
		_cloudOnce.UnsubscribeSignedInChanged(OnCloudOnceSignedInChanged);
		_cloudOnce.UnsubscribeSignInFailed(OnCloudOnceSignInFailed);

		if (isSignedIn)
		{
			OnCloudOnceSignedIn();
		}
		else
		{
			OnCloudOnceSignedOut();
		}
	}

	private void OnCloudOnceSignInFailed()
	{
		_cloudOnce.UnsubscribeSignedInChanged(OnCloudOnceSignedInChanged);
		_cloudOnce.UnsubscribeSignInFailed(OnCloudOnceSignInFailed);

		OnCloudOnceSignedOut();
	}

	private void OnCloudSaveComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudSaveComplete(OnCloudSaveComplete);

		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	private void OnCloudLoadComplete(bool success)
	{
		_cloudOnce.UnsubscribeCloudLoadComplete(OnCloudLoadComplete);

		if (success)
		{
			_cloudOnce.LoadCloudToData();
		}

		_ui.SetInteractableCloudOnceSignInButton(true);
		_ui.SetInteractableCloudOnceFunctionalButton(true);
		_ui.SetInteractableCloudOnceCloseButton(true);
	}

	public void OnCloudOnceSignInButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			OnCloudOnceSignedIn();
		}
		else
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);

			_cloudOnce.SubscribeSignedInChanged(OnCloudOnceSignedInChanged);
			_cloudOnce.SubscribeSignInFailed(OnCloudOnceSignInFailed);

			_cloudOnce.SignIn();
		}

		_ui.AnimateCloudOnceSignInButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceSignOutButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);

			_cloudOnce.SubscribeSignedInChanged(OnCloudOnceSignedInChanged);

			_cloudOnce.SignOut();
		}
		else
		{
			OnCloudOnceSignedOut();
		}

		_ui.AnimateCloudOnceSignOutButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceSaveButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);

			_cloudOnce.SubscribeCloudSaveComplete(OnCloudSaveComplete);
			_cloudOnce.SaveDataToCloud();
			_cloudOnce.Save();
		}
		else
		{
			OnCloudOnceSignedOut();
		}

		_ui.AnimateCloudOnceSaveButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceLoadButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_cloudOnce.IsSignedIn())
		{
			_ui.SetInteractableCloudOnceSignInButton(false);
			_ui.SetInteractableCloudOnceFunctionalButton(false);
			_ui.SetInteractableCloudOnceCloseButton(false);

			_cloudOnce.SubscribeCloudLoadComplete(OnCloudLoadComplete);
			_cloudOnce.Load();
		}
		else
		{
			OnCloudOnceSignedOut();
		}

		_ui.AnimateCloudOnceLoadButtonPressed
		(
			()=>
			{
			}
		);
	}

	public void OnCloudOnceAchievementsButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateCloudOnceAchivementsButtonPressed
		(
			()=>
			{
				if (_cloudOnce.IsSignedIn())
				{
					_cloudOnce.ShowAchievements();
				}
				else
				{
					OnCloudOnceSignedOut();
				}
			}
		);
	}

	public void OnCloudOnceLeaderboardButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateCloudOnceLeaderboardButtonPressed
		(
			()=>
			{
				if (_cloudOnce.IsSignedIn())
				{
					int totalStars = 0;

					for (int i = 0; i < _level.GetNumColor(); i++)
					{
						totalStars += _data.GetColorStar(i);
					}

					_cloudOnce.SubmitLeaderboardHighScore(totalStars);
					_cloudOnce.ShowLeaderboard();
				}
				else
				{
					OnCloudOnceSignedOut();
				}
			}
		);
	}

	public void OnCloudOnceCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableCloudOnceButton(false);

		_ui.AnimateCloudOnceCloseButtonPressed
		(
			()=>
			{
				_ui.AnimateCloudOnceBoardExit
				(
					()=>
					{
						_canExit = true;

						_ui.SetActiveCloudOnce(false);

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
		SetupCloudOnce();
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
