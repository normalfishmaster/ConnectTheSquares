using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static DataManager _instance = null;
	private static bool _initOnce = false;

	// Keys and Default Values

	public const string AUDIO_KEY		= "AudioKey";
	public const int AUDIO_DEFAULT		= 1;

	public const string HINT_KEY		= "HintKey";
	public const int HINT_DEFAULT		= 3;

	public const string ADFREE_KEY		= "AdFreeKey";
	public const int ADFREE_DEFAULT		= 0;

	// Data

	public bool CheckAudio()		{ return PlayerPrefs.HasKey(AUDIO_KEY);				}
	public int GetAudio()			{ return PlayerPrefs.GetInt(AUDIO_KEY);				}
	public void SetAudio(int value)		{        PlayerPrefs.SetInt(AUDIO_KEY, value);			}
	public void InitAudio()			{        PlayerPrefs.SetInt(AUDIO_KEY, AUDIO_DEFAULT);		}

	public bool CheckHint()			{ return PlayerPrefs.HasKey(HINT_KEY);				}
	public int GetHint()			{ return PlayerPrefs.GetInt(HINT_KEY);				}
	public void SetHint(int value)		{        PlayerPrefs.SetInt(HINT_KEY, value);			}
	public void InitHint()			{        PlayerPrefs.SetInt(HINT_KEY, HINT_DEFAULT);		}

	public bool CheckAdFree()		{ return PlayerPrefs.HasKey(ADFREE_KEY);			}
	public int GetAdFree()			{ return PlayerPrefs.GetInt(ADFREE_KEY);			}
	public void SetAdFree(int value)	{        PlayerPrefs.SetInt(ADFREE_KEY, value);			}
	public void InitAdFree()		{        PlayerPrefs.SetInt(ADFREE_KEY, ADFREE_DEFAULT);	}

	// Operations by Key

	public bool CheckByKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public string GetByKey(string key)
	{
		if (key == AUDIO_KEY)
		{
			return GetAudio().ToString();
		}
		else if (key == HINT_KEY)
		{
			return GetHint().ToString();
		}
		else if (key == ADFREE_KEY)
		{
			return GetAdFree().ToString();
		}
		else
		{
			return "";
		}
	}

	public int SetByKey(string key, string value)
	{
		try
		{
			if (key == AUDIO_KEY)
			{
				SetAudio(Convert.ToInt32(value));
			}
			else if (key == HINT_KEY)
			{
				SetHint(Convert.ToInt32(value));
			}
			else if (key == ADFREE_KEY)
			{
				SetAdFree(Convert.ToInt32(value));
			}
			else
			{
				return -1;
			}
		}
		catch
		{
			return -1;
		}
		return 0;
	}

	public int InitByKey(string key)
	{
		if (key == AUDIO_KEY)
		{
			InitAudio();
		}
		else if (key == HINT_KEY)
		{
			InitHint();
		}
		else if (key == ADFREE_KEY)
		{
			InitAdFree();
		}
		else
		{
			return -1;
		}
		return 0;
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
