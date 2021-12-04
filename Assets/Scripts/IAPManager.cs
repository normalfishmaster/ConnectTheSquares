using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
	private static IAPManager _instance;

	private BlockManager _block;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private ItemManager _item;
	private LevelManager _level;

	// Product

	public static string _productRemoveAds = "com.normalfish.connectthesquares.removeallads";
	public static string _productUnlockAllLevels = "com.normalfish.connectthesquares.unlockalllevels";
	public static string _productHints3 = "com.normalfish.connectthesquares.hints3";
	public static string _productHints15p3 = "com.normalfish.connectthesquares.hints15p3";
	public static string _productHints30p9 = "com.normalfish.connectthesquares.hints30p9";
	public static string _productHints60p24 = "com.normalfish.connectthesquares.hints60p24";
	public static string _productBlockMetal = "com.normalfish.connectthesquares.blocksetmetal";
	public static string _productBlockWood = "com.normalfish.connectthesquares.blocksetwood";
	public static string _productBlockGreenMarble = "com.normalfish.connectthesquares.blocksetgreenmarble";
	public static string _productBlockBlueMarble = "com.normalfish.connectthesquares.blocksetbluemarble";
	public static string _productBlockRedMarble = "com.normalfish.connectthesquares.blocksetredmarble";
	public static string _productBlockPurpleMarble = "com.normalfish.connectthesquares.blocksetpurplemarble";

	public void OnPurchaseComplete(Product product)
	{
		int numHint = -1;
		int blockSetNumber = -1;
		int itemNumber = -1;

		Debug.Log("Purchasing " + product.definition.id + " succeeded ");

		if (product.definition.id == _productRemoveAds)
		{
			_item.SetItemUnlocked(ItemManager.REMOVE_ADS, true);
			itemNumber = ItemManager.REMOVE_ADS;
		}
		else if (product.definition.id == _productUnlockAllLevels)
		{
			_item.SetItemUnlocked(ItemManager.UNLOCK_ALL_LEVELS, true);
			itemNumber = ItemManager.UNLOCK_ALL_LEVELS;
		}
		else if (product.definition.id == _productHints3)
		{
			_cloudOnce.IncrementHint(3);
			_cloudOnce.Save();
			numHint = 3;
		}
		else if (product.definition.id == _productHints15p3)
		{
			_cloudOnce.IncrementHint(18);
			_cloudOnce.Save();
			numHint = 18;
		}
		else if (product.definition.id == _productHints30p9)
		{
			_cloudOnce.IncrementHint(39);
			_cloudOnce.Save();
			numHint = 39;
		}
		else if (product.definition.id == _productHints60p24)
		{
			_cloudOnce.IncrementHint(84);
			_cloudOnce.Save();
			numHint = 84;
		}
		else if (product.definition.id == _productBlockMetal)
		{
			_block.SetBlockSetUnlocked(BlockManager.BLOCK_SET_METAL, true);
			blockSetNumber = BlockManager.BLOCK_SET_METAL;
		}
		else if (product.definition.id == _productBlockWood)
		{
			_block.SetBlockSetUnlocked(BlockManager.BLOCK_SET_WOOD, true);
			blockSetNumber = BlockManager.BLOCK_SET_WOOD;
		}
		else if (product.definition.id == _productBlockGreenMarble)
		{
			_block.SetBlockSetUnlocked(BlockManager.BLOCK_SET_GREEN_MARBLE, true);
			blockSetNumber = BlockManager.BLOCK_SET_GREEN_MARBLE;
		}
		else if (product.definition.id == _productBlockBlueMarble)
		{
			_block.SetBlockSetUnlocked(BlockManager.BLOCK_SET_BLUE_MARBLE, true);
			blockSetNumber = BlockManager.BLOCK_SET_BLUE_MARBLE;
		}
		else if (product.definition.id == _productBlockRedMarble)
		{
			_block.SetBlockSetUnlocked(BlockManager.BLOCK_SET_RED_MARBLE, true);
			blockSetNumber = BlockManager.BLOCK_SET_RED_MARBLE;
		}
		else if (product.definition.id == _productBlockPurpleMarble)
		{
			_block.SetBlockSetUnlocked(BlockManager.BLOCK_SET_PURPLE_MARBLE, true);
			blockSetNumber = BlockManager.BLOCK_SET_PURPLE_MARBLE;
		}
		else
		{
			return;
		}

		if (GameObject.Find("StoreLogic") != null)
		{
			StoreLogic store = GameObject.Find("StoreLogic").GetComponent<StoreLogic>();

			if (numHint != -1)
			{
				store.OnPurchaseHintSuccess(numHint);
			}
			else if (blockSetNumber != -1)
			{
				store.OnPurchaseBlockSetSuccess(blockSetNumber);
			}
			else if (itemNumber != -1)
			{
				store.OnPurchaseItemSuccess(itemNumber);
			}
		}
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log("Purchasing " + product.definition.id + " failed because " + failureReason);

		StoreLogic store = GameObject.Find("StoreLogic").GetComponent<StoreLogic>();
		if (store != null)
		{
			store.OnPurchaseFail();
		}
	}

	// Unity Lifecycle

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

		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_item = GameObject.Find("ItemManager").GetComponent<ItemManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
}
