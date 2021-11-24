using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static AudioManager _audio;
	private static DataManager _instance;
	private static ItemManager _item;
	private static LevelManager _level;

	// Keys and Default Values

	public string GetAudioKey()						{ return "AudioKey";										}
	public int    GetAudioDefault()						{ return 1;											}

	public string GetNotificationKey()					{ return "NotificationKey";									}
	public int    GetNotificationDefault()					{ return 1;											}

	public string GetMenuColorKey()						{ return "MenuColorKey";									}
	public int    GetMenuColorDefault()					{ return -1;											}

	public string GetMenuAlphabetKey()					{ return "MenuAlphabetKey";									}
	public int    GetMenuAlphabetDefault()					{ return -1;											}

	public string GetMenuMapKey()						{ return "MenuMapKey";										}
	public int    GetMenuMapDefault()					{ return -1;											}

	public string GetLevelLockKey(int color, int alphabet, int map)		{ return "LevelLockKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelLockDefault()					{ return 1;											}

	public string GetLevelMoveKey(int color, int alphabet, int map)		{ return "levelMoveKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelMoveDefault()					{ return 0;											}

	public string GetLevelStarKey(int color, int alphabet, int map)		{ return "LevelStarKey" + "_" + color + "_" + alphabet + "_" + map;				}
	public int    GetLevelStarDefault()					{ return 0;											}

	public string GetAlphabetStarKey(int color, int alphabet)		{ return "AlphabetStarKey" + "_" + color + "_" + alphabet;					}
	public int    GetAlphabetStarDefault()					{ return 0;											}

	public string GetAlphabetStarTotalKey(int color, int alphabet)		{ return "AlphabetStarTotalKey" + "_" + color + "_" + alphabet;					}
	public int    GetAlphabetStarTotalDefault()				{ return 0;											}

	public string GetColorStarKey(int color)				{ return "ColorStarKey" + "_" + color;								}
	public int    GetColorStarDefault()					{ return 0;											}

	public string GetColorStarTotalKey(int color)				{ return "ColorStarTotalKey" + "_" + color;							}
	public int    GetColorStarTotalDefault()				{ return 0;											}

	public string GetColorSolvedKey(int color)				{ return "ColorSolvedKey" + "_" + color;							}
	public int    GetColorSolvedDefault()					{ return 0;											}

	public string GetColorSolvedTotalKey(int color)				{ return "ColorSolvedTotalKey" + "_" + color;							}
	public int    GetColorSolvedTotalDefault()				{ return 0;											}

	public string GetBackgroundColorKey()					{ return "BackgroundColorKey";									}
	public int    GetBackgroundColorDefault()				{ return 0;											}

	public string GetPlayTimeKey()						{ return "PlayTimeKey";										}
	public float  GetPlayTimeDefault()					{ return 0f;											}

	public string GetSkippedAdsKey()					{ return "GetSkippedAdsKey";									}
	public int    GetSkippedAdsDefault()					{ return 0;											}

	public string GetBlockSetKey()						{ return "BlockSetKey";										}
	public int    GetBlockSetDefault()					{ return 0;											}

	public string GetBlockPreviewKey()					{ return "BlockPreviewKey";									}
	public int    GetBlockPreviewDefault()					{ return 0;											}

	// Operations by Data Type

	public bool  CheckAudio()						{ return PlayerPrefs.HasKey(GetAudioKey());							}
	public int   GetAudio()							{ return PlayerPrefs.GetInt(GetAudioKey());							}
	public void  SetAudio(int value)					{        PlayerPrefs.SetInt(GetAudioKey(), value);						}
	public void  InitAudio()						{        PlayerPrefs.SetInt(GetAudioKey(), GetAudioDefault());					}

	public bool  CheckNotification()					{ return PlayerPrefs.HasKey(GetNotificationKey());						}
	public int   GetNotification()						{ return PlayerPrefs.GetInt(GetNotificationKey());						}
	public void  SetNotification(int value)					{        PlayerPrefs.SetInt(GetNotificationKey(), value);					}
	public void  InitNotification()						{        PlayerPrefs.SetInt(GetNotificationKey(), GetNotificationDefault());			}

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

	public bool  CheckLevelLock(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelLockKey(color, alphabet, map));				}
	public int   GetLevelLock(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelLockKey(color, alphabet, map));				}
	public void  SetLevelLock(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelLockKey(color, alphabet, map), value);			}
	public void  InitLevelLock(int color, int alphabet, int map)		{        PlayerPrefs.SetInt(GetLevelLockKey(color, alphabet, map), GetLevelLockDefault());	}

	public bool  CheckLevelMove(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelMoveKey(color, alphabet, map));				}
	public int   GetLevelMove(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelMoveKey(color, alphabet, map));				}
	public void  SetLevelMove(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelMoveKey(color, alphabet, map), value);			}
	public void  InitLevelMove(int color, int alphabet, int map)		{        PlayerPrefs.SetInt(GetLevelMoveKey(color, alphabet, map), GetLevelMoveDefault());	}

	public bool  CheckLevelStar(int color, int alphabet, int map)		{ return PlayerPrefs.HasKey(GetLevelStarKey(color, alphabet, map));				}
	public int   GetLevelStar(int color, int alphabet, int map)		{ return PlayerPrefs.GetInt(GetLevelStarKey(color, alphabet, map));				}
	public void  SetLevelStar(int color, int alphabet, int map, int value)	{        PlayerPrefs.SetInt(GetLevelStarKey(color, alphabet, map), value);			}
	public void  InitLevelStar(int color, int alphabet, int map)		{        PlayerPrefs.SetInt(GetLevelStarKey(color, alphabet, map), GetLevelStarDefault());	}

	public bool  CheckAlphabetStar(int color, int alphabet)			{ return PlayerPrefs.HasKey(GetAlphabetStarKey(color, alphabet));				}
	public int   GetAlphabetStar(int color, int alphabet)			{ return PlayerPrefs.GetInt(GetAlphabetStarKey(color, alphabet));				}
	public void  SetAlphabetStar(int color, int alphabet, int value)	{        PlayerPrefs.SetInt(GetAlphabetStarKey(color, alphabet), value);			}
	public void  InitAlphabetStar(int color, int alphabet)			{        PlayerPrefs.SetInt(GetAlphabetStarKey(color, alphabet), GetAlphabetStarDefault());	}

	public bool  CheckAlphabetStarTotal(int color, int alphabet)		{ return PlayerPrefs.HasKey(GetAlphabetStarTotalKey(color, alphabet));				}
	public int   GetAlphabetStarTotal(int color, int alphabet)		{ return PlayerPrefs.GetInt(GetAlphabetStarTotalKey(color, alphabet));				}
	public void  SetAlphabetStarTotal(int color, int alphabet, int value)	{        PlayerPrefs.SetInt(GetAlphabetStarTotalKey(color, alphabet), value);			}
	public void  InitAlphabetStarTotal(int color, int alphabet)		{        PlayerPrefs.SetInt(GetAlphabetStarTotalKey(color, alphabet), GetAlphabetStarTotalDefault()); }

	public bool  CheckColorStar(int color)					{ return PlayerPrefs.HasKey(GetColorStarKey(color));						}
	public int   GetColorStar(int color)					{ return PlayerPrefs.GetInt(GetColorStarKey(color));						}
	public void  SetColorStar(int color, int value)				{        PlayerPrefs.SetInt(GetColorStarKey(color), value);					}
	public void  InitColorStar(int color)					{        PlayerPrefs.SetInt(GetColorStarKey(color), GetColorStarDefault());			}

	public bool  CheckColorStarTotal(int color)				{ return PlayerPrefs.HasKey(GetColorStarTotalKey(color));					}
	public int   GetColorStarTotal(int color)				{ return PlayerPrefs.GetInt(GetColorStarTotalKey(color));					}
	public void  SetColorStarTotal(int color, int value)			{        PlayerPrefs.SetInt(GetColorStarTotalKey(color), value);				}
	public void  InitColorStarTotal(int color)				{        PlayerPrefs.SetInt(GetColorStarTotalKey(color), GetColorStarTotalDefault());		}

	public bool  CheckColorSolved(int color)				{ return PlayerPrefs.HasKey(GetColorSolvedKey(color));						}
	public int   GetColorSolved(int color)					{ return PlayerPrefs.GetInt(GetColorSolvedKey(color));						}
	public void  SetColorSolved(int color, int value)			{        PlayerPrefs.SetInt(GetColorSolvedKey(color), value);					}
	public void  InitColorSolved(int color)					{        PlayerPrefs.SetInt(GetColorSolvedKey(color), GetColorSolvedDefault());			}

	public bool  CheckColorSolvedTotal(int color)				{ return PlayerPrefs.HasKey(GetColorSolvedTotalKey(color));					}
	public int   GetColorSolvedTotal(int color)				{ return PlayerPrefs.GetInt(GetColorSolvedTotalKey(color));					}
	public void  SetColorSolvedTotal(int color, int value)			{        PlayerPrefs.SetInt(GetColorSolvedTotalKey(color), value);				}
	public void  InitColorSolvedtotal(int color)				{        PlayerPrefs.SetInt(GetColorSolvedTotalKey(color), GetColorSolvedTotalDefault());	}

	public bool  CheckBackgroundColor()					{ return PlayerPrefs.HasKey(GetBackgroundColorKey());						}
	public int   GetBackgroundColor()					{ return PlayerPrefs.GetInt(GetBackgroundColorKey());						}
	public void  SetBackgroundColor(int value)				{        PlayerPrefs.SetInt(GetBackgroundColorKey(), value);					}
	public void  InitBackgroundColor()					{        PlayerPrefs.SetInt(GetBackgroundColorKey(), GetBackgroundColorDefault());		}

	public bool  CheckPlayTime()						{ return PlayerPrefs.HasKey(GetPlayTimeKey());							}
	public float GetPlayTime()						{ return PlayerPrefs.GetFloat(GetPlayTimeKey());						}
	public void  SetPlayTime(float value)					{        PlayerPrefs.SetFloat(GetPlayTimeKey(), value);						}
	public void  InitPlayTime()						{        PlayerPrefs.SetFloat(GetPlayTimeKey(), GetPlayTimeDefault());				}

	public bool  CheckSkippedAds()						{ return PlayerPrefs.HasKey(GetSkippedAdsKey());						}
	public int   GetSkippedAds()						{ return PlayerPrefs.GetInt(GetSkippedAdsKey());						}
	public void  SetSkippedAds(int value)					{        PlayerPrefs.SetInt(GetSkippedAdsKey(), value);						}
	public void  InitSkippedAds()						{        PlayerPrefs.SetInt(GetSkippedAdsKey(), GetSkippedAdsDefault());			}

	public bool  CheckBlockSet()						{ return PlayerPrefs.HasKey(GetBlockSetKey());							}
	public int   GetBlockSet()						{ return PlayerPrefs.GetInt(GetBlockSetKey());							}
	public void  SetBlockSet(int value)					{        PlayerPrefs.SetInt(GetBlockSetKey(), value);						}
	public void  InitBlockSet()						{        PlayerPrefs.SetInt(GetBlockSetKey(), GetBlockSetDefault());				}

	public bool  CheckBlockPreview()					{ return PlayerPrefs.HasKey(GetBlockPreviewKey());						}
	public int   GetBlockPreview()						{ return PlayerPrefs.GetInt(GetBlockPreviewKey());						}
	public void  SetBlockPreview(int value)					{        PlayerPrefs.SetInt(GetBlockPreviewKey(), value);					}
	public void  InitBlockPreview()						{        PlayerPrefs.SetInt(GetBlockPreviewKey(), GetBlockPreviewDefault());			}

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

	// Calculation Methods

	public void RecalculateBackgroundColor()
	{
		int numColor = _level.GetNumColor();

		for (int i = numColor - 1; i >= 0; i--)
		{
			if (GetColorSolved(i) == GetColorSolvedTotal(i))
			{
				if (i == numColor - 1)
				{
					SetBackgroundColor(i);
				}
				else
				{
					SetBackgroundColor(i + 1);
				}
				return;
			}
		}

		SetBackgroundColor(0);
	}

	public void RecalculateLevelTotal()
	{
		int numColor = _level.GetNumColor();

		for (int i = 0; i < numColor; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);
			int starColorEarned = 0;
			int starColorTotal = 0;
			int solvedColorEarned = 0;
			int solvedColorTotal = 0;

			for (int j = 0; j < numAlphabet; j++)
			{
				int numMap = _level.GetNumMap(i, j);
				int starAlphabetEarned = 0;
				int starAlphabetTotal = 0;

				for (int k = 0; k < numMap; k++)
				{
					int star = GetLevelStar(i, j, k);
					if (star >= 1)
					{
						starAlphabetEarned += star;
						solvedColorEarned += 1;
					}
					starAlphabetTotal += 3;
					solvedColorTotal += 1;
				}

				SetAlphabetStar(i, j, starAlphabetEarned);
				SetAlphabetStarTotal(i, j, starAlphabetTotal);

				starColorEarned += starAlphabetEarned;
				starColorTotal += starAlphabetTotal;
			}

			SetColorStar(i, starColorEarned);
			SetColorStarTotal(i, starColorTotal);

			SetColorSolved(i, solvedColorEarned);
			SetColorSolvedTotal(i, solvedColorTotal);
		}

		RecalculateBackgroundColor();
	}

	// Unlock Levels

	private void UnlockAllLevels()
	{
		if (_item.IsItemUnlocked(ItemManager.UNLOCK_ALL_LEVELS))
		{
			int numColor = _level.GetNumColor();

			for (int i = 0; i < numColor; i++)
			{
				int numAlphabet = _level.GetNumAlphabet(i);

				for (int j = 0; j < numAlphabet; j++)
				{
					int numMap = _level.GetNumMap(i, j);

					for (int k = 0; k < numMap; k++)
					{
						SetLevelLock(i, j, k, 0);
					}
				}
			}
		}
	}

	// Initialize Data

	public void InitializeData()
	{
		if (CheckAudio() == false)
		{
			InitAudio();
		}
		if (CheckNotification() == false)
		{
			InitNotification();
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

		SetLevelLock(0, 0, 0, 0);

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

		if (CheckPlayTime() == false)
		{
			InitPlayTime();
		}
		if (CheckSkippedAds() == false)
		{
			InitSkippedAds();
		}
		if (CheckBlockSet() == false)
		{
			InitBlockSet();
		}
		if (CheckBlockPreview() == false)
		{
			InitBlockPreview();
		}
	}

	// Delegates
	// This is used exclusively by the StartupScene

	public delegate void InitComplete();
	private static event InitComplete _initComplete;

	public void SubscribeInitComplete(InitComplete callback)
	{
		_initComplete += callback;
	}

	public void UnsubscribeInitComplete(InitComplete callback)
	{
		_initComplete -= callback;
	}

	private void TriggerInitComplete()
	{
		if (_initComplete != null)
		{
			_initComplete();
		}
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

		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_item = GameObject.Find("ItemManager").GetComponent<ItemManager>();
	}

	private void Start()
	{
		// Initialize Data if not yet initialized

		InitializeData();

		// Calculate totals stars and background color

		RecalculateLevelTotal();

		// Unlock all levels if purchased

		UnlockAllLevels();

		// Initialize audio

		if (GetAudio() == 0)
		{
			_audio.SetEnable(false);
		}
		else
		{
			_audio.SetEnable(true);
		}

		TriggerInitComplete();
	}
}
