using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;

	private AudioSource _source;

	private bool _enable;

	// Set Enable

	public void SetEnable(bool enable)
	{
		_enable = enable;
	}

	// Audio

	public AudioClip _clipButtonPressed;

	public void PlayButtonPressed()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipButtonPressed);
		}
	}

	public AudioClip _clipHintPressed;

	public void PlayHintPressed()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipHintPressed);
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

		_source = GetComponent<AudioSource>();

		_enable = true;
	}

}
