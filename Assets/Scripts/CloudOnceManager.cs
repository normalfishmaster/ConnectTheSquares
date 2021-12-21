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
		// TODO: Rework Achievement
		return;

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
		// TODO: Rework Achievement
		return;

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
		// TODO: Rework Achievement
		return;

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

	private CloudInt[,,] _levelMoveVar;
	private CloudInt[,,] _levelStarVar;

	private int[,] _collectedAlphabetStar;
	private int[] _collectedColorStar;
	private int _collectedOverallStar;

	private int[,] _solvedAlphabetMap;
	private int[] _solvedColorMap;
	private int _solvedOverallMap;

	private int _backgroundColor;

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

	public void DeleteAll()
	{
		Cloud.Storage.DeleteAll();;
		SanitizeCloudVariables();
	}

	public void Save()
	{
		Cloud.Storage.Save();
	}

	public void Load()
	{
		Cloud.Storage.Load();
	}

	public void IncrementHint(int value)
	{
		CloudVariables.Hint += value;
	}

	public void DecrementHint(int value)
	{
		CloudVariables.Hint -= value;
	}

	public int GetHint()
	{
		return CloudVariables.Hint;
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

	public void SetRewardsLastDateTime(DateTime value)
	{
		CloudVariables.RewardsLastDateTime = value;
	}

	public DateTime GetRewardsLastDateTime()
	{
		return CloudVariables.RewardsLastDateTime;
	}

	public void SetRewardsDayCount(int value)
	{
		CloudVariables.RewardsDayCount = value;
	}

	public int GetRewardsDayCount()
	{
		return CloudVariables.RewardsDayCount;
	}

	public void SetRemoveAds(bool unlock)
	{
		CloudVariables.RemoveAds = unlock;
	}

	public bool GetRemoveAds()
	{
		return CloudVariables.RemoveAds;
	}

	public void SetUnlockAllLevels(bool unlock)
	{
		CloudVariables.UnlockAllLevels = unlock;

		if (unlock)
		{
			UnlockAllLevels();
		}
	}

	public bool GetUnlockAllLevels()
	{
		return CloudVariables.UnlockAllLevels;
	}

	public void SetBlockMetalAUnlocked(bool unlock)
	{
		CloudVariables.BlockMetalAUnlocked = unlock;
	}

	public bool GetBlockMetalAUnlocked()
	{
		return CloudVariables.BlockMetalAUnlocked;
	}

	public void SetBlockMetalBUnlocked(bool unlock)
	{
		CloudVariables.BlockMetalBUnlocked = unlock;
	}

	public bool GetBlockMetalBUnlocked()
	{
		return CloudVariables.BlockMetalBUnlocked;
	}

	public void SetBlockWoodAUnlocked(bool unlock)
	{
		CloudVariables.BlockWoodAUnlocked = unlock;
	}

	public bool GetBlockWoodAUnlocked()
	{
		return CloudVariables.BlockWoodAUnlocked;
	}

	public void SetBlockWoodBUnlocked(bool unlock)
	{
		CloudVariables.BlockWoodBUnlocked = unlock;
	}

	public bool GetBlockWoodBUnlocked()
	{
		return CloudVariables.BlockWoodBUnlocked;
	}

	public void SetBlockGreenMarbleUnlocked(bool unlock)
	{
		CloudVariables.BlockGreenMarbleUnlocked = unlock;
	}

	public bool GetBlockGreenMarbleUnlocked()
	{
		return CloudVariables.BlockGreenMarbleUnlocked;
	}

	public void SetBlockBlueMarbleUnlocked(bool unlock)
	{
		CloudVariables.BlockBlueMarbleUnlocked = unlock;
	}

	public bool GetBlockBlueMarbleUnlocked()
	{
		return CloudVariables.BlockBlueMarbleUnlocked;
	}

	public void SetBlockRedMarbleUnlocked(bool unlock)
	{
		CloudVariables.BlockRedMarbleUnlocked = unlock;
	}

	public bool GetBlockRedMarbleUnlocked()
	{
		return CloudVariables.BlockRedMarbleUnlocked;
	}

	public void SetBlockPurpleMarbleUnlocked(bool unlock)
	{
		CloudVariables.BlockPurpleMarbleUnlocked = unlock;
	}

	public bool GetBlockPurpleMarbleUnlocked()
	{
		return CloudVariables.BlockPurpleMarbleUnlocked;
	}

	public void SetBlockTileAUnlocked(bool unlock)
	{
		CloudVariables.BlockTileAUnlocked = unlock;
	}

	public bool GetBlockTileAUnlocked()
	{
		return CloudVariables.BlockTileAUnlocked;
	}

	public void SetBlockTileBUnlocked(bool unlock)
	{
		CloudVariables.BlockTileBUnlocked = unlock;
	}

	public bool GetBlockTileBUnlocked()
	{
		return CloudVariables.BlockTileBUnlocked;
	}

	public void SetBlockTileCUnlocked(bool unlock)
	{
		CloudVariables.BlockTileCUnlocked = unlock;
	}

	public bool GetBlockTileCUnlocked()
	{
		return CloudVariables.BlockTileCUnlocked;
	}

	public void SetBlockTileDUnlocked(bool unlock)
	{
		CloudVariables.BlockTileDUnlocked = unlock;
	}

	public bool GetBlockTileDUnlocked()
	{
		return CloudVariables.BlockTileDUnlocked;
	}

	public void SetBlockEmbroideryUnlocked(bool unlock)
	{
		CloudVariables.BlockEmbroideryUnlocked = unlock;
	}

	public bool GetBlockEmbroideryUnlocked()
	{
		return CloudVariables.BlockEmbroideryUnlocked;
	}

	public void SetBlockFootprintUnlocked(bool unlock)
	{
		CloudVariables.BlockFootprintUnlocked = unlock;
	}

	public bool GetBlockFootprintUnlocked()
	{
		return CloudVariables.BlockFootprintUnlocked;
	}

	public void SetBlockLatteUnlocked(bool unlock)
	{
		CloudVariables.BlockLatteUnlocked = unlock;
	}

	public bool GetBlockLatteUnlocked()
	{
		return CloudVariables.BlockLatteUnlocked;
	}

	public void SetBlockWaffleUnlocked(bool unlock)
	{
		CloudVariables.BlockWaffleUnlocked = unlock;
	}

	public bool GetBlockWaffleUnlocked()
	{
		return CloudVariables.BlockWaffleUnlocked;
	}

	public void SetLevelMove(int color, int alphabet, int map, int value)
	{
		_levelMoveVar[color, alphabet, map].Value = value;
	}

	public int GetLevelMove(int color, int alphabet, int map)
	{
		return _levelMoveVar[color, alphabet, map].Value;
	}

	public void SetLevelStar(int color, int alphabet, int map, int value)
	{
		int oldValue = _levelStarVar[color, alphabet, map].Value;
		_levelStarVar[color, alphabet, map].Value = value;

		if (value <= 0)
		{
			return;
		}

		oldValue = oldValue < 0 ? 0 : oldValue;

		int diff = value - oldValue;

		if (diff > 0)
		{
			_collectedAlphabetStar[color, alphabet] += diff;
			_collectedColorStar[color] += diff;
			_collectedOverallStar += diff;

			if (oldValue == 0)
			{
				_solvedAlphabetMap[color, alphabet] += 1;
				_solvedColorMap[color] += 1;
				_solvedOverallMap += 1;

				RecalculateBackgroundColor();
			}
		}
	}

	public int GetLevelStar(int color, int alphabet, int map)
	{
		return _levelStarVar[color, alphabet, map].Value;
	}

	public int GetCollectedAlphabetStar(int color, int alphabet)
	{
		return _collectedAlphabetStar[color, alphabet];
	}

	public int GetCollectedColorStar(int color)
	{
		return _collectedColorStar[color];
	}

	public int GetCollectedOverallStar()
	{
		return _collectedOverallStar;
	}

	public int GetSolvedAlphabetMap(int color, int alphabet)
	{
		return _solvedAlphabetMap[color, alphabet];
	}

	public int GetSolvedColorMap(int color)
	{
		return _solvedColorMap[color];
	}

	public int GetSolvedOverallMap()
	{
		return _solvedOverallMap;
	}

	public int GetBackgroundColor()
	{
		return _backgroundColor;
	}

	private void RecalculateBackgroundColor()
	{
		int highestColor = 0;

		int numColor = _level.GetNumColor();

		for (int i = 0; i < numColor - 1; i++)
		{
			int numAlphabet = _level.GetNumAlphabet(i);
			int totalMap = 0;

			for (int j = 0; j < numAlphabet; j++)
			{
				totalMap += _level.GetNumMap(i, j);
			}

			if (_solvedColorMap[i] == totalMap)
			{
				highestColor = i + 1;
			}
		}

		_backgroundColor = highestColor;
	}

	private void UnlockAllLevels()
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
					_levelStarVar[i, j, k].Value = 0;
				}
			}
		}
	}

	private void SanitizeCloudVariables(bool initialise)
	{
		if (initialise)
		{
			_levelMoveVar = new CloudInt[5, 3, 60];
			_levelStarVar = new CloudInt[5, 3, 60];

			_collectedAlphabetStar = new int[5, 3];
			_collectedColorStar = new int[5];

			_solvedAlphabetMap = new int[5, 3];
			_solvedColorMap = new int[5];
		}

		int collectedOverallStar = 0;
		int solvedOverallMap = 0;

		int numColor = _level.GetNumColor();

		for (int i = 0; i < numColor; i++)
		{
			int collectedColorStar = 0;
			int solvedColorMap = 0;

			int numAlphabet = _level.GetNumAlphabet(i);

			for (int j = 0; j < numAlphabet; j++)
			{
				int collectedAlphabetStar = 0;
				int solvedAlphabetMap = 0;

				int numMap = _level.GetNumMap(i, j);

				for (int k = 0; k < numMap; k++)
				{
					if (initialise)
					{
						string levelMoveName = "LevelMove." + i.ToString() + "." + j.ToString() + "." + k.ToString();
						_levelMoveVar[i, j, k] = new CloudInt(levelMoveName, PersistenceType.Lowest, 1000);

						string levelStarName = "LevelStar." + i.ToString() + "." + j.ToString() + "." + k.ToString();
						_levelStarVar[i, j, k] = new CloudInt(levelStarName, PersistenceType.Highest, -1);
					}

					if (GetUnlockAllLevels())
					{
						_levelStarVar[i, j, k].Value = 0;
					}

					if (_levelStarVar[i, j, k].Value > 0)
					{
						collectedAlphabetStar += _levelStarVar[i, j, k].Value;
						solvedAlphabetMap += 1;
					}
				}

				_collectedAlphabetStar[i, j] = collectedAlphabetStar;
				_solvedAlphabetMap[i, j] = solvedAlphabetMap;

				collectedColorStar += collectedAlphabetStar;
				solvedColorMap += solvedAlphabetMap;
			}

			_collectedColorStar[i] = collectedColorStar;
			_solvedColorMap[i] = solvedColorMap;

			collectedOverallStar += collectedColorStar;
			solvedOverallMap += solvedColorMap;
		}

		_collectedOverallStar = collectedOverallStar;
                _solvedOverallMap = solvedOverallMap;

		_levelStarVar[0, 0, 0].Value = 0;

		RecalculateBackgroundColor();
	}

	public void SanitizeCloudVariables()
	{
		SanitizeCloudVariables(false);
	}

	private void SetupCloud()
	{
		// Initialize variables not explicitly declared in CloudOnce editor.
		// An initialization is required for the first load to work correctly.
		// We also need to sanitize the cloud variables.
		// We combine both operations in one for efficiency.

		SanitizeCloudVariables(true);
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
