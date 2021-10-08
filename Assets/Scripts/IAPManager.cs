using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
	private static IAPManager _instance;

	private DataManager _data;
	private LevelManager _level;
	private BlockManager _block;

	// Product

	public static string _productRemoveAds = "com.normalfish.connectthesquares.removeads";
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
	public static string _productBlockRareMarble = "com.normalfish.connectthesquares.blocksetraremarble";
	public static string _productBlockIllusion = "com.normalfish.connectthesquares.blockillusion";

	public void OnPurchaseComplete(Product product)
	{
		Debug.Log("Purchasing " + product.definition.id + " succeeded ");

		if (product.definition.id == _productRemoveAds)
		{
			_data.SetRemoveAds(1);
		}
		else if (product.definition.id == _productUnlockAllLevels)
		{
			_data.SetUnlockAllLevels(1);

			int numColor = _level.GetNumColor();

			for (int i = 0; i < numColor; i++)
			{
				int numAlphabet = _level.GetNumAlphabet(i);

				for (int j = 0; j < numAlphabet; j++)
				{
					int numMap = _level.GetNumMap(i, j);

					for (int k = 0; k < numMap; k++)
					{
						_data.SetLevelLock(i, j, k, 0);
					}
				}
			}
		}
		else if (product.definition.id == _productHints3)
		{
			_data.SetHint(_data.GetHint() + 3);
		}
		else if (product.definition.id == _productHints15p3)
		{
			_data.SetHint(_data.GetHint() + 18);
		}
		else if (product.definition.id == _productHints30p9)
		{
			_data.SetHint(_data.GetHint() + 39);
		}
		else if (product.definition.id == _productHints60p24)
		{
			_data.SetHint(_data.GetHint() + 84);
		}
		else if (product.definition.id == _productBlockMetal)
		{
			_block.SetBlockSetUnlocked(1, 1);
		}
		else if (product.definition.id == _productBlockWood)
		{
			_block.SetBlockSetUnlocked(2, 1);
		}
		else if (product.definition.id == _productBlockGreenMarble)
		{
			_block.SetBlockSetUnlocked(3, 1);
		}
		else if (product.definition.id == _productBlockBlueMarble)
		{
			_block.SetBlockSetUnlocked(4, 1);
		}
		else if (product.definition.id == _productBlockRedMarble)
		{
			_block.SetBlockSetUnlocked(5, 1);
		}
		else if (product.definition.id == _productBlockRareMarble)
		{
			_block.SetBlockSetUnlocked(6, 1);
		}
		else if (product.definition.id == _productBlockIllusion)
		{
			_block.SetBlockSetUnlocked(7, 1);
		}

		StoreLogic store = GameObject.Find("StoreLogic").GetComponent<StoreLogic>();
		if (store != null)
		{
			store.OnPurchaseSuccess(product.definition.id);
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

		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
	}
}
