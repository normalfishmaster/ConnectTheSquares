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
	public Sprite[] _blockMetalA;
	public Sprite[] _blockMetalB;
	public Sprite[] _blockWoodA;
	public Sprite[] _blockWoodB;
	public Sprite[] _blockGreenMarble;
	public Sprite[] _blockBlueMarble;
	public Sprite[] _blockRedMarble;
	public Sprite[] _blockPurpleMarble;
	public Sprite[] _blockTileA;
	public Sprite[] _blockTileB;
	public Sprite[] _blockTileC;
	public Sprite[] _blockTileD;
	public Sprite[] _blockEmbroidery;
	public Sprite[] _blockFootprint;
	public Sprite[] _blockWaffle;
	public Sprite[] _blockLatte;

	private static int NUM_BLOCK_SET = 17;

	public const int BLOCK_SET_PLASTIC = 0;
	public const int BLOCK_SET_METAL_A = 1;
	public const int BLOCK_SET_METAL_B = 2;
	public const int BLOCK_SET_WOOD_A = 3;
	public const int BLOCK_SET_WOOD_B = 4;
	public const int BLOCK_SET_GREEN_MARBLE = 5;
	public const int BLOCK_SET_BLUE_MARBLE = 6;
	public const int BLOCK_SET_RED_MARBLE = 7;
	public const int BLOCK_SET_PURPLE_MARBLE = 8;
	public const int BLOCK_SET_TILE_A = 9;
	public const int BLOCK_SET_TILE_B = 10;
	public const int BLOCK_SET_TILE_C = 11;
	public const int BLOCK_SET_TILE_D = 12;
	public const int BLOCK_SET_EMBROIDERY = 13;
	public const int BLOCK_SET_FOOTPRINT = 14;
	public const int BLOCK_SET_LATTE = 15;
	public const int BLOCK_SET_WAFFLE = 16;

	public static string[] BLOCK_SET_STRING = new string[] {

		"Plastic Set",
		"Brushed Metal Set A",
		"Brushed Metal Set B",
		"Antique Wood Set A",
		"Antique Wood Set B",
		"Green Marble Set",
		"Blue Marble Set",
		"Red Marble Set",
		"Purple Marble Set",
		"Classic Tile Set A",
		"Classic Tile Set B",
		"Classic Tile Set C",
		"Classic Tile Set D",
		"Floral Embroidery Set",
		"Animal Footprints Set",
		"Latte Art Set",
		"Belgian Waffle Set",
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
		else if (setNumber == BLOCK_SET_METAL_A)
		{
			return _cloudOnce.GetBlockMetalAUnlocked();
		}
		else if (setNumber == BLOCK_SET_METAL_B)
		{
			return _cloudOnce.GetBlockMetalBUnlocked();
		}
		else if (setNumber == BLOCK_SET_WOOD_A)
		{
			return _cloudOnce.GetBlockWoodAUnlocked();
		}
		else if (setNumber == BLOCK_SET_WOOD_B)
		{
			return _cloudOnce.GetBlockWoodBUnlocked();
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
		else if (setNumber == BLOCK_SET_TILE_A)
		{
			return _cloudOnce.GetBlockTileAUnlocked();
		}
		else if (setNumber == BLOCK_SET_TILE_B)
		{
			return _cloudOnce.GetBlockTileBUnlocked();
		}
		else if (setNumber == BLOCK_SET_TILE_C)
		{
			return _cloudOnce.GetBlockTileCUnlocked();
		}
		else if (setNumber == BLOCK_SET_TILE_D)
		{
			return _cloudOnce.GetBlockTileDUnlocked();
		}
		else if (setNumber == BLOCK_SET_EMBROIDERY)
		{
			return _cloudOnce.GetBlockEmbroideryUnlocked();
		}
		else if (setNumber == BLOCK_SET_FOOTPRINT)
		{
			return _cloudOnce.GetBlockFootprintUnlocked();
		}
		else if (setNumber == BLOCK_SET_LATTE)
		{
			return _cloudOnce.GetBlockLatteUnlocked();
		}
		else if (setNumber == BLOCK_SET_WAFFLE)
		{
			return _cloudOnce.GetBlockWaffleUnlocked();
		}

		return false;
	}

	public void SetBlockSetUnlocked(int setNumber, bool unlock)
	{
		if (setNumber == BLOCK_SET_METAL_A)
		{
			_cloudOnce.SetBlockMetalAUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_METAL_B)
		{
			_cloudOnce.SetBlockMetalBUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_WOOD_A)
		{
			_cloudOnce.SetBlockWoodAUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_WOOD_B)
		{
			_cloudOnce.SetBlockWoodBUnlocked(unlock);
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
		else if (setNumber == BLOCK_SET_TILE_A)
		{
			_cloudOnce.SetBlockTileAUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_TILE_B)
		{
			_cloudOnce.SetBlockTileBUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_TILE_C)
		{
			_cloudOnce.SetBlockTileCUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_TILE_D)
		{
			_cloudOnce.SetBlockTileDUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_EMBROIDERY)
		{
			_cloudOnce.SetBlockEmbroideryUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_FOOTPRINT)
		{
			_cloudOnce.SetBlockFootprintUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_LATTE)
		{
			_cloudOnce.SetBlockLatteUnlocked(unlock);
		}
		else if (setNumber == BLOCK_SET_WAFFLE)
		{
			_cloudOnce.SetBlockWaffleUnlocked(unlock);
		}

		_cloudOnce.Save();
	}

	public void SetBlockPreview(int setNumber)
	{
		if (setNumber == BLOCK_SET_METAL_A)
		{
			_data.SetBlockPreview(BLOCK_SET_METAL_A);
		}
		else if (setNumber == BLOCK_SET_METAL_B)
		{
			_data.SetBlockPreview(BLOCK_SET_METAL_B);
		}
		else if (setNumber == BLOCK_SET_WOOD_A)
		{
			_data.SetBlockPreview(BLOCK_SET_WOOD_A);
		}
		else if (setNumber == BLOCK_SET_WOOD_B)
		{
			_data.SetBlockPreview(BLOCK_SET_WOOD_B);
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
		else if (setNumber == BLOCK_SET_TILE_A)
		{
			_data.SetBlockPreview(BLOCK_SET_TILE_A);
		}
		else if (setNumber == BLOCK_SET_TILE_B)
		{
			_data.SetBlockPreview(BLOCK_SET_TILE_B);
		}
		else if (setNumber == BLOCK_SET_TILE_C)
		{
			_data.SetBlockPreview(BLOCK_SET_TILE_C);
		}
		else if (setNumber == BLOCK_SET_TILE_D)
		{
			_data.SetBlockPreview(BLOCK_SET_TILE_D);
		}
		else if (setNumber == BLOCK_SET_EMBROIDERY)
		{
			_data.SetBlockPreview(BLOCK_SET_EMBROIDERY);
		}
		else if (setNumber == BLOCK_SET_FOOTPRINT)
		{
			_data.SetBlockPreview(BLOCK_SET_FOOTPRINT);
		}
		else if (setNumber == BLOCK_SET_LATTE)
		{
			_data.SetBlockPreview(BLOCK_SET_LATTE);
		}
		else if (setNumber == BLOCK_SET_WAFFLE)
		{
			_data.SetBlockPreview(BLOCK_SET_WAFFLE);
		}
	}

	public int GetBlockPreview()
	{
		return _data.GetBlockPreview();
	}

	public Sprite GetBlockSprite(int setNumber, int blockIndex)
	{
		if (setNumber == BLOCK_SET_METAL_A)
		{
			return _blockMetalA[blockIndex];
		}
		else if (setNumber == BLOCK_SET_METAL_B)
		{
			return _blockMetalB[blockIndex];
		}
		else if (setNumber == BLOCK_SET_WOOD_A)
		{
			return _blockWoodA[blockIndex];
		}
		else if (setNumber == BLOCK_SET_WOOD_B)
		{
			return _blockWoodB[blockIndex];
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
		else if (setNumber == BLOCK_SET_TILE_A)
		{
			return _blockTileA[blockIndex];
		}
		else if (setNumber == BLOCK_SET_TILE_B)
		{
			return _blockTileB[blockIndex];
		}
		else if (setNumber == BLOCK_SET_TILE_C)
		{
			return _blockTileC[blockIndex];
		}
		else if (setNumber == BLOCK_SET_TILE_D)
		{
			return _blockTileD[blockIndex];
		}
		else if (setNumber == BLOCK_SET_EMBROIDERY)
		{
			return _blockEmbroidery[blockIndex];
		}
		else if (setNumber == BLOCK_SET_FOOTPRINT)
		{
			return _blockFootprint[blockIndex];
		}
		else if (setNumber == BLOCK_SET_LATTE)
		{
			return _blockLatte[blockIndex];
		}
		else if (setNumber == BLOCK_SET_WAFFLE)
		{
			return _blockWaffle[blockIndex];
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
