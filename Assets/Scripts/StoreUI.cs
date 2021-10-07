using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
	private StoreLogic _logic;
	private DataManager _data;
	private LevelManager _level;

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

	private GameObject _productPanel;

	private GameObject _productHintAdButton;
	private GameObject _productRemoveAdsButton;
	private GameObject _productHints3Button;
	private GameObject _productHints15p3Button;
	private GameObject _productHints30p9Button;
	private GameObject _productHints60p24Button;
	private GameObject _productBlockMetalButton;
	private GameObject _productBlockWoodButton;
	private GameObject _productBlockGreenMarbleButton;
	private GameObject _productBlockBlueMarbleButton;
	private GameObject _productBlockRedMarbleButton;
	private GameObject _productBlockRareMarbleButton;
	private GameObject _productBlockIllusionButton;

	private void FindProductGameObject()
	{
		_productPanel = GameObject.Find("/Canvas/Product");

		_productHintAdButton = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Button");
		_productRemoveAdsButton = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Button");
		_productHints3Button = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Button");
		_productHints15p3Button = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Button");
		_productHints30p9Button = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Button");
		_productHints60p24Button = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Button");
		_productBlockMetalButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetal/Button");
		_productBlockWoodButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWood/Button");
		_productBlockGreenMarbleButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Button");
		_productBlockBlueMarbleButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Button");
		_productBlockRedMarbleButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Button");
		_productBlockRareMarbleButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRareMarble/Button");
		_productBlockIllusionButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockIllusion/Button");
	}

	public void SetEnableProductButton(bool enable)
	{
		_productHintAdButton.GetComponent<Button>().enabled = enable;
		_productRemoveAdsButton.GetComponent<Button>().enabled = enable;
		_productHints3Button.GetComponent<Button>().enabled = enable;
		_productHints15p3Button.GetComponent<Button>().enabled = enable;
		_productHints30p9Button.GetComponent<Button>().enabled = enable;
		_productHints60p24Button.GetComponent<Button>().enabled = enable;
		_productBlockMetalButton.GetComponent<Button>().enabled = enable;
		_productBlockWoodButton.GetComponent<Button>().enabled = enable;
		_productBlockGreenMarbleButton.GetComponent<Button>().enabled = enable;
		_productBlockBlueMarbleButton.GetComponent<Button>().enabled = enable;
		_productBlockRedMarbleButton.GetComponent<Button>().enabled = enable;
		_productBlockRareMarbleButton.GetComponent<Button>().enabled = enable;
		_productBlockIllusionButton.GetComponent<Button>().enabled = enable;
	}

	public void SetInteractableProductRemoveAds(bool interactable)
	{
		_productRemoveAdsButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockMetal(bool interactable)
	{
		_productBlockMetalButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockWood(bool interactable)
	{
		_productBlockWoodButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockGreenMarble(bool interactable)
	{
		_productBlockGreenMarbleButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockBlueMarble(bool interactable)
	{
		_productBlockBlueMarbleButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockRedMarble(bool interactable)
	{
		_productBlockRedMarbleButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockRareMarble(bool interactable)
	{
		_productBlockRareMarbleButton.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableProductBlockIllusion(bool interactable)
	{
		_productBlockIllusionButton.GetComponent<Button>().interactable = interactable;
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

	public void AnimateProductHintAdButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHintAdButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductRemoveAdsButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productRemoveAdsButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockMetalButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockGreenMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockGreenMarbleButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockBlueMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockBlueMarbleButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockRedMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockRedMarbleButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockRareMarbleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockRareMarbleButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockIllusionButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockIllusionButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints3ButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints3Button, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints15p3ButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints15p3Button, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints30p9ButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints30p9Button, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductHints60p24ButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productHints60p24Button, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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

		FindTopGameObject();
		FindProductGameObject();
		FindBottomGameObject();
	}
}
