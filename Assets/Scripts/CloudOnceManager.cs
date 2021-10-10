using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceManager : MonoBehaviour
{
	private static CloudOnceManager _instance;

	// Leaderboard

	public void SubmitLeaderboardHighScore(int stars)
	{
		Leaderboards.highScore.SubmitScore(stars);
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

	public void CloudOnceInitializeComplete()
	{
		Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
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

	        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        	Cloud.Initialize();
	}
}
