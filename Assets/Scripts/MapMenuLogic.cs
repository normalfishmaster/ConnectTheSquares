using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuLogic : MonoBehaviour
{
	private MapMenuUI _ui;
	private DataManager _data;

	// Map

	public void DoMapButtonPressed(int map)
	{
		_data.SetMenuMap(map);
		SceneManager.LoadScene("LevelScene");
	}

	// Back

	public void DoBackButtonPressed()
	{
		SceneManager.LoadScene("AlphabetMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("MapMenuUI").GetComponent<MapMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
	}
}
