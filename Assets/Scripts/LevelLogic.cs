using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLogic : MonoBehaviour
{
	private LevelUI _ui;
	private DataManager _data;
	private EventManager _event;
	private LevelManager _level;
	private AdManager _ad;

	private int _menuColor;
	private int _menuAlphabet;
	private int _menuMap;

	private Level.Map _levelMap;

	private bool _hintUsed;

	private const int NUM_X = Level.NUM_COL;
	private const int NUM_Y = Level.NUM_ROW;

	private const int NUM_SQUARE = Level.NUM_SQUARE;

	private Vector2 DIRECTION_NONE  = Vector2.zero;
	private Vector2 DIRECTION_UP    = new Vector2( 0.0f,  1.0f);
	private Vector2 DIRECTION_DOWN  = new Vector2( 0.0f, -1.0f);
	private Vector2 DIRECTION_LEFT  = new Vector2(-1.0f,  0.0f);
	private Vector2 DIRECTION_RIGHT = new Vector2( 1.0f,  0.0f);

	private const int MAX_MOVE_COUNT = 999;

	private const float MAX_AD_LOAD_TIME = 5.0f;

	// Map

	private GameObject[,] _mapWall;
	private GameObject[,] _mapWallShadow;
	private GameObject[] _mapSquare;
	private GameObject[] _mapSquareShadow;

	private float _mapXOffset;
	private float _mapYOffset;

	private void FindMapGameObject()
	{
		// Wall

		_mapWall = new GameObject[NUM_X, NUM_Y];
		_mapWallShadow = new GameObject[NUM_X, NUM_Y];

		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				_mapWall[i, j] = GameObject.Find("/Map/Wall/X" + i + "/Y" + j);
				_mapWallShadow[i, j] = GameObject.Find("/Map/WallShadow/X" + i + "/Y" + j);
			}
		}

		// Square

		_mapSquare = new GameObject[Level.NUM_SQUARE];
		_mapSquareShadow = new GameObject[Level.NUM_SQUARE];

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_mapSquare[i] = GameObject.Find("/Map/Square/S" + i);
			_mapSquareShadow[i] = GameObject.Find("/Map/SquareShadow/S" + i);
		}
	}

	private void SetupMap()
	{
		_mapXOffset = -3.5f;
		_mapYOffset = -3.5f;
	}

	private void SetMapSquarePos(int square, float x, float y)
	{
		Vector2 pos = new Vector2(_mapXOffset + x, _mapYOffset + y);
		_mapSquare[square].transform.position = pos;
		_mapSquareShadow[square].transform.position = pos;
	}

	private void DisableMapWall(int x, int y)
	{
		_mapWall[x, y].SetActive(false);
		_mapWallShadow[x, y].SetActive(false);
	}

	// Physics

	private const float DECELERATION_RATE_START_TO_END = 0.07f;
	private const float DECELERATION_RATE_START_TO_PRE_END = 0.07f;
	private const float DECELERATION_RATE_PRE_END_TO_END = 2.00f;

	private sbyte[,] _physicsMapLayout;
	private Vector2[] _physicsSquarePos;
	private Stack[] _physicsPosStack;

	private Vector2 _physicsDirection;

	private Vector2[] _physicsStartPos;
	private Vector2[] _physicsEndPos;
	private Vector2[] _physicsStartToEndDist;
	private int _physicsLongestDist;

	private Vector2[] _physicsPreEndPos;
	private Vector2[] _physicsStartToPreEndDist;
	private Vector2[] _physicsPreEndToEndDist;

	private float _physicsStartTime;

	private void SetupPhysics()
	{
		// Convert level map to local physics map based on world coordinates:
		// 1. Swap row and col
		// 2. Invert col

		_physicsMapLayout = new sbyte[Level.NUM_COL, Level.NUM_ROW];
		_physicsSquarePos = new Vector2[Level.NUM_SQUARE];
		_physicsPosStack = new Stack[Level.NUM_SQUARE];

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_physicsPosStack[i] = new Stack();
		}

		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				sbyte tile = _physicsMapLayout[i, j] = _levelMap._layout[Level.NUM_ROW - j - 1, i];

				if (Level.IsSquare(tile))
				{
					int n = Level.GetSquareNumber(tile);
					_physicsSquarePos[n] = new Vector2(i, j);
					_physicsPosStack[n].Push(new Vector2(i, j));
                                        SetMapSquarePos(n, i, j);
                                }

				if (Level.IsSquare(tile) || Level.IsEmpty(tile))
				{
					DisableMapWall(i, j);
				}
			}
		}

		_physicsStartPos = new Vector2[NUM_SQUARE];
		_physicsEndPos = new Vector2[NUM_SQUARE];
		_physicsStartToEndDist = new Vector2[NUM_SQUARE];

		_physicsPreEndPos = new Vector2[NUM_SQUARE];
		_physicsStartToPreEndDist = new Vector2[NUM_SQUARE];
		_physicsPreEndToEndDist = new Vector2[NUM_SQUARE];
	}

	private void PushMoveToStack(Vector2[] pos)
	{
		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_physicsMapLayout[(int)_physicsSquarePos[i].x, (int)_physicsSquarePos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_physicsMapLayout[(int)pos[i].x, (int)pos[i].y] = Level.GetSquare((sbyte)i);
			_physicsSquarePos[i].x = pos[i].x;
			_physicsSquarePos[i].y = pos[i].y;
			_physicsPosStack[i].Push(pos[i]);
		}
	}

	private void PopMoveFromStack()
	{
		if (_physicsPosStack[0].Count == 1)
		{
			return;
		}

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_physicsMapLayout[(int)_physicsSquarePos[i].x, (int)_physicsSquarePos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_physicsPosStack[i].Pop();
			Vector2 pos = (Vector2)_physicsPosStack[i].Peek();

			_physicsMapLayout[(int)pos.x, (int)pos.y] = Level.GetSquare((sbyte)i);
			_physicsSquarePos[i].x = pos.x;
			_physicsSquarePos[i].y = pos.y;
		}
	}

	private void ResetMoveInStack()
	{
		while (_physicsPosStack[0].Count > 1)
		{
			for (int j = 0; j < NUM_SQUARE; j++)
			{
				_physicsPosStack[j].Pop();
			}
		}

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			_physicsMapLayout[(int)_physicsSquarePos[i].x, (int)_physicsSquarePos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			Vector2 pos = (Vector2)_physicsPosStack[i].Peek();

			_physicsMapLayout[(int)pos.x, (int)pos.y] = Level.GetSquare((sbyte)i);
			_physicsSquarePos[i].x = pos.x;
			_physicsSquarePos[i].y = pos.y;
		}
	}

	private int GetSquareMoveCount()
	{
		return _physicsPosStack[0].Count - 1;
	}

	private bool CheckHintDirection(Vector2 direction)
	{
		int move = GetSquareMoveCount();
		int hint = _levelMap._hint[move];

		if (hint == Level.UP && direction == DIRECTION_UP)
		{
			return true;
		}
		else if (hint == Level.DOWN && direction == DIRECTION_DOWN)
		{
			return true;
		}
		else if (hint == Level.LEFT && direction == DIRECTION_LEFT)
		{
			return true;
		}
		else if (hint == Level.RIGHT && direction == DIRECTION_RIGHT)
		{
			return true;
		}

		return false;
	}

	private Vector2 GetSquareStartPos(int square)
	{
		return _physicsSquarePos[square];
	}

	private Vector2 GetSquareEndPos(int square, Vector2 direction)
	{
		int x = (int)_physicsSquarePos[square].x;
		int y = (int)_physicsSquarePos[square].y;

		int numSquare = 0;

		if (direction == DIRECTION_UP || direction == DIRECTION_DOWN)
		{
			int add = direction == DIRECTION_UP ? 1 : -1;
			int i;

			for (i = y + add; i >= 0 && i < NUM_Y; i += add)
			{
				sbyte tile = _physicsMapLayout[x, i];

				if (Level.IsSquare(tile))
				{
					numSquare++;
				}
				else if (Level.IsWall(tile))
				{
					break;
				}
			}

			return new Vector2(x, i + (-1 * add) + (-1 * add * numSquare));
		}
		else if (direction == DIRECTION_LEFT || direction == DIRECTION_RIGHT)
		{
			int add = direction == DIRECTION_LEFT ? -1 : 1;
			int i;

			for (i = x + add; i >= 0 && i < NUM_X; i += add)
			{
				sbyte tile = _physicsMapLayout[i, y];

				if (Level.IsSquare(tile))
				{
					numSquare++;
				}
				else if (Level.IsWall(tile))
				{
					break;
				}
			}

			return new Vector2(i + (-1 * add) + (-1 * add * numSquare), y);
		}

		return Vector2.zero;
	}

	bool IsSquareEndPosWinning()
	{
		for (int i = 0; i < NUM_SQUARE; i++)
		{
			int x = (int)_physicsEndPos[i].x;
			int y = (int)_physicsEndPos[i].y;

			Vector2 posUp = new Vector2(x, y + 1.0f);
			Vector2 posDown = new Vector2(x, y - 1.0f);
			Vector2 posLeft = new Vector2(x - 1.0f, y);
			Vector2 posRight = new Vector2(x + 1.0f, y);

			int hitTally = 0;

			for (int j = 0; j < NUM_SQUARE; j++)
			{
				if (i == j)
				{
					continue;
				}

				if (posUp == _physicsEndPos[j])
				{
					hitTally += 1;
				}
				else if (posDown == _physicsEndPos[j])
				{
					hitTally += 1;
				}
				else if (posLeft == _physicsEndPos[j])
				{
					hitTally += 1;
				}
				else if (posRight == _physicsEndPos[j])
				{
					hitTally += 1;
				}
			}

			if (hitTally != 2)
			{
				return false;
			}
		}

		return true;
	}

	private bool StartSquareMovement(Vector2 direction)
	{
		Vector2[] startPos = new Vector2[NUM_SQUARE];
		Vector2[] endPos = new Vector2[NUM_SQUARE];
		Vector2[] startToEndDist = new Vector2[NUM_SQUARE];
		int longestDist = 0;

		Vector2[] preEndPos = new Vector2[NUM_SQUARE];
		Vector2[] startToPreEndDist = new Vector2[NUM_SQUARE];
		Vector2[] preEndToEndDist = new Vector2[NUM_SQUARE];
		float preEndMultiplier = 0.0f;

		bool legal = false;

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			startPos[i] = GetSquareStartPos(i);
			endPos[i] = GetSquareEndPos(i, direction);

			startToEndDist[i] = (int)Vector2.Distance(startPos[i], endPos[i]) * direction;

			if (startToEndDist[i] != Vector2.zero)
			{
				legal = true;
			}

			if (startToEndDist[i].magnitude >= startToEndDist[longestDist].magnitude)
			{
				longestDist = i;
			}
		}

		if (legal == false)
		{
			return false;
		}

		preEndPos[longestDist] = endPos[longestDist] - (direction * 1);

		startToPreEndDist[longestDist] = Vector2.Distance(startPos[longestDist], preEndPos[longestDist]) * direction;
		preEndToEndDist[longestDist] = Vector2.Distance(preEndPos[longestDist], endPos[longestDist]) * direction;

		preEndMultiplier = startToPreEndDist[longestDist].magnitude / startToEndDist[longestDist].magnitude;

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			if (i == longestDist)
			{
				continue;
			}

			preEndPos[i] = startPos[i] + (preEndMultiplier * startToEndDist[i].magnitude) * direction;

			startToPreEndDist[i] = Vector2.Distance(startPos[i], preEndPos[i]) * direction;
			preEndToEndDist[i] = Vector2.Distance(preEndPos[i], endPos[i]) * direction;
		}

		_physicsDirection = direction;

		_physicsStartPos = startPos;
		_physicsEndPos = endPos;
		_physicsStartToEndDist = startToEndDist;
		_physicsLongestDist = longestDist;

		_physicsPreEndPos = preEndPos;
		_physicsStartToPreEndDist = startToPreEndDist;
		_physicsPreEndToEndDist = preEndToEndDist;

		_physicsStartTime = Time.time;

		return true;
	}

	private bool MoveSquareToPos(float startTime, Vector2 direction,
			Vector2[] startPos, Vector2[] endPos,
			Vector2[] startToEndDist, int longestDist,
			float decelerationRate)
	{
		float travelTime = startToEndDist[longestDist].magnitude * decelerationRate;
		float deltaTime = Time.time - startTime;

		if (deltaTime >= travelTime)
		{
			for (int i = 0; i < NUM_SQUARE; i++)
			{
				SetMapSquarePos(i, endPos[i].x, endPos[i].y);
			}
			return true;
		}

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			float totalDistance = startToEndDist[i].magnitude;

			if (totalDistance == 0.0f)
			{
				continue;
			}

			float startSpeed = (2.0f * totalDistance) / travelTime;
			float deceleration = -(startSpeed * startSpeed) / (2.0f * totalDistance);
			float distance = (startSpeed * deltaTime) + ((0.5f * deceleration) * (deltaTime * deltaTime));
			Vector2 movePos = startPos[i] + distance * direction;

			SetMapSquarePos(i, movePos.x, movePos.y);
		}

		return false;
        }

	private bool MoveSquareFromStartToEnd()
	{
		bool ret = MoveSquareToPos(_physicsStartTime, _physicsDirection,
				_physicsStartPos, _physicsEndPos,
				_physicsStartToEndDist, _physicsLongestDist,
				DECELERATION_RATE_START_TO_END);

		if (ret == true)
		{
			PushMoveToStack(_physicsEndPos);
		}

		return ret;
	}

	private bool MoveSquareFromStartToPreEnd()
	{
		bool ret = MoveSquareToPos(_physicsStartTime, _physicsDirection,
				_physicsStartPos, _physicsPreEndPos,
				_physicsStartToPreEndDist, _physicsLongestDist,
				DECELERATION_RATE_START_TO_PRE_END);

		if (ret == true)
		{
			_physicsStartTime = Time.time;
		}

		return ret;
	}

	private bool MoveSquareFromPreEndToEnd()
	{
		bool ret = MoveSquareToPos(_physicsStartTime, _physicsDirection,
				_physicsPreEndPos, _physicsEndPos,
				_physicsPreEndToEndDist, _physicsLongestDist,
				DECELERATION_RATE_PRE_END_TO_END);

		if (ret == true)
		{
			PushMoveToStack(_physicsEndPos);
		}

		return ret;
	}

	private void UndoSquarePos()
	{
		PopMoveFromStack();

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			SetMapSquarePos(i, _physicsSquarePos[i].x, _physicsSquarePos[i].y);
		}
	}

	private void ResetSquarePos()
	{
		ResetMoveInStack();

		for (int i = 0; i < NUM_SQUARE; i++)
		{
			SetMapSquarePos(i, _physicsSquarePos[i].x, _physicsSquarePos[i].y);
		}
	}

	// Touch

	private const float TOUCH_DIRECTION_MULTIPLIER = 1.5f;
	private const float TOUCH_DIRECTION_OFFSET = 20.0f;

	private const float TOUCH_HOLD_TIME = 0.7f;

	private enum TouchState
	{
		NONE,
		START,
		START_TO_END,
		START_TO_PRE_END,
		PRE_END_TO_END,
		WIN,
		LOAD_AD,
		AD,
		WIN_LOAD_AD,
		WIN_AD,
	};

	private TouchState _touchState;
	private bool _touchPause;
	private bool _touchHint;

	private Vector2 _touchStartPos;
	private float _touchStartTime;

	private float _touchLoadAdStartTime;

	private void SetupTouch()
	{
		_touchState = TouchState.NONE;
		_touchPause = false;
		_touchHint = false;
	}

	private Vector2 CalculateTouchDirection(Vector2 start, Vector2 end, float multiplier, float offset)
	{
		Vector2 dist = end - start;

		if ((Mathf.Abs(dist.y) > Mathf.Abs(dist.x) * multiplier) && (Mathf.Abs(dist.y) > offset))
		{
			if (dist.y > 0.0f)
			{
				return DIRECTION_UP;
			}
			else if (dist.y < 0.0f)
			{
				return DIRECTION_DOWN;
			}
		}
		else if ((Mathf.Abs(dist.x) > Mathf.Abs(dist.y) * multiplier) && (Mathf.Abs(dist.x) > offset))
		{
			if (dist.x > 0.0f)
			{
				return DIRECTION_RIGHT;
			}
			else if (dist.x < 0.0f)
			{
				return DIRECTION_LEFT;
			}
		}

		return DIRECTION_NONE;
	}

	private void DoTouchStateNone()
	{
		if (_touchPause == true)
		{
			return;
		}

		if (Input.touchCount != 1)
		{
			_ui.SetInteractableControlButton(true);
			return;
		}

		Touch touch = Input.GetTouch(0);

		if (touch.phase != TouchPhase.Began)
		{
			_ui.SetInteractableControlButton(true);
			return;
		}

		// Check if user is touching any UI elements
		if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
		{
			_ui.SetInteractableControlButton(true);
			return;
		}

		_ui.SetInteractableControlButton(false);

		_touchStartPos = touch.position;
		_touchStartTime = Time.time;
		_touchState = TouchState.START;
	}

	private void DoTouchStateStart()
	{
		Vector2 direction;

		if (Input.touchCount != 1)
		{
			_ui.SetInteractableControlButton(true);
			_touchState = TouchState.NONE;
			return;
		}

		Touch touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began)
		{
			_ui.SetInteractableControlButton(true);
			_touchState = TouchState.NONE;
			return;
		}

		if (touch.phase == TouchPhase.Ended)
		{
			// Move cube in a certain direction

			direction = CalculateTouchDirection(
					_touchStartPos,
					touch.position,
					TOUCH_DIRECTION_MULTIPLIER,
					TOUCH_DIRECTION_OFFSET);

			if (direction == DIRECTION_NONE)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}

			if (GetSquareMoveCount() >= MAX_MOVE_COUNT)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}

			if (_touchHint && CheckHintDirection(direction) == false)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}

			if (StartSquareMovement(direction) == false)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}

			if (IsSquareEndPosWinning() == true)
			{
				_ui.SetInteractableControlButton(false);
				_touchState = TouchState.START_TO_PRE_END;
				return;
			}
			else
			{
				_ui.SetInteractableControlButton(false);
				_touchState = TouchState.START_TO_END;
				return;
			}
		}
		else
		{
			// Hold to cancel

			if (Time.time - _touchStartTime > TOUCH_HOLD_TIME)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}
		}
	}

	private void DoTouchStateStartToEnd()
	{
		if (MoveSquareFromStartToEnd() == true)
		{
			int move = GetSquareMoveCount();

			_ui.SetTopMoveCurrent(move);
			_ui.SetInteractableControlButton(true);

			if (_touchHint)
			{
				_ui.SetHintDirection(_levelMap._hint[move]);
			}

			_touchState = TouchState.NONE;
		}
	}

	private void DoTouchStateStartToPreEnd()
	{
		if (MoveSquareFromStartToPreEnd() == true)
		{
			_touchState = TouchState.PRE_END_TO_END;
		}
	}

	private void DoTouchStatePreEndToEnd()
	{
		if (MoveSquareFromPreEndToEnd() == true)
		{
			int move = GetSquareMoveCount();
			int star = 1;

			if (move == _levelMap._hint.Length)
			{
				star = 3;
			}
			else if (move == _levelMap._hint.Length + 1)
			{
				star = 2;
			}

			if (star > _data.GetLevelStar(_menuColor, _menuAlphabet, _menuMap))
			{
				_ui.SetTopStar(star);
				_data.SetLevelStar(_menuColor, _menuAlphabet, _menuMap, star);
			}

			if (_touchHint)
			{
				_touchHint = false;
				_ui.SetActiveControlHintOnPanel(false);
				_ui.SetActiveControlHintOffPanel(true);
				_ui.SetActiveHintPanel(false);
			}

			int moveCount = GetSquareMoveCount();

			_ui.SetTopMoveCurrent(moveCount);

			if (moveCount > _data.GetLevelMove(_menuColor, _menuAlphabet, _menuMap))
			{
				_data.SetLevelMove(_menuColor, _menuAlphabet, _menuMap, moveCount);
				_ui.SetTopMoveBest(moveCount);
			}

			_ui.SetEnableControlButton(false);
			_ui.SetActiveWinPanel(true);
			_ui.SetWinStar(star);

			if ((_menuColor >= _level.GetNumColor() - 1) &&
					(_menuAlphabet >= _level.GetNumAlphabet(_menuColor) - 1) &&
					(_menuMap >= _level.GetNumMap(_menuColor, _menuAlphabet) - 1))
			{
				_ui.SetInteractableWinNextButton(false);
			}
			else
			{
				_ui.SetInteractableWinNextButton(true);
			}

			_touchState = TouchState.WIN;
		}
	}

	private void DoTouchStateWin()
	{
	}

	private void DoTouchStateLoadAd()
	{
		_ad.ClearRewardStatus();

		if (_ad.ShowRewarded() == 0)
		{
			_ui.SetActiveAdLoadPanel(false);
			_touchState = TouchState.AD;
		}
		else if (Time.time - _touchLoadAdStartTime > MAX_AD_LOAD_TIME)
		{
			_ui.SetActiveAdLoadPanel(false);
			_ui.SetActiveAdFailPanel(true);
			_touchState = TouchState.NONE;
		}
	}

	private void DoTouchStateAd()
	{
		AdManager.RewardStatus status = _ad.GetRewardStatus();

		if (status == AdManager.RewardStatus.SUCCESS)
		{
			_data.SetHint(_data.GetHint() + 1);
			_ui.SetControlHintCount(_data.GetHint());
			_ui.SetActiveControlHintAdPanel(false);
			_ui.SetActiveControlHintOnPanel(false);
			_ui.SetActiveControlHintOffPanel(true);
			_ui.SetActiveAdSuccessPanel(true);
			_touchState = TouchState.NONE;
		}
		else if (status == AdManager.RewardStatus.FAIL)
		{
			_ui.SetActiveAdAbortPanel(true);
			_touchState = TouchState.NONE;
		}
	}

	private void DoTouchStateWinLoadAd()
	{
		_ad.ClearRewardStatus();

		if (_ad.ShowRewarded() == 0)
		{
			_ui.SetActiveAdLoadPanel(false);
			_touchState = TouchState.WIN_AD;
		}
		else if (Time.time - _touchLoadAdStartTime > MAX_AD_LOAD_TIME)
		{
			_ui.SetActiveAdLoadPanel(false);
			_ui.SetActiveAdFailPanel(true);
			_touchState = TouchState.WIN;
		}
	}

	private void DoTouchStateWinAd()
	{
		AdManager.RewardStatus status = _ad.GetRewardStatus();

		if (status == AdManager.RewardStatus.SUCCESS)
		{
			_data.SetHint(_data.GetHint() + 1);
			_ui.SetControlHintCount(_data.GetHint());
			_ui.SetActiveControlHintAdPanel(false);
			_ui.SetActiveControlHintOnPanel(false);
			_ui.SetActiveControlHintOffPanel(true);
			_ui.SetActiveAdSuccessPanel(true);
			_touchState = TouchState.WIN;
		}
		else if (status == AdManager.RewardStatus.FAIL)
		{
			_ui.SetActiveAdAbortPanel(true);
			_touchState = TouchState.WIN;
		}
	}

	// UI - Top

	private void SetupTop()
	{
		_ui.SetTopColor(_menuColor);
		_ui.SetTopAlphabet(_menuAlphabet);
		_ui.SetTopMap(_menuMap);

		_ui.SetTopMoveCurrent(0);
		_ui.SetTopMoveTarget(_levelMap._hint.Length);
		_ui.SetTopMoveBest(_data.GetLevelMove(_menuColor, _menuAlphabet, _menuMap));

		_ui.SetTopStar(_data.GetLevelStar(_menuColor, _menuAlphabet, _menuMap));
	}

	// UI - Hint

	private void SetupHint()
	{
		_ui.SetActiveHintPanel(false);
	}

	// UI - Control

	private void SetupControl()
	{
		_ui.SetEnableControlButton(true);
		_ui.SetInteractableControlButton(true);

		_ui.SetControlHintCount(_data.GetHint());

		if (_data.GetHint() > 0)
		{
			_ui.SetActiveControlHintAdPanel(false);
			_ui.SetActiveControlHintOnPanel(false);
			_ui.SetActiveControlHintOffPanel(true);
		}
		else
		{
			_ui.SetActiveControlHintAdPanel(true);
			_ui.SetActiveControlHintOnPanel(false);
			_ui.SetActiveControlHintOffPanel(false);
		}
	}

	public void DoControlPauseButtonPressed()
	{
		_touchPause = true;
		_ui.SetEnableControlButton(false);
		_ui.SetActivePausePanel(true);
	}

	public void DoControlUndoButtonPressed()
	{
		UndoSquarePos();

		int move = GetSquareMoveCount();
		_ui.SetTopMoveCurrent(move);

		if (_touchHint == true)
		{
			_ui.SetHintDirection(_levelMap._hint[move]);
		}
	}

	public void DoControlResetButtonPressed()
	{
		ResetSquarePos();

		int move = GetSquareMoveCount();
		_ui.SetTopMoveCurrent(move);

		if (_touchHint == true)
		{
			_ui.SetHintDirection(_levelMap._hint[move]);
		}
	}

	public void DoControlHintAdButtonPressed()
	{
		_ui.SetActiveAdLoadPanel(true);
		_touchLoadAdStartTime = Time.time;
		_touchState = TouchState.LOAD_AD;
	}

	public void DoControlHintOnButtonPressed()
	{
		_touchHint = false;
		_ui.SetActiveControlHintOnPanel(false);
		_ui.SetActiveControlHintOffPanel(true);
		_ui.SetActiveHintPanel(false);
	}

	public void DoControlHintOffButtonPressed()
	{
		_touchHint = true;



		_ui.SetActiveControlHintOffPanel(false);
		_ui.SetActiveControlHintOnPanel(true);

		if (_hintUsed == false)
		{
			_data.SetHint(_data.GetHint() - 1);
			_ui.SetControlHintCount(_data.GetHint());
			_hintUsed = true;
		}

		ResetSquarePos();
		int move = GetSquareMoveCount();

		_ui.SetTopMoveCurrent(move);
		_ui.SetActiveHintPanel(true);
		_ui.SetHintDirection(_levelMap._hint[move]);

	}

	// UI - Pause

	private void SetupPause()
	{
		_ui.SetActivePausePanel(false);
	}

	public void DoPauseMenuButtonPressed()
	{
		SceneManager.LoadScene("MapMenuScene");
	}

	public void DoPauseResumeButtonPressed()
	{
		_ui.SetActivePausePanel(false);
		_ui.SetEnableControlButton(true);
		_touchPause = false;
	}

	// UI - Win

	private void SetupWin()
	{
		_ui.SetActiveWinPanel(false);
		_ui.SetWinColor(_menuColor);
	}

	public void DoWinHintButtonPressed()
	{
		_ui.SetActiveWinPanel(false);
		_ui.SetActiveAdLoadPanel(true);
		_touchLoadAdStartTime = Time.time;
		_touchState = TouchState.WIN_LOAD_AD;
	}

	public void DoWinMenuButtonPressed()
	{
		SceneManager.LoadScene("MapMenuScene");
	}

	public void DoWinReplayButtonPressed()
	{
		SceneManager.LoadScene("LevelScene");
	}

	public void DoWinNextButtonPressed()
	{
		int nextColor = _menuColor;
		int nextAlphabet = _menuAlphabet;
		int nextMap = _menuMap;

		nextMap += 1;

		if (nextMap >= _level.GetNumMap(_menuColor, _menuAlphabet))
		{
			nextMap = 0;
			nextAlphabet += 1;

			if (nextAlphabet >= _level.GetNumAlphabet(_menuColor))
			{
				nextAlphabet = 0;
				nextColor += 1;
			}
		}

		_data.SetMenuColor(nextColor);
		_data.SetMenuAlphabet(nextAlphabet);
		_data.SetMenuMap(nextMap);

		SceneManager.LoadScene("LevelScene");
	}

	// UI - AdLoad

	private void SetupAdLoad()
	{
		_ui.SetActiveAdLoadPanel(false);
	}

	// UI - AdSuccess

	private void SetupAdSuccess()
	{
		_ui.SetActiveAdSuccessPanel(false);
	}

	public void DoAdSuccessCloseButtonPressed()
	{
		_ui.SetActiveAdSuccessPanel(false);

		if (_touchState == TouchState.WIN)
		{
			_ui.SetActiveWinPanel(true);
		}
	}

	// UI - AdAbort

	private void SetupAdAbort()
	{
		_ui.SetActiveAdAbortPanel(false);
	}

	public void DoAdAbortCloseButtonPressed()
	{
		_ui.SetActiveAdAbortPanel(false);

		if (_touchState == TouchState.WIN)
		{
			_ui.SetActiveWinPanel(true);
		}
	}

	// UI - AdFail

	private void SetupAdFail()
	{
		_ui.SetActiveAdFailPanel(false);
	}

	public void DoAdFailCloseButtonPressed()
	{
		_ui.SetActiveAdFailPanel(false);

		if (_touchState == TouchState.WIN)
		{
			_ui.SetActiveWinPanel(true);
		}
	}

	// Unity Lifecyle

	private void Awake()
	{
		_ui = GameObject.Find("LevelUI").GetComponent<LevelUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_event = GameObject.Find("EventManager").GetComponent<EventManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();

		FindMapGameObject();
	}

	private void Start()
	{
		_menuColor = _data.GetMenuColor();
		_menuAlphabet = _data.GetMenuAlphabet();
		_menuMap = _data.GetMenuMap();

		_levelMap = _level.GetMap(_menuColor, _menuAlphabet, _menuMap);

		_hintUsed = false;

		_data.SetLastColor(_menuColor);
		_data.SetLastAlphabet(_menuAlphabet);
		_data.SetLastMap(_menuMap);

		SetupMap();	// SetupMap() must preceed SetupPhysics()
		SetupPhysics();
		SetupTouch();
		SetupTop();
		SetupHint();
		SetupControl();
		SetupPause();
		SetupWin();
		SetupAdLoad();
		SetupAdSuccess();
		SetupAdAbort();
		SetupAdFail();
	}

	private void Update()
	{
		if (_touchState == TouchState.NONE)
		{
			DoTouchStateNone();
		}
		else if (_touchState == TouchState.START)
		{
			DoTouchStateStart();
		}
		else if (_touchState == TouchState.START_TO_END)
		{
			DoTouchStateStartToEnd();
		}
		else if (_touchState == TouchState.START_TO_PRE_END)
		{
			DoTouchStateStartToPreEnd();
		}
		else if (_touchState == TouchState.PRE_END_TO_END)
		{
			DoTouchStatePreEndToEnd();
		}
		else if (_touchState == TouchState.WIN)
		{
			DoTouchStateWin();
		}
		else if (_touchState == TouchState.LOAD_AD)
		{
			DoTouchStateLoadAd();
		}
		else if (_touchState == TouchState.AD)
		{
			DoTouchStateAd();
		}
		else if (_touchState == TouchState.WIN_LOAD_AD)
		{
			DoTouchStateWinLoadAd();
		}
		else if (_touchState == TouchState.WIN_AD)
		{
			DoTouchStateWinAd();
		}
	}
}
