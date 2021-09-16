using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;

	private static AudioSource _source;

	private static bool _enable;

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

	public AudioClip _clipMapEnter;

	public void PlayMapEnter()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipMapEnter);
		}
	}

	public AudioClip _clipMapExit;

	public void PlayMapExit()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipMapExit);
		}
	}

	public AudioClip _clipGoEnter;

	public void PlayGoEnter()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipGoEnter);
		}
	}

	public AudioClip _clipMoveStartToEnd;

	public void PlayMoveStartToEnd()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipMoveStartToEnd);
		}
	}

	public AudioClip _clipMovePreEndToEnd;

	public void PlayMovePreEndToEnd()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipMovePreEndToEnd);
		}
	}

	public AudioClip _clipWinEnter;

	public void PlayWinEnter()
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipWinEnter);
		}
	}

	public AudioClip[] _clipStarEnter;

	public void PlayStarEnter(int star)
	{
		if (_enable == true)
		{
			_source.PlayOneShot(_clipStarEnter[star]);
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
