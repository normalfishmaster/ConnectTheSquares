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
		{ BROWN,  "Tutorial" },
		{ GREEN,  "Easy"     },
		{ BLUE,   "Medium"   },
		{ RED,    "Hard"     },
		{ BLACK,  "Expert"   },
	};

	private static Dictionary<int, string> _tableAlphabet = new Dictionary<int, string>()
	{
		{ A, "A" },
		{ B, "B" },
		{ C, "C" },
	};

	private static Dictionary<int, Level[]> _tableLevel = new Dictionary<int, Level[]>()
	{
		{ BROWN,  new Level[] { new LevelBrownA(),                                          } },
		{ GREEN,  new Level[] { new LevelGreenA(),  new LevelGreenB(),  new LevelGreenC(),  } },
		{ BLUE,   new Level[] { new LevelBlueA(),   new LevelBlueB(),   new LevelBlueC(),   } },
		{ RED,    new Level[] { new LevelRedA(),    new LevelRedB(),    new LevelRedC(),    } },
		{ BLACK,  new Level[] { new LevelBlackA(),  new LevelBlackB(),  new LevelBlackC(),  } },
	};

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
	}
}
