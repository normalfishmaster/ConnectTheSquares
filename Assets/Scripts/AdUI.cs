using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdUI : MonoBehaviour
{
	// Success

	public float AD_SUCCESS_ANIMATE_BOARD_ENTER_DURATION;
	public float AD_SUCCESS_ANIMATE_BOARD_EXIT_DURATION;

	public float AD_SUCCESS_ANIMATE_HINT_ENTER_DURATION;

	public float AD_SUCCESS_ANIMATE_BUTTON_PRESSED_SCALE;
	public float AD_SUCCESS_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _adSuccess;
	private GameObject _adSuccessBoard;
	private GameObject _adSuccessHint;
	private GameObject _adSuccessFlare;

	private GameObject _adSuccessCloseButton;

	private void FindAdSuccessGameObject()
	{
		_adSuccess = GameObject.Find("/Canvas/AdSuccess");
		_adSuccessBoard = GameObject.Find("/Canvas/AdSuccess/Board");
		_adSuccessHint = GameObject.Find("/Canvas/AdSuccess/Board/Hint");
		_adSuccessFlare = GameObject.Find("/Canvas/AdSuccess/Board/Flare");

		_adSuccessCloseButton = GameObject.Find("/Canvas/AdSuccess/Board/Close/Button");
	}

	public void SetActiveAdSuccess(bool active)
	{
		_adSuccess.SetActive(active);
	}

	public void SetActiveAdSuccessHint(bool active)
	{
		_adSuccessHint.SetActive(active);
		_adSuccessFlare.SetActive(active);
	}

	public void SetEnableAdSuccessButton(bool enable)
	{
		_adSuccessCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateAdSuccessBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_adSuccess, _adSuccessBoard, AD_SUCCESS_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateAdSuccessBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_adSuccess, _adSuccessBoard, AD_SUCCESS_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateAdSuccessHintEnter(Animate.AnimateComplete callback)
	{
		// Animate Flare

		_adSuccessFlare.transform.localScale = Vector3.zero;

		LeanTween.scale(_adSuccessFlare, Vector3.one, AD_SUCCESS_ANIMATE_HINT_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		// Animate hint

		_adSuccessHint.transform.localScale = Vector3.one * 3.0f;

		LeanTween.scale(_adSuccessHint, Vector3.one, AD_SUCCESS_ANIMATE_HINT_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateAdSuccessCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_adSuccessCloseButton, AD_SUCCESS_ANIMATE_BUTTON_PRESSED_SCALE, AD_SUCCESS_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Abort

	public float AD_ABORT_ANIMATE_BOARD_ENTER_DURATION;
	public float AD_ABORT_ANIMATE_BOARD_EXIT_DURATION;

	public float AD_ABORT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float AD_ABORT_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _adAbort;
	private GameObject _adAbortBoard;

	private GameObject _adAbortCloseButton;

	private void FindAdAbortGameObject()
	{
		_adAbort = GameObject.Find("/Canvas/AdAbort");
		_adAbortBoard = GameObject.Find("/Canvas/AdAbort/Board");

		_adAbortCloseButton = GameObject.Find("/Canvas/AdAbort/Board/Close/Button");
	}

	public void SetActiveAdAbort(bool active)
	{
		_adAbort.SetActive(active);
	}

	public void SetEnableAdAbortButton(bool enable)
	{
		_adAbortCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateAdAbortBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_adAbort, _adAbortBoard, AD_ABORT_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateAdAbortBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_adAbort, _adAbortBoard, AD_ABORT_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateAdAbortCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_adAbortCloseButton, AD_ABORT_ANIMATE_BUTTON_PRESSED_SCALE, AD_ABORT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Fail

	public float AD_FAIL_ANIMATE_BOARD_ENTER_DURATION;
	public float AD_FAIL_ANIMATE_BOARD_EXIT_DURATION;

	public float AD_FAIL_ANIMATE_BUTTON_PRESSED_SCALE;
	public float AD_FAIL_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _adFail;
	private GameObject _adFailBoard;

	private GameObject _adFailCloseButton;

	private void FindAdFailGameObject()
	{
		_adFail = GameObject.Find("/Canvas/AdFail");
		_adFailBoard = GameObject.Find("/Canvas/AdFail/Board");

		_adFailCloseButton = GameObject.Find("/Canvas/AdFail/Board/Close/Button");
	}

	public void SetActiveAdFail(bool active)
	{
		_adFail.SetActive(active);
	}

	public void SetEnableAdFailButton(bool enable)
	{
		_adFailCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateAdFailBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_adFail, _adFailBoard, AD_FAIL_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateAdFailBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_adFail, _adFailBoard, AD_FAIL_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimateAdFailCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_adFailCloseButton, AD_FAIL_ANIMATE_BUTTON_PRESSED_SCALE, AD_FAIL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Unity Lifecycle

	private void Awake()
	{
		FindAdSuccessGameObject();
		FindAdAbortGameObject();
		FindAdFailGameObject();
	}
}
