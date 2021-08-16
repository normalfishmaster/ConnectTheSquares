using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuUI : MonoBehaviour
{
	private LevelMenuLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Level

	public GameObject _levelButtonSinglePrefab;
	public GameObject _levelButtonTriplePrefab;

	private GameObject[] _levelButton;

	private GameObject _levelContent;

	private void FindLevelGameObject()
        {
		_levelContent = GameObject.Find("/Canvas/Level/Viewport/Content");
	}

	public void SetLevelSize(int size)
	{
		_levelButton = new GameObject[size];
	}

	public void AddLevelSingle(int color, string moves, float percentA)
	{
		float pctA = (float)(Math.Floor((double)(percentA * 100)) / 100);

		_levelButton[color] = Instantiate(_levelButtonSinglePrefab);
		_levelButton[color].transform.SetParent(_levelContent.transform);
		_levelButton[color].transform.localScale = new Vector3(1, 1, 1);
		_levelButton[color].transform.Find("Color/Label").GetComponent<Text>().text = _level.GetColorString(color);
		_levelButton[color].transform.Find("Moves").GetComponent<Text>().text = moves;
		_levelButton[color].transform.Find("PercentA").GetComponent<Text>().text = pctA.ToString() + "%";
		_levelButton[color].transform.Find("A").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 0); });
	}

	public void AddALevelTriple(int color, string moves, float percentA, float percentB, float percentC)
	{
		float pctA = (float)(Math.Floor((double)(percentA * 100)) / 100);
		float pctB = (float)(Math.Floor((double)(percentB * 100)) / 100);
		float pctC = (float)(Math.Floor((double)(percentC * 100)) / 100);

		_levelButton[color] = Instantiate(_levelButtonTriplePrefab);
		_levelButton[color].transform.SetParent(_levelContent.transform);
		_levelButton[color].transform.localScale = new Vector3(1, 1, 1);
		_levelButton[color].transform.Find("Color/Label").GetComponent<Text>().text = _level.GetColorString(color);
		_levelButton[color].transform.Find("Moves").GetComponent<Text>().text = moves;
		_levelButton[color].transform.Find("PercentA").GetComponent<Text>().text = pctA.ToString() + "%";
		_levelButton[color].transform.Find("PercentB").GetComponent<Text>().text = pctB.ToString() + "%";
		_levelButton[color].transform.Find("PercentC").GetComponent<Text>().text = pctC.ToString() + "%";
		_levelButton[color].transform.Find("A").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 0); });
		_levelButton[color].transform.Find("B").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 1); });
		_levelButton[color].transform.Find("C").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 2); });
	}

	public void OnLevelButtonPressed(int color, int alphabet)
	{
		_logic.DoLevelButtonPressed(color, alphabet);
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
/*
		_topColorPanel = GameObject.Find("/Canvas/Top/Color");
		_topColorText = GameObject.Find("/Canvas/Top/Color/Label").GetComponent<Text>();

		_topAlphabetAPanel = GameObject.Find("/Canvas/Top/Alphabet/A");
		_topAlphabetBPanel = GameObject.Find("/Canvas/Top/Alphabet/B");
		_topAlphabetCPanel = GameObject.Find("/Canvas/Top/Alphabet/C");
*/
	}

	// Back

	public void OnBackButtonPressed()
	{
		_logic.DoBackButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("LevelMenuLogic").GetComponent<LevelMenuLogic>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindTopGameObject();
		FindLevelGameObject();
	}
}
