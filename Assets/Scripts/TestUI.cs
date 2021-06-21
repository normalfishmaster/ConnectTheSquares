using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
	private TestLogic _logic;

	// Data

	private Text _dataKeyText;
	private Text _dataValueText;
	private Button _dataGetButton;
	private Button _dataSetButton;
	private Button _dataDumpAllButton;
	private Button _dataDeleteAllButton;
	private Button _dataResetAllButton;

	private void FindDataGameObject()
	{
		_dataKeyText = GameObject.Find("/Canvas/Data/GetSet/Key/Text").GetComponent<Text>();
		_dataValueText = GameObject.Find("/Canvas/Data/GetSet/Value/Text").GetComponent<Text>();
		_dataGetButton = GameObject.Find("/Canvas/Data/GetSet/Get").GetComponent<Button>();
		_dataSetButton = GameObject.Find("/Canvas/Data/GetSet/Set").GetComponent<Button>();
		_dataDumpAllButton = GameObject.Find("/Canvas/Data/DumpAll").GetComponent<Button>();
		_dataDeleteAllButton = GameObject.Find("/Canvas/Data/DeleteAll").GetComponent<Button>();
		_dataResetAllButton = GameObject.Find("/Canvas/Data/ResetAll").GetComponent<Button>();
	}

	public string GetDataKeyText()
	{
		return _dataKeyText.text;
	}

	public string GetDataValueText()
	{
		return _dataValueText.text;
	}

	public void OnDataGetButtonPressed()
	{
		_logic.DoDataGetButtonPressed();
	}

	public void OnDataSetButtonPressed()
	{
		_logic.DoDataSetButtonPressed();
	}

	public void OnDataDumpAllButtonPressed()
	{
		_logic.DoDataDumpAllButtonPressed();
	}

	public void OnDataDeleteAllButtonPressed()
	{
		_logic.DoDataDeleteAllButtonPressed();
	}

	public void OnDataResetAllButtonPressed()
	{
		_logic.DoDataResetAllButtonPressed();
	}

	// Ad

	private Button _adInterstitialButton;
	private Button _adInterstitialVideoButton;
	private Button _adRewardedButton;

	private void FindAdGameObject()
	{
		_adInterstitialButton = GameObject.Find("/Canvas/Ad/Interstitial").GetComponent<Button>();
		_adInterstitialVideoButton = GameObject.Find("/Canvas/Ad/InterstitialVideo").GetComponent<Button>();
		_adRewardedButton = GameObject.Find("/Canvas/Ad/Rewarded").GetComponent<Button>();
	}

	public void OnAdInterstitialButtonPressed()
	{
		_logic.DoAdInterstitialButtonPressed();
	}

	public void OnAdInterstitialVideoButtonPressed()
	{
		_logic.DoAdInterstitialVideoButtonPressed();
	}

	public void OnRewardedButtonPressed()
	{
		_logic.DoAdRewardedButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("TestLogic").GetComponent<TestLogic>();
		FindDataGameObject();
		FindAdGameObject();
	}
}
