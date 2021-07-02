using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetMenuUI : MonoBehaviour
{
	private AlphabetMenuLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Alphabet

	public GameObject _alphabetButtonPrefab;

	private GameObject _alphabetContent;
	private GameObject[] _alphabetButton;

	private void FindAlphabetGameObjects()
	{
		_alphabetContent = GameObject.Find("/Canvas/Alphabet/Viewport/Content");
	}

	private void SetupAlphabet()
	{
		int menuColor = _data.GetMenuColor();
		Debug.Log("color:" + menuColor);
		int numAlphabet = _level.GetNumAlphabet(menuColor);

		_alphabetButton = new GameObject[numAlphabet];

		Debug.Log("alphabet:" + numAlphabet);

		for (int i = 0; i < numAlphabet; i++)
		{
			int alphabet = i;
			_alphabetButton[i] = Instantiate(_alphabetButtonPrefab);
			_alphabetButton[i].transform.SetParent(_alphabetContent.transform);
			_alphabetButton[i].transform.localScale= new Vector3(1, 1, 1);
			_alphabetButton[i].transform.Find("Label").GetComponent<Text>().text = _level.GetAlphabetString(alphabet);
			_alphabetButton[i].GetComponent<Button>().onClick.AddListener(delegate { OnAlphabetButtonPressed(alphabet); });
		}
	}

	public void OnAlphabetButtonPressed(int alphabet)
	{
		_logic.DoAlphabetButtonPressed(alphabet);
	}

	// Back

	public void OnBackButtonPressed()
	{
		_logic.DoBackButtonPressed();
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("AlphabetMenuLogic").GetComponent<AlphabetMenuLogic>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindAlphabetGameObjects();
	}

	private void Start()
	{
		SetupAlphabet();
	}

	private void Update()
	{
	}

}
