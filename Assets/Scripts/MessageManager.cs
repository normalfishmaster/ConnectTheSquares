using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoBehaviour
{
	// Hint

	public float HINT_ANIMATE_ENTER_DURATION;

	public float HINT_ANIMATE_SUNBURST_ENTER_DURATION;
	public float HINT_ANIMATE_SUNBURST_ROTATE_DURATION;

	public float HINT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float HINT_ANIMATE_BUTTON_PRESSED_DURATION;

	public float HINT_ANIMATE_EXIT_DURATION;

	private GameObject _hint;
	private GameObject _hintSunburstWide;
	private GameObject _hintSunburstNarrow;
	private GameObject _hintHint;
	private GameObject _hintCount;
	private GameObject _hintMessage;
	private GameObject _hintBack;
	private GameObject _hintBackButton;

	private void FindHintGameObject()
	{
		_hint = GameObject.Find("/Canvas/MessageHint");
		_hintSunburstWide = GameObject.Find("/Canvas/MessageHint/Board/SunburstWide");
		_hintSunburstNarrow = GameObject.Find("/Canvas/MessageHint/Board/SunburstNarrow");
		_hintHint = GameObject.Find("/Canvas/MessageHint/Board/Hint");
		_hintCount = GameObject.Find("/Canvas/MessageHint/Board/Count");
		_hintMessage = GameObject.Find("/Canvas/MessageHint/Board/Message");
		_hintBack = GameObject.Find("/Canvas/MessageHint/Board/Back");
		_hintBackButton = GameObject.Find("/Canvas/MessageHint/Board/Back/Button");
	}

	public void SetActiveHint(bool active)
	{
		_hint.SetActive(active);
	}

	public void SetEnableHintBackButton(bool enable)
	{
		_hintBackButton.GetComponent<Button>().enabled = enable;
	}

	public void SetHintCount(int count)
	{
		string str;

		if (count == 1)
		{
			str = "You get <color=#00BD96><b>" + count + "</b></color> Hint!";
		}
		else
		{
			str = "You get <color=#00BD96><b>" + count + "</b></color> Hints!";
		}

		_hintMessage.GetComponent<TextMeshProUGUI>().SetText(str);
		_hintCount.GetComponent<TextMeshProUGUI>().SetText("+" + count);
	}

	private void AnimateHintSunburstWideRotate()
	{
		LeanTween.rotateAround(_hintSunburstWide, Vector3.forward, -360.0f, HINT_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateHintSunburstWideRotate();
			}
		);
	}

	public void AnimateHintEnter(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		LeanTween.cancel(_hintSunburstWide);

		_hintSunburstWide.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintSunburstWide, Vector3.one, HINT_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		LeanTween.value(_hintSunburstWide, 0.0f, 1, HINT_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				_hintSunburstWide.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
			}
		);

		AnimateHintSunburstWideRotate();

		// Animate Sunburst Narrow

		LeanTween.cancel(_hintSunburstNarrow);

		_hintSunburstNarrow.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintSunburstNarrow, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Count

		LeanTween.cancel(_hintCount);

		_hintCount.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintCount, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Hint

		LeanTween.cancel(_hintHint);

		_hintHint.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintHint, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Message

		LeanTween.cancel(_hintMessage);

		_hintMessage.transform.localScale = Vector3.zero;
		_hintMessage.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_hintMessage, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_hintMessage, Vector3.forward, -20.0f, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Back

		LeanTween.cancel(_hintBack);

		_hintBack.transform.localScale = Vector3.zero;
		_hintBack.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_hintBack, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_hintBack, Vector3.forward, -20.0f, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateHintExit(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		_hintSunburstWide.transform.localScale = Vector3.one;
		LeanTween.scale(_hintSunburstWide, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Sunburst Narrow

		_hintSunburstNarrow.transform.localScale = Vector3.one;
		LeanTween.scale(_hintSunburstNarrow, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Count

		_hintCount.transform.localScale = Vector3.one;
		LeanTween.scale(_hintCount, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Hint

		_hintHint.transform.localScale = Vector3.one;
		LeanTween.scale(_hintHint, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Message

		_hintMessage.transform.localScale = Vector3.one;
		LeanTween.scale(_hintMessage, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Back

		_hintBack.transform.localScale = Vector3.one;
		LeanTween.scale(_hintBack, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateHintBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_hintBackButton, HINT_ANIMATE_BUTTON_PRESSED_SCALE, HINT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Unity Lifecycle

	void Awake()
	{
		FindHintGameObject();
	}

}
