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

	public float MAP_ANIMATE_ENTER_DURATION;

	public float MAP_ANIMATE_BUTTON_PRESSED_SCALE;
	public float MAP_ANIMATE_BUTTON_PRESSED_DURATION;

	public GameObject _mapButtonLockedPrefab;
	public GameObject _mapButtonUnlockedPrefab;
	public Sprite _mapButtonStarSprite;

	private GameObject _mapPanel;
	private GameObject _mapContent;
	private GameObject[] _mapButton;
	private bool[] _mapButtonLock;

	private void FindMapGameObject()
	{
		_mapPanel = GameObject.Find("/Canvas/Map");
		_mapContent = GameObject.Find("/Canvas/Map/Viewport/Content");
	}

	public void SetMapSize(int size)
	{
		_mapButton = new GameObject[size];
		_mapButtonLock = new bool[size];
	}

	public void SetEnableMapButton(bool enable)
	{
		for (int i = 0; i < _mapButton.Length; i++)
		{
			if (_mapButtonLock[i] == false)
			{
				_mapButton[i].GetComponent<Button>().enabled = enable;
			}
		}
	}

	public void AddMap(int map, int locked, int star)
	{
		if (locked == 1)
		{
			_mapButtonLock[map] = true;

			_mapButton[map] = Instantiate(_mapButtonLockedPrefab);
			_mapButton[map].GetComponent<Button>().enabled = false;
		}
		else
		{
			_mapButtonLock[map] = false;

			_mapButton[map] = Instantiate(_mapButtonUnlockedPrefab);

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

	public void AnimateMapEnter(Animate.AnimateComplete callback)
	{
		RectTransform rectTransform = (RectTransform)_mapPanel.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float height = rectTransform.rect.height;

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y - height, pos.z);

		LeanTween.cancel(_mapPanel);
		LeanTween.moveLocalY(_mapPanel, 0.0f, MAP_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateMapButtonPressed(int map, Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_mapButton[map], MAP_ANIMATE_BUTTON_PRESSED_SCALE, MAP_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomBackButton;

	private void FindBottomGameObject()
	{
		_bottomBackButton = GameObject.Find("/Canvas/Bottom/Back/Button");
	}

	public void AnimateBottomBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomBackButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnBottomBackButtonPressed()
	{
		_logic.DoBottomBackButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("MapMenuLogic").GetComponent<MapMenuLogic>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindMapGameObject();
		FindTopGameObject();
		FindBottomGameObject();
	}
}
