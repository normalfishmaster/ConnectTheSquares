using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static DataManager _instance;
	public  static DataManager Instance => _instance;

	private static bool initComplete = false;

	// Int PlayerPrefs

	private int GetInt(string key, int defaultValue)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetInt(key);
		}
		else
		{
			PlayerPrefs.SetInt(key, defaultValue);
			return defaultValue;
		}
	}

	private void SetInt(string key, int value)
	{
	        PlayerPrefs.SetInt(key, value);
	}

	// Float PlayerPrefs

	private float GetFloat(string key, float defaultValue)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetFloat(key);
		}
		else
		{
			PlayerPrefs.SetFloat(key, defaultValue);
			return defaultValue;
		}
	}

	private void SetFloat(string key, float value)
	{
	        PlayerPrefs.SetFloat(key, value);
	}

	// String PlayerPrefs

	private string GetString(string key, string defaultValue)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetString(key);
		}
		else
		{
			PlayerPrefs.SetString(key, defaultValue);
			return defaultValue;
		}
	}

	private void SetString(string key, string value)
	{
	        PlayerPrefs.SetString(key, value);
	}

	// Public Data

	public int GetAudio()			{ return GetInt("AudioKey", 1);		}
	public void SetAudio(int value)		{        SetInt("AudioKey", value);	}

	public int GetHints()			{ return GetInt("HintsKey", 3);		}
	public void SetHints(int value)		{        SetInt("HintsKey", value);	}

	public int GetAdFree()			{ return GetInt("AdFreeKey", 0);	}
	public void SetAdFree(int value)	{	 SetInt("AdFreeKey", value);	}

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
		// Initialize default values for all data fields

		if (!initComplete)
		{
			GetAudio();
			GetHints();
			GetAdFree();

			EventManager.TriggerDataInitCompleteEvent();
			initComplete = true;
		}
	}
}
