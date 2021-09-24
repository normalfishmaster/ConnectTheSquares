using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
	private TestLogic _logic;

	// Data

	private Text _dataIntKeyText;
	private Text _dataIntValueText;

	private Text _dataFloatKeyText;
	private Text _dataFloatValueText;

	private Text _dataStringKeyText;
	private Text _dataStringValueText;

	private void FindDataGameObjects()
	{
		_dataIntKeyText = GameObject.Find("/Canvas/Data/Int/Key/Text").GetComponent<Text>();
		_dataIntValueText = GameObject.Find("/Canvas/Data/Int/Value/Text").GetComponent<Text>();

		_dataFloatKeyText = GameObject.Find("/Canvas/Data/Float/Key/Text").GetComponent<Text>();
		_dataFloatValueText = GameObject.Find("/Canvas/Data/Float/Value/Text").GetComponent<Text>();

		_dataStringKeyText = GameObject.Find("/Canvas/Data/String/Key/Text").GetComponent<Text>();
		_dataStringValueText = GameObject.Find("/Canvas/Data/String/Value/Text").GetComponent<Text>();
	}

	public string GetDataIntKey()
	{
		return _dataIntKeyText.text;
	}

	public string GetDataIntValue()
	{
		return _dataIntValueText.text;
	}

	public string GetDataFloatKey()
	{
		return _dataFloatKeyText.text;
	}

	public string GetDataFloatValue()
	{
		return _dataFloatValueText.text;
	}

	public string GetDataStringKey()
	{
		return _dataStringKeyText.text;
	}

	public string GetDataStringValue()
	{
		return _dataStringValueText.text;
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("TestLogic").GetComponent<TestLogic>();

		FindDataGameObjects();
	}
}
