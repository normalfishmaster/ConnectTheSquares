using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	private LevelLogic _logic;
	private LevelManager _level;

	public delegate void AnimateComplete();

	// Top

	private GameObject _topColorText;

	private GameObject _topAlphabetA;
	private GameObject _topAlphabetB;
	private GameObject _topAlphabetC;

	private GameObject _topMapText;

	private GameObject _topMoveCurrentText;
	private GameObject _topMoveTargetText;
	private GameObject _topMoveBestText;

	private GameObject[] _topStar;

	private void FindTopGameObject()
	{
		_topColorText = GameObject.Find("/Canvas/Top/Color/Label");

		_topAlphabetA = GameObject.Find("/Canvas/Top/Alphabet/A");
		_topAlphabetB = GameObject.Find("/Canvas/Top/Alphabet/B");
		_topAlphabetC = GameObject.Find("/Canvas/Top/Alphabet/C");

		_topMapText = GameObject.Find("/Canvas/Top/Map/Map");

		_topMoveCurrentText = GameObject.Find("/Canvas/Top/Move/Current");
		_topMoveTargetText = GameObject.Find("/Canvas/Top/Move/Target");
		_topMoveBestText = GameObject.Find("/Canvas/Top/Move/Best");

		_topStar = new GameObject[3];

		for (int i = 0; i < 3; i++)
		{
			_topStar[i] = GameObject.Find("/Canvas/Top/Star/Star" + i);
		}
	}

	public void SetTopColor(int color)
	{
		_topColorText.GetComponent<Text>().text = _level.GetColorString(color);
	}

	public void SetTopAlphabet(int alphabet)
	{
		string str = _level.GetAlphabetString(alphabet);

		_topAlphabetA.SetActive(false);
		_topAlphabetB.SetActive(false);
		_topAlphabetC.SetActive(false);

		if (str == "A")
		{
			_topAlphabetA.SetActive(true);
		}
		else if (str == "B")
		{
			_topAlphabetB.SetActive(true);
		}
		else if (str == "C")
		{
			_topAlphabetC.SetActive(true);
		}
	}

	public void SetTopMap(int map)
	{
		_topMapText.GetComponent<Text>().text = map.ToString();
	}

	public void SetTopMoveCurrent(int current)
	{
		_topMoveCurrentText.GetComponent<Text>().text = current.ToString();
	}

	public void SetTopMoveTarget(int target)
	{
		_topMoveTargetText.GetComponent<Text>().text = target.ToString();
	}

	public void SetTopMoveBest(int best)
	{
		_topMoveBestText.GetComponent<Text>().text = best.ToString();
	}

	public void SetActiveTopStar(int star, bool active)
	{
		_topStar[star].SetActive(active);
	}

	private void AnimateTopStarEnterSingle(int star, float duration)
	{
		LeanTween.cancel(_topStar[star]);

		// Scale

		_topStar[star].transform.localScale = Vector3.one * 2.0f;

		LeanTween.scale(_topStar[star], Vector3.one, duration).setEase(LeanTweenType.easeOutQuad);
	}

	// Hint

	private GameObject _hint;

	private GameObject _hintUp;
	private GameObject _hintDown;
	private GameObject _hintLeft;
	private GameObject _hintRight;

	private void FindHintGameObject()
	{
		_hint = GameObject.Find("/Canvas/Hint");
		_hintUp = GameObject.Find("/Canvas/Hint/Up");
		_hintDown = GameObject.Find("/Canvas/Hint/Down");
		_hintLeft = GameObject.Find("/Canvas/Hint/Left");
		_hintRight = GameObject.Find("/Canvas/Hint/Right");
	}

	public void SetActiveHint(bool active)
	{
		_hint.SetActive(active);
	}

	public void SetActiveHintDirection(char direction)
	{
		char directionUpper = char.ToUpper(direction);

		_hintUp.SetActive(false);
		_hintDown.SetActive(false);
		_hintLeft.SetActive(false);
		_hintRight.SetActive(false);

		if (directionUpper == 'U')
		{
			_hintUp.SetActive(true);
		}
		else if (directionUpper == 'D')
		{
			_hintDown.SetActive(true);
		}
		else if (directionUpper == 'L')
		{
			_hintLeft.SetActive(true);
		}
		else if (directionUpper == 'R')
		{
			_hintRight.SetActive(true);
		}
	}

	private void AnimateHintDirectionUpStop()
	{
		LeanTween.cancel(_hintUp);
	}

	private void AnimateHintDirectionDownStop()
	{
		LeanTween.cancel(_hintDown);
	}

	private void AnimateHintDirectionLeftStop()
	{
		LeanTween.cancel(_hintLeft);
	}

	private void AnimateHintDirectionRightStop()
	{
		LeanTween.cancel(_hintRight);
	}

	private void AnimateHintDirectionUpStart(float animateTime)
	{
		RectTransform rectTransform = (RectTransform)_hintUp.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float delta = ((((RectTransform)(_hint.transform)).rect.height / 2) - (rectTransform.rect.height / 2)) / 2;

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y - delta, pos.z);

		LeanTween.moveLocalY(_hintUp, pos.y + delta, animateTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				rectTransform.anchoredPosition = new Vector3(pos.x, pos.y, pos.z);
				AnimateHintDirectionUpStart(animateTime);
			}
		);
	}

	private void AnimateHintDirectionDownStart(float animateTime)
	{
		RectTransform rectTransform = (RectTransform)_hintDown.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float delta = ((((RectTransform)(_hint.transform)).rect.height / 2) - (rectTransform.rect.height / 2)) / 2;

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y + delta, pos.z);

		LeanTween.moveLocalY(_hintDown, pos.y - delta, animateTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				rectTransform.anchoredPosition = new Vector3(pos.x, pos.y, pos.z);
				AnimateHintDirectionDownStart(animateTime);
			}
		);
	}

	private void AnimateHintDirectionLeftStart(float animateTime)
	{
		RectTransform rectTransform = (RectTransform)_hintLeft.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float delta = ((((RectTransform)(_hint.transform)).rect.height / 2) - (rectTransform.rect.height / 2)) / 2;

		rectTransform.anchoredPosition = new Vector3(pos.x + delta, pos.y, pos.z);

		LeanTween.moveLocalX(_hintLeft, pos.x - delta, animateTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				rectTransform.anchoredPosition = new Vector3(pos.x, pos.y, pos.z);
				AnimateHintDirectionLeftStart(animateTime);
			}
		);
	}

	private void AnimateHintDirectionRightStart(float animateTime)
	{
		RectTransform rectTransform = (RectTransform)_hintRight.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float delta = ((((RectTransform)(_hint.transform)).rect.height / 2) - (rectTransform.rect.height / 2)) / 2;

		rectTransform.anchoredPosition = new Vector3(pos.x - delta, pos.y, pos.z);

		LeanTween.moveLocalX(_hintRight, pos.x + delta, animateTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				rectTransform.anchoredPosition = new Vector3(pos.x, pos.y, pos.z);
				AnimateHintDirectionRightStart(animateTime);
			}
		);
	}

	public void AnimateHintDirectionStop()
	{
		AnimateHintDirectionUpStop();
		AnimateHintDirectionDownStop();
		AnimateHintDirectionLeftStop();
		AnimateHintDirectionRightStop();
	}

	public void AnimateHintDirectionStart(char direction, float animateTime)
	{
		char directionUpper = char.ToUpper(direction);

		if (directionUpper == 'U')
		{
			AnimateHintDirectionUpStart(animateTime);
		}
		else if (directionUpper == 'D')
		{
			AnimateHintDirectionDownStart(animateTime);
		}
		else if (directionUpper == 'L')
		{
			AnimateHintDirectionLeftStart(animateTime);
		}
		else if (directionUpper == 'R')
		{
			AnimateHintDirectionRightStart(animateTime);
		}
	}

	// Control

	public float CONTROL_ANIMATE_BUTTON_PRESSED_SCALE;
	public float CONTROL_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _controlHintAdButton;
	private GameObject _controlHintOnButton;
	private GameObject _controlHintOffButton;
	private GameObject _controlPauseButton;
	private GameObject _controlUndoButton;
	private GameObject _controlResetButton;

	private GameObject _controlHintAd;
	private GameObject _controlHintOn;
	private GameObject _controlHintOff;

	private GameObject _controlHintOnText;
	private GameObject _controlHintOffText;

	private void FindControlGameObject()
	{
		_controlHintAdButton = GameObject.Find("/Canvas/ControlL/HintAd/Button");
		_controlHintOnButton = GameObject.Find("/Canvas/ControlL/HintOn/Button");
		_controlHintOffButton = GameObject.Find("/Canvas/ControlL/HintOff/Button");
		_controlPauseButton = GameObject.Find("/Canvas/ControlL/Pause/Button");
		_controlUndoButton = GameObject.Find("/Canvas/ControlR/Undo/Button");
		_controlResetButton = GameObject.Find("/Canvas/ControlR/Reset/Button");

		_controlHintAd = GameObject.Find("/Canvas/ControlL/HintAd");
		_controlHintOff = GameObject.Find("/Canvas/ControlL/HintOff");
		_controlHintOn = GameObject.Find("/Canvas/ControlL/HintOn");

		_controlHintOnText = GameObject.Find("/Canvas/ControlL/HintOn/Label");
		_controlHintOffText = GameObject.Find("/Canvas/ControlL/HintOff/Label");
	}

	public void SetEnableControlButton(bool enable)
	{
		_controlHintAdButton.GetComponent<Button>().enabled = enable;
		_controlHintOnButton.GetComponent<Button>().enabled = enable;
		_controlHintOffButton.GetComponent<Button>().enabled = enable;
		_controlPauseButton.GetComponent<Button>().enabled = enable;
		_controlUndoButton.GetComponent<Button>().enabled = enable;
		_controlResetButton.GetComponent<Button>().enabled = enable;
	}

	public void SetInteractableControlButton(bool interactable)
	{
		_controlHintAdButton.GetComponent<Button>().interactable = interactable;
		_controlHintOnButton.GetComponent<Button>().interactable = interactable;
		_controlHintOffButton.GetComponent<Button>().interactable = interactable;
		_controlPauseButton.GetComponent<Button>().interactable = interactable;
		_controlUndoButton.GetComponent<Button>().interactable = interactable;
		_controlResetButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetActiveControlHintAd(bool active)
	{
		_controlHintAd.SetActive(active);
	}

	public void SetActiveControlHintOn(bool active)
	{
		_controlHintOn.SetActive(active);
	}

	public void SetActiveControlHintOff(bool active)
	{
		_controlHintOff.SetActive(active);
	}

	public void SetControlHintCount(int hint)
	{
		string text = "Hint(" + hint + ")";
		_controlHintOnText.GetComponent<Text>().text = text;
		_controlHintOffText.GetComponent<Text>().text = text;
	}

	public void AnimateControlPauseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlPauseButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateControlUndoButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlUndoButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateControlResetButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlResetButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateControlHintAdButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlHintAdButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateControlHintOnButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlHintOnButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateControlHintOffButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_controlHintOffButton, CONTROL_ANIMATE_BUTTON_PRESSED_SCALE, CONTROL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnControlPauseButtonPressed()
	{
		_logic.DoControlPauseButtonPressed();
	}

	public void OnControlUndoButtonPressed()
	{
		_logic.DoControlUndoButtonPressed();
	}

	public void OnControlResetButtonPressed()
	{
		_logic.DoControlResetButtonPressed();
	}

	public void OnControlHintAdButtonPressed()
	{
		_logic.DoControlHintAdButtonPressed();
	}

	public void OnControlHintOnButtonPressed()
	{
		_logic.DoControlHintOnButtonPressed();
	}

	public void OnControlHintOffButtonPressed()
	{
		_logic.DoControlHintOffButtonPressed();
	}

	// Go

	public float GO_ANIMATE_BANNER_ENTER_DELAY;
	public float GO_ANIMATE_BANNER_ENTER_EXIT_DURATION;

	public float GO_ANIMATE_LABEL_ENTER_DELAY;
	public float GO_ANIMATE_LABEL_ENTER_EXIT_DURATION;
	public float GO_ANIMATE_LABEL_EXIT_DELAY;

	private GameObject _go;
	private GameObject _goBannerBlack;
	private GameObject _goBannerYellow;
	private GameObject _goLabel;

	private void FindGoGameObject()
	{
		_go = GameObject.Find("/Canvas/Go");
		_goBannerBlack = GameObject.Find("/Canvas/Go/BannerBlack");
		_goBannerYellow = GameObject.Find("/Canvas/Go/BannerYellow");
		_goLabel = GameObject.Find("/Canvas/Go/Label");
	}

	public void SetActiveGo(bool enable)
	{
		_go.SetActive(enable);
	}

	public void AnimateGoEnterAndExit(AnimateComplete callback)
	{
		RectTransform rectTransform;
		Vector3 pos;
		float width;

		// Animate Banner Black

		rectTransform = (RectTransform)_goBannerBlack.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x - width, pos.y, pos.z);

		LeanTween.cancel(_goBannerBlack);
		LeanTween.moveLocalX(_goBannerBlack, 0.0f, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY);
		LeanTween.moveLocalX(_goBannerBlack, pos.x + width, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY + GO_ANIMATE_BANNER_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_ENTER_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_EXIT_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION);

		// Animate Banner Yellow

		rectTransform = (RectTransform)_goBannerYellow.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x + width, pos.y, pos.z);

		LeanTween.cancel(_goBannerYellow);
		LeanTween.moveLocalX(_goBannerYellow, 0.0f, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY);
		LeanTween.moveLocalX(_goBannerYellow, pos.x - width, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY + GO_ANIMATE_BANNER_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_ENTER_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_EXIT_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION);

		// Animate Label

		rectTransform = (RectTransform)_goLabel.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x - width, pos.y, pos.z);

		LeanTween.cancel(_goLabel);
		LeanTween.moveLocalX(_goLabel, 0.0f, GO_ANIMATE_LABEL_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY + GO_ANIMATE_BANNER_ENTER_EXIT_DURATION + GO_ANIMATE_LABEL_ENTER_DELAY);
		LeanTween.moveLocalX(_goLabel, pos.x + width, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY + GO_ANIMATE_BANNER_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_ENTER_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_EXIT_DELAY)
				.setOnComplete(
					()=>
					{
						callback();
					}
				);
	}

	// Pause

	public float PAUSE_ANIMATE_BOARD_ENTER_DURATION;
	public float PAUSE_ANIMATE_BOARD_EXIT_DURATION;

	public float PAUSE_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PAUSE_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _pause;
	private GameObject _pauseBoard;

	private GameObject _pauseAudioOnButton;
	private GameObject _pauseAudioOffButton;
	private GameObject _pauseMenuButton;
	private GameObject _pauseHintAdButton;
	private GameObject _pauseResumeButton;

	public void FindPauseGameObject()
	{
		_pause = GameObject.Find("/Canvas/Pause");
		_pauseBoard = GameObject.Find("/Canvas/Pause/Board");

		_pauseAudioOnButton = GameObject.Find("/Canvas/Pause/Board/AudioOn/Button");
		_pauseAudioOffButton = GameObject.Find("/Canvas/Pause/Board/AudioOff/Button");
		_pauseMenuButton = GameObject.Find("/Canvas/Pause/Board/Menu/Button");
		_pauseHintAdButton = GameObject.Find("/Canvas/Pause/Board/HintAd/Button");
		_pauseResumeButton = GameObject.Find("/Canvas/Pause/Board/Resume/Button");
	}

	public void SetActivePause(bool active)
	{
		_pause.SetActive(active);
	}

	public void SetEnablePauseButton(bool enable)
	{
		_pauseAudioOnButton.GetComponent<Button>().enabled = enable;
		_pauseAudioOffButton.GetComponent<Button>().enabled = enable;
		_pauseMenuButton.GetComponent<Button>().enabled = enable;
		_pauseHintAdButton.GetComponent<Button>().enabled = enable;
		_pauseResumeButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimatePauseBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_pause, _pauseBoard, PAUSE_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimatePauseBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_pause, _pauseBoard, PAUSE_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimatePauseAudioOnButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseAudioOnButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimatePauseAudioOffButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseAudioOffButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimatePauseMenuButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseMenuButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimatePauseHintAdButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseHintAdButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimatePauseResumeButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseResumeButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnPauseMenuButtonPressed()
	{
		_logic.DoPauseMenuButtonPressed();
	}

	public void OnPauseHintAdButtonPressed()
	{
		_logic.DoPauseHintAdButtonPressed();
	}

	public void OnPauseResumeButtonPressed()
	{
		_logic.DoPauseResumeButtonPressed();
	}

	// Win

	public float WIN_ANIMATE_BOARD_ENTER_DURATION;
	public float WIN_ANIMATE_BOARD_EXIT_DURATION;

	public float WIN_ANIMATE_STAR_ENTER_DURATION;

	public float WIN_ANIMATE_BUTTON_PRESSED_SCALE;
	public float WIN_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _win;
	private GameObject _winBoard;
	private GameObject[] _winStar;
	private GameObject[] _winStarParticleSystem;

	private GameObject _winHintAdButton;
	private GameObject _winMenuButton;
	private GameObject _winReplayButton;
	private GameObject _winNextButton;

	int _winNumStar;

	public void FindWinGameObject()
	{
		_win = GameObject.Find("/Canvas/Win");
		_winBoard = GameObject.Find("/Canvas/Win/Board");
		_winStar = new GameObject[3];
		_winStarParticleSystem = new GameObject[3];

		for (int i = 0; i < 3; i++)
		{
			_winStar[i] = GameObject.Find("/Canvas/Win/Board/Star/Star" + i);
			_winStarParticleSystem[i] = GameObject.Find("/Canvas/Win/Board/Star/StarParticleSystem" + i);
		}

		_winHintAdButton = GameObject.Find("/Canvas/Win/Board/HintAd/Button");
		_winMenuButton = GameObject.Find("/Canvas/Win/Board/Menu/Button");
		_winReplayButton = GameObject.Find("/Canvas/Win/Board/Replay/Button");
		_winNextButton = GameObject.Find("/Canvas/Win/Board/Next/Button");
	}

	public void SetActiveWin(bool active)
	{
		_win.SetActive(active);
	}

	public void SetActiveWinStar(int star, bool active)
	{
		_winStar[star].SetActive(active);
	}

	public void SetEnableWinButton(bool enable)
	{
		_winHintAdButton.GetComponent<Button>().enabled = enable;
		_winMenuButton.GetComponent<Button>().enabled = enable;
		_winReplayButton.GetComponent<Button>().enabled = enable;
		_winNextButton.GetComponent<Button>().enabled = enable;
	}

	public void SetInteractableWinNextButton(bool interactable)
	{
		_winNextButton.GetComponent<Button>().interactable = interactable;
	}

	public void AnimateWinBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_win, _winBoard, WIN_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimateWinBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_win, _winBoard, WIN_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	private void AnimateWinStarEnterSingle(int star, Animate.AnimateComplete callback)
	{
		SetActiveWinStar(star, true);

		LeanTween.cancel(_winStar[star]);

		// X and Y

		float height = ((RectTransform)(_winBoard.transform)).rect.height * 0.25f;
		float width = ((RectTransform)(_winBoard.transform)).rect.width * 0.25f;

		if (star == 0)
		{
			width *= -1;
		}
		else if (star == 1)
		{
			width = 0;
		}

		Vector3 pos = ((RectTransform)_winStar[star].transform).anchoredPosition;
		((RectTransform)_winStar[star].transform).anchoredPosition = new Vector3(pos.x + width, pos.y + height, pos.z);

		LeanTween.moveLocalX(_winStar[star], pos.x, WIN_ANIMATE_STAR_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);
		LeanTween.moveLocalY(_winStar[star], pos.y, WIN_ANIMATE_STAR_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		// Scale

		_winStar[star].transform.localScale = Vector3.one * 5.0f;

		LeanTween.scale(_winStar[star], Vector3.one, WIN_ANIMATE_STAR_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				_winStarParticleSystem[star].GetComponent<ParticleSystem>().Play();
				callback();
			}
		);

		// Top Star

		if (!_topStar[star].activeSelf)
		{
			SetActiveTopStar(star, true);
			AnimateTopStarEnterSingle(star, WIN_ANIMATE_STAR_ENTER_DURATION);
		}
	}

	public void AnimateWinStarEnter(int star, Animate.AnimateComplete callback)
	{
		if (star == 1)
		{
			AnimateWinStarEnterSingle(0, callback);
		}
		else if (star == 2)
		{
			AnimateWinStarEnterSingle(0,
				()=>
				{
					AnimateWinStarEnterSingle(1, callback);
				}
			);
		}
		else if (star == 3)
		{
			AnimateWinStarEnterSingle(0,
				()=>
				{
					AnimateWinStarEnterSingle(1,
						()=>
						{
							AnimateWinStarEnterSingle(2, callback);
						}
					);
				}
			);
		}
	}

	public void AnimateWinHintAdButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_winHintAdButton, WIN_ANIMATE_BUTTON_PRESSED_SCALE, WIN_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateWinMenuButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_winMenuButton, WIN_ANIMATE_BUTTON_PRESSED_SCALE, WIN_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateWinReplayButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_winReplayButton, WIN_ANIMATE_BUTTON_PRESSED_SCALE, WIN_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateWinNextButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_winNextButton, WIN_ANIMATE_BUTTON_PRESSED_SCALE, WIN_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnWinHintAdButtonPressed()
	{
		_logic.DoWinHintAdButtonPressed();
	}

	public void OnWinMenuButtonPressed()
	{
		_logic.DoWinMenuButtonPressed();
	}

	public void OnWinReplayButtonPressed()
	{
		_logic.DoWinReplayButtonPressed();
	}

	public void OnWinNextButtonPressed()
	{
		_logic.DoWinNextButtonPressed();
	}

	// Load

	public float LOAD_ANIMATE_SQUARE_DURATION;
	public float LOAD_ANIMATE_SQUARE_DELAY;

	private GameObject _load;
	private GameObject[] _loadSquare;

	private void FindLoadGameObject()
	{
		_load = GameObject.Find("/Canvas/Load");

		_loadSquare = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			_loadSquare[i] = GameObject.Find("/Canvas/Load/Board/Square" + i);
		}
	}

	public void SetActiveLoad(bool active)
	{
		_load.SetActive(active);
	}

	private void AnimateLoadSquareStopSingle(int square)
	{
		LeanTween.cancel(_loadSquare[square]);
	}

	private void AnimateLoadSquareStartSingle(int square, AnimateComplete callback)
	{
		AnimateLoadSquareStopSingle(square);

		_loadSquare[square].transform.localScale = Vector3.one;

		LeanTween.scale(_loadSquare[square], Vector3.one * 1.5f, LOAD_ANIMATE_SQUARE_DURATION).setDelay(LOAD_ANIMATE_SQUARE_DELAY).setEasePunch().setOnComplete(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateLoadSquareStop()
	{
		for (int i = 0; i < 4; i++)
		{
			AnimateLoadSquareStopSingle(i);
		}
	}

	public void AnimateLoadSquareStart()
	{
		AnimateLoadSquareStartSingle(0,
			()=>
			{
				AnimateLoadSquareStartSingle(1,
					()=>
					{
						AnimateLoadSquareStartSingle(2,
							()=>
							{
								AnimateLoadSquareStartSingle(3,
									()=>
									{
										AnimateLoadSquareStart();
									}
								);
							}
						);
					}
				);
			}
		);
	}

	// Ad - Success

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

	public void OnAdSuccessCloseButtonPressed()
	{
		_logic.DoAdSuccessCloseButtonPressed();
	}

	// Ad - Abort

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

	public void OnAdAbortCloseButtonPressed()
	{
		_logic.DoAdAbortCloseButtonPressed();
	}

	// Ad - Fail

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

	public void OnAdFailCloseButtonPressed()
	{
		_logic.DoAdFailCloseButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindTopGameObject();
		FindHintGameObject();
		FindControlGameObject();
		FindGoGameObject();
		FindPauseGameObject();
		FindWinGameObject();
		FindLoadGameObject();
		FindAdSuccessGameObject();
		FindAdAbortGameObject();
		FindAdFailGameObject();
	}
}
