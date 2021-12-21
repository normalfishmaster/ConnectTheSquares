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

	private bool _controlHintOffPermanentlyNonInteractable;

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

		_controlHintOffPermanentlyNonInteractable = false;
	}

	public void SetPermanentlyNonInteractableControlHintOffButton()
	{
		_controlHintOffButton.GetComponent<Button>().interactable = false;
		_controlHintOffPermanentlyNonInteractable = true;
	}

	public void SetInteractableControlButton(bool interactable)
	{
		_controlHintAdButton.GetComponent<Button>().interactable = interactable;
		_controlHintOnButton.GetComponent<Button>().interactable = interactable;
		_controlPauseButton.GetComponent<Button>().interactable = interactable;
		_controlUndoButton.GetComponent<Button>().interactable = interactable;
		_controlResetButton.GetComponent<Button>().interactable = interactable;

		if (_controlHintOffPermanentlyNonInteractable)
		{
			_controlHintOffButton.GetComponent<Button>().interactable = false;
		}
		else
		{
			_controlHintOffButton.GetComponent<Button>().interactable = interactable;
		}
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

	public float PAUSE_ANIMATE_SUNBURST_ROTATE_DURATION;

	public float PAUSE_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PAUSE_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _pause;
	private GameObject _pauseBoard;

	private GameObject _pauseSunburstWide;
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

		_pauseSunburstWide = GameObject.Find("/Canvas/Pause/Board/SunburstWide");
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

	public void AnimatePauseSunburstRotate()
	{
		LeanTween.cancel(_pauseSunburstWide);

                LeanTween.rotateAround(_pauseSunburstWide, Vector3.forward, -360.0f, PAUSE_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
                (
                        ()=>
                        {
                                AnimatePauseSunburstRotate();
                        }
                );
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

	bool _winPermanentlyDisableNextButton;
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

		_winPermanentlyDisableNextButton = false;
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

	public void SetInteractableWinButton(bool interactable)
	{
		_winHintAdButton.GetComponent<Button>().interactable = interactable;
		_winMenuButton.GetComponent<Button>().interactable = interactable;
		_winReplayButton.GetComponent<Button>().interactable = interactable;

		if (_winPermanentlyDisableNextButton)
		{
			_winNextButton.GetComponent<Button>().interactable = false;
		}
		else
		{
			_winNextButton.GetComponent<Button>().interactable = interactable;
		}
	}

	public void SetPermanentlyNonInteractableWinNextButton()
	{
		_winPermanentlyDisableNextButton = true;
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

	public float DARKEN_ANIMATE_PRE_END_TO_END_DURATION;

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

	public void AnimateDarkenPreEndToEnd()
	{
		_darken.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);

		LeanTween.cancel(_darken);

		LeanTween.value(_darken, 0f, 1f, DARKEN_ANIMATE_PRE_END_TO_END_DURATION).setEase(LeanTweenType.easeOutQuint).setOnUpdate
		(
			(float val) =>
			{
				_darken.GetComponent<Image>().color = new Color(0f, 0f, 0f, val);
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

	public void SetBlinderColor(int color)
	{
		if (color == 0)
		{
			_blinder.GetComponent<Image>().color = new Color32(229, 159, 66, 255);
		}
		else if (color == 1)
		{
			_blinder.GetComponent<Image>().color = new Color32(0, 194, 162, 255);
		}
		else if (color == 2)
		{
			_blinder.GetComponent<Image>().color = new Color32(107, 126, 203, 255);
		}
		else if (color == 3)
		{
			_blinder.GetComponent<Image>().color = new Color32(198, 69, 138, 255);
		}
		else if (color == 4)
		{
			_blinder.GetComponent<Image>().color = new Color32(115, 115, 115, 255);
		}
	}

	public void ResetBlinderColor()
	{
		_blinder.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
	}

	public void AnimateBlinder()
	{
		LeanTween.cancel(_blinder);

		Color currentColor = _blinder.GetComponent<Image>().color;
		_blinder.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);

		LeanTween.value(_blinder, 0f, 1f, BLINDER_ANIMATE_DURATION).setEase(LeanTweenType.easeOutQuint).setOnUpdate
		(
			(float val) =>
			{
				Color currColor = _blinder.GetComponent<Image>().color;
				_blinder.GetComponent<Image>().color = new Color(currColor.r, currColor.g, currColor.b, val);
			}
		);
	}

	// Tutorial

	public float TUTORIAL_ANIMATE_ENTER_DURATION;
	public float TUTORIAL_ANIMATE_EXIT_DURATION;

	public float TUTORIAL_ANIMATE_TARGET_SUNBURST_ROTATE_DURATION;

	public float TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DURATION;
	public float TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DELAY;

	public float TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DURATION;
	public float TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DELAY;

	public float TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION;
	public float TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DELAY;

	public float TUTORIAL_ANIMATE_BUTTON_PRESSED_SCALE;
	public float TUTORIAL_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _tutorial;

	private GameObject _tutorialTargetArrow;
	private GameObject _tutorialTargetSunburst;

	private GameObject _tutorialControlsArrowUp;
	private GameObject _tutorialControlsArrowDown;
	private GameObject _tutorialControlsArrowLeft;
	private GameObject _tutorialControlsArrowRight;

	private GameObject[] _tutorialControlsArrowUpArrow;
	private GameObject[] _tutorialControlsArrowDownArrow;
	private GameObject[] _tutorialControlsArrowLeftArrow;
	private GameObject[] _tutorialControlsArrowRightArrow;

	private GameObject _tutorialControlsHand;
	private GameObject _tutorialControlsHandHandVertical;
	private GameObject _tutorialControlsHandHandHorizontal;
	private GameObject _tutorialControlsHandArrowUp;
	private GameObject _tutorialControlsHandArrowDown;
	private GameObject _tutorialControlsHandArrowLeft;
	private GameObject _tutorialControlsHandArrowRight;

	private GameObject _tutorialCloseButton;

	private Vector3 _tutorialControlsHandHandOriginalPos;
	private Vector3[] _tutorialControlsArrowOriginalPos;

	private void FindTutorialGameObject()
	{
		_tutorial = GameObject.Find("/Canvas/Tutorial");

		_tutorialTargetArrow = GameObject.Find("/Canvas/Tutorial/Target/Arrow");
		_tutorialTargetSunburst = GameObject.Find("/Canvas/Tutorial/Target/BlockArranged/SunburstWide");

		_tutorialControlsArrowUp = GameObject.Find("/Canvas/Tutorial/Controls/ArrowUp");
		_tutorialControlsArrowDown = GameObject.Find("/Canvas/Tutorial/Controls/ArrowDown");
		_tutorialControlsArrowLeft = GameObject.Find("/Canvas/Tutorial/Controls/ArrowLeft");
		_tutorialControlsArrowRight = GameObject.Find("/Canvas/Tutorial/Controls/ArrowRight");

		_tutorialControlsArrowUpArrow = new GameObject[4];
		_tutorialControlsArrowDownArrow = new GameObject[4];
		_tutorialControlsArrowLeftArrow = new GameObject[4];
		_tutorialControlsArrowRightArrow = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			_tutorialControlsArrowUpArrow[i] = GameObject.Find("/Canvas/Tutorial/Controls/ArrowUp/Arrow" + i);
			_tutorialControlsArrowDownArrow[i] = GameObject.Find("/Canvas/Tutorial/Controls/ArrowDown/Arrow" + i);
			_tutorialControlsArrowLeftArrow[i] = GameObject.Find("/Canvas/Tutorial/Controls/ArrowLeft/Arrow" + i);
			_tutorialControlsArrowRightArrow[i] = GameObject.Find("/Canvas/Tutorial/Controls/ArrowRight/Arrow" + i);
		}

		_tutorialControlsHand = GameObject.Find("/Canvas/Tutorial/Controls/Hand");
		_tutorialControlsHandHandVertical = GameObject.Find("/Canvas/Tutorial/Controls/Hand/HandVertical");
		_tutorialControlsHandHandHorizontal = GameObject.Find("/Canvas/Tutorial/Controls/Hand/HandHorizontal");
		_tutorialControlsHandArrowUp = GameObject.Find("/Canvas/Tutorial/Controls/Hand/ArrowUp");
		_tutorialControlsHandArrowDown = GameObject.Find("/Canvas/Tutorial/Controls/Hand/ArrowDown");
		_tutorialControlsHandArrowLeft = GameObject.Find("/Canvas/Tutorial/Controls/Hand/ArrowLeft");
		_tutorialControlsHandArrowRight = GameObject.Find("/Canvas/Tutorial/Controls/Hand/ArrowRight");

		_tutorialCloseButton = GameObject.Find("/Canvas/Tutorial/Close");

		// Store original positions

		_tutorialControlsHandHandOriginalPos = ((RectTransform)_tutorialControlsHandHandVertical.transform).anchoredPosition;
		_tutorialControlsArrowOriginalPos = new Vector3[4];
		for (int i = 0; i < 4; i++)
		{
			_tutorialControlsArrowOriginalPos[i] = ((RectTransform)_tutorialControlsArrowUpArrow[i].transform).anchoredPosition;
		}
	}

	public void SetActiveTutorial(bool active)
	{
		_tutorial.SetActive(active);
	}

	public void SetEnableTutorialButton(bool enable)
	{
		_tutorialCloseButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateTutorialEnter(Animate.AnimateComplete callback)
	{
		_tutorial.transform.localScale = Vector3.zero;

		LeanTween.cancel(_tutorial);

		LeanTween.scale(_tutorial, Vector3.one, TUTORIAL_ANIMATE_ENTER_DURATION)
				.setEase(LeanTweenType.easeOutBounce)
				.setOnComplete
				(
					()=>
					{
						callback();
					}
				);
	}

	public void AnimateTutorialExit(Animate.AnimateComplete callback)
	{
		_tutorial.transform.localScale = Vector3.one;

		LeanTween.cancel(_tutorial);

		LeanTween.scale(_tutorial, Vector3.zero, TUTORIAL_ANIMATE_ENTER_DURATION)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnComplete
				(
					()=>
					{
						callback();
					}
				);
	}

	private void StopAnimateTutorialTargetSunburst()
	{
		LeanTween.cancel(_tutorialTargetSunburst);
	}

	private void AnimateTutorialTargetSunburst()
	{
		LeanTween.rotateAround(_tutorialTargetSunburst, Vector3.forward, -360.0f, TUTORIAL_ANIMATE_TARGET_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateTutorialTargetSunburst();
			}
		);
	}

	private void AnimateTutorialTarget()
	{
		StopAnimateTutorialTargetSunburst();
		AnimateTutorialTargetSunburst();
	}

	private void StopAnimateTutorialTarget()
	{
		StopAnimateTutorialTargetSunburst();
	}

	private void StopAnimateTutorialControls()
	{
		LeanTween.cancel(_tutorialControlsHandHandVertical);
		LeanTween.cancel(_tutorialControlsHandHandHorizontal);
		LeanTween.cancel(_tutorialControlsHandArrowUp);
		LeanTween.cancel(_tutorialControlsHandArrowDown);
		LeanTween.cancel(_tutorialControlsHandArrowLeft);
		LeanTween.cancel(_tutorialControlsHandArrowRight);

		for (int i = 0; i < 4; i++)
		{
			LeanTween.cancel(_tutorialControlsArrowUpArrow[i]);
			LeanTween.cancel(_tutorialControlsArrowDownArrow[i]);
			LeanTween.cancel(_tutorialControlsArrowLeftArrow[i]);
			LeanTween.cancel(_tutorialControlsArrowRightArrow[i]);
		}
	}

	private void AnimateTutorialControlsSwipeVertical(int dir, Animate.AnimateComplete callback)
	{
		GameObject handArrow;
		GameObject[] arrowArrow = new GameObject[4];

		RectTransform parentRectTransform = (RectTransform)_tutorialControlsHand.transform;
		RectTransform handRectTransform = (RectTransform)_tutorialControlsHandHandVertical.transform;
		RectTransform handArrowRectTransform;
		RectTransform[] arrowRectTransform = new RectTransform[4];

		if (dir == 1)
		{
			handArrow = _tutorialControlsHandArrowUp;
			handArrowRectTransform = (RectTransform)handArrow.transform;
			for (int i = 0; i < 4; i++)
			{
				arrowArrow[i] = _tutorialControlsArrowUpArrow[i];
				arrowRectTransform[i] = (RectTransform)arrowArrow[i].transform;
			}
		}
		else
		{
			handArrow = _tutorialControlsHandArrowDown;
			handArrowRectTransform = (RectTransform)handArrow.transform;
			for (int i = 0; i < 4; i++)
			{
				arrowArrow[i] = _tutorialControlsArrowDownArrow[i];
				arrowRectTransform[i] = (RectTransform)arrowArrow[i].transform;
			}
		}

		// Set Active

		_tutorialControlsHandHandVertical.SetActive(true);
		_tutorialControlsHandHandHorizontal.SetActive(false);

		if (dir == 1)
		{
			_tutorialControlsHandArrowUp.SetActive(true);
			_tutorialControlsHandArrowDown.SetActive(false);
			_tutorialControlsHandArrowLeft.SetActive(false);
			_tutorialControlsHandArrowRight.SetActive(false);

			for (int i = 0; i < 4; i++)
			{
				_tutorialControlsArrowUpArrow[i].SetActive(true);
				_tutorialControlsArrowDownArrow[i].SetActive(false);
				_tutorialControlsArrowLeftArrow[i].SetActive(false);
				_tutorialControlsArrowRightArrow[i].SetActive(false);
			}
		}
		else
		{
			_tutorialControlsHandArrowUp.SetActive(false);
			_tutorialControlsHandArrowDown.SetActive(true);
			_tutorialControlsHandArrowLeft.SetActive(false);
			_tutorialControlsHandArrowRight.SetActive(false);

			for (int i = 0; i < 4; i++)
			{
				_tutorialControlsArrowUpArrow[i].SetActive(false);
				_tutorialControlsArrowDownArrow[i].SetActive(true);
				_tutorialControlsArrowLeftArrow[i].SetActive(false);
				_tutorialControlsArrowRightArrow[i].SetActive(false);
			}
		}

		// Cancel Animations

		StopAnimateTutorialControls();

		// Animate Hand - Direction

		float handDeltaY = ((parentRectTransform.rect.height / 2) - (handRectTransform.rect.height / 2)) * 2;

		float handStartPosY = _tutorialControlsHandHandOriginalPos.y - ((handDeltaY / 2) * dir);
		float handEndPosY = _tutorialControlsHandHandOriginalPos.y + ((handDeltaY / 2) * dir);

		handRectTransform.anchoredPosition = new Vector3(_tutorialControlsHandHandOriginalPos.x, handStartPosY, _tutorialControlsHandHandOriginalPos.z);

		LeanTween.moveLocalY(_tutorialControlsHandHandVertical, handEndPosY, TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Hand - Opacity

		_tutorialControlsHandHandVertical.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

		LeanTween.value(_tutorialControlsHandHandVertical, 1f, 0f, TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnUpdate
				(
					(float val) =>
					{
						_tutorialControlsHandHandVertical.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
					}
				)
				.setOnComplete
				(
					()=>
					{
						_tutorialControlsHandHandVertical.SetActive(false);
					}
				);

		// Animate Hand Arrow - Direction

		float handArrowStartPosY = handStartPosY;
		float handArrowEndPosY = handEndPosY;

		handArrowRectTransform.anchoredPosition = new Vector3(_tutorialControlsHandHandOriginalPos.x, handArrowStartPosY, _tutorialControlsHandHandOriginalPos.z);

		LeanTween.moveLocalY(handArrow, handArrowEndPosY, TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Hand Arrow - Scale

		handArrow.transform.localScale = Vector3.zero;

		LeanTween.scale(handArrow, Vector3.one, TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnComplete
				(
					()=>
					{
						handArrow.SetActive(false);
					}
				);

		// Animate Arrow - Direction

		for (int i = 0; i < 4; i++)
		{
			float arrowStartPosY = 0;
			float arrowEndPosY = arrowStartPosY + ((1.10f * arrowRectTransform[i].rect.height) * dir);

			arrowRectTransform[i].anchoredPosition = new Vector3(_tutorialControlsArrowOriginalPos[i].x, arrowStartPosY, _tutorialControlsArrowOriginalPos[i].z);

			LeanTween.moveY((RectTransform)arrowArrow[i].transform, arrowEndPosY, TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setDelay(TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DELAY)
					.setEase(LeanTweenType.easeInOutQuint);
		}

		// Animate Arrow - Scale

		for (int i = 0; i < 4; i++)
		{
			arrowArrow[i].transform.localScale = Vector3.zero;
			LeanTween.scale(arrowArrow[i], Vector3.one, TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setDelay(TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DELAY)
					.setEase(LeanTweenType.easeInOutQuint).setOnComplete
					(
						()=>
						{
							arrowArrow[0].SetActive(false);
							arrowArrow[1].SetActive(false);
							arrowArrow[2].SetActive(false);
							arrowArrow[3].SetActive(false);
						}
					);
		}

		// Callback

		LeanTween.value(arrowArrow[0], 0f, 1f, TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setDelay(TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setEase(LeanTweenType.easeInSine)
					.setOnUpdate
					(
						(float val) =>
						{
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

	private void AnimateTutorialControlsSwipeHorizontal(int dir, Animate.AnimateComplete callback)
	{
		GameObject handArrow;
		GameObject[] arrowArrow = new GameObject[4];

		RectTransform parentRectTransform = (RectTransform)_tutorialControlsHand.transform;
		RectTransform handRectTransform = (RectTransform)_tutorialControlsHandHandHorizontal.transform;
		RectTransform handArrowRectTransform;
		RectTransform[] arrowRectTransform = new RectTransform[4];

		if (dir == 1)
		{
			handArrow = _tutorialControlsHandArrowRight;
			handArrowRectTransform = (RectTransform)handArrow.transform;
			for (int i = 0; i < 4; i++)
			{
				arrowArrow[i] = _tutorialControlsArrowRightArrow[i];
				arrowRectTransform[i] = (RectTransform)arrowArrow[i].transform;
			}
		}
		else
		{
			handArrow = _tutorialControlsHandArrowLeft;
			handArrowRectTransform = (RectTransform)handArrow.transform;
			for (int i = 0; i < 4; i++)
			{
				arrowArrow[i] = _tutorialControlsArrowLeftArrow[i];
				arrowRectTransform[i] = (RectTransform)arrowArrow[i].transform;
			}
		}

		// Set Active

		_tutorialControlsHandHandVertical.SetActive(false);
		_tutorialControlsHandHandHorizontal.SetActive(true);

		if (dir == 1)
		{
			_tutorialControlsHandArrowUp.SetActive(false);
			_tutorialControlsHandArrowDown.SetActive(false);
			_tutorialControlsHandArrowLeft.SetActive(false);
			_tutorialControlsHandArrowRight.SetActive(true);

			for (int i = 0; i < 4; i++)
			{
				_tutorialControlsArrowUpArrow[i].SetActive(false);
				_tutorialControlsArrowDownArrow[i].SetActive(false);
				_tutorialControlsArrowLeftArrow[i].SetActive(false);
				_tutorialControlsArrowRightArrow[i].SetActive(true);
			}
		}
		else
		{
			_tutorialControlsHandArrowUp.SetActive(false);
			_tutorialControlsHandArrowDown.SetActive(false);
			_tutorialControlsHandArrowLeft.SetActive(true);
			_tutorialControlsHandArrowRight.SetActive(false);

			for (int i = 0; i < 4; i++)
			{
				_tutorialControlsArrowUpArrow[i].SetActive(false);
				_tutorialControlsArrowDownArrow[i].SetActive(false);
				_tutorialControlsArrowLeftArrow[i].SetActive(true);
				_tutorialControlsArrowRightArrow[i].SetActive(false);
			}
		}

		// Cancel Animations

		StopAnimateTutorialControls();

		// Animate Hand - Direction

		float handDeltaX = ((parentRectTransform.rect.width / 2) - (handRectTransform.rect.width / 2)) * 2;

		float handStartPosX = _tutorialControlsHandHandOriginalPos.x - ((handDeltaX / 2) * dir);
		float handEndPosX = _tutorialControlsHandHandOriginalPos.x + ((handDeltaX / 2) * dir);

		handRectTransform.anchoredPosition = new Vector3(handStartPosX, _tutorialControlsHandHandOriginalPos.y, _tutorialControlsHandHandOriginalPos.z);

		LeanTween.moveLocalX(_tutorialControlsHandHandHorizontal, handEndPosX, TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Hand - Opacity

		_tutorialControlsHandHandHorizontal.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

		LeanTween.value(_tutorialControlsHandHandHorizontal, 1f, 0f, TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_HAND_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnUpdate
				(
					(float val) =>
					{
						_tutorialControlsHandHandHorizontal.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
					}
				)
				.setOnComplete
				(
					()=>
					{
						_tutorialControlsHandHandHorizontal.SetActive(false);
					}
				);

		// Animate Hand Arrow - Direction

		float handArrowStartPosX = handStartPosX;
		float handArrowEndPosX = handEndPosX;

		handArrowRectTransform.anchoredPosition = new Vector3(handArrowStartPosX, _tutorialControlsHandHandOriginalPos.y, _tutorialControlsHandHandOriginalPos.z);

		LeanTween.moveLocalX(handArrow, handArrowEndPosX, TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Hand Arrow - Scale

		handArrow.transform.localScale = Vector3.zero;


		LeanTween.scale(handArrow, Vector3.one, TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DURATION)
				.setDelay(TUTORIAL_ANIMATE_CONTROLS_HAND_ARROW_SWIPE_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnComplete
				(
					()=>
					{
						handArrow.SetActive(false);
					}
				);

		// Animate Arrow - Direction

		for (int i = 0; i < 4; i++)
		{
			float arrowStartPosX = 0;
			float arrowEndPosX = arrowStartPosX + ((1.10f * arrowRectTransform[i].rect.width) * dir);

			arrowRectTransform[i].anchoredPosition = new Vector3(arrowStartPosX, _tutorialControlsArrowOriginalPos[i].y, _tutorialControlsArrowOriginalPos[i].z);

			LeanTween.moveX((RectTransform)arrowArrow[i].transform, arrowEndPosX, TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setDelay(TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DELAY)
					.setEase(LeanTweenType.easeInOutQuint);
		}

		// Animate Arrow - Scale

		for (int i = 0; i < 4; i++)
		{
			arrowArrow[i].transform.localScale = Vector3.zero;
			LeanTween.scale(arrowArrow[i], Vector3.one, TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setDelay(TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DELAY)
					.setEase(LeanTweenType.easeInOutQuint).setOnComplete
					(
						()=>
						{
							arrowArrow[0].SetActive(false);
							arrowArrow[1].SetActive(false);
							arrowArrow[2].SetActive(false);
							arrowArrow[3].SetActive(false);
						}
					);
		}

		// Callback

		LeanTween.value(arrowArrow[0], 0f, 1f, TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setDelay(TUTORIAL_ANIMATE_CONTROLS_ARROW_MOVE_DURATION)
					.setEase(LeanTweenType.easeInSine)
					.setOnUpdate
					(
						(float val) =>
						{
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

	private void AnimateTutorialControls()
	{
		AnimateTutorialControlsSwipeVertical(1,
			()=>
			{
				AnimateTutorialControlsSwipeHorizontal(1,
					()=>
					{
						AnimateTutorialControlsSwipeVertical(-1,
							()=>
							{
								AnimateTutorialControlsSwipeHorizontal(-1,
									()=>
									{
										AnimateTutorialControls();
									}
								);
							}
						);
					}
				);
			}
		);
	}

	public void StartAnimateTutorial()
	{
		AnimateTutorialTarget();
		AnimateTutorialControls();
	}

	public void StopAnimateTutorial()
	{
		StopAnimateTutorialTarget();
		StopAnimateTutorialControls();
	}

	public void AnimateTutorialCloseButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_tutorialCloseButton, TUTORIAL_ANIMATE_BUTTON_PRESSED_SCALE, TUTORIAL_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Solution

	public float SOLUTION_ANIMATE_SWIPE_HAND_DURATION;
	public float SOLUTION_ANIMATE_SWIPE_HAND_DELAY;

	public float SOLUTION_ANIMATE_SWIPE_ARROW_DURATION;
	public float SOLUTION_ANIMATE_SWIPE_ARROW_DELAY;

	private GameObject _solution;
	private GameObject _solutionHandVertical;
	private GameObject _solutionHandHorizontal;
	private GameObject _solutionArrowUp;
	private GameObject _solutionArrowDown;
	private GameObject _solutionArrowLeft;
	private GameObject _solutionArrowRight;
	private GameObject _solutionCircleArrowUp;
	private GameObject _solutionCircleArrowDown;
	private GameObject _solutionCircleArrowLeft;
	private GameObject _solutionCircleArrowRight;

	private Vector3 _solutionHandOriginalPos;

	private void FindSolutionGameObject()
	{
		_solution = GameObject.Find("/Canvas/Solution");
		_solutionHandVertical = GameObject.Find("/Canvas/Solution/HandVertical");
		_solutionHandHorizontal = GameObject.Find("/Canvas/Solution/HandHorizontal");
		_solutionArrowUp = GameObject.Find("/Canvas/Solution/ArrowUp");
		_solutionArrowDown = GameObject.Find("/Canvas/Solution/ArrowDown");
		_solutionArrowLeft = GameObject.Find("/Canvas/Solution/ArrowLeft");
		_solutionArrowRight = GameObject.Find("/Canvas/Solution/ArrowRight");
		_solutionCircleArrowUp = GameObject.Find("/Canvas/Solution/CircleArrowUp");
		_solutionCircleArrowDown = GameObject.Find("/Canvas/Solution/CircleArrowDown");
		_solutionCircleArrowLeft = GameObject.Find("/Canvas/Solution/CircleArrowLeft");
		_solutionCircleArrowRight = GameObject.Find("/Canvas/Solution/CircleArrowRight");

		_solutionHandOriginalPos = ((RectTransform)_solutionHandVertical.transform).anchoredPosition;
	}

	public void SetActiveSolution(bool active)
	{
		_solution.SetActive(active);
	}

	private void AnimateSolutionSwipeVertical(int dir)
	{
		GameObject arrow;

		RectTransform parentRectTransform = (RectTransform)_solution.transform;
		RectTransform handRectTransform = (RectTransform)_solutionHandVertical.transform;
		RectTransform arrowRectTransform;

		if (dir == 1)
		{
			arrow = _solutionArrowUp;
			arrowRectTransform = (RectTransform)_solutionArrowUp.transform;
		}
		else
		{
			arrow = _solutionArrowDown;
			arrowRectTransform = (RectTransform)_solutionArrowDown.transform;
		}

		// Set Active

		_solutionHandVertical.SetActive(true);
		_solutionHandHorizontal.SetActive(false);

		if (dir == 1)
		{
			_solutionArrowUp.SetActive(true);
			_solutionArrowDown.SetActive(false);
			_solutionArrowLeft.SetActive(false);
			_solutionArrowRight.SetActive(false);

			_solutionCircleArrowUp.SetActive(true);
			_solutionCircleArrowDown.SetActive(false);
			_solutionCircleArrowLeft.SetActive(false);
			_solutionCircleArrowRight.SetActive(false);
		}
		else
		{
			_solutionArrowUp.SetActive(false);
			_solutionArrowDown.SetActive(true);
			_solutionArrowLeft.SetActive(false);
			_solutionArrowRight.SetActive(false);

			_solutionCircleArrowUp.SetActive(false);
			_solutionCircleArrowDown.SetActive(true);
			_solutionCircleArrowLeft.SetActive(false);
			_solutionCircleArrowRight.SetActive(false);
		}

		// Cancel Animation

		StopAnimateSolution();

		// Animate Hand - Direction

		float handDeltaY = ((parentRectTransform.rect.height / 2) - (handRectTransform.rect.height / 2)) * 2;

		float handStartPosY = _solutionHandOriginalPos.y - ((handDeltaY / 2) * dir);
		float handEndPosY = _solutionHandOriginalPos.y + ((handDeltaY / 2) * dir);

		handRectTransform.anchoredPosition = new Vector3(_solutionHandOriginalPos.x, handStartPosY, _solutionHandOriginalPos.z);

		LeanTween.moveLocalY(_solutionHandVertical, handEndPosY, SOLUTION_ANIMATE_SWIPE_HAND_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_HAND_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Hand - Opacity

		_solutionHandVertical.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

		LeanTween.value(_solutionHandVertical, 1f, 0f, SOLUTION_ANIMATE_SWIPE_HAND_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_HAND_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnUpdate
				(
					(float val) =>
					{
						_solutionHandVertical.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
					}
				)
				.setOnComplete
				(
					()=>
					{
						_solutionHandVertical.SetActive(false);
					}
				);

		// Animate Arrow - Direction

		float arrowStartPosY = handStartPosY;
		float arrowEndPosY = handEndPosY;

		arrowRectTransform.anchoredPosition = new Vector3(_solutionHandOriginalPos.x, arrowStartPosY, _solutionHandOriginalPos.z);

		LeanTween.moveLocalY(arrow, arrowEndPosY, SOLUTION_ANIMATE_SWIPE_ARROW_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_ARROW_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Arrow - Scale

		arrow.transform.localScale = Vector3.zero;

		LeanTween.scale(arrow, Vector3.one, SOLUTION_ANIMATE_SWIPE_ARROW_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_ARROW_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnComplete
				(
					()=>
					{
						arrow.SetActive(false);
					}
				);

		// Callback

		LeanTween.value(arrow, 0f, 1f, SOLUTION_ANIMATE_SWIPE_ARROW_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_ARROW_DELAY)
				.setEase(LeanTweenType.easeInSine)
				.setOnUpdate
				(
					(float val) =>
					{
					}
				)
				.setOnComplete
				(
					()=>
					{
						AnimateSolutionSwipeVertical(dir);
					}
				);
	}

	private void AnimateSolutionSwipeHorizontal(int dir)
	{
		GameObject arrow;

		RectTransform parentRectTransform = (RectTransform)_solution.transform;
		RectTransform handRectTransform = (RectTransform)_solutionHandHorizontal.transform;
		RectTransform arrowRectTransform;

		if (dir == 1)
		{
			arrow = _solutionArrowRight;
			arrowRectTransform = (RectTransform)_solutionArrowRight.transform;
		}
		else
		{
			arrow = _solutionArrowLeft;
			arrowRectTransform = (RectTransform)_solutionArrowLeft.transform;
		}

		// Set Active

		_solutionHandVertical.SetActive(false);
		_solutionHandHorizontal.SetActive(true);

		if (dir == 1)
		{
			_solutionArrowUp.SetActive(false);
			_solutionArrowDown.SetActive(false);
			_solutionArrowLeft.SetActive(false);
			_solutionArrowRight.SetActive(true);

			_solutionCircleArrowUp.SetActive(false);
			_solutionCircleArrowDown.SetActive(false);
			_solutionCircleArrowLeft.SetActive(false);
			_solutionCircleArrowRight.SetActive(true);
		}
		else
		{
			_solutionArrowUp.SetActive(false);
			_solutionArrowDown.SetActive(false);
			_solutionArrowLeft.SetActive(true);
			_solutionArrowRight.SetActive(false);

			_solutionCircleArrowUp.SetActive(false);
			_solutionCircleArrowDown.SetActive(false);
			_solutionCircleArrowLeft.SetActive(true);
			_solutionCircleArrowRight.SetActive(false);
		}

		// Cancel Animation

		StopAnimateSolution();

		// Animate Hand - Direction

		float handDeltaX = ((parentRectTransform.rect.width / 2) - (handRectTransform.rect.width / 2)) * 2;

		float handStartPosX = _solutionHandOriginalPos.x - ((handDeltaX / 2) * dir);
		float handEndPosX = _solutionHandOriginalPos.x + ((handDeltaX / 2) * dir);

		handRectTransform.anchoredPosition = new Vector3(handStartPosX, _solutionHandOriginalPos.y, _solutionHandOriginalPos.z);

		LeanTween.cancel(_solutionHandHorizontal);
		LeanTween.moveLocalX(_solutionHandHorizontal, handEndPosX, SOLUTION_ANIMATE_SWIPE_HAND_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_HAND_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Hand - Opacity

		_solutionHandHorizontal.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

		LeanTween.value(_solutionHandHorizontal, 1f, 0f, SOLUTION_ANIMATE_SWIPE_HAND_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_HAND_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnUpdate
				(
					(float val) =>
					{
						_solutionHandHorizontal.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
					}
				)
				.setOnComplete
				(
					()=>
					{
						_solutionHandHorizontal.SetActive(false);
					}
				);

		// Animate Arrow - Direction

		float arrowStartPosX = handStartPosX;
		float arrowEndPosX = handEndPosX;

		arrowRectTransform.anchoredPosition = new Vector3(arrowStartPosX, _solutionHandOriginalPos.y, _solutionHandOriginalPos.z);

		LeanTween.cancel(arrow);
		LeanTween.moveLocalX(arrow, arrowEndPosX, SOLUTION_ANIMATE_SWIPE_ARROW_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_ARROW_DELAY)
				.setEase(LeanTweenType.easeInOutQuint);

		// Animate Arrow - Scale

		arrow.transform.localScale = Vector3.zero;

		LeanTween.scale(arrow, Vector3.one, SOLUTION_ANIMATE_SWIPE_ARROW_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_ARROW_DELAY)
				.setEase(LeanTweenType.easeInOutQuint)
				.setOnComplete
				(
					()=>
					{
						arrow.SetActive(false);
					}
				);

		// Callback

		LeanTween.value(arrow, 0f, 1f, SOLUTION_ANIMATE_SWIPE_ARROW_DURATION)
				.setDelay(SOLUTION_ANIMATE_SWIPE_ARROW_DELAY)
				.setEase(LeanTweenType.easeInSine)
				.setOnUpdate
				(
					(float val) =>
					{
					}
				)
				.setOnComplete
				(
					()=>
					{
						AnimateSolutionSwipeHorizontal(dir);
					}
				);
	}

	public void StartAnimateSolution(char direction)
	{
		char directionUpper = char.ToUpper(direction);

		if (directionUpper == 'U')
		{
			AnimateSolutionSwipeVertical(1);
		}
		else if (directionUpper == 'D')
		{
			AnimateSolutionSwipeVertical(-1);
		}
		else if (directionUpper == 'L')
		{
			AnimateSolutionSwipeHorizontal(-1);
		}
		else if (directionUpper == 'R')
		{
			AnimateSolutionSwipeHorizontal(1);
		}
	}

	public void StopAnimateSolution()
	{
		LeanTween.cancel(_solutionHandVertical);
		LeanTween.cancel(_solutionHandHorizontal);
		LeanTween.cancel(_solutionArrowUp);
		LeanTween.cancel(_solutionArrowDown);
		LeanTween.cancel(_solutionArrowLeft);
		LeanTween.cancel(_solutionArrowRight);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();

		FindTopGameObject();
		FindControlGameObject();
		FindGoGameObject();
		FindPauseGameObject();
		FindWinGameObject();
		FindDarkenGameObject();
		FindBlinderGameObject();
		FindTutorialGameObject();
		FindSolutionGameObject();
	}
}
