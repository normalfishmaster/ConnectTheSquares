using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetMenuLogic : MonoBehaviour
{
	private AlphabetMenuUI _ui;
	private DataManager _data;

	// Alphabet

	public void DoAlphabetButtonPressed(int alphabet)
	{
		_data.SetMenuAlphabet(alphabet);
		SceneManager.LoadScene("MapMenuScene");
	}

	// Back

	public void DoBackButtonPressed()
	{
		SceneManager.LoadScene("ColorMenuScene");
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("AlphabetMenuUI").GetComponent<AlphabetMenuUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
	}
}
