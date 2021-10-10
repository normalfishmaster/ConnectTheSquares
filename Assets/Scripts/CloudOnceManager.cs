using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceManager : MonoBehaviour
{
	private static CloudOnceManager _instance;

	// Sign In / Out
	// This is used exculsively by MainMenuScene

	public delegate void SignInComplete();
	private static event SignInComplete _signInComplete;

	public void SubscribeSignInComplete(SignInComplete callback)
	{
		_signInComplete += callback;
	}

	public void UnsubscribeSignInComplete(SignInComplete callback)
	{
		_signInComplete -= callback;
	}

        private void TriggerSignInComplete()
        {
                if (_signInComplete != null)
                {
                        _signInComplete();
                }
        }

	public delegate void SignOutComplete();
	private static event SignOutComplete _signOutComplete;

	public void SubscribeSignOutComplete(SignOutComplete callback)
	{
		_signOutComplete += callback;
	}

	public void UnsubscribeSignOutComplete(SignOutComplete callback)
	{
		_signOutComplete -= callback;
	}

        private void TriggerSignOutComplete()
        {
                if (_signOutComplete != null)
                {
                        _signOutComplete();
                }
        }

	private void OnSignedInChanged(bool isSignedIn)
	{
		if (IsSignedIn())
		{
			TriggerSignInComplete();
		}
		else
		{
			TriggerSignOutComplete();
		}
	}

	public bool IsSignedIn()
	{
		return Cloud.IsSignedIn;
	}

	public void SignIn()
	{
		Cloud.SignIn();
	}

	public void SignOut()
	{
		Cloud.SignOut();
	}

	// Leaderboard

	public void SubmitLeaderboardHighScore(int stars)
	{
		Leaderboards.highScore.SubmitScore(stars);
	}

	public void ShowLeaderboard()
	{
		if (IsSignedIn())
		{
			Cloud.Leaderboards.ShowOverlay();
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

	// Initialize Complete Callback

	private void OnInitializeComplete()
	{
		Cloud.OnInitializeComplete -= OnInitializeComplete;
		TriggerInitComplete();
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

		// Initialize CloudOnce

	        Cloud.OnInitializeComplete += OnInitializeComplete;
		Cloud.OnSignedInChanged += OnSignedInChanged;
        	Cloud.Initialize();
	}
}
