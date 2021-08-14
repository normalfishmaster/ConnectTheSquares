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
	public Sprite[] _alphabetButtonSprite;

	private GameObject _alphabetContent;
	private GameObject[] _alphabetButton;

	private void FindAlphabetGameObjects()
	{
		_alphabetContent = GameObject.Find("/Canvas/Alphabet/Viewport/Content");
	}

	public void SetAlphabetSize(int size)
	{
		_alphabetButton = new GameObject[size];
	}

	public void AddAlphabet(int color, int alphabet, int star)
	{
		_alphabetButton[alphabet] = Instantiate(_alphabetButtonPrefab);
		_alphabetButton[alphabet].transform.SetParent(_alphabetContent.transform);
		_alphabetButton[alphabet].transform.localScale = new Vector3(1, 1, 1);
		_alphabetButton[alphabet].GetComponent<Image>().sprite = _alphabetButtonSprite[color];
		_alphabetButton[alphabet].transform.Find("Alphabet").GetComponent<Text>().text = _level.GetAlphabetString(alphabet);
		_alphabetButton[alphabet].transform.Find("Star").GetComponent<Text>().text = star.ToString() + " / 180";
		_alphabetButton[alphabet].GetComponent<Button>().onClick.AddListener(delegate { OnAlphabetButtonPressed(alphabet); });
	}

	public void OnAlphabetButtonPressed(int alphabet)
	{
		_logic.DoAlphabetButtonPressed(alphabet);
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
		_topColorPanel = GameObject.Find("/Canvas/Top/Color");
		_topColorText = GameObject.Find("/Canvas/Top/Color/Label").GetComponent<Text>();

		_topAlphabetAPanel = GameObject.Find("/Canvas/Top/Alphabet/A");
		_topAlphabetBPanel = GameObject.Find("/Canvas/Top/Alphabet/B");
		_topAlphabetCPanel = GameObject.Find("/Canvas/Top/Alphabet/C");
	}

	public void SetTopColor(int color)
	{
		_topColorPanel.GetComponent<Image>().sprite = _topColorSprite[color];
		_topColorText.text = _level.GetColorString(color);
	}

	public void SetTopAlphabet(int alphabet)
	{
		string str = _level.GetAlphabetString(alphabet);

		_topAlphabetAPanel.SetActive(false);
		_topAlphabetBPanel.SetActive(false);
		_topAlphabetCPanel.SetActive(false);

		if (str == "A")
		{
			_topAlphabetAPanel.SetActive(true);
		}
		else if (str == "B")
		{
			_topAlphabetBPanel.SetActive(true);
		}
		else if (str == "C")
		{
			_topAlphabetCPanel.SetActive(true);
		}
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
		FindTopGameObject();
	}
}
