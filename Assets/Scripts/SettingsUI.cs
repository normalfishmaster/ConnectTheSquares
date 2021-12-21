using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
	private SettingsLogic _logic;
	private BlockManager _block;
	private LevelManager _level;

        // Background

	private GameObject _background;

	private void FindBackgroundGameObject()
	{
		_background = GameObject.Find("/Background/Color");
	}

	public void SetBackgroundColor(int color)
	{
		_background.GetComponent<Image>().color = _level.GetBackgroundColor(color);
	}

	// Settings

	public float SETTINGS_ANIMATE_ENTER_DURATION;

	public float SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE;
	public float SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION;

	GameObject _settings;

	GameObject[] _settingsBlockBlock;
	GameObject _settingsBlockLock;
	GameObject _settingsBlockPrevButton;
	GameObject _settingsBlockNextButton;

	GameObject _settingsAudioOn;
	GameObject _settingsAudioOff;
	GameObject _settingsAudioPrevButton;
	GameObject _settingsAudioNextButton;

	GameObject _settingsNotificationsOn;
	GameObject _settingsNotificationsOff;
	GameObject _settingsNotificationsPrevButton;
	GameObject _settingsNotificationsNextButton;

	private void FindSettingsGameObject()
	{
		_settings = GameObject.Find("/Canvas/Settings");

		_settingsBlockBlock = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			_settingsBlockBlock[i] = GameObject.Find("/Canvas/Settings/Viewport/Content/Block/Panel/Block" + i);
		}

		_settingsBlockLock = GameObject.Find("/Canvas/Settings/Viewport/Content/Block/Panel/Lock");

		_settingsBlockPrevButton = GameObject.Find("/Canvas/Settings/Viewport/Content/Block/Panel/Prev");
		_settingsBlockNextButton = GameObject.Find("/Canvas/Settings/Viewport/Content/Block/Panel/Next");

		_settingsAudioOn = GameObject.Find("/Canvas/Settings/Viewport/Content/Audio/Panel/On");
		_settingsAudioOff = GameObject.Find("/Canvas/Settings/Viewport/Content/Audio/Panel/Off");
		_settingsAudioPrevButton = GameObject.Find("/Canvas/Settings/Viewport/Content/Audio/Panel/Prev");
		_settingsAudioNextButton = GameObject.Find("/Canvas/Settings/Viewport/Content/Audio/Panel/Next");

		_settingsNotificationsOn = GameObject.Find("/Canvas/Settings/Viewport/Content/Notifications/Panel/On");
		_settingsNotificationsOff = GameObject.Find("/Canvas/Settings/Viewport/Content/Notifications/Panel/Off");
		_settingsNotificationsPrevButton = GameObject.Find("/Canvas/Settings/Viewport/Content/Notifications/Panel/Prev");
		_settingsNotificationsNextButton = GameObject.Find("/Canvas/Settings/Viewport/Content/Notifications/Panel/Next");
	}

	public void SetEnableSettingsButton(bool enable)
	{
		_settingsBlockPrevButton.GetComponent<Button>().enabled = enable;
		_settingsBlockNextButton.GetComponent<Button>().enabled = enable;
		_settingsAudioPrevButton.GetComponent<Button>().enabled = enable;
		_settingsAudioNextButton.GetComponent<Button>().enabled = enable;
		_settingsNotificationsPrevButton.GetComponent<Button>().enabled = enable;
		_settingsNotificationsNextButton.GetComponent<Button>().enabled = enable;
	}

	public void SetSettingsBlockBlockSprite(int setNumber)
	{
		for (int i = 0; i < 4; i++)
		{
			_settingsBlockBlock[i].GetComponent<Image>().sprite = _block.GetBlockSprite(setNumber, i);
		}
	}

	public void SetActiveSettingsBlockLock(bool active)
	{
		_settingsBlockLock.SetActive(active);
	}

	public void SetActiveSettingsAudioOn(bool active)
	{
		_settingsAudioOn.SetActive(active);
	}

	public void SetActiveSettingsAudioOff(bool active)
	{
		_settingsAudioOff.SetActive(active);
	}

	public void SetActiveSettingsNotificationsOn(bool active)
	{
		_settingsNotificationsOn.SetActive(active);
	}

	public void SetActiveSettingsNotificationsOff(bool active)
	{
		_settingsNotificationsOff.SetActive(active);
	}

	public void AnimateSettingsEnter(Animate.AnimateComplete callback)
	{
		RectTransform rectTransform = (RectTransform)_settings.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float height = rectTransform.rect.height;

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y - height, pos.z);

		LeanTween.cancel(_settings);
		LeanTween.moveLocalY(_settings, 0.0f, SETTINGS_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateSettingsBlockPrevButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsBlockPrevButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsBlockNextButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsBlockNextButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsAudioPrevButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsAudioPrevButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsAudioNextButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsAudioNextButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsNotificationsPrevButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsNotificationsPrevButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateSettingsNotificationsNextButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_settingsNotificationsNextButton, SETTINGS_ANIMATE_BUTTON_PRESSED_SCALE, SETTINGS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomRestoreButton;
	private GameObject _bottomBackButton;

	private void FindBottomGameObject()
	{
		_bottomBackButton = GameObject.Find("/Canvas/Bottom/Back/Button");
	}

	public void SetActiveBottomRestoreButton(bool active)
	{
		_bottomRestoreButton.SetActive(active);
	}

	public void SetEnableBottomButton(bool enable)
	{
		_bottomBackButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateBottomBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomBackButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

        // Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("SettingsLogic").GetComponent<SettingsLogic>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindBackgroundGameObject();
		FindSettingsGameObject();
		FindBottomGameObject();
	}

}
