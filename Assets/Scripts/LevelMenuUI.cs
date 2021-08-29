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

	public GameObject _levelPanel;
	public GameObject _levelButtonSinglePrefab;
	public GameObject _levelButtonTriplePrefab;

	private GameObject[] _levelButton;

	private GameObject _levelContent;

	private void FindLevelGameObject()
        {
		_levelPanel = GameObject.Find("/Canvas/Level");
		_levelContent = GameObject.Find("/Canvas/Level/Viewport/Content");
	}

	public void SetLevelSize(int size)
	{
		_levelButton = new GameObject[size];
	}

	private void AnimatePercentage(GameObject button, string name, float val)
	{
		Transform transform = button.transform.Find(name);
		GameObject gameObject = transform.gameObject;

		transform.localScale = Vector3.one;

		LeanTween.cancel(gameObject);

		LeanTween.scale(gameObject, Vector3.one * 1.25f, 2.0f).setEasePunch();

		LeanTween.value(gameObject, 0.0f, val, 0.5f).setOnUpdate
		(
			(float val) =>
			{
				transform.GetComponent<Text>().text = val.ToString("0") + "%";
			}
		)
		.setEase(LeanTweenType.easeOutSine);
	}

	public void AddLevelSingle(int color, string moves, float percentA)
	{
		float pctA = (float)(Math.Floor((double)(percentA * 100)) / 100);

		_levelButton[color] = Instantiate(_levelButtonSinglePrefab);
		_levelButton[color].transform.SetParent(_levelContent.transform);
		_levelButton[color].transform.localScale = new Vector3(1, 1, 1);
		_levelButton[color].transform.Find("Color/Label").GetComponent<Text>().text = _level.GetColorString(color);
		_levelButton[color].transform.Find("Moves").GetComponent<Text>().text = moves;
		_levelButton[color].transform.Find("A").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 0); });

		AnimatePercentage(_levelButton[color], "PercentA", pctA);
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
		_levelButton[color].transform.Find("A").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 0); });
		_levelButton[color].transform.Find("B").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 1); });
		_levelButton[color].transform.Find("C").GetComponent<Button>().onClick.AddListener(delegate { OnLevelButtonPressed(color, 2); });

		pctA = 10f;
		pctB = 100f;
		pctC = 100f;

		AnimatePercentage(_levelButton[color], "PercentA", pctA);
		AnimatePercentage(_levelButton[color], "PercentB", pctB);
		AnimatePercentage(_levelButton[color], "PercentC", pctC);
	}

        public void AnimateLevelEnter()
        {
                RectTransform rt = (RectTransform)_levelPanel.transform;
                Vector3 pos = rt.anchoredPosition;
                float height = rt.rect.height;

                rt.anchoredPosition = new Vector3(pos.x, pos.y - height, pos.z);

                LeanTween.cancel(_levelPanel);
                LeanTween.moveLocalY(_levelPanel, 0.0f, 0.25f).setEase(LeanTweenType.easeOutQuad);
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
