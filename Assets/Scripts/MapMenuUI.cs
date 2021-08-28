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

	public GameObject _mapButtonLockedPrefab;
	public GameObject _mapButtonUnlockedPrefab;
	public Sprite _mapButtonStarSprite;

	private GameObject _mapContent;
	private GameObject[] _mapButton;

	private void FindMapGameObject()
	{
		_mapContent = GameObject.Find("/Canvas/Map/Viewport/Content");
	}

	public void SetMapSize(int size)
	{
		_mapButton = new GameObject[size];
	}

	public void AddMap(int map, int locked, int star)
	{
		if (locked == 1)
		{
			_mapButton[map] = Instantiate(_mapButtonLockedPrefab);
			_mapButton[map].GetComponent<Button>().interactable = false;
		}
		else
		{
			_mapButton[map] = Instantiate(_mapButtonUnlockedPrefab);
			_mapButton[map].GetComponent<Button>().interactable = true;

	                for (int j = 0; j < 3; j++)
               		{
	                        if (j < star)
               		        {
					_mapButton[map].transform.Find("Star" + j).GetComponent<Image>().sprite = _mapButtonStarSprite;
	                        }
               		        else
	                        {
					break;
	                        }
               		}
		}

		_mapButton[map].transform.SetParent(_mapContent.transform);
		_mapButton[map].transform.localScale = new Vector3(1, 1, 1);
		_mapButton[map].transform.Find("Label").GetComponent<Text>().text = _level.GetMapString(map);
		_mapButton[map].GetComponent<Button>().onClick.AddListener(delegate { OnMapButtonPressed(map); });
	}

	public void OnMapButtonPressed(int map)
	{
		_logic.DoMapButtonPressed(map);
	}

	// Top

	private Text _topLabelText;

	private void FindTopGameObject()
	{
		_topLabelText = GameObject.Find("/Canvas/Top/Label").GetComponent<Text>();
	}

	public void SetTopLabel(int color, int alphabet)
	{
		_topLabelText.text = _level.GetColorString(color) + " - " + _level.GetAlphabetString(alphabet);
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

		FindMapGameObject();
		FindTopGameObject();
	}
}
