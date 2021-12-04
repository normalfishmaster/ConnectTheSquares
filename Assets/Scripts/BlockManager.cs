using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
	private static BlockManager _instance;
	private static DataManager _data;
	private static CloudOnceManager _cloudOnce;

	public Sprite[] _blockPlastic;
	public Sprite[] _blockMetal;
	public Sprite[] _blockWood;
	public Sprite[] _blockGreenMarble;
	public Sprite[] _blockBlueMarble;
	public Sprite[] _blockRedMarble;
	public Sprite[] _blockPurpleMarble;

	private static int NUM_BLOCK_SET = 7;

	public const int BLOCK_SET_PLASTIC = 0;
	public const int BLOCK_SET_METAL = 1;
	public const int BLOCK_SET_WOOD = 2;
	public const int BLOCK_SET_GREEN_MARBLE = 3;
	public const int BLOCK_SET_BLUE_MARBLE = 4;
	public const int BLOCK_SET_RED_MARBLE = 5;
	public const int BLOCK_SET_PURPLE_MARBLE = 6;

	public static string[] BLOCK_SET_STRING = new string[] {

		"Plastic Set",
		"Brushed Metal Set",
		"Antique Wood Set",
		"Green Marble Set",
		"Blue Marble Set",
		"Red Marble Set",
		"Purple Marble Set",
        };

	public int GetBlockSetNumber()
	{
		int setNumber = _data.GetBlockSet();

		if (IsBlockSetUnlocked(setNumber))
		{
			return setNumber;
		}

		_data.SetBlockSet(BLOCK_SET_PLASTIC);
		return BLOCK_SET_PLASTIC;
	}

	public void SetBlockSetNumber(int setNumber)
	{
		if (IsBlockSetUnlocked(setNumber))
		{
			_data.SetBlockSet(setNumber);
		}
		else
		{
			_data.SetBlockSet(BLOCK_SET_PLASTIC);
		}
	}

	public bool IsBlockSetUnlocked(int setNumber)
	{
		if (setNumber == BLOCK_SET_PLASTIC)
		{
			return true;
		}
		else if (setNumber == BLOCK_SET_METAL)
		{
			return _cloudOnce.GetBlockMetalUnlocked();
		}
		else if (setNumber == BLOCK_SET_WOOD)
		{
			return _cloudOnce.GetBlockWoodUnlocked();
		}
		else if (setNumber == BLOCK_SET_GREEN_MARBLE)
		{
			return _cloudOnce.GetBlockGreenMarbleUnlocked();
		}
		else if (setNumber == BLOCK_SET_BLUE_MARBLE)
		{
			return _cloudOnce.GetBlockBlueMarbleUnlocked();
		}
		else if (setNumber == BLOCK_SET_RED_MARBLE)
		{
			return _cloudOnce.GetBlockRedMarbleUnlocked();
		}
		else if (setNumber == BLOCK_SET_PURPLE_MARBLE)
		{
			return _cloudOnce.GetBlockPurpleMarbleUnlocked();
		}

		return false;
	}

	public void SetBlockSetUnlocked(int setNumber, bool unlock)
	{
		if (setNumber == BLOCK_SET_METAL)
		{
			_cloudOnce.SetBlockMetalUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_WOOD)
		{
			_cloudOnce.SetBlockWoodUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_GREEN_MARBLE)
		{
			_cloudOnce.SetBlockGreenMarbleUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_BLUE_MARBLE)
		{
			_cloudOnce.SetBlockBlueMarbleUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_RED_MARBLE)
		{
			_cloudOnce.SetBlockRedMarbleUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_PURPLE_MARBLE)
		{
			_cloudOnce.SetBlockPurpleMarbleUnlocked(unlock);
		}

		_cloudOnce.Save();
	}

	public void SetBlockPreview(int setNumber)
	{
		if (setNumber == BLOCK_SET_METAL)
		{
			_data.SetBlockPreview(BLOCK_SET_METAL);
		}
		else if (setNumber == BLOCK_SET_WOOD)
		{
			_data.SetBlockPreview(BLOCK_SET_WOOD);
		}
		else if (setNumber == BLOCK_SET_GREEN_MARBLE)
		{
			_data.SetBlockPreview(BLOCK_SET_GREEN_MARBLE);
		}
		else if (setNumber == BLOCK_SET_BLUE_MARBLE)
		{
			_data.SetBlockPreview(BLOCK_SET_BLUE_MARBLE);
		}
		else if (setNumber == BLOCK_SET_RED_MARBLE)
		{
			_data.SetBlockPreview(BLOCK_SET_RED_MARBLE);
		}
		else if (setNumber == BLOCK_SET_PURPLE_MARBLE)
		{
			_data.SetBlockPreview(BLOCK_SET_PURPLE_MARBLE);
		}
	}

	public int GetBlockPreview()
	{
		return _data.GetBlockPreview();
	}

	public Sprite GetBlockSprite(int setNumber, int blockIndex)
	{
		if (setNumber == BLOCK_SET_METAL)
		{
			return _blockMetal[blockIndex];
		}
		else if (setNumber == BLOCK_SET_WOOD)
		{
			return _blockWood[blockIndex];
		}
		else if (setNumber == BLOCK_SET_GREEN_MARBLE)
		{
			return _blockGreenMarble[blockIndex];
		}
		else if (setNumber == BLOCK_SET_BLUE_MARBLE)
		{
			return _blockBlueMarble[blockIndex];
		}
		else if (setNumber == BLOCK_SET_RED_MARBLE)
		{
			return _blockRedMarble[blockIndex];
		}
		else if (setNumber == BLOCK_SET_PURPLE_MARBLE)
		{
			return _blockPurpleMarble[blockIndex];
		}

		return _blockPlastic[blockIndex];
	}

	public int IncrementSetNumber(int setNumber)
	{
		int newNumber = setNumber + 1;

		if (newNumber == NUM_BLOCK_SET)
		{
			return 0;
		}
		return newNumber;
	}

	public int DecrementSetNumber(int setNumber)
	{
		int newNumber = setNumber - 1;

		if (newNumber < 0)
		{
			return NUM_BLOCK_SET - 1;
		}
		return newNumber;
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

		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
	}
}
