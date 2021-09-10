using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuLogic : MonoBehaviour
{
	private MapMenuUI _ui;
	private DataManager _data;
	private LevelManager _level;

	private int _menuColor;
	private int _menuAlphabet;

	private delegate void AnimateComplete();

	// UI - Map

	private const float MAP_ANIMATE_ENTER_TIME = 0.3f;

	private void SetupMap()
	{
		int numMap = _level.GetNumMap(_menuColor, _menuAlphabet);

		_ui.SetMapSize(numMap);

		for (int i = 0; i < numMap; i++)
		{
			int locked = _data.GetLevelLock(_menuColor, _menuAlphabet, i);
			int star = _data.GetLevelStar(_menuColor, _menuAlphabet, i);

			_ui.AddMap(i, locked, star);
		}
	}

	public void DoMapButtonPressed(int map)
	{
		_data.SetMenuMap(map);

		_ui.AnimateMapButtonPressed(map,
			()=>
			{
				SceneManager.LoadScene("LevelScene");
			}
		);
	}

	// UI - Top

	private void SetupTop()
	{
		_ui.SetTopLabel(_menuColor, _menuAlphabet);
	}

	// UI - Bottom

	public void DoBottomBackButtonPressed()
	{
		_ui.AnimateBottomBackButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("LevelMenuScene");
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("MapMenuUI").GetComponent<MapMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

	private void Start()
	{
		_menuColor = _data.GetMenuColor();
		_menuAlphabet = _data.GetMenuAlphabet();

		SetupTop();
		SetupMap();

		_ui.SetEnableMapButton(false);
		_ui.AnimateMapEnter
		(
			()=>
			{
				_ui.SetEnableMapButton(true);
			}
		);
	}
}
