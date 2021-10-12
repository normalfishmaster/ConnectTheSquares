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

	// Achievements

	public void IncrementClearAchivement(int color, int alphabet, int current, int goal)
	{
		float fcurrent = (float)(current);
		float fgoal = (float)(goal);

		if (color == 0 && alphabet == 0)
		{
			Achievements.TutorialAClear.Increment(fcurrent, fgoal);
		}
		else if (color == 1 && alphabet == 0)
		{
			Achievements.EasyAClear.Increment(fcurrent, fgoal);
		}
		else if (color == 1 && alphabet == 1)
		{
			Achievements.EasyBClear.Increment(fcurrent, fgoal);
		}
		else if (color == 1 && alphabet == 2)
		{
			Achievements.EasyCClear.Increment(fcurrent, fgoal);
		}
		else if (color == 2 && alphabet == 0)
		{
			Achievements.MediumAClear.Increment(fcurrent, fgoal);
		}
		else if (color == 2 && alphabet == 1)
		{
			Achievements.MediumBClear.Increment(fcurrent, fgoal);
		}
		else if (color == 2 && alphabet == 2)
		{
			Achievements.MediumCClear.Increment(fcurrent, fgoal);
		}
		else if (color == 3 && alphabet == 0)
		{
			Achievements.HardAClear.Increment(fcurrent, fgoal);
		}
		else if (color == 3 && alphabet == 1)
		{
			Achievements.HardBClear.Increment(fcurrent, fgoal);
		}
		else if (color == 3 && alphabet == 2)
		{
			Achievements.HardCClear.Increment(fcurrent, fgoal);
		}
		else if (color == 4 && alphabet == 0)
		{
			Achievements.ExpertAClear.Increment(fcurrent, fgoal);
		}
		else if (color == 4 && alphabet == 1)
		{
			Achievements.ExpertBClear.Increment(fcurrent, fgoal);
		}
		else if (color == 4 && alphabet == 2)
		{
			Achievements.ExpertCClear.Increment(fcurrent, fgoal);
		}
	}

	public void IncrementFullClearAchivement(int color, int alphabet, int current, int goal)
	{
		float fcurrent = (float)(current);
		float fgoal = (float)(goal);

		if (color == 0 && alphabet == 0)
		{
			Achievements.TutorialAFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 1 && alphabet == 0)
		{
			Achievements.EasyAFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 1 && alphabet == 1)
		{
			Achievements.EasyBFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 1 && alphabet == 2)
		{
			Achievements.EasyCFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 2 && alphabet == 0)
		{
			Achievements.MediumAFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 2 && alphabet == 1)
		{
			Achievements.MediumBFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 2 && alphabet == 2)
		{
			Achievements.MediumCFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 3 && alphabet == 0)
		{
			Achievements.HardAFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 3 && alphabet == 1)
		{
			Achievements.HardBFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 3 && alphabet == 2)
		{
			Achievements.HardCFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 4 && alphabet == 0)
		{
			Achievements.ExpertAFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 4 && alphabet == 1)
		{
			Achievements.ExpertBFullClear.Increment(fcurrent, fgoal);
		}
		else if (color == 4 && alphabet == 2)
		{
			Achievements.ExpertCFullClear.Increment(fcurrent, fgoal);
		}
	}

	public void IncrementThePerfectionistAchivement(int current, int goal)
	{
		Achievements.ThePerfectionist.Increment(current, goal);
	}

	public void ShowAchievements()
	{
		if (IsSignedIn())
		{
			Cloud.Achievements.ShowOverlay();
		}
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
