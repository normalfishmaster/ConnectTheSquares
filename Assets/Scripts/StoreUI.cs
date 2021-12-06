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
	private GameObject _productBlockMetalAPanel;
	private GameObject _productBlockMetalBPanel;
	private GameObject _productBlockWoodAPanel;
	private GameObject _productBlockWoodBPanel;
	private GameObject _productBlockGreenMarblePanel;
	private GameObject _productBlockBlueMarblePanel;
	private GameObject _productBlockRedMarblePanel;
	private GameObject _productBlockPurpleMarblePanel;
	private GameObject _productBlockTileAPanel;
	private GameObject _productBlockTileBPanel;
	private GameObject _productBlockTileCPanel;
	private GameObject _productBlockTileDPanel;
	private GameObject _productBlockEmbroideryPanel;
	private GameObject _productBlockFootprintPanel;
	private GameObject _productBlockLattePanel;
	private GameObject _productBlockWafflePanel;

	private GameObject _productBlockMetalATry;
	private GameObject _productBlockMetalBTry;
	private GameObject _productBlockWoodATry;
	private GameObject _productBlockWoodBTry;
	private GameObject _productBlockGreenMarbleTry;
	private GameObject _productBlockBlueMarbleTry;
	private GameObject _productBlockRedMarbleTry;
	private GameObject _productBlockPurpleMarbleTry;
	private GameObject _productBlockTileATry;
	private GameObject _productBlockTileBTry;
	private GameObject _productBlockTileCTry;
	private GameObject _productBlockTileDTry;
	private GameObject _productBlockEmbroideryTry;
	private GameObject _productBlockFootprintTry;
	private GameObject _productBlockLatteTry;
	private GameObject _productBlockWaffleTry;

	private GameObject _productRemoveAdsRibbon;
	private GameObject _productBlockMetalBRibbon;
	private GameObject _productBlockWoodBRibbon;
	private GameObject _productBlockRedMarbleRibbon;
	private GameObject _productBlockTileCRibbon;
	private GameObject _productBlockFootprintRibbon;
	private GameObject _productBlockLatteRibbon;
	private GameObject _productBlockWaffleRibbon;

	private GameObject _productHintAdSunburst;
	private GameObject _productRemoveAdsSunburst;
	private GameObject _productUnlockAllLevelsSunburst;
	private GameObject _productHints3Sunburst;
	private GameObject _productHints15p3Sunburst;
	private GameObject _productHints30p9Sunburst;
	private GameObject _productHints60p24Sunburst;
	private GameObject _productBlockMetalASunburst;
	private GameObject _productBlockMetalBSunburst;
	private GameObject _productBlockWoodASunburst;
	private GameObject _productBlockWoodBSunburst;
	private GameObject _productBlockGreenMarbleSunburst;
	private GameObject _productBlockBlueMarbleSunburst;
	private GameObject _productBlockRedMarbleSunburst;
	private GameObject _productBlockPurpleMarbleSunburst;
	private GameObject _productBlockTileASunburst;
	private GameObject _productBlockTileBSunburst;
	private GameObject _productBlockTileCSunburst;
	private GameObject _productBlockTileDSunburst;
	private GameObject _productBlockEmbroiderySunburst;
	private GameObject _productBlockFootprintSunburst;
	private GameObject _productBlockLatteSunburst;
	private GameObject _productBlockWaffleSunburst;

	private GameObject _productHintAdPrice;
	private GameObject _productRemoveAdsPrice;
	private GameObject _productUnlockAllLevelsPrice;
	private GameObject _productHints3Price;
	private GameObject _productHints15p3Price;
	private GameObject _productHints30p9Price;
	private GameObject _productHints60p24Price;
	private GameObject _productBlockMetalAPrice;
	private GameObject _productBlockMetalBPrice;
	private GameObject _productBlockWoodAPrice;
	private GameObject _productBlockWoodBPrice;
	private GameObject _productBlockGreenMarblePrice;
	private GameObject _productBlockBlueMarblePrice;
	private GameObject _productBlockRedMarblePrice;
	private GameObject _productBlockPurpleMarblePrice;
	private GameObject _productBlockTileAPrice;
	private GameObject _productBlockTileBPrice;
	private GameObject _productBlockTileCPrice;
	private GameObject _productBlockTileDPrice;
	private GameObject _productBlockEmbroideryPrice;
	private GameObject _productBlockFootprintPrice;
	private GameObject _productBlockLattePrice;
	private GameObject _productBlockWafflePrice;

	private GameObject _productHintAdPriceButton;
	private GameObject _productRemoveAdsPriceButton;
	private GameObject _productUnlockAllLevelsPriceButton;
	private GameObject _productHints3PriceButton;
	private GameObject _productHints15p3PriceButton;
	private GameObject _productHints30p9PriceButton;
	private GameObject _productHints60p24PriceButton;
	private GameObject _productBlockMetalAPriceButton;
	private GameObject _productBlockMetalBPriceButton;
	private GameObject _productBlockWoodAPriceButton;
	private GameObject _productBlockWoodBPriceButton;
	private GameObject _productBlockGreenMarblePriceButton;
	private GameObject _productBlockBlueMarblePriceButton;
	private GameObject _productBlockRedMarblePriceButton;
	private GameObject _productBlockPurpleMarblePriceButton;
	private GameObject _productBlockTileAPriceButton;
	private GameObject _productBlockTileBPriceButton;
	private GameObject _productBlockTileCPriceButton;
	private GameObject _productBlockTileDPriceButton;
	private GameObject _productBlockEmbroideryPriceButton;
	private GameObject _productBlockFootprintPriceButton;
	private GameObject _productBlockLattePriceButton;
	private GameObject _productBlockWafflePriceButton;

	private GameObject _productRemoveAdsPurchased;
	private GameObject _productUnlockAllLevelsPurchased;
	private GameObject _productBlockMetalAPurchased;
	private GameObject _productBlockMetalBPurchased;
	private GameObject _productBlockWoodAPurchased;
	private GameObject _productBlockWoodBPurchased;
	private GameObject _productBlockGreenMarblePurchased;
	private GameObject _productBlockBlueMarblePurchased;
	private GameObject _productBlockRedMarblePurchased;
	private GameObject _productBlockPurpleMarblePurchased;
	private GameObject _productBlockTileAPurchased;
	private GameObject _productBlockTileBPurchased;
	private GameObject _productBlockTileCPurchased;
	private GameObject _productBlockTileDPurchased;
	private GameObject _productBlockEmbroideryPurchased;
	private GameObject _productBlockFootprintPurchased;
	private GameObject _productBlockLattePurchased;
	private GameObject _productBlockWafflePurchased;

	private void FindProductGameObject()
	{
		_productPanel = GameObject.Find("/Canvas/Product");

		_productUnlockAllLevelsPanel = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel");
		_productBlockMetalAPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalA/Panel");
		_productBlockMetalBPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel");
		_productBlockWoodAPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodA/Panel");
		_productBlockWoodBPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel");
		_productBlockGreenMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel");
		_productBlockBlueMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel");
		_productBlockRedMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel");
		_productBlockPurpleMarblePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel");
		_productBlockTileAPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileA/Panel");
		_productBlockTileBPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileB/Panel");
		_productBlockTileCPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel");
		_productBlockTileDPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileD/Panel");
		_productBlockEmbroideryPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockEmbroidery/Panel");
		_productBlockFootprintPanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel");
		_productBlockLattePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel");
		_productBlockWafflePanel = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel");

		_productBlockMetalATry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalA/Panel/Try");
		_productBlockMetalBTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel/Try");
		_productBlockWoodATry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodA/Panel/Try");
		_productBlockWoodBTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel/Try");
		_productBlockGreenMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Try");
		_productBlockBlueMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Try");
		_productBlockRedMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Try");
		_productBlockPurpleMarbleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Try");
		_productBlockTileATry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileA/Panel/Try");
		_productBlockTileBTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileB/Panel/Try");
		_productBlockTileCTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel/Try");
		_productBlockTileDTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileD/Panel/Try");
		_productBlockEmbroideryTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockEmbroidery/Panel/Try");
		_productBlockFootprintTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel/Try");
		_productBlockLatteTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel/Try");
		_productBlockWaffleTry = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel/Try");

		_productRemoveAdsRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Ribbon");
		_productBlockMetalBRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel/Ribbon");
		_productBlockWoodBRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel/Ribbon");
		_productBlockRedMarbleRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Ribbon");
		_productBlockTileCRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel/Ribbon");
		_productBlockFootprintRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel/Ribbon");
		_productBlockLatteRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel/Ribbon");
		_productBlockWaffleRibbon = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel/Ribbon");

		_productHintAdSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Panel/Sunburst");
		_productRemoveAdsSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Sunburst");
		_productUnlockAllLevelsSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Sunburst");
		_productHints3Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Panel/Sunburst");
		_productHints15p3Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Panel/Sunburst");
		_productHints30p9Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Panel/Sunburst");
		_productHints60p24Sunburst = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Panel/Sunburst");
		_productBlockMetalASunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalA/Panel/Sunburst");
		_productBlockMetalBSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel/Sunburst");
		_productBlockWoodASunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodA/Panel/Sunburst");
		_productBlockWoodBSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel/Sunburst");
		_productBlockGreenMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Sunburst");
		_productBlockBlueMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Sunburst");
		_productBlockRedMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Sunburst");
		_productBlockPurpleMarbleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Sunburst");
		_productBlockTileASunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileA/Panel/Sunburst");
		_productBlockTileBSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileB/Panel/Sunburst");
		_productBlockTileCSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel/Sunburst");
		_productBlockTileDSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileD/Panel/Sunburst");
		_productBlockEmbroiderySunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockEmbroidery/Panel/Sunburst");
		_productBlockFootprintSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel/Sunburst");
		_productBlockLatteSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel/Sunburst");
		_productBlockWaffleSunburst = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel/Sunburst");

		_productHintAdPrice = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Panel/Price");
		_productRemoveAdsPrice = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Price");
		_productUnlockAllLevelsPrice = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Price");
		_productHints3Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Panel/Price");
		_productHints15p3Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Panel/Price");
		_productHints30p9Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Panel/Price");
		_productHints60p24Price = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Panel/Price");
		_productBlockMetalAPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalA/Panel/Price");
		_productBlockMetalBPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel/Price");
		_productBlockWoodAPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodA/Panel/Price");
		_productBlockWoodBPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel/Price");
		_productBlockGreenMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Price");
		_productBlockBlueMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Price");
		_productBlockRedMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Price");
		_productBlockPurpleMarblePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Price");
		_productBlockTileAPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileA/Panel/Price");
		_productBlockTileBPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileB/Panel/Price");
		_productBlockTileCPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel/Price");
		_productBlockTileDPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileD/Panel/Price");
		_productBlockEmbroideryPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockEmbroidery/Panel/Price");
		_productBlockFootprintPrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel/Price");
		_productBlockLattePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel/Price");
		_productBlockWafflePrice = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel/Price");

		_productHintAdPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/HintAd/Panel/Price/Button");
		_productRemoveAdsPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Price/Button");
		_productUnlockAllLevelsPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Price/Button");
		_productHints3PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints3/Panel/Price/Button");
		_productHints15p3PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints15p3/Panel/Price/Button");
		_productHints30p9PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints30p9/Panel/Price/Button");
		_productHints60p24PriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/Hints60p24/Panel/Price/Button");
		_productBlockMetalAPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalA/Panel/Price/Button");
		_productBlockMetalBPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel/Price/Button");
		_productBlockWoodAPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodA/Panel/Price/Button");
		_productBlockWoodBPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel/Price/Button");
		_productBlockGreenMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Price/Button");
		_productBlockBlueMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Price/Button");
		_productBlockRedMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Price/Button");
		_productBlockPurpleMarblePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Price/Button");
		_productBlockTileAPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileA/Panel/Price/Button");
		_productBlockTileBPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileB/Panel/Price/Button");
		_productBlockTileCPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel/Price/Button");
		_productBlockTileDPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileD/Panel/Price/Button");
		_productBlockEmbroideryPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockEmbroidery/Panel/Price/Button");
		_productBlockFootprintPriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel/Price/Button");
		_productBlockLattePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel/Price/Button");
		_productBlockWafflePriceButton = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel/Price/Button");

		_productRemoveAdsPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/RemoveAds/Panel/Purchased");
		_productUnlockAllLevelsPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/UnlockAllLevels/Panel/Purchased");
		_productBlockMetalAPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalA/Panel/Purchased");
		_productBlockMetalBPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockMetalB/Panel/Purchased");
		_productBlockWoodAPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodA/Panel/Purchased");
		_productBlockWoodBPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWoodB/Panel/Purchased");
		_productBlockGreenMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockGreenMarble/Panel/Purchased");
		_productBlockBlueMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockBlueMarble/Panel/Purchased");
		_productBlockRedMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockRedMarble/Panel/Purchased");
		_productBlockPurpleMarblePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockPurpleMarble/Panel/Purchased");
		_productBlockTileAPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileA/Panel/Purchased");
		_productBlockTileBPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileB/Panel/Purchased");
		_productBlockTileCPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileC/Panel/Purchased");
		_productBlockTileDPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockTileD/Panel/Purchased");
		_productBlockEmbroideryPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockEmbroidery/Panel/Purchased");
		_productBlockFootprintPurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockFootprint/Panel/Purchased");
		_productBlockLattePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockLatte/Panel/Purchased");
		_productBlockWafflePurchased = GameObject.Find("/Canvas/Product/Viewport/Content/BlockWaffle/Panel/Purchased");
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

	public void SetActiveProductBlockMetalAPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockMetalAPrice.SetActive(price);
		_productBlockMetalAPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockMetalBPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockMetalBPrice.SetActive(price);
		_productBlockMetalBPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockWoodAPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockWoodAPrice.SetActive(price);
		_productBlockWoodAPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockWoodBPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockWoodBPrice.SetActive(price);
		_productBlockWoodBPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockGreenMarblePriceAndPurchased(bool price, bool purchased) {

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

	public void SetActiveProductBlockTileAPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockTileAPrice.SetActive(price);
		_productBlockTileAPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockTileBPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockTileBPrice.SetActive(price);
		_productBlockTileBPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockTileCPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockTileCPrice.SetActive(price);
		_productBlockTileCPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockTileDPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockTileDPrice.SetActive(price);
		_productBlockTileDPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockEmbroideryPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockEmbroideryPrice.SetActive(price);
		_productBlockEmbroideryPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockFootprintPriceAndPurchased(bool price, bool purchased)
	{
		_productBlockFootprintPrice.SetActive(price);
		_productBlockFootprintPurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockLattePriceAndPurchased(bool price, bool purchased)
	{
		_productBlockLattePrice.SetActive(price);
		_productBlockLattePurchased.SetActive(purchased);
	}

	public void SetActiveProductBlockWafflePriceAndPurchased(bool price, bool purchased)
	{
		_productBlockWafflePrice.SetActive(price);
		_productBlockWafflePurchased.SetActive(purchased);
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
		_productBlockMetalAPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockMetalBPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockWoodAPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockWoodBPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockGreenMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockBlueMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockRedMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockPurpleMarblePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockTileAPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockTileBPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockTileCPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockTileDPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockEmbroideryPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockFootprintPriceButton.GetComponent<Button>().enabled = enable;
		_productBlockLattePriceButton.GetComponent<Button>().enabled = enable;
		_productBlockWafflePriceButton.GetComponent<Button>().enabled = enable;

		_productBlockMetalAPanel.GetComponent<Button>().enabled = enable;
		_productBlockMetalBPanel.GetComponent<Button>().enabled = enable;
		_productBlockWoodAPanel.GetComponent<Button>().enabled = enable;
		_productBlockWoodBPanel.GetComponent<Button>().enabled = enable;
		_productBlockGreenMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockBlueMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockRedMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockPurpleMarblePanel.GetComponent<Button>().enabled = enable;
		_productBlockTileAPanel.GetComponent<Button>().enabled = enable;
		_productBlockTileBPanel.GetComponent<Button>().enabled = enable;
		_productBlockTileCPanel.GetComponent<Button>().enabled = enable;
		_productBlockTileDPanel.GetComponent<Button>().enabled = enable;
		_productBlockEmbroideryPanel.GetComponent<Button>().enabled = enable;
		_productBlockFootprintPanel.GetComponent<Button>().enabled = enable;
		_productBlockLattePanel.GetComponent<Button>().enabled = enable;
		_productBlockWafflePanel.GetComponent<Button>().enabled = enable;
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

	public void SetInteractableBlockMetalA(bool interactable)
	{
		_productBlockMetalAPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockMetalB(bool interactable)
	{
		_productBlockMetalBPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockWoodA(bool interactable)
	{
		_productBlockWoodAPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockWoodB(bool interactable)
	{
		_productBlockWoodBPanel.GetComponent<Button>().interactable = interactable;
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

	public void SetInteractableBlockTileA(bool interactable)
	{
		_productBlockTileAPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockTileB(bool interactable)
	{
		_productBlockTileBPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockTileC(bool interactable)
	{
		_productBlockTileCPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockTileD(bool interactable)
	{
		_productBlockTileDPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockEmbroidery(bool interactable)
	{
		_productBlockEmbroideryPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockFootprint(bool interactable)
	{
		_productBlockFootprintPanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockLatte(bool interactable)
	{
		_productBlockLattePanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetInteractableBlockWaffle(bool interactable)
	{
		_productBlockWafflePanel.GetComponent<Button>().interactable = interactable;
	}

	public void SetActiveBlockMetalATry(bool active)
	{
		_productBlockMetalATry.SetActive(active);
	}

	public void SetActiveBlockMetalBTry(bool active)
	{
		_productBlockMetalBTry.SetActive(active);
	}

	public void SetActiveBlockWoodATry(bool active)
	{
		_productBlockWoodATry.SetActive(active);
	}

	public void SetActiveBlockWoodBTry(bool active)
	{
		_productBlockWoodBTry.SetActive(active);
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

	public void SetActiveBlockTileATry(bool active)
	{
		_productBlockTileATry.SetActive(active);
	}

	public void SetActiveBlockTileBTry(bool active)
	{
		_productBlockTileBTry.SetActive(active);
	}

	public void SetActiveBlockTileCTry(bool active)
	{
		_productBlockTileCTry.SetActive(active);
	}

	public void SetActiveBlockTileDTry(bool active)
	{
		_productBlockTileDTry.SetActive(active);
	}

	public void SetActiveBlockEmbroideryTry(bool active)
	{
		_productBlockEmbroideryTry.SetActive(active);
	}

	public void SetActiveBlockFootprintTry(bool active)
	{
		_productBlockFootprintTry.SetActive(active);
	}

	public void SetActiveBlockLatteTry(bool active)
	{
		_productBlockLatteTry.SetActive(active);
	}

	public void SetActiveBlockWaffleTry(bool active)
	{
		_productBlockWaffleTry.SetActive(active);
	}

	public void SetActiveRemoveAdsRibbon(bool active)
	{
		_productRemoveAdsRibbon.SetActive(active);
	}

	public void SetActiveBlockMetalBRibbon(bool active)
	{
		_productBlockMetalBRibbon.SetActive(active);
	}

	public void SetActiveBlockWoodBRibbon(bool active)
	{
		_productBlockWoodBRibbon.SetActive(active);
	}

	public void SetActiveBlockRedMarbleRibbon(bool active)
	{
		_productBlockRedMarbleRibbon.SetActive(active);
	}

	public void SetActiveBlockTileCRibbon(bool active)
	{
		_productBlockTileCRibbon.SetActive(active);
	}

	public void SetActiveBlockFootprintRibbon(bool active)
	{
		_productBlockFootprintRibbon.SetActive(active);
	}

	public void SetActiveBlockLatteRibbon(bool active)
	{
		_productBlockLatteRibbon.SetActive(active);
	}

	public void SetActiveBlockWaffleRibbon(bool active)
	{
		_productBlockWaffleRibbon.SetActive(active);
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
		LeanTween.rotateAround(_productBlockMetalASunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockMetalBSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockWoodASunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockWoodBSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockGreenMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockBlueMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockRedMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockPurpleMarbleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockTileASunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockTileBSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockTileCSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockTileDSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockEmbroiderySunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockFootprintSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockLatteSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION);
		LeanTween.rotateAround(_productBlockWaffleSunburst, Vector3.forward, -360.0f, PRODUCT_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
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

	public void AnimateProductBlockMetalAPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalAPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockMetalBPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalBPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodAPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodAPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodBPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodBPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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

	public void AnimateProductBlockTileAPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileAPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockTileBPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileBPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockTileCPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileCPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockTileDPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileDPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockEmbroideryPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockEmbroideryPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockFootprintPriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockFootprintPriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockLattePriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockLattePriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWafflePriceButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWafflePriceButton, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockMetalAButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalAPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockMetalBButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockMetalBPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodAButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodAPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWoodBButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWoodBPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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

	public void AnimateProductBlockTileAButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileAPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockTileBButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileBPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockTileCButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileCPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockTileDButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockTileDPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockEmbroideryButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockEmbroideryPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockFootprintButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockFootprintPanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockLatteButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockLattePanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	public void AnimateProductBlockWaffleButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_productBlockWafflePanel, PRODUCT_ANIMATE_BUTTON_PRESSED_SCALE, PRODUCT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
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
