using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private static LevelManager _instance = null;

	private static int BROWN  = 0;
	private static int GREEN  = 1;
	private static int BLUE   = 2;
	private static int RED    = 3;
	private static int BLACK  = 4;

	private static int A      = 0;
	private static int B      = 1;
	private static int C      = 2;

	private static Dictionary<int, string> _tableColor = new Dictionary<int, string>()
	{
		{ BROWN,  "Novice" },
		{ GREEN,  "Adept"   },
		{ BLUE,   "Expert" },
		{ RED,    "Veteran"   },
		{ BLACK,  "Master" },
	};

	private static Dictionary<int, string> _tableAlphabet = new Dictionary<int, string>()
	{
		{ A, "A" },
		{ B, "B" },
		{ C, "C" },
	};

	private static Dictionary<int, Level[]> _tableLevel = new Dictionary<int, Level[]>()
	{
		{ BROWN,  new Level[] { new LevelBrownA(),  new LevelBrownB(),                      } },
		{ GREEN,  new Level[] { new LevelGreenA(),  new LevelGreenB(),  new LevelGreenC(),  } },
		{ BLUE,   new Level[] { new LevelBlueA(),   new LevelBlueB(),   new LevelBlueC(),   } },
		{ RED,    new Level[] { new LevelRedA(),    new LevelRedB(),    new LevelRedC(),    } },
		{ BLACK,  new Level[] { new LevelBlackA(),  new LevelBlackB(),  new LevelBlackC(),  } },
	};

	private static int[,] _totalAlphabetMaps;
	private static int[] _totalColorMaps;
	private static int _totalOverallMaps;

	private static int[,] _totalAlphabetStars;
	private static int[] _totalColorStars;
	private static int _totalOverallStars;

	// Conversion

	public string GetColorString(int color)
	{
		if (_tableColor.ContainsKey(color))
		{
			return _tableColor[color];
		}
		return "";
	}

	public string GetAlphabetString(int alphabet)
	{
		if (_tableAlphabet.ContainsKey(alphabet))
		{
			return _tableAlphabet[alphabet];
		}
		return "";
	}

	public string GetMapString(int map)
	{
		int val = map + 1;
		return val.ToString();
	}

	// Table operations

	public int GetNumColor()
	{
		return _tableLevel.Count;
	}

	public int GetNumAlphabet(int color)
	{
		if (color < GetNumColor())
		{
			return _tableLevel[color].Length;
		}
		return -1;
	}

	public int GetNumMap(int color, int alphabet)
	{
		if (alphabet < GetNumAlphabet(color))
		{
			return _tableLevel[color][alphabet]._map.Length;
		}
		return -1;
	}

	public Level.Map GetMap(int color, int alphabet, int map)
	{
		if (map < GetNumMap(color, alphabet))
		{
			return _tableLevel[color][alphabet]._map[map];
		}
		return new Level.Map();
	}

	// Totals

	private void CalculateTotals()
	{
		_totalAlphabetMaps = new int[5, 3];
		_totalColorMaps = new int[5];
		_totalOverallMaps = 0;

		_totalAlphabetStars = new int[5, 3];
		_totalColorStars = new int[5];
		_totalOverallStars = 0;

		int numColors = GetNumColor();

		for (int i = 0; i < numColors; i++)
		{
			_totalColorMaps[i] = 0;
			_totalColorStars[i] = 0;

			int numAlphabets = GetNumAlphabet(i);

			for (int j = 0; j < numAlphabets; j++)
			{
				int numMaps = GetNumMap(i, j);

				_totalAlphabetMaps[i, j] = numMaps;
				_totalAlphabetStars[i, j] = numMaps * 3;

				_totalColorMaps[i] += _totalAlphabetMaps[i, j];
				_totalColorStars[i] += _totalAlphabetStars[i, j];
			}

			_totalOverallMaps += _totalColorMaps[i];
			_totalOverallStars += _totalColorStars[i];
		}
	}

	public int GetTotalAlphabetMaps(int color, int alphabet)
	{
		return _totalAlphabetMaps[color, alphabet];
	}

	public int GetTotalColorMaps(int color)
	{
		return _totalColorMaps[color];
	}

	public int GetTotalOverallMaps()
	{
		return _totalOverallMaps;
	}

	public int GetTotalAlphabetStars(int color, int alphabet)
	{
		return _totalAlphabetStars[color, alphabet];
	}

	public int GetTotalColorStars(int color)
	{
		return _totalColorStars[color];
	}

	public int GetTotalOverallStars()
	{
		return _totalOverallStars;
	}

	// Unity Lifecycle

	private void Awake()
	{
		// Singleton implementation
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);

		CalculateTotals();
	}

	private void Start()
	{
	}
}
