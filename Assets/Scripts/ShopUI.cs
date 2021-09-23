using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
	private ShopLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Product

	public float PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _productNoAds;

	private void FindProductGameObject()
	{
		_productNoAds = GameObject.Find("/Canvas/Product/Viewport/Content/NoAds");
	}

	public void AnimateProductNoAdsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productNoAds, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnProductNoAdsButtonPressed()
	{
		_logic.DoProductNoAdsButtonPressed();
	}

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomBackButton;

	private void FindBottomGameObject()
	{
		_bottomBackButton = GameObject.Find("/Canvas/Bottom/Back/Button");
	}

	public void AnimateBottomBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomBackButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void OnBottomBackButtonPressed()
	{
		_logic.DoBottomBackButtonPressed();
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
