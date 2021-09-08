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

	public delegate void AnimateComplete();

	// Level

	private enum LevelButtonType
	{
		SINGLE,
		TRIPLE,
	};

	public GameObject _levelPanel;
	public GameObject _levelButtonSinglePrefab;
	public GameObject _levelButtonTriplePrefab;

	private GameObject[] _levelButton;
	private LevelButtonType[] _levelButtonType;
	private float[] _levelPercentA;
	private float[] _levelPercentB;
	private float[] _levelPercentC;

	private GameObject _levelContent;

	private void FindLevelGameObject()
        {
		_levelPanel = GameObject.Find("/Canvas/Level");
		_levelContent = GameObject.Find("/Canvas/Level/Viewport/Content");
	}

	public void SetLevelSize(int size)
	{
		_levelButton = new GameObject[size];
		_levelButtonType = new LevelButtonType[size];
		_levelPercentA = new float[size];
		_levelPercentB = new float[size];
		_levelPercentC = new float[size];
	}

	public void SetEnableLevelButton(bool enable)
	{
		for (int i = 0; i < _levelButton.Length; i++)
		{
			if (_levelButtonType[i] == LevelButtonType.SINGLE)
			{
				_levelButton[i].transform.Find("A").GetComponent<Button>().enabled = enable;
			}
			else
			{
				_levelButton[i].transform.Find("A").GetComponent<Button>().enabled = enable;
				_levelButton[i].transform.Find("B").GetComponent<Button>().enabled = enable;
				_levelButton[i].transform.Find("C").GetComponent<Button>().enabled = enable;
			}
		}
	}

	public void AddLevelSingle(int color, string moves, float percentA)
	{
		_levelButtonType[color] = LevelButtonType.SINGLE;

		_levelPercentA[color] = (float)(Math.Floor((double)(percentA * 100)) / 100);

		_levelButton[color] = Instantiate(_levelButtonSinglePrefab);
		_levelButton[color].transform.SetParent(_levelContent.transform);
		_levelButton[color].transform.localScale = new Vector3(1, 1, 1);
		_levelButton[color].transform.Find("Color/Label").GetComponent<Text>().text = _level.GetColorString(color);
		_levelButton[color].transform.Find("Moves").GetComponent<Text>().text = moves;
		_levelButton[color].transform.Find("A").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 0); });
	}

	public void AddLevelTriple(int color, string moves, float percentA, float percentB, float percentC)
	{
		_levelButtonType[color] = LevelButtonType.TRIPLE;

		_levelPercentA[color] = (float)(Math.Floor((double)(percentA * 100)) / 100);
		_levelPercentB[color] = (float)(Math.Floor((double)(percentB * 100)) / 100);
		_levelPercentC[color] = (float)(Math.Floor((double)(percentC * 100)) / 100);

		_levelButton[color] = Instantiate(_levelButtonTriplePrefab);
		_levelButton[color].transform.SetParent(_levelContent.transform);
		_levelButton[color].transform.localScale = new Vector3(1, 1, 1);
		_levelButton[color].transform.Find("Color/Label").GetComponent<Text>().text = _level.GetColorString(color);
		_levelButton[color].transform.Find("Moves").GetComponent<Text>().text = moves;
		_levelButton[color].transform.Find("A").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 0); });
		_levelButton[color].transform.Find("B").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 1); });
		_levelButton[color].transform.Find("C").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 2); });
	}

        public void AnimateLevelEnter(float enterTime, AnimateComplete callback)
        {
		RectTransform rectTransform = (RectTransform)_levelPanel.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float height = rectTransform.rect.height;

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y - height, pos.z);

		LeanTween.cancel(_levelPanel);
		LeanTween.moveLocalY(_levelPanel, 0.0f, enterTime).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
        }

	private void AnimateLevelPercentageSingle(GameObject button, string name, float val, float animateTime)
	{
		Transform transform = button.transform.Find(name);
		GameObject gameObject = transform.gameObject;

		transform.localScale = Vector3.one;

		LeanTween.cancel(gameObject);

		LeanTween.scale(gameObject, Vector3.one * 1.25f, animateTime).setEasePunch();

		LeanTween.value(gameObject, 0.0f, val, animateTime).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				transform.GetComponent<Text>().text = val.ToString("0") + "%";
			}
		);
	}

	public void AnimateLevelPercentage(float animateTime)
	{
		for (int i = 0; i < _levelButton.Length; i++)
		{
			if (_levelButtonType[i] == LevelButtonType.SINGLE)
			{
				AnimateLevelPercentageSingle(_levelButton[i], "PercentA", _levelPercentA[i], animateTime);
			}
			else
			{
				AnimateLevelPercentageSingle(_levelButton[i], "PercentA", _levelPercentA[i], animateTime);
				AnimateLevelPercentageSingle(_levelButton[i], "PercentB", _levelPercentB[i], animateTime);
				AnimateLevelPercentageSingle(_levelButton[i], "PercentC", _levelPercentC[i], animateTime);
			}
		}
	}

	public void OnLevelButtonPressed(int color, int alphabet)
	{
		_logic.DoLevelButtonPressed(color, alphabet);
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

		FindLevelGameObject();
	}
}
