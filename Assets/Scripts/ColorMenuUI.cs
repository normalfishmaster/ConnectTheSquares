using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMenuUI : MonoBehaviour
{
	private ColorMenuLogic _logic;
	private LevelManager _level;

	// Color

	public GameObject _colorButtonPrefab;
	public Sprite[] _colorButtonSprite;

	private GameObject _colorContent;
	private GameObject[] _colorButton;

	private void FindColorGameObjects()
	{
		_colorContent = GameObject.Find("/Canvas/Color/Viewport/Content");
	}

	public void SetupColorSize(int size)
	{
		_colorButton = new GameObject[size];
	}

	public void AddColor(int color, float percentage)
	{
		// Round to nearest 0.01f
		float pct = (float)(Math.Floor((double)(percentage * 100)) / 100);

		_colorButton[color] = Instantiate(_colorButtonPrefab);
		_colorButton[color].transform.SetParent(_colorContent.transform);
		_colorButton[color].transform.localScale = new Vector3(1, 1, 1);
		_colorButton[color].GetComponent<Image>().sprite = _colorButtonSprite[color];
		_colorButton[color].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
		_colorButton[color].transform.Find("Label").GetComponent<Text>().text = _level.GetColorString(color);
		_colorButton[color].transform.Find("Percent").GetComponent<Text>().text = pct.ToString() + "%";
		_colorButton[color].transform.Find("Wheel").GetComponent<Image>().fillAmount = percentage;
		_colorButton[color].GetComponent<Button>().onClick.AddListener(delegate { OnColorButtonPressed(color); });

		if (color % 2 == 1)
		{
			Text colorText = _colorButton[color].transform.Find("Label").GetComponent<Text>();
			Vector3 positionColor = colorText.transform.position;
			colorText.transform.position = new Vector3(-1 * positionColor.x, positionColor.y, positionColor.z);

			Image wheelVoidImage = _colorButton[color].transform.Find("WheelVoid").GetComponent<Image>();
			Vector3 positionVoid = wheelVoidImage.transform.position;
			wheelVoidImage.transform.position = new Vector3(-1 * positionVoid.x, positionVoid.y, positionVoid.z);

			Image wheelImage = _colorButton[color].transform.Find("Wheel").GetComponent<Image>();
			Vector3 positionWheel = wheelImage.transform.position;
			wheelImage.transform.position = new Vector3(-1 * positionWheel.x, positionWheel.y, positionWheel.z);

			Image starImage = _colorButton[color].transform.Find("Star").GetComponent<Image>();
			Vector3 positionStar = starImage.transform.position;
			starImage.transform.position = new Vector3(-1 * positionStar.x, positionStar.y, positionStar.z);

			Text percentText = _colorButton[color].transform.Find("Percent").GetComponent<Text>();
			Vector3 positionPercent = percentText.transform.position;
			percentText.transform.position = new Vector3(-1 * positionPercent.x, positionPercent.y, positionPercent.z);
		}
	}

	public void OnColorButtonPressed(int color)
	{
		_logic.DoColorButtonPressed(color);
	}

	// Back

	public void OnBackButtonPressed()
	{
		_logic.DoBackButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("ColorMenuLogic").GetComponent<ColorMenuLogic>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindColorGameObjects();
	}
}
