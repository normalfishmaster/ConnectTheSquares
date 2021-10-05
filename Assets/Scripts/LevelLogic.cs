using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLogic : MonoBehaviour
{
	private LevelUI _ui;
	private LoadUI _loadUi;
	private AdUI _adUi;
	private DataManager _data;
	private EventManager _event;
	private LevelManager _level;
	private AudioManager _audio;
	private AdManager _ad;
	private BlockManager _block;

	private int _menuColor;
	private int _menuAlphabet;
	private int _menuMap;

	private Level.Map _levelMap;

	private bool _hintUsed;

	private const int NUM_X = Level.NUM_COL;
	private const int NUM_Y = Level.NUM_ROW;

	private const int NUM_BLOCK = Level.NUM_BLOCK;

	private Vector2 DIRECTION_NONE  = Vector2.zero;
	private Vector2 DIRECTION_UP    = new Vector2( 0.0f,  1.0f);
	private Vector2 DIRECTION_DOWN  = new Vector2( 0.0f, -1.0f);
	private Vector2 DIRECTION_LEFT  = new Vector2(-1.0f,  0.0f);
	private Vector2 DIRECTION_RIGHT = new Vector2( 1.0f,  0.0f);

	private const int MAX_MOVE_COUNT = 999;

	private const float MAX_AD_LOAD_TIME = 5.0f;

	// Map

	public float MAP_ANIMATE_WALL_ENTER_ROTATION;
	public float MAP_ANIMATE_WALL_ENTER_TIME;
	public float MAP_ANIMATE_BLOCK_ENTER_TIME;

	public float MAP_ANIMATE_WALL_EXIT_ROTATION;
	public float MAP_ANIMATE_WALL_EXIT_INITIAL_SPEED;
	public float MAP_ANIMATE_WALL_EXIT_SPEED_MULTIPLIER;
	public float MAP_ANIMATE_WALL_EXIT_TIME;

	private GameObject[,] _mapWall;
	private GameObject[,] _mapWallShadow;
	private GameObject[] _mapBlock;
	private GameObject[] _mapBlockShadow;

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

		// Block

		_mapBlock = new GameObject[Level.NUM_BLOCK];
		_mapBlockShadow = new GameObject[Level.NUM_BLOCK];

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_mapBlock[i] = GameObject.Find("/Map/Block/B" + i);
			_mapBlockShadow[i] = GameObject.Find("/Map/BlockShadow/B" + i);
		}
	}

	private void SetupMap()
	{
		_mapXOffset = -3.5f;
		_mapYOffset = -3.5f;

		SetMapBlockSprite(_block.GetBlockSetNumber());
	}

	private void SetMapBlockSprite(int setNumber)
	{
		for (int i = 0; i < 4; i++)
		{
			_mapBlock[i].GetComponent<SpriteRenderer>().sprite = _block.GetBlockSprite(setNumber, i);
		}
	}

	private void SetMapBlockPos(int block, float x, float y)
	{
		Vector2 pos = new Vector2(_mapXOffset + x, _mapYOffset + y);
		_mapBlock[block].transform.position = pos;
		_mapBlockShadow[block].transform.position = pos;
	}

	private void DisableMapWall(int x, int y)
	{
		_mapWall[x, y].SetActive(false);
		_mapWallShadow[x, y].SetActive(false);
	}

	private void AnimateBlockEnter(int block)
	{
		LeanTween.cancel(_mapBlock[block]);

		// Animate scale

		_mapBlock[block].transform.localScale = new Vector3(0, 0, 0);
		_mapBlockShadow[block].transform.localScale = new Vector3(0, 0, 0);

		LeanTween.scale(_mapBlock[block], Vector3.one, MAP_ANIMATE_BLOCK_ENTER_TIME).setEase(LeanTweenType.easeOutSine);
		LeanTween.scale(_mapBlockShadow[block], Vector3.one, MAP_ANIMATE_BLOCK_ENTER_TIME).setEase(LeanTweenType.easeOutSine);
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

	private void AnimateMapEnter(Animate.AnimateComplete callback)
	{
		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				sbyte tile = _levelMap._layout[Level.NUM_ROW - j - 1, i];

				if (Level.IsBlock(tile))
				{
					int n = Level.GetBlockNumber(tile);
					AnimateBlockEnter(n);
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

	void AnimateMapExit(Animate.AnimateComplete callback)
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
	private Vector2[] _physicsBlockPos;
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
		_physicsBlockPos = new Vector2[Level.NUM_BLOCK];
		_physicsPosStack = new Stack[Level.NUM_BLOCK];

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsPosStack[i] = new Stack();
		}

		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				sbyte tile = _physicsMapLayout[i, j] = _levelMap._layout[Level.NUM_ROW - j - 1, i];

				if (Level.IsBlock(tile))
				{
					int n = Level.GetBlockNumber(tile);
					_physicsBlockPos[n] = new Vector2(i, j);
					_physicsPosStack[n].Push(new Vector2(i, j));
                                        SetMapBlockPos(n, i, j);
                                }

				if (Level.IsBlock(tile) || Level.IsEmpty(tile))
				{
					DisableMapWall(i, j);
				}
			}
		}

		_physicsStartPos = new Vector2[NUM_BLOCK];
		_physicsEndPos = new Vector2[NUM_BLOCK];
		_physicsStartToEndDist = new Vector2[NUM_BLOCK];

		_physicsPreEndPos = new Vector2[NUM_BLOCK];
		_physicsStartToPreEndDist = new Vector2[NUM_BLOCK];
		_physicsPreEndToEndDist = new Vector2[NUM_BLOCK];
	}

	private void PushMoveToStack(Vector2[] pos)
	{
		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsMapLayout[(int)_physicsBlockPos[i].x, (int)_physicsBlockPos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsMapLayout[(int)pos[i].x, (int)pos[i].y] = Level.GetBlock((sbyte)i);
			_physicsBlockPos[i].x = pos[i].x;
			_physicsBlockPos[i].y = pos[i].y;
			_physicsPosStack[i].Push(pos[i]);
		}
	}

	private void PopMoveFromStack()
	{
		if (_physicsPosStack[0].Count == 1)
		{
			return;
		}

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsMapLayout[(int)_physicsBlockPos[i].x, (int)_physicsBlockPos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsPosStack[i].Pop();
			Vector2 pos = (Vector2)_physicsPosStack[i].Peek();

			_physicsMapLayout[(int)pos.x, (int)pos.y] = Level.GetBlock((sbyte)i);
			_physicsBlockPos[i].x = pos.x;
			_physicsBlockPos[i].y = pos.y;
		}
	}

	private void ResetMoveInStack()
	{
		while (_physicsPosStack[0].Count > 1)
		{
			for (int j = 0; j < NUM_BLOCK; j++)
			{
				_physicsPosStack[j].Pop();
			}
		}

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsMapLayout[(int)_physicsBlockPos[i].x, (int)_physicsBlockPos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			Vector2 pos = (Vector2)_physicsPosStack[i].Peek();

			_physicsMapLayout[(int)pos.x, (int)pos.y] = Level.GetBlock((sbyte)i);
			_physicsBlockPos[i].x = pos.x;
			_physicsBlockPos[i].y = pos.y;
		}
	}

	private int GetBlockMoveCount()
	{
		return _physicsPosStack[0].Count - 1;
	}

	private bool CheckHintDirection(Vector2 direction)
	{
		int move = GetBlockMoveCount();
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

	private Vector2 GetBlockStartPos(int block)
	{
		return _physicsBlockPos[block];
	}

	private Vector2 GetBlockEndPos(int block, Vector2 direction)
	{
		int x = (int)_physicsBlockPos[block].x;
		int y = (int)_physicsBlockPos[block].y;

		int numBlock = 0;

		if (direction == DIRECTION_UP || direction == DIRECTION_DOWN)
		{
			int add = direction == DIRECTION_UP ? 1 : -1;
			int i;

			for (i = y + add; i >= 0 && i < NUM_Y; i += add)
			{
				sbyte tile = _physicsMapLayout[x, i];

				if (Level.IsBlock(tile))
				{
					numBlock++;
				}
				else if (Level.IsWall(tile))
				{
					break;
				}
			}

			return new Vector2(x, i + (-1 * add) + (-1 * add * numBlock));
		}
		else if (direction == DIRECTION_LEFT || direction == DIRECTION_RIGHT)
		{
			int add = direction == DIRECTION_LEFT ? -1 : 1;
			int i;

			for (i = x + add; i >= 0 && i < NUM_X; i += add)
			{
				sbyte tile = _physicsMapLayout[i, y];

				if (Level.IsBlock(tile))
				{
					numBlock++;
				}
				else if (Level.IsWall(tile))
				{
					break;
				}
			}

			return new Vector2(i + (-1 * add) + (-1 * add * numBlock), y);
		}

		return Vector2.zero;
	}

	bool IsBlockEndPosWinning()
	{
		for (int i = 0; i < NUM_BLOCK; i++)
		{
			int x = (int)_physicsEndPos[i].x;
			int y = (int)_physicsEndPos[i].y;

			Vector2 posUp = new Vector2(x, y + 1.0f);
			Vector2 posDown = new Vector2(x, y - 1.0f);
			Vector2 posLeft = new Vector2(x - 1.0f, y);
			Vector2 posRight = new Vector2(x + 1.0f, y);

			int hitTally = 0;

			for (int j = 0; j < NUM_BLOCK; j++)
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

	private bool StartBlockMovement(Vector2 direction)
	{
		Vector2[] startPos = new Vector2[NUM_BLOCK];
		Vector2[] endPos = new Vector2[NUM_BLOCK];
		Vector2[] startToEndDist = new Vector2[NUM_BLOCK];
		int longestDist = 0;

		Vector2[] preEndPos = new Vector2[NUM_BLOCK];
		Vector2[] startToPreEndDist = new Vector2[NUM_BLOCK];
		Vector2[] preEndToEndDist = new Vector2[NUM_BLOCK];
		float preEndMultiplier = 0.0f;

		bool legal = false;

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			startPos[i] = GetBlockStartPos(i);
			endPos[i] = GetBlockEndPos(i, direction);

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

		for (int i = 0; i < NUM_BLOCK; i++)
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

	private bool MoveBlockToPos(float startTime, Vector2 direction,
			Vector2[] startPos, Vector2[] endPos,
			Vector2[] startToEndDist, int longestDist,
			float decelerationRate)
	{
		float travelTime = startToEndDist[longestDist].magnitude * decelerationRate;
		float deltaTime = Time.time - startTime;

		if (deltaTime >= travelTime)
		{
			for (int i = 0; i < NUM_BLOCK; i++)
			{
				SetMapBlockPos(i, endPos[i].x, endPos[i].y);
			}
			return true;
		}

		for (int i = 0; i < NUM_BLOCK; i++)
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

			SetMapBlockPos(i, movePos.x, movePos.y);
		}

		return false;
        }

	private bool MoveBlockFromStartToEnd()
	{
		bool ret = MoveBlockToPos(_physicsStartTime, _physicsDirection,
				_physicsStartPos, _physicsEndPos,
				_physicsStartToEndDist, _physicsLongestDist,
				DECELERATION_RATE_START_TO_END);

		if (ret == true)
		{
			PushMoveToStack(_physicsEndPos);
		}

		return ret;
	}

	private bool MoveBlockFromStartToPreEnd()
	{
		bool ret = MoveBlockToPos(_physicsStartTime, _physicsDirection,
				_physicsStartPos, _physicsPreEndPos,
				_physicsStartToPreEndDist, _physicsLongestDist,
				DECELERATION_RATE_START_TO_PRE_END);

		if (ret == true)
		{
			_physicsStartTime = Time.time;
		}

		return ret;
	}

	private bool MoveBlockFromPreEndToEnd()
	{
		bool ret = MoveBlockToPos(_physicsStartTime, _physicsDirection,
				_physicsPreEndPos, _physicsEndPos,
				_physicsPreEndToEndDist, _physicsLongestDist,
				DECELERATION_RATE_PRE_END_TO_END);

		if (ret == true)
		{
			PushMoveToStack(_physicsEndPos);
		}

		return ret;
	}

	private void UndoBlockPos()
	{
		PopMoveFromStack();

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			SetMapBlockPos(i, _physicsBlockPos[i].x, _physicsBlockPos[i].y);
		}
	}

	private void ResetBlockPos()
	{
		ResetMoveInStack();

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			SetMapBlockPos(i, _physicsBlockPos[i].x, _physicsBlockPos[i].y);
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

			if (GetBlockMoveCount() >= MAX_MOVE_COUNT)
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

			if (StartBlockMovement(direction) == false)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}

			if (IsBlockEndPosWinning() == true)
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
		if (MoveBlockFromStartToEnd() == true)
		{
			int move = GetBlockMoveCount();

			_ui.SetTopMoveCurrent(move);
			_ui.SetInteractableControlButton(true);

			if (_touchHint)
			{
				_ui.SetActiveHintDirection(_levelMap._hint[move]);
				AnimateHintDirectionStop();
				AnimateHintDirectionStart(_levelMap._hint[move]);
			}

			_audio.PlayMoveStartToEnd();

			_touchState = TouchState.NONE;
		}
	}

	private void DoTouchStateStartToPreEnd()
	{
		if (MoveBlockFromStartToPreEnd() == true)
		{
			_audio.PlayMovePreEndToEnd();
			_touchState = TouchState.PRE_END_TO_END;
		}
	}

	private void DoTouchStatePreEndToEnd()
	{
		if (MoveBlockFromPreEndToEnd() == true)
		{
			_audio.PlayMapExit();

			int move = GetBlockMoveCount();
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
				_ui.SetActiveControlHintOn(false);
				_ui.SetActiveControlHintOff(true);

				_ui.SetActiveHint(false);
				AnimateHintDirectionStop();
			}

			int moveCount = GetBlockMoveCount();
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
					_audio.PlayWinEnter();

					_ui.SetActiveWin(true);
					_ui.SetEnableWinButton(false);
					_ui.SetInteractableWinNextButton(enableNext);

					_ui.AnimateWinBoardEnter(
						()=>
						{
							_ui.AnimateWinStarEnter(star,
								()=>
								{
									_ui.SetEnableWinButton(true);
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
			_loadUi.AnimateLoadBlockStop();
			_loadUi.SetActiveLoad(false);
			_touchState = adState;
		}
		else if (Time.time - _touchLoadAdStartTime > MAX_AD_LOAD_TIME)
		{
			_loadUi.AnimateLoadBlockStop();
			_loadUi.SetActiveLoad(false);
			_adUi.SetActiveAdFail(true);
			_adUi.SetEnableAdFailButton(false);
			_adUi.AnimateAdFailBoardEnter
			(
				()=>
				{
					_adUi.SetEnableAdFailButton(true);
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
			_ui.SetActiveControlHintAd(false);
			_ui.SetActiveControlHintOn(false);
			_ui.SetActiveControlHintOff(true);
			_adUi.SetActiveAdSuccess(true);
			_adUi.SetActiveAdSuccessHint(false);
			_adUi.SetEnableAdSuccessButton(false);
			_adUi.AnimateAdSuccessBoardEnter
			(
				()=>
				{
					_audio.PlayRewardReceived();
					_adUi.SetActiveAdSuccessHint(true);
					_adUi.AnimateAdSuccessHintEnter
					(
						()=>
						{
							_adUi.SetEnableAdSuccessButton(true);
						}
					);
				}
			);
			_touchState = postAdState;
		}
		else if (status == AdManager.RewardStatus.FAIL)
		{
			_adUi.SetActiveAdAbort(true);
			_adUi.SetEnableAdAbortButton(false);
			_adUi.AnimateAdAbortBoardEnter
			(
				()=>
				{
					_adUi.SetEnableAdAbortButton(true);
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
		_ui.SetTopMap(_menuMap + 1);

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
		_ui.SetActiveHint(false);
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
			_ui.SetActiveControlHintAd(false);
			_ui.SetActiveControlHintOn(false);
			_ui.SetActiveControlHintOff(true);
		}
		else
		{
			_ui.SetActiveControlHintAd(true);
			_ui.SetActiveControlHintOn(false);
			_ui.SetActiveControlHintOff(false);
		}
	}

	public void OnControlPauseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_touchState = TouchState.PAUSE;

		if (_touchHint == true)
		{
			_touchHint = false;

			_ui.SetActiveControlHintOn(false);
			_ui.SetActiveControlHintOff(true);

			AnimateHintDirectionStop();
			_ui.SetActiveHint(false);
		}

		_ui.SetEnableControlButton(false);
		_ui.SetActivePause(true);
		_ui.SetEnablePauseButton(false);
		_ui.SetPauseBlockSprite(_data.GetBlockSet());
		_pauseBlockSetNumber = _data.GetBlockSet();
		_ui.SetActivePausePreviewButton(false);
		_ui.SetActivePauseBlockLock(false);

		if (_data.GetAudio() == 0)
		{
			_ui.SetActivePauseAudioOnButton(false);
			_ui.SetActivePauseAudioOffButton(true);
		}
		else
		{
			_ui.SetActivePauseAudioOnButton(true);
			_ui.SetActivePauseAudioOffButton(false);
		}

		_ui.AnimateControlPauseButtonPressed(()=>{});
		_ui.AnimatePauseBoardEnter
		(
			()=>
			{
				_ui.SetEnablePauseButton(true);
			}
		);
	}

	public void OnControlUndoButtonPressed()
	{
		_audio.PlayButtonPressed();

		UndoBlockPos();

		int move = GetBlockMoveCount();
		_ui.SetTopMoveCurrent(move);

		if (_touchHint == true)
		{
			_ui.SetActiveHintDirection(_levelMap._hint[move]);
			AnimateHintDirectionStop();
			AnimateHintDirectionStart(_levelMap._hint[move]);
		}

		_ui.AnimateControlUndoButtonPressed(()=>{});
	}

	public void OnControlResetButtonPressed()
	{
		_audio.PlayButtonPressed();

		ResetBlockPos();

		int move = GetBlockMoveCount();
		_ui.SetTopMoveCurrent(move);

		if (_touchHint == true)
		{
			_ui.SetActiveHintDirection(_levelMap._hint[move]);
			AnimateHintDirectionStop();
			AnimateHintDirectionStart(_levelMap._hint[move]);
		}

		_ui.AnimateControlResetButtonPressed(()=>{});
	}

	public void OnControlHintAdButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateControlHintAdButtonPressed(()=>{});
		_loadUi.SetActiveLoad(true);
		_loadUi.AnimateLoadBlockStart();
		_touchLoadAdStartTime = Time.time;
		_touchState = TouchState.LOAD_AD;
	}

	public void OnControlHintOnButtonPressed()
	{
		_touchHint = false;

		_audio.PlayButtonPressed();

		_ui.SetActiveControlHintOn(false);
		_ui.SetActiveControlHintOff(true);

		AnimateHintDirectionStop();
		_ui.SetActiveHint(false);

		_ui.AnimateControlHintOffButtonPressed(()=>{});
	}

	public void OnControlHintOffButtonPressed()
	{
		_touchHint = true;

		_audio.PlayHintPressed();

		_ui.SetActiveControlHintOff(false);
		_ui.SetActiveControlHintOn(true);

		if (_hintUsed == false)
		{
			_data.SetHint(_data.GetHint() - 1);
			_ui.SetControlHintCount(_data.GetHint());
			_hintUsed = true;
		}

		ResetBlockPos();
		int move = GetBlockMoveCount();

		_ui.SetTopMoveCurrent(move);

		_ui.SetActiveHint(true);
		_ui.SetActiveHintDirection(_levelMap._hint[move]);
		AnimateHintDirectionStop();
		AnimateHintDirectionStart(_levelMap._hint[move]);

		_ui.AnimateControlHintOnButtonPressed(()=>{});
	}

	// UI - Go

	private void SetupGo()
	{
		_ui.SetActiveGo(false);
	}

	// UI - Pause

	private int _pauseBlockSetNumber;

	private void SetupPause()
	{
		_ui.SetActivePause(false);
	}

	public void OnPausePreviewButtonPressed()
	{
		_audio.PlayButtonPressed();

		SetMapBlockSprite(_pauseBlockSetNumber);

		_ui.SetInteractableControlButton(false);

		_ui.SetEnablePauseButton(false);
		_ui.AnimatePausePreviewButtonPressed
		(
			()=>
			{
				_ui.AnimatePauseBoardExit
				(
					()=>
					{
						_ui.SetActivePause(false);
						_ui.SetActiveExitPreviewButton(true);
						_ui.SetEnableExitPreviewButton(true);
						_ui.AnimateActiveExitButtonPunch();
					}
				);
			}
		);
	}

	public void OnPauseBlockButtonPressed()
	{
		_audio.PlayButtonPressed();

		_pauseBlockSetNumber = _block.IncrementSetNumber(_pauseBlockSetNumber);
		_ui.SetPauseBlockSprite(_pauseBlockSetNumber);
		if (_block.IsBlockSetUnlocked(_pauseBlockSetNumber) == 1)
		{
			_ui.SetActivePausePreviewButton(false);
			_ui.SetActivePauseBlockLock(false);
		}
		else
		{
			_ui.SetActivePausePreviewButton(true);
			_ui.SetActivePauseBlockLock(true);
			_ui.AnimatePausePreviewButtonBounce();
		}

		_ui.AnimatePauseBlockButtonPressed(()=>{});
	}

	public void OnPauseAudioOnButtonPressed()
	{
		_data.SetAudio(0);
		_audio.SetEnable(false);

		_ui.SetActivePauseAudioOnButton(false);
		_ui.SetActivePauseAudioOffButton(true);

		_ui.AnimatePauseAudioOffButtonPressed(()=>{});
	}

	public void OnPauseAudioOffButtonPressed()
	{
		_data.SetAudio(1);
		_audio.SetEnable(true);

		_audio.PlayButtonPressed();

		_ui.SetActivePauseAudioOnButton(true);
		_ui.SetActivePauseAudioOffButton(false);

		_ui.AnimatePauseAudioOnButtonPressed(()=>{});
	}

	public void OnPauseMenuButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnablePauseButton(false);
		_ui.AnimatePauseMenuButtonPressed
		(
			()=>
			{
				_ui.AnimatePauseBoardExit
				(
					()=>
					{
						SceneManager.LoadScene("MapMenuScene");
					}
				);
			}
		);
	}

	public void OnPauseResumeButtonPressed()
	{
		_audio.PlayButtonPressed();

		if (_block.IsBlockSetUnlocked(_pauseBlockSetNumber) == 1)
		{
			_data.SetBlockSet(_pauseBlockSetNumber);
			SetMapBlockSprite(_pauseBlockSetNumber);
		}

		_ui.SetEnablePauseButton(false);
		_ui.AnimatePauseResumeButtonPressed
		(
			()=>
			{
				_ui.AnimatePauseBoardExit
				(
					()=>
					{
						_ui.SetActivePause(false);
						_ui.SetEnableControlButton(true);
						_touchState = TouchState.NONE;
					}
				);
			}
		);
	}

	// UI - ExitPreview

	private void SetupExitPreview()
	{
		_ui.SetActiveExitPreviewButton(false);
	}

	public void OnExitPreviewButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableExitPreviewButton(false);

		_ui.AnimateActiveExitButtonPressed
		(
			()=>
			{
				_ui.SetActiveExitPreviewButton(false);

				_ui.SetInteractableControlButton(true);

				_ui.SetActivePause(true);
				_ui.SetEnablePauseButton(false);

				_ui.AnimatePauseBoardEnter
				(
					()=>
					{
						SetMapBlockSprite(_block.GetBlockSetNumber());
						_ui.SetEnablePauseButton(true);
						_ui.AnimatePausePreviewButtonBounce();
					}
				);
			}
		);
	}

	// UI - Win

	private const float WIN_ANIMATE_BOARD_ENTER_TIME = 0.3f;
	private const float WIN_ANIMATE_BOARD_EXIT_TIME = 0.3f;

	private const float WIN_ANIMATE_STAR_ENTER_TIME = 0.2f;

	private void SetupWin()
	{
		_ui.SetActiveWin(false);

		for (int i = 0; i < 3; i++)
		{
			_ui.SetActiveWinStar(i, false);
		}
	}

	public void OnWinHintAdButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableWinButton(false);
		_ui.AnimateWinHintAdButtonPressed
		(
			()=>
			{
				_ui.AnimateWinBoardExit
				(
					()=>
					{
						_ui.SetActiveWin(false);
						_loadUi.SetActiveLoad(true);
						_loadUi.AnimateLoadBlockStart();
						_touchLoadAdStartTime = Time.time;
						_touchState = TouchState.WIN_LOAD_AD;
					}
				);
			}
		);
	}

	public void OnWinMenuButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableWinButton(false);
		_ui.AnimateWinMenuButtonPressed
		(
			()=>
			{
				_ui.AnimateWinBoardExit
				(
					()=>
					{
						SceneManager.LoadScene("MapMenuScene");
					}
				);
			}
		);
	}

	public void OnWinReplayButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableWinButton(false);
		_ui.AnimateWinReplayButtonPressed
		(
			()=>
			{
				_ui.AnimateWinBoardExit
				(
					()=>
					{
						SceneManager.LoadScene("LevelScene");
					}
				);
			}
		);
	}

	public void OnWinNextButtonPressed()
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

		_audio.PlayButtonPressed();

		_ui.SetEnableWinButton(false);
		_ui.AnimateWinNextButtonPressed
		(
			()=>
			{
				_ui.AnimateWinBoardExit
				(
					()=>
					{
						SceneManager.LoadScene("LevelScene");
					}
				);
			}
		);
	}

	// Load

	private void SetupLoad()
	{
		_loadUi.SetActiveLoad(false);
	}

	// Ad - Success

	private void SetupAdSuccess()
	{
		_adUi.SetActiveAdSuccess(false);
	}

	public void OnAdSuccessCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdSuccessButton(false);
		_adUi.AnimateAdSuccessCloseButtonPressed
		(
			()=>
			{
				_adUi.AnimateAdSuccessBoardExit
				(
					()=>
					{
						_adUi.SetActiveAdSuccess(false);

						if (_touchState == TouchState.WIN)
						{
							_ui.SetActiveWin(true);

							_ui.AnimateWinBoardEnter
							(
								()=>
								{
									_ui.SetEnableWinButton(true);
								}
							);
						}
						else if (_touchState == TouchState.PAUSE)
						{
							_ui.SetActivePause(true);

							_ui.AnimatePauseBoardEnter
							(
								()=>
								{
									_ui.SetEnablePauseButton(true);
								}
							);
						}
					}
				);
			}
		);
	}

	// Ad - Abort

	private void SetupAdAbort()
	{
		_adUi.SetActiveAdAbort(false);
	}

	public void OnAdAbortCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdAbortButton(false);
		_adUi.AnimateAdAbortBoardExit
		(
			()=>
			{
				_adUi.SetActiveAdAbort(false);

				if (_touchState == TouchState.WIN)
				{
					_ui.SetActiveWin(true);

					_ui.AnimateWinBoardEnter
					(
						()=>
						{
							_ui.SetEnableWinButton(true);
						}
					);
				}
				else if (_touchState == TouchState.PAUSE)
				{
					_ui.SetActivePause(true);

					_ui.AnimatePauseBoardEnter(
						()=>
						{
							_ui.SetEnablePauseButton(true);
						}
					);
				}
			}
		);
	}

	// Ad - Fail

	private void SetupAdFail()
	{
		_adUi.SetActiveAdFail(false);
	}

	public void OnAdFailCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdFailButton(false);
		_adUi.AnimateAdFailBoardExit
		(
			()=>
			{
				_adUi.SetActiveAdFail(false);

				if (_touchState == TouchState.WIN)
				{
					_ui.SetActiveWin(true);

					_ui.AnimateWinBoardEnter
					(
						()=>
						{
							_ui.SetEnableWinButton(true);
						}
					);
				}
				else if (_touchState == TouchState.PAUSE)
				{
					_ui.SetActivePause(true);

					_ui.AnimatePauseBoardEnter(
						()=>
						{
							_ui.SetEnablePauseButton(true);
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
		_loadUi = GameObject.Find("LoadUI").GetComponent<LoadUI>();
		_adUi = GameObject.Find("AdUI").GetComponent<AdUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_event = GameObject.Find("EventManager").GetComponent<EventManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();

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
		SetupExitPreview();
		SetupWin();
		SetupLoad();
		SetupAdSuccess();
		SetupAdAbort();
		SetupAdFail();

		_audio.PlayMapEnter();
		AnimateMapEnter
		(
			()=>
			{
				_audio.PlayGoEnter();
				_ui.SetActiveGo(true);
				_ui.AnimateGoEnterAndExit
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
