using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
	private StoreLogic _logic;
	private DataManager _data;
	private LevelManager _level;

	// Background

	public Sprite[] _backgroundSprite;

	private GameObject _background;

	private void FindBackgroundGameObject()
	{
		_background = GameObject.Find("/Background/Color");
	}

	public void SetBackgroundColor(int color)
	{
		_background.GetComponent<Image>().sprite = _backgroundSprite[color];
	}

	// Top

	private GameObject _topHintCount;

	private void FindTopGameObject()
	{
		_topHintCount = GameObject.Find("/Canvas/Top/Hint/Count");
	}

	public void SetTopHintCount(int count)
	{
		_topHintCount.GetComponent<Text>().text = count.ToString();
	}

	// Product

	public float PRODUCT_ANIMATE_ENTER_DURATION;

	public float PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION;

	public float PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION;

	private GameObject _productPanel;

	private GameObject _productUnlockAllLevelsPanel;
	private GameObject _productBlockMetalPanel;
	private GameObject _productBlockWoodPanel;
	private GameObject _productBlockGreenMarblePanel;
	private GameObject _productBlockBlueMarblePanel;
	private GameObject _productBlockRedMarblePanel;
	private GameObject _productBlockPurpleMarblePanel;

	private GameObject _productBlockMetalTry;
	private GameObject _productBlockWoodTry;
	private GameObject _productBlockGreenMarbleTry;
	private GameObject _productBlockBlueMarbleTry;
	private GameObject _productBlockRedMarbleTry;
	private GameObject _productBlockPurpleMarbleTry;

	private GameObject _productRemoveAdsRibbon;
	private GameObject _productBlockWoodRibbon;
	private GameObject _productBlockRedMarbleRibbon;

	private GameObject _productHintAdSunburst;
	private GameObject _productRemoveAdsSunburst;
	private GameObject _productUnlockAllLevelsSunburst;
	private GameObject _productHints3Sunburst;
	private GameObject _productHints15p3Sunburst;
	private GameObject _productHints30p9Sunburst;
	private GameObject _productHints60p24Sunburst;
	private GameObject _productBlockMetalSunburst;
	private GameObject _productBlockWoodSunburst;
	private GameObject _productBlockGreenMarbleSunburst;
	private GameObject _productBlockBlueMarbleSunburst;
	private GameObject _productBlockRedMarbleSunburst;
	private GameObject _productBlockPurpleMarbleSunburst;

	private GameObject _productHintAdPrice;
	private GameObject _productRemoveAdsPrice;
	private GameObject _productUnlockAllLevelsPrice;
	private GameObject _productHints3Price;
	private GameObject _productHints15p3Price;
	private GameObject _productHints30p9Price;
	private GameObject _productHints60p24Price;
	private GameObject _productBlockMetalPrice;
	private GameObject _productBlockWoodPrice;
	private GameObject _productBlockGreenMarblePrice;
	private GameObject _productBlockBlueMarblePrice;
	private GameObject _productBlockRedMarblePrice;
	private GameObject _productBlockPurpleMarblePrice;

	private GameObject _productHintAdPriceButton;
	private GameObject _productRemoveAdsPriceButton;
	private GameObject _productUnlockAllLevelsPriceButton;
	private GameObject _productHints3PriceButton;
	private GameObject _productHints15p3PriceButton;
	private GameObject _productHints30p9PriceButton;
	private GameObject _productHints60p24PriceButton;
	private GameObject _productBlockMetalPriceButton;
	private GameObject _productBlockWoodPriceButton;
	private GameObject _productBlockGreenMarblePriceButton;
	private GameObject _productBlockBlueMarblePriceButton;
	private GameObject _productBlockRedMarblePriceButton;
	private GameObject _productBlockPurpleMarblePriceButton;

	private GameObject _productRemoveAdsPurchased;
	private GameObject _productUnlockAllLevelsPurchased;
	private GameObject _productBlockMetalPurchased;
	private GameObject _productBlockWoodPurchased;
	private GameObject _productBlockGreenMarblePurchased;
	private GameObject _productBlockBlueMarblePurchased;
	private GameObject _productBlockRedMarblePurchased;
	private GameObject _productBlockPurpleMarblePurchased;

	private void FindProductGameObject()
	{
		_productPanel = GameObject.Find("/Canvas/Product");

		_productUnlockAllLevelsPanel = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel");
		_productBlockMetalPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Panel");
		_productBlockWoodPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel");
		_productBlockGreenMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel");
		_productBlockBlueMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel");
		_productBlockRedMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel");
		_productBlockPurpleMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel");

		_productBlockMetalTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Panel/Try");
		_productBlockWoodTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel/Try");
		_productBlockGreenMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Try");
		_productBlockBlueMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Try");
		_productBlockRedMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Try");
		_productBlockPurpleMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Try");

		_productRemoveAdsRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Ribbon");
		_productBlockWoodRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel/Ribbon");
		_productBlockRedMarbleRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Ribbon");

		_productHintAdSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Panel/Sunburst");
		_productRemoveAdsSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Sunburst");
		_productUnlockAllLevelsSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Sunburst");
		_productHints3Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Panel/Sunburst");
		_productHints15p3Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Panel/Sunburst");
		_productHints30p9Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Panel/Sunburst");
		_productHints60p24Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Panel/Sunburst");
		_productBlockMetalSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Panel/Sunburst");
		_productBlockWoodSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel/Sunburst");
		_productBlockGreenMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Sunburst");
		_productBlockBlueMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Sunburst");
		_productBlockRedMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Sunburst");
		_productBlockPurpleMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Sunburst");

		_productHintAdPrice = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Panel/Price");
		_productRemoveAdsPrice = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Price");
		_productUnlockAllLevelsPrice = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Price");
		_productHints3Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Panel/Price");
		_productHints15p3Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Panel/Price");
		_productHints30p9Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Panel/Price");
		_productHints60p24Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Panel/Price");
		_productBlockMetalPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Panel/Price");
		_productBlockWoodPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel/Price");
		_productBlockGreenMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Price");
		_productBlockBlueMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Price");
		_productBlockRedMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Price");
		_productBlockPurpleMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Price");

		_productHintAdPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Panel/Price/Button");
		_productRemoveAdsPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Price/Button");
		_productUnlockAllLevelsPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Price/Button");
		_productHints3PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Panel/Price/Button");
		_productHints15p3PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Panel/Price/Button");
		_productHints30p9PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Panel/Price/Button");
		_productHints60p24PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Panel/Price/Button");
		_productBlockMetalPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Panel/Price/Button");
		_productBlockWoodPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel/Price/Button");
		_productBlockGreenMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Price/Button");
		_productBlockBlueMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Price/Button");
		_productBlockRedMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Price/Button");
		_productBlockPurpleMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Price/Button");

		_productRemoveAdsPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Purchased");
		_productUnlockAllLevelsPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Purchased");
		_productBlockMetalPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Panel/Purchased");
		_productBlockWoodPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Panel/Purchased");
		_productBlockGreenMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Purchased");
		_productBlockBlueMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Purchased");
		_productBlockRedMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Purchased");
		_productBlockPurpleMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Purchased");
	}

	public void SetActiveProductRemoveAdsPriceAndPurchased(bool price, bool purchased)
	{
		_productRemoveAdsPrice.SetActive(price);
		_productRemoveAdsPurchased.SetActive(purchased);
	}

	public void SetActiveProductUnlockAllLevelsPriceAndPurchased(bool price, bool purchased)
	{
		_productUnlockAllLevelsPrice.SetActive(price);
		_productUnlockAllLevelsPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockMetalPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockMetalPrice.SetActive(price);
		_productBlockMetalPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockWoodPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockWoodPrice.SetActive(price);
		_productBlockWoodPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockGreenMarblePriceAndPurchased(bool price, bool purchased)
	{
		_productBlockGreenMarblePrice.SetActive(price);
		_productBlockGreenMarblePurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockBlueMarblePriceAndPurchased(bool price, bool purchased)
	{
		_productBlockBlueMarblePrice.SetActive(price);
		_productBlockBlueMarblePurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockRedMarblePriceAndPurchased(bool price, bool purchased)
	{
		_productBlockRedMarblePrice.SetActive(price);
		_productBlockRedMarblePurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockPurpleMarblePriceAndPurchased(bool price, bool purchased)
	{
		_productBlockPurpleMarblePrice.SetActive(price);
		_productBlockPurpleMarblePurchased.SetActive(purchased);
	}

	public void SetEnableProductButton(bool enable)
	{
		if (_productUnlockAllLevelsPriceButton.GetComponent<Button>().interactable)
		{
			_productUnlockAllLevelsPriceButton.GetComponent<Button>().enabled = enable;
		}

		_productHintAdPriceButton.GetComponent<Button>().enabled = enable;
		_productRemoveAdsPriceButton.GetComponent<Button>().enabled = enable;
		_productHints3PriceButton.GetComponent<Button>().enabled = enable;
		_productHints15p3PriceButton.GetComponent<Button>().enabled = enable;
		_productHints30p9PriceButton.GetComponent<Button>().enabled = enable;
		_productHints60p24PriceButton.GetComponent<Button>().enabled = enable;
		_productBlockMetalPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockWoodPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockGreenMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockBlueMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockRedMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockPurpleMarblePriceButton.GetComponent<Button>().enabled = enable;

		_productBlockMetalPanel.GetComponent<Button>().enabled = enable;
		_productBlockWoodPanel.GetComponent<Button>().enabled = enable;
		_productBlockGreenMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockBlueMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockRedMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockPurpleMarblePanel.GetComponent<Button>().enabled = enable;
	}

	public void SetInteractableProductUnlockAllLevels(bool interactable)
	{
		if (interactable == false)
		{
			_productUnlockAllLevelsPanel.GetComponent<Image>().color = new Color(0.65f, 0.65f, 0.65f, 1.0f);
			_productUnlockAllLevelsPriceButton.GetComponent<Button>().interactable = interactable;
		}
		else
		{
			_productUnlockAllLevelsPanel.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			_productUnlockAllLevelsPriceButton.GetComponent<Button>().interactable = interactable;
		}
	}

	public void SetInteractableBlockMetal(bool interactable)
	{
		_productBlockMetalPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockWood(bool interactable)
	{
		_productBlockWoodPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockGreenMarble(bool interactable)
	{
		_productBlockGreenMarblePanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockBlueMarble(bool interactable)
	{
		_productBlockBlueMarblePanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockRedMarble(bool interactable)
	{
		_productBlockRedMarblePanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockPurpleMarble(bool interactable)
	{
		_productBlockPurpleMarblePanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetActiveBlockMetalTry(bool active)
	{
		_productBlockMetalTry.SetActive(active);
	}

	public void SetActiveBlockWoodTry(bool active)
	{
		_productBlockWoodTry.SetActive(active);
	}

	public void SetActiveBlockGreenMarbleTry(bool active)
	{
		_productBlockGreenMarbleTry.SetActive(active);
	}

	public void SetActiveBlockBlueMarbleTry(bool active)
	{
		_productBlockBlueMarbleTry.SetActive(active);
	}

	public void SetActiveBlockRedMarbleTry(bool active)
	{
		_productBlockRedMarbleTry.SetActive(active);
	}

	public void SetActiveBlockPurpleMarbleTry(bool active)
	{
		_productBlockPurpleMarbleTry.SetActive(active);
	}

	public void SetActiveRemoveAdsRibbon(bool active)
	{
		_productRemoveAdsRibbon.SetActive(active);
	}

	public void SetActiveBlockWoodRibbon(bool active)
	{
		_productBlockWoodRibbon.SetActive(active);
	}

	public void SetActiveBlockRedMarbleRibbon(bool active)
	{
		_productBlockRedMarbleRibbon.SetActive(active);
	}

	public void AnimateProductSunburst()
	{
		LeanTween.rotateAround(_productHintAdSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productRemoveAdsSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productUnlockAllLevelsSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productHints3Sunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productHints15p3Sunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productHints30p9Sunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productHints60p24Sunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockMetalSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockWoodSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockGreenMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockBlueMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockRedMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockPurpleMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateProductSunburst();
			}
		);
	}

	public void AnimateProductEnter(Animate.AnimateComplete callback)
	{
		RectTransform rectTransform = (RectTransform)_productPanel.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float height = rectTransform.rect.height;

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y - height, pos.z);

		LeanTween.cancel(_productPanel);
		LeanTween.moveLocalY(_productPanel, 0.0f, PRODUCT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateProductHintAdPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHintAdPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductRemoveAdsPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productRemoveAdsPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductUnlockAllLevelsPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productUnlockAllLevelsPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints3PriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints3PriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints15p3PriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints15p3PriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints30p9PriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints30p9PriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints60p24PriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints60p24PriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockMetalPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockGreenMarblePriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockGreenMarblePriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockBlueMarblePriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockBlueMarblePriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockRedMarblePriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockRedMarblePriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockPurpleMarblePriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockPurpleMarblePriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockMetalButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockGreenMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockGreenMarblePanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockBlueMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockBlueMarblePanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockRedMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockRedMarblePanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockPurpleMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockPurpleMarblePanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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

		FindBackgroundGameObject();
		FindTopGameObject();
		FindProductGameObject();
		FindBottomGameObject();
	}
}
