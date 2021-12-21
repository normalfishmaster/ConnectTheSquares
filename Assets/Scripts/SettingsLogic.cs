using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsLogic : MonoBehaviour
{
	private SettingsUI _ui;
	private AudioManager _audio;
	private BlockManager _block;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private FrameRateManager _frameRate;

	// Estimated scroll duration
	private const float FRAME_RATE_CHANGE_DELAY = 1.0f;

	// UI - Background

	private void SetupBackground()
	{
		_ui.SetBackgroundColor(_cloudOnce.GetBackgroundColor());
	}

	// UI - Settings

	int _settingsBlockSetNumber;

	private void SetupSettings()
	{
		_settingsBlockSetNumber = _block.GetBlockSetNumber();

		if (_block.IsBlockSetUnlocked(_settingsBlockSetNumber))
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
		_frameRate.setHighFrameRate();

		_audio.PlayButtonPressed();

		_settingsBlockSetNumber = _block.DecrementSetNumber(_settingsBlockSetNumber);

		_ui.SetSettingsBlockBlockSprite(_settingsBlockSetNumber);

		if (_block.IsBlockSetUnlocked(_settingsBlockSetNumber))
		{
			_ui.SetActiveSettingsBlockLock(false);
			_block.SetBlockSetNumber(_settingsBlockSetNumber);
		}
		else
		{
			_ui.SetActiveSettingsBlockLock(true);
		}

		_ui.AnimateSettingsBlockPrevButtonPressed
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}
		);
	}

	public void OnSettingsBlockNextButtonPressed()
	{
		_frameRate.setHighFrameRate();

		_audio.PlayButtonPressed();

		_settingsBlockSetNumber = _block.IncrementSetNumber(_settingsBlockSetNumber);

		_ui.SetSettingsBlockBlockSprite(_settingsBlockSetNumber);

		if (_block.IsBlockSetUnlocked(_settingsBlockSetNumber))
		{
			_ui.SetActiveSettingsBlockLock(false);
			_block.SetBlockSetNumber(_settingsBlockSetNumber);
		}
		else
		{
			_ui.SetActiveSettingsBlockLock(true);
		}

		_ui.AnimateSettingsBlockNextButtonPressed
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}
		);
	}

	private void CommonSettingsAudioButtonPressed()
	{
		_frameRate.setHighFrameRate();

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

		_ui.AnimateSettingsAudioPrevButtonPressed
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}
		);
	}

	public void OnSettingsAudioNextButtonPressed()
	{
		CommonSettingsAudioButtonPressed();

		_ui.AnimateSettingsAudioNextButtonPressed
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}
		);
	}

	private void CommonSettingsNotificationsButtonPressed()
	{
		_frameRate.setHighFrameRate();

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

		_ui.AnimateSettingsNotificationsPrevButtonPressed
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}
		);
	}

	public void OnSettingsNotificationsNextButtonPressed()
	{
		_audio.PlayButtonPressed();

		CommonSettingsNotificationsButtonPressed();

		_ui.AnimateSettingsNotificationsNextButtonPressed
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}
		);
	}

	// UI - Bottom

	public void OnBottomBackButtonPressed()
	{
		_frameRate.setHighFrameRate();

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
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_frameRate = GameObject.Find("FrameRateManager").GetComponent<FrameRateManager>();
	}

	private void Start()
	{
		SetupBackground();
		SetupSettings();
		SetupBottom();

		_frameRate.setHighFrameRate();

		_ui.SetEnableSettingsButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateSettingsEnter
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);

				_ui.SetEnableSettingsButton(true);
				_ui.SetEnableBottomButton(true);
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
