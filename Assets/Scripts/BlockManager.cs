using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
	private static BlockManager _instance;
	private static DataManager _data;

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
		"Wooden Set",
		"Green Marble Set",
		"Blue Marble Set",
		"Red Marble Set",
		"Purple Marble Set",
        };

	public int GetBlockSetNumber()
	{
		return _data.GetBlockSet();
	}

	public void SetBlockSetNumber(int setNumber)
	{
		_data.SetBlockSet(setNumber);
	}

	public int IsBlockSetUnlocked(int setNumber)
	{
		if (setNumber == BLOCK_SET_PLASTIC)
		{
			return 1;
		}
		else if (setNumber == BLOCK_SET_METAL)
		{
			return _data.GetBlockMetalUnlocked();
		}
		else if (setNumber == BLOCK_SET_WOOD)
		{
			return _data.GetBlockWoodUnlocked();
		}
		else if (setNumber == BLOCK_SET_GREEN_MARBLE)
		{
			return _data.GetBlockGreenMarbleUnlocked();
		}
		else if (setNumber == BLOCK_SET_BLUE_MARBLE)
		{
			return _data.GetBlockBlueMarbleUnlocked();
		}
		else if (setNumber == BLOCK_SET_RED_MARBLE)
		{
			return _data.GetBlockRedMarbleUnlocked();
		}
		else if (setNumber == BLOCK_SET_PURPLE_MARBLE)
		{
			return _data.GetBlockPurpleMarbleUnlocked();
		}

		return 0;
	}

	public void SetBlockSetUnlocked(int setNumber, int unlock)
	{
		if (setNumber == BLOCK_SET_METAL)
		{
			_data.SetBlockMetalUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_WOOD)
		{
			_data.SetBlockWoodUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_GREEN_MARBLE)
		{
			_data.SetBlockGreenMarbleUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_BLUE_MARBLE)
		{
			_data.SetBlockBlueMarbleUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_RED_MARBLE)
		{
			_data.SetBlockRedMarbleUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_PURPLE_MARBLE)
		{
			_data.SetBlockPurpleMarbleUnlocked(unlock);
		}
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
	}
}
