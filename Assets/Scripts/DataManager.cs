using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static DataManager _instance = null;
	private static bool _initOnce = false;

	// Keys and Default Values

	public string GetAudioKey()						{ return "AudioKey";										}
	public int    GetAudioDefault()						{ return 1;											}

	public string GetAdFreeKey()						{ return "AdFreeKey";										}
	public int    GetAdFreeDefault()					{ return 0;											}

	public string GetHintKey()						{ return "HintKey";										}
	public int    GetHintDefault()						{ return 3;											}

	public string GetLevelLockKey(int color, int alphabet, int map)		{ return "LevelLockKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelLockDefault()					{ return 1;											}

	public string GetLevelStarKey(int color, int alphabet, int map)		{ return "LevelStarKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelStarDefault()					{ return 0;											}

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

	public bool  CheckLevelLock(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelLockKey(color, alphabet, map));				}
	public int   GetLevelLock(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelLockKey(color, alphabet, map));				}
	public void  SetLevelLock(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelLockKey(color, alphabet, map), value);			}
	public void  InitLevelLock(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelLockKey(color, alphabet, map), GetLevelLockDefault());	}

	public bool  CheckLevelStar(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelStarKey(color, alphabet, map));				}
	public int   GetLevelStar(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelStarKey(color, alphabet, map));				}
	public void  SetLevelStar(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelStarKey(color, alphabet, map), value);			}
	public void  InitLevelStar(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelStarKey(color, alphabet, map), GetLevelStarDefault());	}

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

			_initOnce = true;
			EventManager.TriggerDataInitCompleteEvent();
		}
	}
}
