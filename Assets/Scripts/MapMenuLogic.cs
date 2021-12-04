using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuLogic : MonoBehaviour
{
	private MapMenuUI _ui;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private FrameRateManager _frameRate;
	private LevelManager _level;
	private AudioManager _audio;

	private int _menuColor;
	private int _menuAlphabet;

	// Estimated scroll duration
	private const float FRAME_RATE_CHANGE_DELAY = 4.0f;

	// UI - Background

	private void SetupBackground()
	{
		_ui.SetBackgroundColor(_cloudOnce.GetBackgroundColor());
	}

	// UI - Map

	private const float MAP_ANIMATE_ENTER_TIME = 0.3f;

	private void SetupMap()
	{
		int numMap = _level.GetNumMap(_menuColor, _menuAlphabet);

		_ui.SetMapSize(numMap);

		for (int i = 0; i < numMap; i++)
		{
			int star = _cloudOnce.GetLevelStar(_menuColor, _menuAlphabet, i);
			_ui.AddMap(i, star);
		}
	}

	public void OnMapButtonPressed(int map)
	{
		_frameRate.setHighFrameRate();

		_audio.PlayButtonPressed();

		_data.SetMenuMap(map);

		_ui.SetEnableMapButton(false);
		_ui.SetEnableBottomButton(false);

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

	public void OnBottomBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableMapButton(false);
		_ui.SetEnableBottomButton(false);

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
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_frameRate = GameObject.Find("FrameRateManager").GetComponent<FrameRateManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}

	private void Start()
	{
		_menuColor = _data.GetMenuColor();
		_menuAlphabet = _data.GetMenuAlphabet();

		SetupBackground();
		SetupTop();
		SetupMap();

		_frameRate.setHighFrameRate();

		_ui.SetEnableMapButton(false);
		_ui.AnimateMapEnter
		(
			()=>
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
				_ui.SetEnableMapButton(true);
			}
		);
	}

	private void Update()
	{
		if (Input.touchCount != 0)
		{
			_frameRate.setHighFrameRate();

			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Ended)
			{
				_frameRate.setLowFrameRate(FRAME_RATE_CHANGE_DELAY);
			}

			return;
		}
	}
}
