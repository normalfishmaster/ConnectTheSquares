using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoLogic : MonoBehaviour
{
	private DemoUI _ui;
	private AudioManager _audio;
	private BlockManager _block;
	private DataManager _data;
	private LevelManager _level;

	private int _menuColor;
	private int _menuAlphabet;
	private int _menuMap;

	private Level.Map _levelMap;

	private const int NUM_X = Level.NUM_COL;
	private const int NUM_Y = Level.NUM_ROW;

	private const int NUM_BLOCK = Level.NUM_BLOCK;

        private const sbyte O = Level.O;
        private const sbyte X = Level.X;
        private const sbyte A = Level.A;
        private const sbyte B = Level.B;
        private const sbyte C = Level.C;
        private const sbyte D = Level.D;

	private Vector2 DIRECTION_NONE  = Vector2.zero;
	private Vector2 DIRECTION_UP    = new Vector2( 0.0f,  1.0f);
	private Vector2 DIRECTION_DOWN  = new Vector2( 0.0f, -1.0f);
	private Vector2 DIRECTION_LEFT  = new Vector2(-1.0f,  0.0f);
	private Vector2 DIRECTION_RIGHT = new Vector2( 1.0f,  0.0f);

	private int _blockSet;

	// Map

	private GameObject[,] _mapWall;
	private GameObject[,] _mapWallShadow;
	private GameObject[] _mapBlock;
	private GameObject[] _mapBlockShadow;

	private float _mapXOffset;
	private float _mapYOffset;

	Vector2[,] _mapWallOriginalPos;

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

		SetMapBlockSprite(_blockSet);
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

	// Physics

	private const float DECELERATION_RATE_START_TO_END = 0.07f;
	private const float DECELERATION_RATE_START_TO_PRE_END = 0.07f;
	private const float DECELERATION_RATE_PRE_END_TO_END = 2.00f;

	private sbyte[,] _physicsMapLayout;
	private Vector2[] _physicsBlockPos;
	private Vector2[] _physicsStartBlockPos;

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
		_physicsBlockPos = new Vector2[Level.NUM_BLOCK];
		_physicsStartBlockPos = new Vector2[Level.NUM_BLOCK];

		_physicsMapLayout = new sbyte[,]
		{
			{ X, X, X, X, X, X, X, X, },
			{ X, 0, 0, 0, 0, 0, X, X, },
			{ X, 0, C, 0, 0, A, 0, X, },
			{ X, 0, 0, X, X, 0, 0, X, },
			{ X, 0, 0, X, X, 0, 0, X, },
			{ X, 0, D, 0, 0, B, 0, X, },
			{ X, X, 0, 0, 0, 0, 0, X, },
			{ X, X, X, X, X, X, X, X, },
		};

		for (int i = 0; i < NUM_X; i++)
		{
			for (int j = 0; j < NUM_Y; j++)
			{
				sbyte tile = _physicsMapLayout[i, j];

				if (Level.IsBlock(tile))
				{
					int n = Level.GetBlockNumber(tile);
					_physicsBlockPos[n] = new Vector2(i, j);
					_physicsStartBlockPos[n] = new Vector2(i, j);
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
		}
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

	private void ResetBlockPos()
	{

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsMapLayout[(int)_physicsBlockPos[i].x, (int)_physicsBlockPos[i].y] = Level.EMPTY;
		}

		for (int i = 0; i < NUM_BLOCK; i++)
		{
			_physicsBlockPos[i].x = _physicsStartBlockPos[i].x;
			_physicsBlockPos[i].y = _physicsStartBlockPos[i].y;

			_physicsMapLayout[(int)_physicsBlockPos[i].x, (int)_physicsBlockPos[i].y] = Level.GetBlock((sbyte)i);

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
		END,
	};

	private TouchState _touchState;

	private Vector2 _touchStartPos;
	private float _touchStartTime;

	private float _touchLoadAdStartTime;

	private void SetupTouch()
	{
		_touchState = TouchState.WAIT;
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

			if (StartBlockMovement(direction) == false)
			{
				_ui.SetInteractableControlButton(true);
				_touchState = TouchState.NONE;
				return;
			}

			_ui.SetInteractableControlButton(false);
			_touchState = TouchState.START_TO_END;
			return;
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
			_ui.SetInteractableControlButton(true);

			_audio.PlayMoveStartToEnd();

			_touchState = TouchState.NONE;
		}
	}

	private void DoTouchStateEnd()
	{
	}

	// UI - Control

	private void SetupControl()
	{
		_ui.SetEnableControlButton(false);
		_ui.SetInteractableControlButton(false);
	}

	public void OnControlBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableControlButton(false);
		_ui.SetInteractableControlButton(false);

		_ui.AnimateControlBackButtonPressed(()=>{});

		_ui.SetActiveBlinder(true);
		_ui.AnimateBlinderDarken
		(
			()=>
			{
				SceneManager.LoadScene("StoreScene");
			}
		);

		_touchState = TouchState.END;
	}

	public void OnControlBlockButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateControlBlockButtonPressed(()=>{});

		_blockSet = _block.IncrementSetNumber(_blockSet);
		SetMapBlockSprite(_blockSet);

		if (_block.IsBlockSetUnlocked(_blockSet))
		{
			_ui.SetActiveMiscLocked(false);
			_ui.SetActiveMiscUnlocked(true);
		}
		else
		{
			_ui.SetActiveMiscLocked(true);
			_ui.SetActiveMiscUnlocked(false);
		}
	}

	public void OnControlResetkButtonPressed()
	{
		_audio.PlayButtonPressed();

		ResetBlockPos();

		_ui.AnimateControlResetButtonPressed(()=>{});
	}

	// Blinder

	private void SetupBlinder()
	{
		_ui.SetActiveBlinder(false);
	}

	// Misc

	private void SetupMisc()
	{
		if (_block.IsBlockSetUnlocked(_blockSet))
		{
			_ui.SetActiveMiscLocked(false);
			_ui.SetActiveMiscUnlocked(true);
		}
		else
		{
			_ui.SetActiveMiscLocked(true);
			_ui.SetActiveMiscUnlocked(false);
		}
	}

	// Unity Lifecyle

	private void Awake()
	{
		_ui = GameObject.Find("DemoUI").GetComponent<DemoUI>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		_blockSet = _block.GetBlockPreview();

		FindMapGameObject();
	}

	private void Start()
	{
		SetupMap();	// SetupMap() must preceed SetupPhysics()
		SetupPhysics();
		SetupTouch();
		SetupControl();
		SetupBlinder();
		SetupMisc();

		_ui.SetActiveBlinder(true);
		_ui.AnimateBlinderLighten
		(
			()=>
			{
				_ui.SetActiveBlinder(false);
				_ui.SetEnableControlButton(true);
				_ui.SetInteractableControlButton(true);

				_touchState = TouchState.NONE;
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
		else if (_touchState == TouchState.END)
		{
			DoTouchStateEnd();
		}
	}
}
