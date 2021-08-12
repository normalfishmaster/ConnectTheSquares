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
	public Sprite[] _mapButtonUnlockedSprite;
	public Sprite _mapButtonStarSprite;

	private GameObject _mapContent;
	private GameObject[] _mapButton;

	private void FindMapGameObjects()
	{
		_mapContent = GameObject.Find("/Canvas/Map/Viewport/Content");
	}
/*
	private void SetupMap()
	{
		int menuColor = _data.GetMenuColor();
		int menuAlphabet = _data.GetMenuAlphabet();
		int numMap = _level.GetNumMap(menuColor, menuAlphabet);

		_mapButton = new GameObject[numMap];

		for (int i = 0; i < numMap; i++)
		{
			int map = i;
			int locked = _data.GetLevelLock(menuColor, menuAlphabet, map);
			int star = _data.GetLevelStar(menuColor, menuAlphabet, map);

			if (locked == 1)
			{
				_mapButton[map] = Instantiate(_mapButtonLockedPrefab);
				_mapButton[map].GetComponent<Button>().interactable = false;
			}
			else
			{
				_mapButton[map] = Instantiate(_mapButtonUnlockedPrefab);
				_mapButton[map].GetComponent<Button>().interactable = true;
				_mapButton[map].GetComponent<Image>().sprite = _mapButtonUnlockedSprite[menuColor];

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

			_mapButton[i].transform.SetParent(_mapContent.transform);
			_mapButton[i].transform.localScale= new Vector3(1, 1, 1);
			_mapButton[i].transform.Find("Label").GetComponent<Text>().text = _level.GetMapString(map);
			_mapButton[i].GetComponent<Button>().onClick.AddListener(delegate { OnMapButtonPressed(map); });
		}
	}
*/

	public void SetMapSize(int size)
	{
		_mapButton = new GameObject[size];
	}

	public void AddMap(int color, int alphabet, int map, int locked, int star)
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
			_mapButton[map].GetComponent<Image>().sprite = _mapButtonUnlockedSprite[color];

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

	public Sprite[] _topColorSprite;

	private GameObject _topColorPanel;
	private Text _topColorText;

	private GameObject _topAlphabetAPanel;
	private GameObject _topAlphabetBPanel;
	private GameObject _topAlphabetCPanel;

	private void FindTopGameObject()
	{
		_topColorPanel = GameObject.Find("/Canvas/Top/Color");
		_topColorText = GameObject.Find("/Canvas/Top/Color/Label").GetComponent<Text>();

		_topAlphabetAPanel = GameObject.Find("/Canvas/Top/Alphabet/A");
		_topAlphabetBPanel = GameObject.Find("/Canvas/Top/Alphabet/B");
		_topAlphabetCPanel = GameObject.Find("/Canvas/Top/Alphabet/C");
	}

	public void SetTopColor(int color)
	{
		_topColorPanel.GetComponent<Image>().sprite = _topColorSprite[color];
		_topColorText.text = _level.GetColorString(color);
	}

	public void SetTopAlphabet(int alphabet)
	{
		string str = _level.GetAlphabetString(alphabet);

		_topAlphabetAPanel.SetActive(false);
		_topAlphabetBPanel.SetActive(false);
		_topAlphabetCPanel.SetActive(false);

		if (str == "A")
		{
			_topAlphabetAPanel.SetActive(true);
		}
		else if (str == "B")
		{
			_topAlphabetBPanel.SetActive(true);
		}
		else if (str == "C")
		{
			_topAlphabetCPanel.SetActive(true);
		}
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
		FindTopGameObject();
	}
}
