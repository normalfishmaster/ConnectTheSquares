using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

//	private Level.Map? _map;
	private Level.Map _map;

	// Level

	private GameObject _board;
	private GameObject[,] _wall;
	private GameObject[] _square;

	private float _rowOffset;
	private float _colOffset;

	private void FindLevelGameObject()
	{
		// Board

		_board = GameObject.Find("Level/Board");

		// Wall

		_wall = new GameObject[Level.NUM_ROW, Level.NUM_COL];

		for (int i = 0; i < Level.NUM_ROW; i++)
		{
			for (int j = 0; j < Level.NUM_COL; j++)
			{
				_wall[i, j] = GameObject.Find("Level/Wall/R" + i + "/C" + j);
			}
		}

		// Square

		_square = new GameObject[Level.NUM_SQUARE];

		for (int i = 0; i < Level.NUM_SQUARE; i++)
		{
			_square[i] = GameObject.Find("Level/Square/S" + i);
		}
	}

	private void SetupLevel()
	{
		_rowOffset = 3.5f;
		_colOffset = -3.5f;

		for (int i = 0; i < Level.NUM_ROW; i++)
		{
			for (int j = 0; j < Level.NUM_COL; j++)
			{
				Debug.Log("i:" + i + " j:" + j);

				int tile = _map._layout[i, j];

				if (Level.IsEmpty(tile) || Level.IsSquare(tile))
				{
					Debug.Log("empty");
					_wall[i, j].GetComponent<SpriteRenderer>().color = new Color(140, 140, 140);
					Debug.Log("empty after");
				}

				if (Level.IsSquare(tile))
				{
					Debug.Log("square");
					int square = Level.GetSquareNumber(tile);
					_square[square].transform.position = new Vector2(_colOffset + j, _rowOffset - i);
				}
			}
		}
	}



	// Unity Lifecyle

	private void Awake()
	{
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_event = GameObject.Find("EventManager").GetComponent<EventManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();

		FindLevelGameObject();

	}

	private void Start()
	{
		_menuColor = _data.GetMenuColor();
		_menuAlphabet = _data.GetMenuAlphabet();
		_menuMap = _data.GetMenuMap();

		Debug.Log("color:" + _menuColor);
		Debug.Log("alphabet:" + _menuAlphabet);
		Debug.Log("map:" + _menuMap);

		_map = _level.GetMap(_menuColor, _menuAlphabet, _menuMap);

		SetupLevel();
	}
}
