using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
	private MainMenuUI _ui;
	private DataManager _data;
	private AdManager _ad;

	// UI Events - Front

	public void DoFrontContinueButtonPressed()
	{
	}

	public void DoFrontLevelsButtonPressed()
	{
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
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
	}

	private void Start()
	{
		_ui.SetActiveExitPanel(false);
		_ui.SetEnableFrontButtons(true);
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
