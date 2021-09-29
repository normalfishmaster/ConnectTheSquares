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
	public Sprite[] _blockRareMarble;

	private static int NUM_BLOCK_SET = 7;

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
		if (setNumber == 0)
		{
			return 1;
		}
		else if (setNumber == 1)
		{
			return _data.GetBlockMetalUnlocked();
		}
		else if (setNumber == 2)
		{
			return _data.GetBlockWoodUnlocked();
		}
		else if (setNumber == 3)
		{
			return _data.GetBlockGreenMarbleUnlocked();
		}
		else if (setNumber == 4)
		{
			return _data.GetBlockBlueMarbleUnlocked();
		}
		else if (setNumber == 5)
		{
			return _data.GetBlockRedMarbleUnlocked();
		}
		else if (setNumber == 6)
		{
			return _data.GetBlockRareMarbleUnlocked();
		}

		return 0;
	}

	public void SetBlockSetUnlocked(int setNumber, int unlock)
	{
		if (setNumber == 1)
		{
			_data.SetBlockMetalUnlocked(unlock);
		}
		else if (setNumber == 2)
		{
			_data.SetBlockWoodUnlocked(unlock);
		}
		else if (setNumber == 3)
		{
			_data.SetBlockGreenMarbleUnlocked(unlock);
		}
		else if (setNumber == 4)
		{
			_data.SetBlockBlueMarbleUnlocked(unlock);
		}
		else if (setNumber == 5)
		{
			_data.SetBlockRedMarbleUnlocked(unlock);
		}
		else if (setNumber == 6)
		{
			_data.SetBlockRareMarbleUnlocked(unlock);
		}
	}

	public Sprite GetBlockSprite(int setNumber, int blockIndex)
	{
		if (setNumber == 1)
		{
			return _blockMetal[blockIndex];
		}
		else if (setNumber == 2)
		{
			return _blockWood[blockIndex];
		}
		else if (setNumber == 3)
		{
			return _blockGreenMarble[blockIndex];
		}
		else if (setNumber == 4)
		{
			return _blockBlueMarble[blockIndex];
		}
		else if (setNumber == 5)
		{
			return _blockRedMarble[blockIndex];
		}
		else if (setNumber == 6)
		{
			return _blockRareMarble[blockIndex];
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
