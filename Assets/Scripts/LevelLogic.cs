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

	public delegate void AnimateComplete();

	// Map

	private const float MAP_ANIMATE_WALL_ENTER_ROTATION = 180.0f;
	private const float MAP_ANIMATE_WALL_ENTER_TIME = 0.4f;
	private const float MAP_ANIMATE_SQUARE_ENTER_TIME = 0.4f;

	private const float MAP_ANIMATE_WALL_EXIT_ROTATION = 720.0f;
	private const float MAP_ANIMATE_WALL_EXIT_INITIAL_SPEED = 30.0f;
	private const float MAP_ANIMATE_WALL_EXIT_SPEED_MULTIPLIER = 0.6f;
	private const float MAP_ANIMATE_WALL_EXIT_TIME = 1.5f;

	private GameObject[,] _mapWall;
	private GameObject[,] _mapWallShadow;
	private GameObject[] _mapSquare;
	private GameObject[] _mapSquareShadow;

	private float _mapXOffset;
	private float _mapYOffset;

	Vector2[,] _mapWallOriginalPos;
	float[,] _mapWallExitAngle;

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

	private void AnimateSquareEnter(int square)
	{
		LeanTween.cancel(_mapSquare[square]);

		// Animate scale

		_mapSquare[square].transform.localScale = new Vector3(0, 0, 0);
		_mapSquareShadow[square].transform.localScale = new Vector3(0, 0, 0);

		LeanTween.scale(_mapSquare[square], Vector3.one, MAP_ANIMATE_SQUARE_ENTER_TIME).setEase(LeanTweenType.easeOutSine);
		LeanTween.scale(_mapSquareShadow[square], Vector3.one, MAP_ANIMATE_SQUARE_ENTER_TIME).setEase(LeanTweenType.easeOutSine);
	}

	private void AnimateWallEnter(int x, int y)
	{
		LeanTween.cancel(_mapWall[x, y]);

		// Animate scale

		_mapWall[x, y].transform.localScale = new Vector3(0, 0, 0);
		_mapWallShadow[x, y].transform.localScale = new Vector3(0, 0, 0);

		LeanTween.scale(_mapWall[x, y], Vector3.one, MAP_ANIMATE_WALL_ENTER_TIME).setEase(LeanTweenType.easeOutSine);
		LeanTween.scale(_mapWallShadow[x, y], Vector3.one, MAP_ANIMATE_WALL_ENTER_TIME).setEase(LeanTweenType.easeOutSine);

		// Animate rotation

		_mapWall[x, y].transform.eulerAngles = new Vector3(0, 0, MAP_ANIMATE_WALL_ENTER_ROTATION);
		_mapWallShadow[x, y].transform.eulerAngles = new Vector3(0, 0, MAP_ANIMATE_WALL_ENTER_ROTATION);

		LeanTween.rotateAround(_mapWall[x, y], Vector3.forward, -MAP_ANIMATE_WALL_ENTER_ROTATION, MAP_ANIMATE_WALL_ENTER_TIME);
		LeanTween.rotateAround(_mapWallShadow[x, y], Vector3.forward, -MAP_ANIMATE_WALL_ENTER_ROTATION, MAP_ANIMATE_WALL_ENTER_TIME);
	}

	private void AnimateMapEnter(AnimateComplete callback)
	{
		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				sbyte tile = _levelMap._layout[Level.NUM_ROW - j - 1, i];

				if (Level.IsSquare(tile))
				{
					int n = Level.GetSquareNumber(tile);
					AnimateSquareEnter(n);
                                }
				else if (Level.IsWall(tile))
				{
					AnimateWallEnter(i, j);
				}
			}
		}

		LeanTween.value(gameObject, 0.0f, 0.0f, MAP_ANIMATE_WALL_ENTER_TIME).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	void AnimateMapExit(AnimateComplete callback)
	{
		_mapWallOriginalPos = new Vector2[NUM_X, NUM_Y];
		_mapWallExitAngle = new float[NUM_X, NUM_Y];

		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				sbyte tile = _levelMap._layout[Level.NUM_ROW - j - 1, i];

				if (Level.IsWall(tile) == false)
				{
					continue;
				}

				_mapWall[i, j].GetComponent<SpriteRenderer>().sortingLayerName = "WallExit";
				_mapWallOriginalPos[i, j] = _mapWall[i, j].transform.position;
				_mapWallExitAngle[i, j] = Mathf.Atan(_mapWallOriginalPos[i, j].x / (_mapWallOriginalPos[i, j].y + 16.5F));

				LeanTween.cancel(_mapWall[i, j]);
				LeanTween.cancel(_mapWallShadow[i, j]);

				// Rotation

				if (i < NUM_X / 2)
				{
					LeanTween.rotateAround(_mapWall[i, j], Vector3.forward, -MAP_ANIMATE_WALL_EXIT_ROTATION, MAP_ANIMATE_WALL_EXIT_TIME);
					LeanTween.rotateAround(_mapWallShadow[i, j], Vector3.forward, -MAP_ANIMATE_WALL_EXIT_ROTATION, MAP_ANIMATE_WALL_EXIT_TIME);
				}
				else
				{
					LeanTween.rotateAround(_mapWall[i, j], Vector3.back, -MAP_ANIMATE_WALL_EXIT_ROTATION, MAP_ANIMATE_WALL_EXIT_TIME);
					LeanTween.rotateAround(_mapWallShadow[i, j], Vector3.back, -MAP_ANIMATE_WALL_EXIT_ROTATION, MAP_ANIMATE_WALL_EXIT_TIME);
				}

			}
		}

		// Parabolic movement

		LeanTween.value(gameObject, 0.0f, MAP_ANIMATE_WALL_EXIT_TIME, MAP_ANIMATE_WALL_EXIT_TIME).setOnUpdate
		(
			(float duration) =>
			{
				float durationMod = duration * MAP_ANIMATE_WALL_EXIT_SPEED_MULTIPLIER;

				for (int i = 0; i < NUM_X; i++)
				{
					for (int j = 0; j < NUM_Y; j++)
					{
						Vector2 distance = new Vector2(MAP_ANIMATE_WALL_EXIT_INITIAL_SPEED * Mathf.Sin(_mapWallExitAngle[i, j]) * durationMod,
								(MAP_ANIMATE_WALL_EXIT_INITIAL_SPEED * Mathf.Cos(_mapWallExitAngle[i, j]) - 90.0F * durationMod) * durationMod);

						_mapWall[i, j].transform.position = _mapWallOriginalPos[i, j] + distance;
						_mapWallShadow[i, j].transform.position = _mapWallOriginalPos[i, j] + distance;
					}
				}
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
		WAIT,
		NONE,
		START,
		START_TO_END,
		START_TO_PRE_END,
		PRE_END_TO_END,
		PAUSE,
		WIN,
		LOAD_AD,
		AD,
		PAUSE_LOAD_AD,
		PAUSE_AD,
		WIN_LOAD_AD,
		WIN_AD,
	};

	private TouchState _touchState;
	private bool _touchHint;

	private Vector2 _touchStartPos;
	private float _touchStartTime;

	private float _touchLoadAdStartTime;

	private void SetupTouch()
	{
		_touchState = TouchState.WAIT;
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

	private void DoTouchStateWait()
	{
	}

	private void DoTouchStateNone()
	{
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
				_ui.SetActiveHintDirectionPanel(_levelMap._hint[move]);
				AnimateHintDirectionStop();
				AnimateHintDirectionStart(_levelMap._hint[move]);
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

			int currentStar = _data.GetLevelStar(_menuColor, _menuAlphabet, _menuMap);

			if (star > currentStar)
			{
				_data.SetLevelStar(_menuColor, _menuAlphabet, _menuMap, star);

				int currentAlphabetStar = _data.GetAlphabetStar(_menuColor, _menuAlphabet);
				_data.SetAlphabetStar(_menuColor, _menuAlphabet, currentAlphabetStar + (star - currentStar));

				int currentColorStar = _data.GetColorStar(_menuColor);
				_data.SetColorStar(_menuColor, currentColorStar + (star - currentStar));
			}

			if (_touchHint)
			{
				_touchHint = false;
				_ui.SetActiveControlHintOnPanel(false);
				_ui.SetActiveControlHintOffPanel(true);

				_ui.SetActiveHintPanel(false);
				AnimateHintDirectionStop();
			}

			int moveCount = GetSquareMoveCount();
			_ui.SetTopMoveCurrent(moveCount);
			if (moveCount > _data.GetLevelMove(_menuColor, _menuAlphabet, _menuMap))
			{
				_data.SetLevelMove(_menuColor, _menuAlphabet, _menuMap, moveCount);
				_ui.SetTopMoveBest(moveCount);
			}

			int nextColor = _menuColor;
			int nextAlphabet = _menuAlphabet;
			int nextMap = _menuMap + 1;
			bool enableNext;

			if (nextMap >= _level.GetNumMap(_menuColor, _menuAlphabet))
			{
				nextMap = 0;
				nextAlphabet += 1;
			}

			if (nextAlphabet >= _level.GetNumAlphabet(_menuColor))
			{
				nextAlphabet = 0;
				nextColor += 1;
			}

			if (nextColor >= _level.GetNumColor())
			{
				enableNext = false;
			}
			else
			{
				enableNext = true;
				_data.SetLevelLock(nextColor, nextAlphabet, nextMap, 0);
			}

			_ui.SetEnableControlButton(false);
			_touchState = TouchState.WIN;

			AnimateMapExit(
				()=>
				{
					_ui.SetActiveWinPanel(true);
					_ui.SetInteractableWinButton(false);
					_ui.SetInteractableWinNextButton(false);

					AnimateWinBoardEnter(
						()=>
						{
							AnimateWinStarEnter(star,
								()=>
								{
									_ui.SetInteractableWinButton(true);
									_ui.SetInteractableWinNextButton(enableNext);
								}
							);
						}
					);
				}
			);
		}
	}

	private void DoTouchStatePause()
	{
	}

	private void DoTouchStateWin()
	{
	}

	private void CommonLoadAd(TouchState adState, TouchState postAdState)
	{
		_ad.ClearRewardStatus();

		if (_ad.ShowRewarded() == 0)
		{
			AnimateLoadSquareStop();
			_ui.SetActiveLoadPanel(false);
			_touchState = adState;
		}
		else if (Time.time - _touchLoadAdStartTime > MAX_AD_LOAD_TIME)
		{
			AnimateLoadSquareStop();
			_ui.SetActiveLoadPanel(false);
			_ui.SetActiveAdFailPanel(true);
			_ui.SetInteractableAdFailButton(false);
			AnimateAdFailBoardEnter
			(
				()=>
				{
					_ui.SetInteractableAdFailButton(true);
				}
			);
			_touchState = postAdState;
		}
	}

	private void CommonAd(TouchState postAdState)
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
			_ui.SetActiveAdSuccessHintPanel(false);
			_ui.SetInteractableAdSuccessButton(false);
			AnimateAdSuccessBoardEnter
			(
				()=>
				{
					_ui.SetActiveAdSuccessHintPanel(true);
					AnimateAdSuccessHintEnter
					(
						()=>
						{
							_ui.SetInteractableAdSuccessButton(true);
						}
					);
				}
			);
			_touchState = postAdState;
		}
		else if (status == AdManager.RewardStatus.FAIL)
		{
			_ui.SetActiveAdAbortPanel(true);
			_ui.SetInteractableAdAbortButton(false);
			AnimateAdAbortBoardEnter
			(
				()=>
				{
					_ui.SetInteractableAdAbortButton(true);
				}
			);
			_touchState = postAdState;
		}
	}

	private void DoTouchStateLoadAd()
	{
		CommonLoadAd(TouchState.AD, TouchState.NONE);
	}

	private void DoTouchStateAd()
	{
		CommonAd(TouchState.NONE);
	}

	private void DoTouchStatePauseLoadAd()
	{
		CommonLoadAd(TouchState.PAUSE_AD, TouchState.PAUSE);
	}

	private void DoTouchStatePauseAd()
	{
		CommonAd(TouchState.PAUSE);
	}

	private void DoTouchStateWinLoadAd()
	{
		CommonLoadAd(TouchState.WIN_AD, TouchState.WIN);
	}

	private void DoTouchStateWinAd()
	{
		CommonAd(TouchState.WIN);
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

		int star = _data.GetLevelStar(_menuColor, _menuAlphabet, _menuMap);

		for (int i = 0; i < 3; i++)
		{
			if (i < star)
			{
				_ui.SetActiveTopStar(i, true);
			}
			else
			{
				_ui.SetActiveTopStar(i, false);
			}
		}
	}

	// UI - Hint

	private const float HINT_ANIMATE_DIRECTION_TIME = 0.75f;

	private void SetupHint()
	{
		_ui.SetActiveHintPanel(false);
	}

	private void AnimateHintDirectionStop()
	{
		_ui.AnimateHintDirectionStop();
	}

	private void AnimateHintDirectionStart(char direction)
	{
		_ui.AnimateHintDirectionStart(direction, HINT_ANIMATE_DIRECTION_TIME);
	}

	// UI - Control

	private void SetupControl()
	{
		_ui.SetEnableControlButton(false);
		_ui.SetInteractableControlButton(false);

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
		_touchState = TouchState.PAUSE;
		_ui.SetEnableControlButton(false);
		_ui.SetActivePausePanel(true);
		_ui.SetInteractablePauseButton(false);

		if (_touchHint == true)
		{
			_touchHint = false;

			_ui.SetActiveControlHintOnPanel(false);
			_ui.SetActiveControlHintOffPanel(true);

			AnimateHintDirectionStop();
			_ui.SetActiveHintPanel(false);
		}

		AnimatePauseBoardEnter
		(
			()=>
			{
				_ui.SetInteractablePauseButton(true);
			}
		);
	}

	public void DoControlUndoButtonPressed()
	{
		UndoSquarePos();

		int move = GetSquareMoveCount();
		_ui.SetTopMoveCurrent(move);

		if (_touchHint == true)
		{
			_ui.SetActiveHintDirectionPanel(_levelMap._hint[move]);
			AnimateHintDirectionStop();
			AnimateHintDirectionStart(_levelMap._hint[move]);
		}
	}

	public void DoControlResetButtonPressed()
	{
		ResetSquarePos();

		int move = GetSquareMoveCount();
		_ui.SetTopMoveCurrent(move);

		if (_touchHint == true)
		{
			_ui.SetActiveHintDirectionPanel(_levelMap._hint[move]);
			AnimateHintDirectionStop();
			AnimateHintDirectionStart(_levelMap._hint[move]);
		}
	}

	public void DoControlHintAdButtonPressed()
	{
		_ui.SetActiveLoadPanel(true);
		AnimateLoadSquareStart();
		_touchLoadAdStartTime = Time.time;
		_touchState = TouchState.LOAD_AD;
	}

	public void DoControlHintOnButtonPressed()
	{
		_touchHint = false;

		_ui.SetActiveControlHintOnPanel(false);
		_ui.SetActiveControlHintOffPanel(true);

		AnimateHintDirectionStop();
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
		_ui.SetActiveHintDirectionPanel(_levelMap._hint[move]);
		AnimateHintDirectionStop();
		AnimateHintDirectionStart(_levelMap._hint[move]);
	}

	// UI - Go

	private const float GO_ANIMATE_BANNER_ENTER_EXIT_TIME = 0.3f;
	private const float GO_ANIMATE_LABEL_ENTER_EXIT_TIME = 0.3f;

	private const float GO_ANIMATE_BANNER_ENTER_DELAY = MAP_ANIMATE_WALL_ENTER_TIME + 0.1f;
	private const float GO_ANIMATE_LABEL_ENTER_DELAY = 0.3f;
	private const float GO_ANIMATE_LABEL_EXIT_DELAY = 0.5f;

	private void SetupGo()
	{
		_ui.SetActiveGoPanel(false);
	}

	private void AnimateGoEnterAndExit(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.SetActiveGoPanel(true);

		_ui.AnimateGoEnterAndExit(GO_ANIMATE_LABEL_ENTER_EXIT_TIME, GO_ANIMATE_LABEL_ENTER_EXIT_TIME,
				GO_ANIMATE_BANNER_ENTER_DELAY, GO_ANIMATE_LABEL_ENTER_DELAY, GO_ANIMATE_LABEL_EXIT_DELAY,
				uiCallback);
	}

	// UI - Pause

	private const float PAUSE_ANIMATE_BOARD_ENTER_TIME = 0.3f;
	private const float PAUSE_ANIMATE_BOARD_EXIT_TIME = 0.3f;

	private void SetupPause()
	{
		_ui.SetActivePausePanel(false);
	}

	private void AnimatePauseBoardEnter(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimatePauseBoardEnter(PAUSE_ANIMATE_BOARD_ENTER_TIME, uiCallback);
	}

	private void AnimatePauseBoardExit(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimatePauseBoardExit(PAUSE_ANIMATE_BOARD_EXIT_TIME, uiCallback);
	}

	public void DoPauseMenuButtonPressed()
	{
		SceneManager.LoadScene("MapMenuScene");
	}

	public void DoPauseHintAdButtonPressed()
	{
		_ui.SetInteractablePauseButton(false);

		AnimatePauseBoardExit(
			()=>
			{
				_ui.SetActivePausePanel(false);
				_ui.SetActiveLoadPanel(true);
				AnimateLoadSquareStart();
				_touchLoadAdStartTime = Time.time;
				_touchState = TouchState.PAUSE_LOAD_AD;
			}
		);
	}

	public void DoPauseResumeButtonPressed()
	{
		_ui.SetInteractablePauseButton(false);

		AnimatePauseBoardExit(
			()=>
			{
				_ui.SetActivePausePanel(false);
				_ui.SetEnableControlButton(true);
				_touchState = TouchState.NONE;
			}
		);
	}

	// UI - Win

	private const float WIN_ANIMATE_BOARD_ENTER_TIME = 0.3f;
	private const float WIN_ANIMATE_BOARD_EXIT_TIME = 0.3f;

	private const float WIN_ANIMATE_STAR_ENTER_TIME = 0.2f;

	private void SetupWin()
	{
		_ui.SetActiveWinPanel(false);

		for (int i = 0; i < 3; i++)
		{
			_ui.SetActiveWinStarPanel(i, false);
		}
	}

	private void AnimateWinBoardEnter(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateWinBoardEnter(WIN_ANIMATE_BOARD_ENTER_TIME, uiCallback);
	}

	private void AnimateWinBoardExit(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateWinBoardExit(WIN_ANIMATE_BOARD_EXIT_TIME, uiCallback);
	}

	private void AnimateWinStarEnter(int star, AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateWinStarEnter(star, WIN_ANIMATE_STAR_ENTER_TIME, uiCallback);
	}

	public void DoWinHintAdButtonPressed()
	{
		_ui.SetInteractableWinButton(false);

		AnimateWinBoardExit
		(
			()=>
			{
				_ui.SetActiveWinPanel(false);
				_ui.SetActiveLoadPanel(true);
				AnimateLoadSquareStart();
				_touchLoadAdStartTime = Time.time;
				_touchState = TouchState.WIN_LOAD_AD;
			}
		);
	}

	public void DoWinMenuButtonPressed()
	{
		_ui.SetInteractableWinButton(false);

		AnimateWinBoardExit
		(
			()=>
			{
				SceneManager.LoadScene("MapMenuScene");
			}
		);
	}

	public void DoWinReplayButtonPressed()
	{
		_ui.SetInteractableWinButton(false);

		AnimateWinBoardExit
		(
			()=>
			{
				SceneManager.LoadScene("LevelScene");
			}
		);
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

		_ui.SetInteractableWinButton(false);

		AnimateWinBoardExit
		(
			()=>
			{
				SceneManager.LoadScene("LevelScene");
			}
		);
	}

	// UI - Load

	private const float LOAD_ANIMATE_SQUARE_PUNCH_TIME = 0.5f;

	private void SetupLoad()
	{
		_ui.SetActiveLoadPanel(false);
	}

	private void AnimateLoadSquareStart()
	{
		_ui.AnimateLoadSquareStart(LOAD_ANIMATE_SQUARE_PUNCH_TIME);
	}

	private void AnimateLoadSquareStop()
	{
		_ui.AnimateLoadSquareStop();
	}

	// UI - AdSuccess

	private const float AD_SUCCESS_ANIMATE_BOARD_ENTER_TIME = 0.3f;
	private const float AD_SUCCESS_ANIMATE_BOARD_EXIT_TIME = 0.3f;

	private const float AD_SUCCESS_ANIMATE_HINT_ENTER_TIME = 0.5f;

	private void SetupAdSuccess()
	{
		_ui.SetActiveAdSuccessPanel(false);
	}

	private void AnimateAdSuccessBoardEnter(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdSuccessBoardEnter(AD_SUCCESS_ANIMATE_BOARD_ENTER_TIME, uiCallback);
	}

	private void AnimateAdSuccessHintEnter(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdSuccessHintEnter(AD_SUCCESS_ANIMATE_HINT_ENTER_TIME, uiCallback);
	}

	private void AnimateAdSuccessBoardExit(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdSuccessBoardExit(AD_SUCCESS_ANIMATE_BOARD_EXIT_TIME, uiCallback);
	}

	public void DoAdSuccessCloseButtonPressed()
	{
		_ui.SetInteractableAdSuccessButton(false);

		AnimateAdSuccessBoardExit
		(
			()=>
			{
				_ui.SetActiveAdSuccessPanel(false);

				if (_touchState == TouchState.WIN)
				{
					_ui.SetActiveWinPanel(true);

					AnimateWinBoardEnter
					(
						()=>
						{
							_ui.SetInteractableWinButton(true);
						}
					);
				}
				else if (_touchState == TouchState.PAUSE)
				{
					_ui.SetActivePausePanel(true);

					AnimatePauseBoardEnter
					(
						()=>
						{
							_ui.SetInteractablePauseButton(true);
						}
					);
				}
			}
		);
	}

	// UI - AdAbort

	private const float AD_ABORT_ANIMATE_BOARD_ENTER_TIME = 0.3f;
	private const float AD_ABORT_ANIMATE_BOARD_EXIT_TIME = 0.3f;

	private void SetupAdAbort()
	{
		_ui.SetActiveAdAbortPanel(false);
	}

	private void AnimateAdAbortBoardEnter(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdAbortBoardEnter(AD_ABORT_ANIMATE_BOARD_ENTER_TIME, uiCallback);
	}

	private void AnimateAdAbortBoardExit(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdAbortBoardExit(AD_ABORT_ANIMATE_BOARD_EXIT_TIME, uiCallback);
	}

	public void DoAdAbortCloseButtonPressed()
	{
		_ui.SetInteractableAdAbortButton(false);

		AnimateAdAbortBoardExit
		(
			()=>
			{
				_ui.SetActiveAdAbortPanel(false);

				if (_touchState == TouchState.WIN)
				{
					_ui.SetActiveWinPanel(true);

					AnimateWinBoardEnter
					(
						()=>
						{
							_ui.SetInteractableWinButton(true);
						}
					);
				}
				else if (_touchState == TouchState.PAUSE)
				{
					_ui.SetActivePausePanel(true);

					AnimatePauseBoardEnter(
						()=>
						{
							_ui.SetInteractablePauseButton(true);
						}
					);
				}
			}
		);
	}

	// UI - AdFail

	private const float AD_FAIL_ANIMATE_BOARD_ENTER_TIME = 0.3f;
	private const float AD_FAIL_ANIMATE_BOARD_EXIT_TIME = 0.3f;

	private void SetupAdFail()
	{
		_ui.SetActiveAdFailPanel(false);
	}

	private void AnimateAdFailBoardEnter(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdFailBoardEnter(AD_FAIL_ANIMATE_BOARD_ENTER_TIME, uiCallback);
	}

	private void AnimateAdFailBoardExit(AnimateComplete callback)
	{
		LevelUI.AnimateComplete uiCallback = new LevelUI.AnimateComplete(callback);

		_ui.AnimateAdFailBoardExit(AD_FAIL_ANIMATE_BOARD_EXIT_TIME, uiCallback);
	}

	public void DoAdFailCloseButtonPressed()
	{
		_ui.SetInteractableAdFailButton(false);

		AnimateAdFailBoardExit
		(
			()=>
			{
				_ui.SetActiveAdFailPanel(false);

				if (_touchState == TouchState.WIN)
				{
					_ui.SetActiveWinPanel(true);

					AnimateWinBoardEnter
					(
						()=>
						{
							_ui.SetInteractableWinButton(true);
						}
					);
				}
				else if (_touchState == TouchState.PAUSE)
				{
					_ui.SetActivePausePanel(true);

					AnimatePauseBoardEnter(
						()=>
						{
							_ui.SetInteractablePauseButton(true);
						}
					);
				}
			}
		);
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
		SetupGo();
		SetupPause();
		SetupWin();
		SetupLoad();
		SetupAdSuccess();
		SetupAdAbort();
		SetupAdFail();

		AnimateMapEnter
		(
			()=>
			{
				AnimateGoEnterAndExit
				(
					()=>
					{
						_ui.SetEnableControlButton(true);
						_ui.SetInteractableControlButton(true);
						_touchState = TouchState.NONE;
					}
				);
			}
		);
	}

	private void Update()
	{
		if (_touchState == TouchState.WAIT)
		{
			DoTouchStateWait();
		}
		else if (_touchState == TouchState.NONE)
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
		else if (_touchState == TouchState.PAUSE)
		{
			DoTouchStatePause();
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
		else if (_touchState == TouchState.PAUSE_LOAD_AD)
		{
			DoTouchStatePauseLoadAd();
		}
		else if (_touchState == TouchState.PAUSE_AD)
		{
			DoTouchStatePauseAd();
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
