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

	private void AnimateMapEnter(AnimateComplete callback)
	{
		MapMenuUI.AnimateComplete uiCallback = new MapMenuUI.AnimateComplete(callback);

		_ui.AnimateMapEnter(MAP_ANIMATE_ENTER_TIME, uiCallback);
	}

	public void DoMapButtonPressed(int map)
	{
		_data.SetMenuMap(map);
		SceneManager.LoadScene("LevelScene");
	}

	// UI - Top

	private void SetupTop()
	{
		_ui.SetTopLabel(_menuColor, _menuAlphabet);
	}

	// UI - Back

	public void DoBackButtonPressed()
	{
		SceneManager.LoadScene("LevelMenuScene");
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
		AnimateMapEnter
		(
			()=>
			{
				_ui.SetEnableMapButton(true);
			}
		);
	}
}
