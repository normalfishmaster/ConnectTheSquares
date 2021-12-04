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

		// Initialize audio

		if (GetAudio() == 0)
		{
			_audio.SetEnable(false);
		}
		else
		{
			_audio.SetEnable(true);
		}

		// Trigger init completion

		TriggerInitComplete();
	}
}
