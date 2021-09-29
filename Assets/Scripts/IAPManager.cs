using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
	private static IAPManager _instance;

	private DataManager _data;
	private BlockManager _block;

	// Product

	private string _productRemoveAds = "com.normalfish.connectthesquares.removeads";
	private string _productBlockMetal = "com.normalfish.connectthesquares.blocksetmetal";
	private string _productBlockWood = "com.normalfish.connectthesquares.blocksetwood";
	private string _productBlockGreenMarble = "com.normalfish.connectthesquares.blocksetgreenmarble";
	private string _productBlockBlueMarble = "com.normalfish.connectthesquares.blocksetbluemarble";
	private string _productBlockRedMarble = "com.normalfish.connectthesquares.blocksetredmarble";
	private string _productBlockRareMarble = "com.normalfish.connectthesquares.blocksetraremarble";
	private string _productHints3 = "com.normalfish.connectthesquares.hints3";
	private string _productHints15p3 = "com.normalfish.connectthesquares.hints15p3";
	private string _productHints30p9 = "com.normalfish.connectthesquares.hints30p9";
	private string _productHints60p24 = "com.normalfish.connectthesquares.hints60p24";

	public void OnPurchaseComplete(Product product)
	{
		Debug.Log("Purchasing " + product.definition.id + " succeeded ");

		if (product.definition.id == _productRemoveAds)
		{
			_data.SetRemoveAds(1);
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
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log("Purchasing " + product.definition.id + " failed because " + failureReason);
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
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
	}
}
