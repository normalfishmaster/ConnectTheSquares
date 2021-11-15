using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreviewUI : MonoBehaviour
{
	private PreviewLogic _logic;
	private LevelManager _level;
	private AudioManager _audio;
	private BlockManager _block;

	// Control

	public float CONTROL_ANIMATE_BUTTON_PRESSED_SCALE;
	public float CONTROL_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _controlBackButton;
	private GameObject _controlBlockButton;

	private void FindControlGameObject()
	{
		_controlBackButton = GameObject.Find("/Canvas/ControlL/Back/Button");
		_controlBlockButton = GameObject.Find("/Canvas/ControlR/Block/Button");
	}

	public void SetEnableControlButton(bool enable)
	{
		_controlBackButton.GetComponent<Button>().enabled = enable;
		_controlBlockButton.GetComponent<Button>().enabled = enable;
	}

	public void SetInteractableControlButton(bool interactable)
	{
		_controlBackButton.GetComponent<Button>().interactable = interactable;
		_controlBlockButton.GetComponent<Button>().interactable = interactable;
	}

	public void AnimateControlBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlBackButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateControlBlockButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlBlockButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Blinder

	public float BLINDER_ANIMATE_DURATION;

	private GameObject _blinder;

	private void FindBlinderGameObject()
	{
		_blinder = GameObject.Find("/Canvas/Blinder");
	}

	public void SetActiveBlinder(bool active)
	{
		_blinder.SetActive(active);
	}

	public void AnimateBlinderLighten(Animate.AnimateComplete callback)
	{
		_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);

		LeanTween.cancel(_blinder);

		LeanTween.value(_blinder, 1f, 0f, BLINDER_ANIMATE_DURATION).setEase(LeanTweenType.easeInSine).setOnUpdate
		(
			(float val) =>
			{
				_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, val);
			}
		)
				.setOnComplete
				(
					()=>
					{
						callback();
					}
				);
	}

	public void AnimateBlinderDarken(Animate.AnimateComplete callback)
	{
		_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);

		LeanTween.cancel(_blinder);

		LeanTween.value(_blinder, 0f, 1f, BLINDER_ANIMATE_DURATION).setEase(LeanTweenType.easeInSine).setOnUpdate
		(
			(float val) =>
			{
				_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, val);
			}
		)
				.setOnComplete
				(
					()=>
					{
						callback();
					}
				);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("PreviewLogic").GetComponent<PreviewLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();

		FindControlGameObject();
		FindBlinderGameObject();
	}
}
