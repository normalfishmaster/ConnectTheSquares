using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static DataManager _instance;
	private static LevelManager _level;

	private static bool _initOnce = false;

	// Keys and Default Values

	public string GetAudioKey()						{ return "AudioKey";										}
	public int    GetAudioDefault()						{ return 1;											}

	public string GetAdFreeKey()						{ return "AdFreeKey";										}
	public int    GetAdFreeDefault()					{ return 0;											}

	public string GetHintKey()						{ return "HintKey";										}
	public int    GetHintDefault()						{ return 3;											}

	public string GetMenuColorKey()						{ return "MenuColorKey";									}
	public int    GetMenuColorDefault()					{ return -1;											}

	public string GetMenuAlphabetKey()					{ return "MenuAlphabetKey";									}
	public int    GetMenuAlphabetDefault()					{ return -1;											}

	public string GetMenuMapKey()						{ return "MenuMapKey";										}
	public int    GetMenuMapDefault()					{ return -1;											}

	public string GetLastColorKey()						{ return "LastColorKey";									}
	public int    GetLastColorDefault()					{ return -1;											}

	public string GetLastAlphabetKey()					{ return "LastAlphabetKey";									}
	public int    GetLastAlphabetDefault()					{ return -1;											}

	public string GetLastMapKey()						{ return "LastMapKey";										}
	public int    GetLastMapDefault()					{ return -1;											}

	public string GetLevelLockKey(int color, int alphabet, int map)		{ return "LevelLockKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelLockDefault()					{ return 1;											}

	public string GetLevelStarKey(int color, int alphabet, int map)		{ return "LevelStarKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelStarDefault()					{ return 0;											}

	public string GetLevelMoveKey(int color, int alphabet, int map)		{ return "levelMoveKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelMoveDefault()					{ return 0;											}

	// Operations by Data Type

	public bool  CheckAudio()						{ return PlayerPrefs.HasKey(GetAudioKey());							}
	public int   GetAudio()							{ return PlayerPrefs.GetInt(GetAudioKey());							}
	public void  SetAudio(int value)					{        PlayerPrefs.SetInt(GetAudioKey(), value);						}
	public void  InitAudio()						{        PlayerPrefs.SetInt(GetAudioKey(), GetAudioDefault());					}

	public bool  CheckHint()						{ return PlayerPrefs.HasKey(GetHintKey());							}
	public int   GetHint()							{ return PlayerPrefs.GetInt(GetHintKey());							}
	public void  SetHint(int value)						{        PlayerPrefs.SetInt(GetHintKey(), value);						}
	public void  InitHint()							{        PlayerPrefs.SetInt(GetHintKey(), GetHintDefault());					}

	public bool  CheckAdFree()						{ return PlayerPrefs.HasKey(GetAdFreeKey());							}
	public int   GetAdFree()						{ return PlayerPrefs.GetInt(GetAdFreeKey());							}
	public void  SetAdFree(int value)					{        PlayerPrefs.SetInt(GetAdFreeKey(), value);						}
	public void  InitAdFree()						{        PlayerPrefs.SetInt(GetAdFreeKey(), GetAdFreeDefault());				}

	public bool  CheckMenuColor()						{ return PlayerPrefs.HasKey(GetMenuColorKey());							}
	public int   GetMenuColor()						{ return PlayerPrefs.GetInt(GetMenuColorKey());							}
	public void  SetMenuColor(int value)					{        PlayerPrefs.SetInt(GetMenuColorKey(), value);						}
	public void  InitMenuColor()						{        PlayerPrefs.SetInt(GetMenuColorKey(), GetMenuColorDefault());				}

	public bool  CheckMenuAlphabet()					{ return PlayerPrefs.HasKey(GetMenuAlphabetKey());						}
	public int   GetMenuAlphabet()						{ return PlayerPrefs.GetInt(GetMenuAlphabetKey());						}
	public void  SetMenuAlphabet(int value)					{        PlayerPrefs.SetInt(GetMenuAlphabetKey(), value);					}
	public void  InitMenuAlphabet()						{        PlayerPrefs.SetInt(GetMenuAlphabetKey(), GetMenuAlphabetDefault());			}

	public bool  CheckMenuMap()						{ return PlayerPrefs.HasKey(GetMenuMapKey());							}
	public int   GetMenuMap()						{ return PlayerPrefs.GetInt(GetMenuMapKey());							}
	public void  SetMenuMap(int value)					{        PlayerPrefs.SetInt(GetMenuMapKey(), value);						}
	public void  InitMenuMap()						{        PlayerPrefs.SetInt(GetMenuMapKey(), GetMenuMapDefault());				}

	public bool  CheckLastColor()						{ return PlayerPrefs.HasKey(GetLastColorKey());							}
	public int   GetLastColor()						{ return PlayerPrefs.GetInt(GetLastColorKey());							}
	public void  SetLastColor(int value)					{        PlayerPrefs.SetInt(GetLastColorKey(), value);						}
	public void  InitLastColor()						{        PlayerPrefs.SetInt(GetLastColorKey(), GetMenuColorDefault());				}

	public bool  CheckLastAlphabet()					{ return PlayerPrefs.HasKey(GetLastAlphabetKey());						}
	public int   GetLastAlphabet()						{ return PlayerPrefs.GetInt(GetLastAlphabetKey());						}
	public void  SetLastAlphabet(int value)					{        PlayerPrefs.SetInt(GetLastAlphabetKey(), value);					}
	public void  InitLastAlphabet()						{        PlayerPrefs.SetInt(GetLastAlphabetKey(), GetMenuAlphabetDefault());			}

	public bool  CheckLastMap()						{ return PlayerPrefs.HasKey(GetLastMapKey());							}
	public int   GetLastMap()						{ return PlayerPrefs.GetInt(GetLastMapKey());							}
	public void  SetLastMap(int value)					{        PlayerPrefs.SetInt(GetLastMapKey(), value);						}
	public void  InitLastMap()						{        PlayerPrefs.SetInt(GetLastMapKey(), GetMenuMapDefault());				}

	public bool  CheckLevelLock(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelLockKey(color, alphabet, map));				}
	public int   GetLevelLock(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelLockKey(color, alphabet, map));				}
	public void  SetLevelLock(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelLockKey(color, alphabet, map), value);			}
	public void  InitLevelLock(int color, int alphabet, int map)		{        PlayerPrefs.SetInt(GetLevelLockKey(color, alphabet, map), GetLevelLockDefault());	}

	public bool  CheckLevelStar(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelStarKey(color, alphabet, map));				}
	public int   GetLevelStar(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelStarKey(color, alphabet, map));				}
	public void  SetLevelStar(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelStarKey(color, alphabet, map), value);			}
	public void  InitLevelStar(int color, int alphabet, int map)		{        PlayerPrefs.SetInt(GetLevelStarKey(color, alphabet, map), GetLevelStarDefault());	}

	public bool  CheckLevelMove(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelMoveKey(color, alphabet, map));				}
	public int   GetLevelMove(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelMoveKey(color, alphabet, map));				}
	public void  SetLevelMove(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelMoveKey(color, alphabet, map), value);			}
	public void  InitLevelMove(int color, int alphabet, int map)		{        PlayerPrefs.SetInt(GetLevelMoveKey(color, alphabet, map), GetLevelMoveDefault());	}

	// Check by Key

	public bool CheckByKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	// Get by Key

	public int GetIntByKey(string key)
	{
		return PlayerPrefs.GetInt(key);
	}

	public float GetFloatByKey(string key)
	{
		return PlayerPrefs.GetFloat(key);
	}

	public string GetStringByKey(string key)
	{
		return PlayerPrefs.GetString(key);
	}

	// Set by Key

	public void SetIntByKey(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public void SetFloatByKey(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public void SetStringByKey(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	// Manage Data

	public void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	// Unity Lifecyle

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

		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

	private void Start()
	{
		if (_initOnce == false)
		{
			if (CheckAudio() == false)
			{
				InitAudio();
			}
			if (CheckHint() == false)
			{
				InitHint();
			}
			if (CheckAdFree() == false)
			{
				InitAdFree();
			}
			if (CheckMenuColor() == false)
			{
				InitMenuColor();
			}
			if (CheckMenuAlphabet() == false)
			{
				InitMenuAlphabet();
			}
			if (CheckMenuMap() == false)
			{
				InitMenuMap();
			}
			if (CheckLastColor() == false)
			{
				InitLastColor();
			}
			if (CheckLastAlphabet() == false)
			{
				InitLastAlphabet();
			}
			if (CheckLastMap() == false)
			{
				InitLastMap();
			}

			int numColor = _level.GetNumColor();

			for (int i = 0; i < numColor; i++)
			{
				int numAlphabet = _level.GetNumAlphabet(i);

				for (int j = 0; j < numAlphabet; j++)
				{
					int numMap = _level.GetNumMap(i, j);

					for (int k = 0; k < numMap; k++)
					{
						if (CheckLevelLock(i, j, k) == false)
						{
							InitLevelLock(i, j, k);
						}

						if (CheckLevelStar(i, j, k) == false)
						{
							InitLevelStar(i, j, k);
						}

						if (CheckLevelMove(i, j, k) == false)
						{
							InitLevelMove(i, j, k);
						}
					}
				}
			}

			_initOnce = true;
			EventManager.TriggerDataInitCompleteEvent();
		}
	}
}
