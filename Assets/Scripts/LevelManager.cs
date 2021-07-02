using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private static LevelManager _instance = null;

	private static int GREY   = 0;
	private static int BLUE   = 1;
	private static int GREEN  = 2;
	private static int YELLOW = 3;
	private static int RED    = 4;

	private static int A      = 0;
	private static int B      = 1;
	private static int C      = 2;

	private static Dictionary<int, Level[]> _tableLevel = new Dictionary<int, Level[]>()
	{
		{ GREY,	  new Level[] { new LevelGreyA(),                                           } },
		{ BLUE,	  new Level[] { new LevelBlueA(),   new LevelBlueB(),   new LevelBlueC(),   } },
		{ GREEN,  new Level[] { new LevelGreenA(),  new LevelGreenB(),  new LevelGreenC(),  } },
		{ YELLOW, new Level[] { new LevelYellowA(), new LevelYellowB(), new LevelYellowC(), } },
		{ RED,	  new Level[] { new LevelRedA(),    new LevelRedB(),    new LevelRedC(),    } },

	};

	private static Dictionary<int, string> _tableColor = new Dictionary<int, string>()
	{
		{ GREY,   "Grey"   },
		{ BLUE,   "Blue"   },
		{ GREEN,  "Green"  },
		{ YELLOW, "Yellow" },
		{ RED,    "Red"    },
	};

	private static Dictionary<int, string> _tableAlphabet = new Dictionary<int, string>()
	{
		{ A, "A" },
		{ B, "B" },
		{ C, "C" },
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

	// Table operations

	public int GetNumColor()
	{
		return _tableLevel.Count;
	}

	public int GetNumAlphabet(int color)
	{
		if (_tableColor.ContainsKey(color))
		{
			return _tableLevel[color].Length;
		}
		return -1;
	}

	public int GetNumMap(int color, int alphabet)
	{
		if (_tableColor.ContainsKey(color))
		{
			return _tableLevel[color][alphabet]._map.Length;
		}
		return -1;
	}

	public Level.Map? GetMap(int color, int alphabet, int map)
	{
		if (_tableColor.ContainsKey(color))
		{
			return _tableLevel[color][alphabet]._map[map];
		}
		return null;
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
