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

	public void OnDataIntGetButtonPressed()
	{
		_logic.DoDataIntGetButtonPressed(_dataIntKeyText.text);
	}

	public void OnDataIntSetButtonPressed()
	{
		_logic.DoDataIntSetButtonPressed(_dataIntKeyText.text, _dataIntValueText.text);
	}

	public void OnDataFloatGetButtonPressed()
	{
		_logic.DoDataFloatGetButtonPressed(_dataFloatKeyText.text);
	}

	public void OnDataFloatSetButtonPressed()
	{
		_logic.DoDataFloatSetButtonPressed(_dataFloatKeyText.text, _dataFloatValueText.text);
	}

	public void OnDataStringGetButtonPressed()
	{
		_logic.DoDataStringGetButtonPressed(_dataStringKeyText.text);
	}

	public void OnDataStringSetButtonPressed()
	{
		_logic.DoDataStringSetButtonPressed(_dataStringKeyText.text, _dataStringValueText.text);
	}

	public void OnDataAllDumpButtonPressed()
	{
		_logic.DoDataAllDumpButtonPressed();
	}

	public void OnDataAllDeleteButtonPressed()
	{
		_logic.DoDataAllDeleteButtonPressed();
	}

	public void OnDataAllReinitButtonPressed()
	{
		_logic.DoDataAllReinitButtonPressed();
	}

	// Ad

	public void OnAdInterstitialButtonPressed()
	{
		_logic.DoAdInterstitialButtonPressed();
	}

	public void OnAdInterstitialVideoButtonPressed()
	{
		_logic.DoAdInterstitialVideoButtonPressed();
	}

	public void OnAdRewardedButtonPressed()
	{
		_logic.DoAdRewardedButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("TestLogic").GetComponent<TestLogic>();

		FindDataGameObjects();
	}
}
