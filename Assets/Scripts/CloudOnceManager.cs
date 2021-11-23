using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
using CloudOnce.CloudPrefs;

public class CloudOnceManager : MonoBehaviour
{
	private static CloudOnceManager _instance;

	private DataManager _data;
	private LevelManager _level;

	// Sign In / Out

	public delegate void SignedInChanged(bool isSignedIn);
	private static event SignedInChanged _signedInChanged;

	public void SubscribeSignedInChanged(SignedInChanged callback)
	{
		_signedInChanged += callback;
	}

	public void UnsubscribeSignedInChanged(SignedInChanged callback)
	{
		_signedInChanged -= callback;
	}

	private void OnSignedInChanged(bool isSignedIn)
	{
                if (_signedInChanged != null)
                {
                        _signedInChanged(isSignedIn);
                }
	}

	public delegate void SignInFailed();
	private static event SignInFailed _signInFailed;

	public void SubscribeSignInFailed(SignInFailed callback)
	{
		_signInFailed += callback;
	}

	public void UnsubscribeSignInFailed(SignInFailed callback)
	{
		_signInFailed -= callback;
	}

        private void OnSignInFailed()
        {
                if (_signInFailed != null)
                {
                        _signInFailed();
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
			Achievements.NoviceAClear.Increment(fcurrent, fgoal);
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
			Achievements.NoviceAFullClear.Increment(fcurrent, fgoal);
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
		Leaderboards.HighScore.SubmitScore(stars);
	}

	public void ShowLeaderboard()
	{
		if (IsSignedIn())
		{
			Cloud.Leaderboards.ShowOverlay();
		}
	}

	// Cloud

	public delegate void CloudSaveComplete(bool success);
	private static event CloudSaveComplete _cloudSaveComplete;

	public void SubscribeCloudSaveComplete(CloudSaveComplete callback)
	{
		_cloudSaveComplete += callback;
	}

	public void UnsubscribeCloudSaveComplete(CloudSaveComplete callback)
	{
		_cloudSaveComplete -= callback;
	}

	private void OnCloudSaveComplete(bool success)
	{
                if (_cloudSaveComplete != null)
                {
                        _cloudSaveComplete(success);
                }
	}

	public delegate void CloudLoadComplete(bool success);
	private static event CloudLoadComplete _cloudLoadComplete;

	public void SubscribeCloudLoadComplete(CloudLoadComplete callback)
	{
		_cloudLoadComplete += callback;
	}

	public void UnsubscribeCloudLoadComplete(CloudLoadComplete callback)
	{
		_cloudLoadComplete -= callback;
	}

	private void OnCloudLoadComplete(bool success)
	{
                if (_cloudLoadComplete != null)
                {
                        _cloudLoadComplete(success);
                }
	}

	public void LoadCloudToData()
	{
		int numColor = _level.GetNumColor();

		for (int i = 0; i < numColor; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);
			int starColorEarned = 0;
			int solvedColorEarned = 0;

			for (int j = 0; j < numAlphabet; j++)
			{
				int numMap = _level.GetNumMap(i, j);
				int starAlphabetEarned = 0;

				for (int k = 0; k < numMap; k++)
				{
					string varName = i.ToString() + "." + j.ToString() + "." + k.ToString();
					CloudInt variable = new CloudInt(varName, PersistenceType.Highest, -1);
					int value = variable.Value;

					if (value > -1)
					{
						_data.SetLevelLock(i, j, k, 0);

						int star = _data.GetLevelStar(i, j, k);

						if (value > star)
						{
							_data.SetLevelStar(i, j, k, value);
						}
					}

					int finalStar = _data.GetLevelStar(i, j, k);
					if (finalStar >= 1)
					{
						starAlphabetEarned += finalStar;
						solvedColorEarned += 1;
					}
				}

				_data.SetAlphabetStar(i, j, starAlphabetEarned);
			}

			_data.SetColorStar(i, starColorEarned);
			_data.SetColorSolved(i, solvedColorEarned);
		}

		_data.RecalculateBackgroundColor();
	}

	public void SaveDataToCloud()
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
					if (_data.GetLevelLock(i, j, k) == 1)
					{
						continue;
					}

					string varName = i.ToString() + "." + j.ToString() + "." + k.ToString();
					CloudInt variable = new CloudInt(varName, PersistenceType.Highest, -1);

					int star = _data.GetLevelStar(i, j, k);

					if (star > variable.Value)
					{
						variable.Value = star;
					}
				}
			}
		}
	}

	public void IncrementHint(int value)
	{
		CloudVariables.Hint += value;
		Cloud.Storage.Save();
	}

	public void DecrementHint(int value)
	{
		CloudVariables.Hint -= value;
		Cloud.Storage.Save();
	}

	public void SetLastColor(int value)
	{
		CloudVariables.LastColor = value;
	}

	public int GetLastColor()
	{
		return CloudVariables.LastColor;
	}

	public void SetLastAlphabet(int value)
	{
		CloudVariables.LastAlphabet = value;
	}

	public int GetLastAlphabet()
	{
		return CloudVariables.LastAlphabet;
	}

	public void SetLastMap(int value)
	{
		CloudVariables.LastMap = value;
	}

	public int GetLastMap()
	{
		return CloudVariables.LastMap;
	}

	public int GetHint()
	{
		return CloudVariables.Hint;
	}

	public void SetRewardsLastDateTime(DateTime value)
	{
		CloudVariables.RewardsLastDateTime = value;
	}

	public void SetRewardsDayCount(int value)
	{
		CloudVariables.RewardsDayCount = value;
	}

	public DateTime GetRewardsLastDateTime()
	{
		return CloudVariables.RewardsLastDateTime;
	}

	public int GetRewardsDayCount()
	{
		return CloudVariables.RewardsDayCount;
	}

	public void DeleteAll()
	{
		Cloud.Storage.DeleteAll();;
	}

	public void Save()
	{
		Cloud.Storage.Save();
	}

	public void Load()
	{
		Cloud.Storage.Load();
	}

	private void SetupCloud()
	{
		// An initialization is required for the first load to work correctly.

		int numColor = _level.GetNumColor();

		for (int i = 0; i < numColor; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);

			for (int j = 0; j < numAlphabet; j++)
			{
				int numMap = _level.GetNumMap(i, j);

				for (int k = 0; k < numMap; k++)
				{
					string varName = i.ToString() + "." + j.ToString() + "." + k.ToString();
					CloudInt variable = new CloudInt(varName, PersistenceType.Highest, -1);
				}
			}
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

		// Initialization

		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		// Initialize CloudOnce

	        Cloud.OnInitializeComplete += OnInitializeComplete;
		Cloud.OnSignedInChanged += OnSignedInChanged;
		Cloud.OnSignInFailed += OnSignInFailed;
		Cloud.OnCloudSaveComplete += OnCloudSaveComplete;
		Cloud.OnCloudLoadComplete += OnCloudLoadComplete;

        	Cloud.Initialize();
	}

	private void Start()
	{
		SetupCloud();
	}
}
