using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

	private static LevelManager _instance = null;

	private static Level[] _level =
	{
		new LevelGrey(),
		new LevelBlue(),
		new LevelGreen(),
		new LevelYellow(),
		new LevelRed()
	};

	private static string[] _levelColor =
	{
		"Grey",
		"Blue",
		"Green",
		"Yellow",
		"Red"
	};

	// Misc

	public int GetNumColors()
	{
		return _level.Length;
	}

	public string ColorIntToString(int color)
	{
		if (color >= GetNumColors())
		{
			return "";
		}
		else
		{
			return _levelColor[color];
		}
	}

	public int ColorStringToInt(string color)
	{
		for (int i = 0; i < GetNumColors(); i++)
		{
			if (color == _levelColor[i])
			{
				return i;
			}
		}

		return -1;
	}

	// Per color operations

	public int GetColorNumMaps(int color)
	{
		if (color >= GetNumColors())
		{
			return -1;
		}

		return _level[color]._map.Length;
	}

	public Level.Map? GetColorMap(int color, int map)
	{
		if (color >= GetNumColors() || map >= GetColorNumMaps(color))
		{
			return null;
		}

		return _level[color]._map[map];
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
