using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsLogic : MonoBehaviour
{
	private SettingsUI _ui;
	private AudioManager _audio;
	private BlockManager _block;
	private DataManager _data;

	// UI - Settings

	int _settingsBlockSetNumber;

	private void SetupSettings()
	{
		_settingsBlockSetNumber = _block.GetBlockSetNumber();

		if (_block.IsBlockSetUnlocked(_settingsBlockSetNumber) == 1)
		{
			_ui.SetActiveSettingsBlockLock(false);
		}
		else
		{
			_ui.SetActiveSettingsBlockLock(true);
		}

		if (_data.GetAudio() == 1)
		{
			_ui.SetActiveSettingsAudioOn(true);
			_ui.SetActiveSettingsAudioOff(false);
		}
		else
		{
			_ui.SetActiveSettingsAudioOn(false);
			_ui.SetActiveSettingsAudioOff(true);
		}

		if (_data.GetNotification() == 1)
		{
			_ui.SetActiveSettingsNotificationsOn(true);
			_ui.SetActiveSettingsNotificationsOff(false);
		}
		else
		{
			_ui.SetActiveSettingsNotificationsOn(false);
			_ui.SetActiveSettingsNotificationsOff(true);
		}
	}

	public void OnSettingsBlockPrevButtonPressed()
	{
		_audio.PlayButtonPressed();

		_settingsBlockSetNumber = _block.DecrementSetNumber(_settingsBlockSetNumber);

		_ui.SetSettingsBlockBlockSprite(_settingsBlockSetNumber);

		if (_block.IsBlockSetUnlocked(_settingsBlockSetNumber) == 1)
		{
			_ui.SetActiveSettingsBlockLock(false);
			_block.SetBlockSetNumber(_settingsBlockSetNumber);
		}
		else
		{
			_ui.SetActiveSettingsBlockLock(true);
		}

		_ui.AnimateSettingsBlockPrevButtonPressed(()=>{});
	}

	public void OnSettingsBlockNextButtonPressed()
	{
		_audio.PlayButtonPressed();

		_settingsBlockSetNumber = _block.IncrementSetNumber(_settingsBlockSetNumber);

		_ui.SetSettingsBlockBlockSprite(_settingsBlockSetNumber);

		if (_block.IsBlockSetUnlocked(_settingsBlockSetNumber) == 1)
		{
			_ui.SetActiveSettingsBlockLock(false);
			_block.SetBlockSetNumber(_settingsBlockSetNumber);
		}
		else
		{
			_ui.SetActiveSettingsBlockLock(true);
		}

		_ui.AnimateSettingsBlockNextButtonPressed(()=>{});
	}

	private void CommonSettingsAudioButtonPressed()
	{
		if (_data.GetAudio() == 1)
		{
			_data.SetAudio(0);
			_audio.SetEnable(false);
			_ui.SetActiveSettingsAudioOn(false);
			_ui.SetActiveSettingsAudioOff(true);
		}
		else
		{
			_data.SetAudio(1);
			_audio.SetEnable(true);
			_audio.PlayButtonPressed();

			_ui.SetActiveSettingsAudioOn(true);
			_ui.SetActiveSettingsAudioOff(false);
		}
	}

	public void OnSettingsAudioPrevButtonPressed()
	{
		CommonSettingsAudioButtonPressed();

		_ui.AnimateSettingsAudioPrevButtonPressed(()=>{});
	}

	public void OnSettingsAudioNextButtonPressed()
	{
		CommonSettingsAudioButtonPressed();

		_ui.AnimateSettingsAudioNextButtonPressed(()=>{});
	}

	private void CommonSettingsNotificationsButtonPressed()
	{
		if (_data.GetNotification() == 1)
		{
			_data.SetNotification(0);
			_ui.SetActiveSettingsNotificationsOn(false);
			_ui.SetActiveSettingsNotificationsOff(true);
		}
		else
		{
			_data.SetNotification(1);
			_ui.SetActiveSettingsNotificationsOn(true);
			_ui.SetActiveSettingsNotificationsOff(false);
		}
	}

	public void OnSettingsNotificationsPrevButtonPressed()
	{
		_audio.PlayButtonPressed();

		CommonSettingsNotificationsButtonPressed();

		_ui.AnimateSettingsNotificationsPrevButtonPressed(()=>{});
	}

	public void OnSettingsNotificationsNextButtonPressed()
	{
		_audio.PlayButtonPressed();

		CommonSettingsNotificationsButtonPressed();

		_ui.AnimateSettingsNotificationsNextButtonPressed(()=>{});
	}

	// UI - Bottom

	public void OnBottomBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableBottomButton(false);

		_ui.AnimateBottomBackButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("MainMenuScene");
			}
		);
	}

	private void SetupBottom()
	{
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("SettingsUI").GetComponent<SettingsUI>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
	}

	private void Start()
	{
		SetupSettings();
		SetupBottom();

		_ui.SetEnableSettingsButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateSettingsEnter
		(
			()=>
			{
				_ui.SetEnableSettingsButton(true);
				_ui.SetEnableBottomButton(true);
			}
		);
	}
}
