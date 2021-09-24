using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
	private ShopLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Product

	public float PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _productHintAd;
	private GameObject _productNoAds;

	private void FindProductGameObject()
	{
		_productHintAd = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd");
		_productNoAds = GameObject.Find("/Canvas/Product/Viewport/Content/NoAds");
	}

	public void SetEnableProductButton(bool enable)
	{
		_productHintAd.GetComponent<Button>().enabled = enable;
		_productNoAds.GetComponent<Button>().enabled = enable;
	}

	public void AnimateProductHintAdButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHintAd, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductNoAdsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productNoAds, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomBackButton;

	private void FindBottomGameObject()
	{
		_bottomBackButton = GameObject.Find("/Canvas/Bottom/Back/Button");
	}

	public void SetEnableBottomButton(bool enable)
	{
		_bottomBackButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateBottomBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomBackButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("ShopLogic").GetComponent<ShopLogic>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindProductGameObject();
		FindBottomGameObject();
	}
}
