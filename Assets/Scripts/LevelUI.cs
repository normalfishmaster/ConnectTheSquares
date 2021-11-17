using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
	private LevelLogic _logic;
	private LevelManager _level;
	private AudioManager _audio;
	private BlockManager _block;

	// Top

	public Sprite[] _topColorSprite;

	private GameObject _topColor;
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
		_topColor = GameObject.Find("/Canvas/Top/Color");
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
		_topColor.GetComponent<Image>().sprite = _topColorSprite[color];
		_topColorText.GetComponent<TextMeshProUGUI>().SetText(_level.GetColorString(color));
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

	// Go

	public float GO_ANIMATE_BANNER_ENTER_DELAY;
	public float GO_ANIMATE_BANNER_ENTER_EXIT_DURATION;

	public float GO_ANIMATE_LABEL_ENTER_DELAY;
	public float GO_ANIMATE_LABEL_ENTER_EXIT_DURATION;
	public float GO_ANIMATE_LABEL_EXIT_DELAY;

	private GameObject _go;
	private GameObject _goBannerBack;
	private GameObject _goBannerFront;
	private GameObject _goLabel;

	private void FindGoGameObject()
	{
		_go = GameObject.Find("/Canvas/Go");
		_goBannerBack = GameObject.Find("/Canvas/Go/BannerBack");
		_goBannerFront = GameObject.Find("/Canvas/Go/BannerFront");
		_goLabel = GameObject.Find("/Canvas/Go/Label");
	}

	public void SetActiveGo(bool enable)
	{
		_go.SetActive(enable);
	}

	public void SetGoColor(int color)
	{
		if (color == 0)
		{
			_goBannerFront.GetComponent<Image>().color = new Color32(229, 159, 66, 255);
		}
		else if (color == 1)
		{
			_goBannerFront.GetComponent<Image>().color = new Color32(0, 194, 162, 255);
		}
		else if (color == 2)
		{
			_goBannerFront.GetComponent<Image>().color = new Color32(107, 126, 203, 255);
		}
		else if (color == 3)
		{
			_goBannerFront.GetComponent<Image>().color = new Color32(198, 69, 138, 255);
		}
		else if (color == 4)
		{
			_goBannerFront.GetComponent<Image>().color = new Color32(115, 115, 115, 255);
		}
	}

	public void AnimateGoEnterAndExit(Animate.AnimateComplete callback)
	{
		RectTransform rectTransform;
		Vector3 pos;
		float width;

		// Animate Banner Black

		rectTransform = (RectTransform)_goBannerBack.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x - width, pos.y, pos.z);

		LeanTween.cancel(_goBannerBack);
		LeanTween.moveLocalX(_goBannerBack, 0.0f, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY);
		LeanTween.moveLocalX(_goBannerBack, pos.x + width, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY + GO_ANIMATE_BANNER_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_ENTER_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_EXIT_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION);

		// Animate Banner Yellow

		rectTransform = (RectTransform)_goBannerFront.transform;
		pos = rectTransform.anchoredPosition;
		width = rectTransform.rect.width;

		rectTransform.anchoredPosition = new Vector3(pos.x + width, pos.y, pos.z);

		LeanTween.cancel(_goBannerFront);
		LeanTween.moveLocalX(_goBannerFront, 0.0f, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY);
		LeanTween.moveLocalX(_goBannerFront, pos.x - width, GO_ANIMATE_BANNER_ENTER_EXIT_DURATION).setEase(LeanTweenType.easeOutSine)
				.setDelay(GO_ANIMATE_BANNER_ENTER_DELAY + GO_ANIMATE_BANNER_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_ENTER_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION
						+ GO_ANIMATE_LABEL_EXIT_DELAY + GO_ANIMATE_LABEL_ENTER_EXIT_DURATION)
				.setOnComplete(
					()=>
					{
						callback();
					}
				);

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
						+ GO_ANIMATE_LABEL_EXIT_DELAY);
	}

	// Pause

	public float PAUSE_ANIMATE_BOARD_ENTER_DURATION;
	public float PAUSE_ANIMATE_BOARD_EXIT_DURATION;

	public float PAUSE_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PAUSE_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _pause;
	private GameObject _pauseBoard;

	private GameObject[] _pauseBlock;

	private GameObject _pauseLock;

	private GameObject _pausePrevButton;
	private GameObject _pauseNextButton;

	private GameObject _pauseAudioOnButton;
	private GameObject _pauseAudioOffButton;
	private GameObject _pauseMenuButton;
	private GameObject _pauseResumeButton;

	public void FindPauseGameObject()
	{
		_pause = GameObject.Find("/Canvas/Pause");
		_pauseBoard = GameObject.Find("/Canvas/Pause/Board");

		_pauseBlock = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			_pauseBlock[i] = GameObject.Find("/Canvas/Pause/Board/Block/Block" + i);
		}

		_pauseLock = GameObject.Find("/Canvas/Pause/Board/Lock");

		_pausePrevButton = GameObject.Find("/Canvas/Pause/Board/Prev");
		_pauseNextButton = GameObject.Find("/Canvas/Pause/Board/Next");

		_pauseAudioOnButton = GameObject.Find("/Canvas/Pause/Board/AudioOn/Button");
		_pauseAudioOffButton = GameObject.Find("/Canvas/Pause/Board/AudioOff/Button");
		_pauseMenuButton = GameObject.Find("/Canvas/Pause/Board/Menu/Button");
		_pauseResumeButton = GameObject.Find("/Canvas/Pause/Board/Resume/Button");
	}

	public void SetActivePause(bool active)
	{
		_pause.SetActive(active);
	}

	public void SetActivePauseAudioOnButton(bool active)
	{
		_pauseAudioOnButton.SetActive(active);
	}

	public void SetActivePauseAudioOffButton(bool active)
	{
		_pauseAudioOffButton.SetActive(active);
	}

	public void SetActivePauseLock(bool active)
	{
		_pauseLock.SetActive(active);
	}

	public void SetEnablePauseButton(bool enable)
	{
		_pausePrevButton.GetComponent<Button>().enabled = enable;
		_pauseNextButton.GetComponent<Button>().enabled = enable;
		_pauseAudioOnButton.GetComponent<Button>().enabled = enable;
		_pauseAudioOffButton.GetComponent<Button>().enabled = enable;
		_pauseMenuButton.GetComponent<Button>().enabled = enable;
		_pauseResumeButton.GetComponent<Button>().enabled = enable;
	}

	public void SetPauseBlockSprite(int setNumber)
	{
		for (int i = 0; i < 4; i++)
		{
			_pauseBlock[i].GetComponent<Image>().sprite = _block.GetBlockSprite(setNumber, i);
		}
	}

	public void AnimatePauseBoardEnter(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardEnter(_pause, _pauseBoard, PAUSE_ANIMATE_BOARD_ENTER_DURATION, callback);
	}

	public void AnimatePauseBoardExit(Animate.AnimateComplete callback)
	{
		Animate.AnimateBoardExit(_pause, _pauseBoard, PAUSE_ANIMATE_BOARD_EXIT_DURATION, callback);
	}

	public void AnimatePausePrevButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pausePrevButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimatePauseNextButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseNextButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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

	public void AnimatePauseResumeButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_pauseResumeButton, PAUSE_ANIMATE_BUTTON_PRESSED_SCALE, PAUSE_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Win

	public float WIN_ANIMATE_BOARD_ENTER_DURATION;
	public float WIN_ANIMATE_BOARD_EXIT_DURATION;

	public float WIN_ANIMATE_STAR_ENTER_DURATION;

	public float WIN_ANIMATE_BUTTON_PRESSED_SCALE;
	public float WIN_ANIMATE_BUTTON_PRESSED_DURATION;

	public float WIN_ANIMATE_MESSAGE_PERFECT_ENTER_DURATION;
	public float WIN_ANIMATE_MESSAGE_PERFECT_EXIT_DURATION;

	public float WIN_ANIMATE_MESSAGE_TRY_ENTER_DURATION;
	public float WIN_ANIMATE_MESSAGE_TRY_EXIT_DURATION;

	public Sprite[] _winColorSprite;

	private GameObject _win;
	private GameObject _winBoard;
	private GameObject _winColor;
	private GameObject[] _winStar;
	private GameObject[] _winStarParticleSystem;

	private GameObject _winHintAdButton;
	private GameObject _winMenuButton;
	private GameObject _winReplayButton;
	private GameObject _winNextButton;

	private GameObject _winMessagePerfect;
	private GameObject _winMessageTry;

	int _winNumStar;

	public void FindWinGameObject()
	{
		_win = GameObject.Find("/Canvas/Win");
		_winBoard = GameObject.Find("/Canvas/Win/Board");
		_winColor = GameObject.Find("/Canvas/Win/Board/Color");
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

		_winMessagePerfect = GameObject.Find("/Canvas/Win/Board/MessagePerfect");
		_winMessageTry = GameObject.Find("/Canvas/Win/Board/MessageTry");
	}

	public void SetWinColor(int color)
	{
		_winColor.GetComponent<Image>().sprite = _winColorSprite[color];
	}

	public void SetActiveWin(bool active)
	{
		_win.SetActive(active);
	}

	public void SetActiveWinStar(int star, bool active)
	{
		_winStar[star].SetActive(active);
	}

	public void SetActiveWinMessagePerfect(bool active)
	{
		_winMessagePerfect.SetActive(active);
	}

	public void SetActiveWinMessageTry(bool active)
	{
		_winMessageTry.SetActive(active);
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

	public void SetWinMessageTryMovesNumber(int moves)
	{
		_winMessageTry.GetComponent<TextMeshProUGUI>().SetText("Solve within <color=#EC2167><b><u>" + moves + " moves</u></b></color>\nto get 3 stars");
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
		_audio.PlayStarEnter(star);

		SetActiveWinStar(star, true);

		LeanTween.cancel(_winStar[star]);

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

	public void AnimateWinMessagePerfectEnter(Animate.AnimateComplete callback)
	{
		_winMessagePerfect.transform.localScale = Vector3.zero;
		LeanTween.scale(_winMessagePerfect, Vector3.one, WIN_ANIMATE_MESSAGE_PERFECT_ENTER_DURATION).setEase(LeanTweenType.easeOutBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateWinMessagePerfectExit(Animate.AnimateComplete callback)
	{
		_winMessagePerfect.transform.localScale = Vector3.one;
		LeanTween.scale(_winMessagePerfect, Vector3.zero, WIN_ANIMATE_MESSAGE_PERFECT_EXIT_DURATION).setEase(LeanTweenType.easeOutExpo).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateWinMessageTryEnter(Animate.AnimateComplete callback)
	{
		Color currentColor = _winMessageTry.GetComponent<TextMeshProUGUI>().color;

		_winMessageTry.GetComponent<TextMeshProUGUI>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);

		LeanTween.value(_winMessageTry, 0.0f, 1, WIN_ANIMATE_MESSAGE_TRY_ENTER_DURATION).setEase(LeanTweenType.easeInSine).setOnUpdate
		(
			(float val) =>
			{
				_winMessageTry.GetComponent<TextMeshProUGUI>().color = new Color(currentColor.r, currentColor.g, currentColor.b, val);
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

	public void AnimateWinMessageTryExit(Animate.AnimateComplete callback)
	{
		_winMessageTry.transform.localScale = Vector3.one;
		LeanTween.scale(_winMessageTry, Vector3.zero, WIN_ANIMATE_MESSAGE_TRY_EXIT_DURATION).setEase(LeanTweenType.easeOutExpo).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
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

	// Darken

	public float DARKEN_ANIMATE_ENTER_DELAY;
	public float DARKEN_ANIMATE_ENTER_DURATION;

	public float DARKEN_ANIMATE_EXIT_DELAY;
	public float DARKEN_ANIMATE_EXIT_DURATION;

	private GameObject _darken;

	private void FindDarkenGameObject()
	{
		_darken = GameObject.Find("/Canvas/Darken");
	}

	public void SetActiveDarken(bool active)
	{
		_darken.SetActive(active);
	}

	public void AnimateDarkenEnterAndExit()
	{
		_darken.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);

		LeanTween.cancel(_darken);

		LeanTween.value(_darken, 0f, 1f, DARKEN_ANIMATE_ENTER_DURATION).setDelay(DARKEN_ANIMATE_ENTER_DELAY).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				_darken.GetComponent<Image>().color = new Color(0f, 0f, 0f, val);
			}
		)
				.setOnComplete
				(
					()=>
					{
						LeanTween.value(_darken, 1f, 0f, DARKEN_ANIMATE_EXIT_DURATION).setDelay(DARKEN_ANIMATE_EXIT_DELAY).setEase(LeanTweenType.easeOutSine).setOnUpdate
						(
							(float val) =>
							{
								_darken.GetComponent<Image>().color = new Color(0f, 0f, 0f, val);
							}
						);
					}
				);
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

	public void AnimateBlinder()
	{
		_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);

		LeanTween.cancel(_blinder);

		LeanTween.value(_blinder, 0f, 1f, BLINDER_ANIMATE_DURATION).setEase(LeanTweenType.easeOutQuint).setOnUpdate
		(
			(float val) =>
			{
				_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, val);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();

		FindTopGameObject();
		FindHintGameObject();
		FindControlGameObject();
		FindGoGameObject();
		FindPauseGameObject();
		FindWinGameObject();
		FindDarkenGameObject();
		FindBlinderGameObject();
	}
}
