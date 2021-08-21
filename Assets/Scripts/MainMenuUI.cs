using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	private MainMenuLogic _logic;
	private LevelManager _level;

	// Front

	private Button _frontContinueButton;
	private Button _frontLevelsButton;
	private Button _frontSettingsButton;
	private Button _frontStoreButton;
	private Button _frontDailyRewardsButton;

	private Text _frontContinueLabelText;
	private Text _frontContinueLevelText;

	private Button _frontLeaderboardButton;
	private Button _frontNoAdsButton;
	private Button _frontLanguageButton;

	private void FindFrontGameObjects()
	{
		_frontContinueButton = GameObject.Find("/Canvas/Front/Continue").GetComponent<Button>();
		_frontLevelsButton = GameObject.Find("/Canvas/Front/Levels").GetComponent<Button>();
		_frontSettingsButton = GameObject.Find("/Canvas/Front/Settings").GetComponent<Button>();
		_frontStoreButton = GameObject.Find("/Canvas/Front/Store").GetComponent<Button>();

		_frontContinueLabelText = GameObject.Find("/Canvas/Front/Continue/Label").GetComponent<Text>();
		_frontContinueLevelText = GameObject.Find("/Canvas/Front/Continue/Level").GetComponent<Text>();

		_frontDailyRewardsButton = GameObject.Find("/Canvas/DailyRewards").GetComponent<Button>();

		_frontLeaderboardButton = GameObject.Find("/Canvas/Bottom/Leaderboard").GetComponent<Button>();
		_frontNoAdsButton = GameObject.Find("/Canvas/Bottom/NoAds").GetComponent<Button>();
		_frontLanguageButton = GameObject.Find("/Canvas/Bottom/Language").GetComponent<Button>();
	}

	public void SetEnableFrontButtons(bool enable)
	{
		_frontContinueButton.enabled = enable;
		_frontLevelsButton.enabled = enable;
		_frontSettingsButton.enabled = enable;
		_frontStoreButton.enabled = enable;
		_frontLeaderboardButton.enabled = enable;
		_frontNoAdsButton.enabled = enable;
		_frontDailyRewardsButton.enabled = enable;
	}

	public void SetFrontContinueLabel(string text)
	{
		_frontContinueLabelText.text = text;
	}

	public void SetFrontContinueLevel(int color, int alphabet, int map)
	{
		string str = _level.GetColorString(color) + " - " + _level.GetAlphabetString(alphabet) + " - " + _level.GetMapString(map);
		_frontContinueLevelText.text = str;
	}

	public void OnFrontContinueButtonPressed()
	{
		_logic.DoFrontContinueButtonPressed();
	}

	public void OnFrontLevelsButtonPressed()
	{
		_logic.DoFrontLevelsButtonPressed();
	}

	public void OnFrontSettingsButtonPressed()
	{
		_logic.DoFrontSettingsButtonPressed();
	}

	public void OnFrontStoreButtonPressed()
	{
		_logic.DoFrontStoreButtonPressed();
	}

	public void OnFrontLeaderboardButtonPressed()
	{
		_logic.DoFrontLeaderboardButtonPressed();
	}

	public void OnFrontNoAdsButtonPressed()
	{
		_logic.DoFrontNoAdsButtonPressed();
	}

	public void OnFrontLanguageButtonPressed()
	{
		_logic.DoFrontLanguageButtonPressed();
	}

	public void OnFrontDailyRewardsButtonPressed()
	{
		_logic.DoFrontDailyRewardsButtonPressed();
	}

	// Exit

	private GameObject _exitPanel;

	private void FindExitGameObjects()
	{
		_exitPanel = GameObject.Find("/Canvas/Exit");
	}

	public void SetActiveExitPanel(bool active)
	{
		_exitPanel.SetActive(active);
	}

	public void OnExitYesButtonPressed()
	{
		_logic.DoExitYesButtonPressed();
	}

	public void OnExitNoButtonPressed()
	{
		_logic.DoExitNoButtonPressed();
	}

        // Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("MainMenuLogic").GetComponent<MainMenuLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindFrontGameObjects();
		FindExitGameObjects();
        }
}
