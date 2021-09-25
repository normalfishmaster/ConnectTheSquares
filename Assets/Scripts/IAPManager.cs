using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
	private static IAPManager _instance;

	private DataManager _data;

	// Product

	private string _productRemoveAds = "com.normalfish.connectthesquares.removeads";

	public void OnPurchaseComplete(Product product)
	{
		if (product.definition.id == _productRemoveAds)
		{
			_data.SetRemoveAds(1);
			Debug.Log("Purchasing remove ads success");
		}
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log(product.definition.id + " failed because " + failureReason);
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
	}
}
