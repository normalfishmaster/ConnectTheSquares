using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static DataManager _instance;
	private static LevelManager _level;
	private static AudioManager _audio;

	// Keys and Default Values

	public string GetAudioKey()						{ return "AudioKey";										}
	public int    GetAudioDefault()						{ return 1;											}

	public string GetRemoveAdsKey()						{ return "RemoveAdsKey";									}
	public int    GetRemoveAdsDefault()					{ return 0;											}

	public string GetUnlockAllLevelsKey()					{ return "UnlockAllLevels";									}
	public int    GetUnlockAllLevelsDefault()				{ return 0;											}

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

	public string GetAlphabetStarKey(int color, int alphabet)		{ return "LevelAlphabetStarKey" + "_" + color + "_" + alphabet;					}
	public int    GetAlphabetStarDefault()					{ return 0;											}

	public string GetAlphabetStarTotalKey(int color, int alphabet)		{ return "LevelAlphabetStarTotalKey" + "_" + color + "_" + alphabet;				}
	public int    GetAlphabetStarTotalDefault()				{ return 0;											}

	public string GetColorStarKey(int color)				{ return "LevelColorStarKey" + "_" + color;							}
	public int    GetColorStarDefault()					{ return 0;											}

	public string GetColorStarTotalKey(int color)				{ return "LevelColorStarTotalKey" + "_" + color;						}
	public int    GetColorStarTotalDefault()				{ return 0;											}

	public string GetBlockSetKey()						{ return "BlockSetKey";										}
	public int    GetBlockSetDefault()					{ return 0;											}

	public string GetBlockMetalUnlockedKey()				{ return "BlockMetalUnlockedKey";								}
	public int    GetBlockMetalUnlockedDefault()				{ return 0;											}

	public string GetBlockWoodUnlockedKey()					{ return "BlockWoodUnlockedKey";								}
	public int    GetBlockWoodUnlockedDefault()				{ return 0;											}

	public string GetBlockGreenMarbleUnlockedKey()				{ return "BlockGreenMarbleUnlockedKey";								}
	public int    GetBlockGreenMarbleUnlockedDefault()			{ return 0;											}

	public string GetBlockBlueMarbleUnlockedKey()				{ return "BlockBlueMarbleUnlockedKey";								}
	public int    GetBlockBlueMarbleUnlockedDefault()			{ return 0;											}

	public string GetBlockRedMarbleUnlockedKey()				{ return "BlockRedMarbleUnlockedKey";								}
	public int    GetBlockRedMarbleUnlockedDefault()			{ return 0;											}

	public string GetBlockRareMarbleUnlockedKey()				{ return "BlockRareMarbleUnlockedKey";								}
	public int    GetBlockRareMarbleUnlockedDefault()			{ return 0;											}

	public string GetBlockIllusionUnlockedKey()				{ return "BlockIllusionUnlockedKey";								}
	public int    GetBlockIllusionUnlockedDefault()				{ return 0;											}

	// Operations by Data Type

	public bool  CheckAudio()						{ return PlayerPrefs.HasKey(GetAudioKey());							}
	public int   GetAudio()							{ return PlayerPrefs.GetInt(GetAudioKey());							}
	public void  SetAudio(int value)					{        PlayerPrefs.SetInt(GetAudioKey(), value);						}
	public void  InitAudio()						{        PlayerPrefs.SetInt(GetAudioKey(), GetAudioDefault());					}

	public bool  CheckRemoveAds()						{ return PlayerPrefs.HasKey(GetRemoveAdsKey());							}
	public int   GetRemoveAds()						{ return PlayerPrefs.GetInt(GetRemoveAdsKey());							}
	public void  SetRemoveAds(int value)					{        PlayerPrefs.SetInt(GetRemoveAdsKey(), value);						}
	public void  InitRemoveAds()						{        PlayerPrefs.SetInt(GetRemoveAdsKey(), GetRemoveAdsDefault());				}

	public bool  CheckUnlockAllLevels()					{ return PlayerPrefs.HasKey(GetUnlockAllLevelsKey());						}
	public int   GetUnlockAllLevels()					{ return PlayerPrefs.GetInt(GetUnlockAllLevelsKey());						}
	public void  SetUnlockAllLevels(int value)				{        PlayerPrefs.SetInt(GetUnlockAllLevelsKey(), value);					}
	public void  InitUnlockAllLevels()					{        PlayerPrefs.SetInt(GetUnlockAllLevelsKey(), GetUnlockAllLevelsDefault());		}

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
	public void  InitColorStar(int color)					{        PlayerPrefs.SetInt(GetColorStarKey(color), GetAlphabetStarDefault());			}

	public bool  CheckColorStarTotal(int color)				{ return PlayerPrefs.HasKey(GetColorStarTotalKey(color));					}
	public int   GetColorStarTotal(int color)				{ return PlayerPrefs.GetInt(GetColorStarTotalKey(color));					}
	public void  SetColorStarTotal(int color, int value)			{        PlayerPrefs.SetInt(GetColorStarTotalKey(color), value);				}
	public void  InitColorStarTotal(int color)				{        PlayerPrefs.SetInt(GetColorStarTotalKey(color), GetAlphabetStarTotalDefault());	}

	public bool  CheckBlockSet()						{ return PlayerPrefs.HasKey(GetBlockSetKey());							}
	public int   GetBlockSet()						{ return PlayerPrefs.GetInt(GetBlockSetKey());							}
	public void  SetBlockSet(int value)					{        PlayerPrefs.SetInt(GetBlockSetKey(), value);						}
	public void  InitBlockSet()						{        PlayerPrefs.SetInt(GetBlockSetKey(), GetBlockSetDefault());				}

	public bool  CheckBlockMetalUnlocked()					{ return PlayerPrefs.HasKey(GetBlockMetalUnlockedKey());					}
	public int   GetBlockMetalUnlocked()					{ return PlayerPrefs.GetInt(GetBlockMetalUnlockedKey());					}
	public void  SetBlockMetalUnlocked(int value)				{        PlayerPrefs.SetInt(GetBlockMetalUnlockedKey(), value);					}
	public void  InitBlockMetalUnlocked()					{        PlayerPrefs.SetInt(GetBlockMetalUnlockedKey(), GetBlockMetalUnlockedDefault());	}

	public bool  CheckBlockWoodUnlocked()					{ return PlayerPrefs.HasKey(GetBlockWoodUnlockedKey());						}
	public int   GetBlockWoodUnlocked()					{ return PlayerPrefs.GetInt(GetBlockWoodUnlockedKey());						}
	public void  SetBlockWoodUnlocked(int value)				{        PlayerPrefs.SetInt(GetBlockWoodUnlockedKey(), value);					}
	public void  InitBlockWoodUnlocked()					{        PlayerPrefs.SetInt(GetBlockWoodUnlockedKey(), GetBlockMetalUnlockedDefault());		}

	public bool  CheckBlockGreenMarbleUnlocked()				{ return PlayerPrefs.HasKey(GetBlockGreenMarbleUnlockedKey());					}
	public int   GetBlockGreenMarbleUnlocked()				{ return PlayerPrefs.GetInt(GetBlockGreenMarbleUnlockedKey());					}
	public void  SetBlockGreenMarbleUnlocked(int value)			{        PlayerPrefs.SetInt(GetBlockGreenMarbleUnlockedKey(), value);				}
	public void  InitBlockGreenMarbleUnlocked()				{        PlayerPrefs.SetInt(GetBlockGreenMarbleUnlockedKey(), GetBlockGreenMarbleUnlockedDefault()); }

	public bool  CheckBlockBlueMarbleUnlocked()				{ return PlayerPrefs.HasKey(GetBlockBlueMarbleUnlockedKey());					}
	public int   GetBlockBlueMarbleUnlocked()				{ return PlayerPrefs.GetInt(GetBlockBlueMarbleUnlockedKey());					}
	public void  SetBlockBlueMarbleUnlocked(int value)			{        PlayerPrefs.SetInt(GetBlockBlueMarbleUnlockedKey(), value);				}
	public void  InitBlockBlueMarbleUnlocked()				{        PlayerPrefs.SetInt(GetBlockBlueMarbleUnlockedKey(), GetBlockBlueMarbleUnlockedDefault()); }

	public bool  CheckBlockRedMarbleUnlocked()				{ return PlayerPrefs.HasKey(GetBlockRedMarbleUnlockedKey());					}
	public int   GetBlockRedMarbleUnlocked()				{ return PlayerPrefs.GetInt(GetBlockRedMarbleUnlockedKey());					}
	public void  SetBlockRedMarbleUnlocked(int value)			{        PlayerPrefs.SetInt(GetBlockRedMarbleUnlockedKey(), value);				}
	public void  InitBlockRedMarbleUnlocked()				{        PlayerPrefs.SetInt(GetBlockRedMarbleUnlockedKey(), GetBlockRedMarbleUnlockedDefault()); }

	public bool  CheckBlockRareMarbleUnlocked()				{ return PlayerPrefs.HasKey(GetBlockRareMarbleUnlockedKey());					}
	public int   GetBlockRareMarbleUnlocked()				{ return PlayerPrefs.GetInt(GetBlockRareMarbleUnlockedKey());					}
	public void  SetBlockRareMarbleUnlocked(int value)			{        PlayerPrefs.SetInt(GetBlockRareMarbleUnlockedKey(), value);				}
	public void  InitBlockRareMarbleUnlocked()				{        PlayerPrefs.SetInt(GetBlockRareMarbleUnlockedKey(), GetBlockRareMarbleUnlockedDefault()); }

	public bool  CheckBlockIllusionUnlocked()				{ return PlayerPrefs.HasKey(GetBlockIllusionUnlockedKey());					}
	public int   GetBlockIllusionUnlocked()					{ return PlayerPrefs.GetInt(GetBlockIllusionUnlockedKey());					}
	public void  SetBlockIllusionUnlocked(int value)			{        PlayerPrefs.SetInt(GetBlockIllusionUnlockedKey(), value);				}
	public void  InitBlockIllusionUnlocked()				{        PlayerPrefs.SetInt(GetBlockIllusionUnlockedKey(), GetBlockIllusionUnlockedDefault());	}

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

		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}

	private void Start()
	{
		if (CheckAudio() == false)
		{
			InitAudio();
		}
		if (CheckRemoveAds() == false)
		{
			InitRemoveAds();
		}
		if (CheckUnlockAllLevels() == false)
		{
			InitUnlockAllLevels();
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

						if (i == 0 && j == 0 && k == 0)
						{
							SetLevelLock(0, 0, 0, 0);
						}
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

		if (CheckBlockSet() == false)
		{
			InitBlockSet();
		}
		if (CheckBlockMetalUnlocked() == false)
		{
			InitBlockMetalUnlocked();
		}
		if (CheckBlockWoodUnlocked() == false)
		{
			InitBlockWoodUnlocked();
		}
		if (CheckBlockGreenMarbleUnlocked() == false)
		{
			InitBlockGreenMarbleUnlocked();
		}
		if (CheckBlockBlueMarbleUnlocked() == false)
		{
			InitBlockBlueMarbleUnlocked();
		}
		if (CheckBlockRedMarbleUnlocked() == false)
		{
			InitBlockRedMarbleUnlocked();
		}
		if (CheckBlockRareMarbleUnlocked() == false)
		{
			InitBlockRareMarbleUnlocked();
		}
		if (CheckBlockIllusionUnlocked() == false)
		{
			InitBlockIllusionUnlocked();
		}

		// Calculate Color and Alphabet Star as well as Totals

		for (int i = 0; i < numColor; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);
			int starColorEarned = 0;
			int starColorTotal = 0;

			for (int j = 0; j < numAlphabet; j++)
			{
				int numMap = _level.GetNumMap(i, j);
				int starAlphabetEarned = 0;
				int starAlphabetTotal = 0;

				for (int k = 0; k < numMap; k++)
				{
					starAlphabetEarned += GetLevelStar(i, j, k);
					starAlphabetTotal += 3;
				}

				SetAlphabetStar(i, j, starAlphabetEarned);
				SetAlphabetStarTotal(i, j, starAlphabetTotal);

				starColorEarned += starAlphabetEarned;
				starColorTotal += starAlphabetTotal;
			}

			SetColorStar(i, starColorEarned);
			SetColorStarTotal(i, starColorTotal);
		}

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
