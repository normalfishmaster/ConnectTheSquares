using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
	private StoreLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Product

	public float PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _productHintAd;
	private GameObject _productRemoveAds;
	private GameObject _productRemoveAdsTest;

	private void FindProductGameObject()
	{
		_productHintAd = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd");
		_productRemoveAds = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds");
		_productRemoveAdsTest = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAdsTest");
	}

	public void SetActiveProductNonTestButton(bool active)
	{
		_productRemoveAds.SetActive(active);
	}

	public void SetActiveProductTestButton(bool active)
	{
		_productRemoveAdsTest.SetActive(active);
	}

	public void SetEnableProductButton(bool enable)
	{
		_productHintAd.GetComponent<Button>().enabled = enable;
		_productRemoveAds.GetComponent<Button>().enabled = enable;
		_productRemoveAdsTest.GetComponent<Button>().enabled = enable;
	}

	public void AnimateProductHintAdButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHintAd, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductRemoveAdsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productRemoveAds, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductRemoveAdsTestButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productRemoveAdsTest, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Bottom

	public float BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION;

	private GameObject _bottomRestoreButton;
	private GameObject _bottomBackButton;

	private void FindBottomGameObject()
	{
		_bottomRestoreButton = GameObject.Find("/Canvas/Bottom/Restore");
		_bottomBackButton = GameObject.Find("/Canvas/Bottom/Back/Button");
	}

	public void SetActiveBottomRestoreButton(bool active)
	{
		_bottomRestoreButton.SetActive(active);
	}

	public void SetEnableBottomButton(bool enable)
	{
		_bottomRestoreButton.GetComponent<Button>().enabled = enable;
		_bottomBackButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateBottomBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_bottomBackButton, BOTTOM_ANIMATE_BUTTON_PRESSED_SCALE, BOTTOM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_logic = GameObject.Find("StoreLogic").GetComponent<StoreLogic>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindProductGameObject();
		FindBottomGameObject();
	}
}
