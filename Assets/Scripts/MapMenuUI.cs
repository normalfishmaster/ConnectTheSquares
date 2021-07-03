using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMenuUI : MonoBehaviour
{
	private MapMenuLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Map

	public GameObject _mapButtonPrefab;

	private GameObject _mapContent;
	private GameObject[] _mapButton;

	private void FindMapGameObjects()
	{
		_mapContent = GameObject.Find("/Canvas/Map/Viewport/Content");
	}

	private void SetupMap()
	{
		int menuColor = _data.GetMenuColor();
		int menuAlphabet = _data.GetMenuAlphabet();
		int numMap = _level.GetNumMap(menuColor, menuAlphabet);

		_mapButton = new GameObject[numMap];

		for (int i = 0; i < numMap; i++)
		{
			int map = i;
			_mapButton[i] = Instantiate(_mapButtonPrefab);
			_mapButton[i].transform.SetParent(_mapContent.transform);
			_mapButton[i].transform.localScale= new Vector3(1, 1, 1);
			_mapButton[i].transform.Find("Label").GetComponent<Text>().text = _level.GetMapString(map);
			_mapButton[i].GetComponent<Button>().onClick.AddListener(delegate { OnMapButtonPressed(map); });
		}
	}

	public void OnMapButtonPressed(int map)
	{
		_logic.DoMapButtonPressed(map);
	}

	// Back

	public void OnBackButtonPressed()
	{
		_logic.DoBackButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("MapMenuLogic").GetComponent<MapMenuLogic>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindMapGameObjects();
	}

	private void Start()
	{
		SetupMap();
	}

	private void Update()
	{
	}

}
