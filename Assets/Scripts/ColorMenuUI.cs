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

	private GameObject _colorContent;
	private GameObject[] _colorButton;

	private void FindColorGameObjects()
	{
		_colorContent = GameObject.Find("/Canvas/Color/Viewport/Content");
	}

	private void SetupColor()
	{
		int numColors = _level.GetNumColors();

		_colorButton = new GameObject[numColors];

		for (int i = 0; i < numColors; i++)
		{
			string color = _level.GetColorString(i);

			_colorButton[i] = Instantiate(_colorButtonPrefab);
			_colorButton[i].transform.SetParent(_colorContent.transform);
			_colorButton[i].transform.localScale= new Vector3(1, 1, 1);
			_colorButton[i].transform.Find("Label").GetComponent<Text>().text = color;
			_colorButton[i].GetComponent<Button>().onClick.AddListener(delegate { OnColorButtonPressed(color); });
		}
	}

	public void OnColorButtonPressed(string color)
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

	private void Start()
	{
		SetupColor();
	}

	private void Update()
	{
	}

}
