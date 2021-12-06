using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreLogic : MonoBehaviour
{
        private StoreUI _ui;
	private AdManager _ad;
        private AudioManager _audio;
	private BlockManager _block;
	private CloudOnceManager _cloudOnce;
	private DataManager _data;
	private FrameRateManager _frameRate;
	private ItemManager _item;
	private LevelManager _level;
	private MessageManager _message;

	private int _purchasePending;

	// UI - Background

	private void SetupBackground()
	{
		_ui.SetBackgroundColor(_cloudOnce.GetBackgroundColor());
	}

	// State

	private const float MAX_AD_LOAD_TIME = 5.0f;

	private enum State
	{
		NONE,
		LOAD_AD,
		AD,
	};

	private State _state;
	private float _stateLoadAdStartTime;

	private void SetupState()
	{
		_state = State.NONE;
	}

	private void DoStateNone()
	{
	}

	private void DoStateLoadAd()
	{
		if (_messageLoadEnterInProgress)
		{
			return;
		}

		if (_ad.IsRewardedLoaded())
		{
			_ad.ClearRewardStatus();

			_message.AnimateLoadExit
			(
				()=>
				{
					_message.SetActiveLoad(false);
					_ad.ShowRewarded();
				}
			);

			_state = State.AD;
		}
		else if (Time.time - _stateLoadAdStartTime > MAX_AD_LOAD_TIME)
		{
			_message.AnimateLoadExit
			(
				()=>
				{
					_message.SetActiveLoad(false);

					_message.SetActiveError(true);
					_message.SetEnableErrorBackButton(false);
					_message.AnimateErrorEnter
					(
						()=>
						{
							_message.SetEnableErrorBackButton(true);
						}
					);
				}
			);

                        _state = State.NONE;
		}
	}

	private void DoStateAd()
	{
		AdManager.RewardStatus status = _ad.GetRewardStatus();

		if (status == AdManager.RewardStatus.SUCCESS)
		{
			_cloudOnce.IncrementHint(1);

			_audio.PlayRewardReceived();

			_ui.SetTopHintCount(_cloudOnce.GetHint());

			_message.SetHintCount(1);
			_message.SetActiveHint(true);
			_message.SetEnableHintBackButton(false);
			_message.AnimateHintEnter
			(
				()=>
				{
					_message.SetEnableHintBackButton(true);
				}
			);

			_state = State.NONE;
		}
		else if (status == AdManager.RewardStatus.FAIL)
		{
			_ui.SetEnableProductButton(true);
			_ui.SetEnableBottomButton(true);
			_state = State.NONE;
		}
	}

	// UI - Top

	private void SetupTop()
	{
		_ui.SetTopHintCount(_cloudOnce.GetHint());
	}

	// UI - Product

	private void SetupProduct()
	{
		int lastColor = _level.GetNumColor() - 1;
		int lastAlphabet = _level.GetNumAlphabet(lastColor) - 1;
		int lastMap = _level.GetNumMap(lastColor, lastAlphabet) - 1;

		_ui.AnimateProductSunburst();

		if (_item.IsItemUnlocked(ItemManager.REMOVE_ADS))
		{
			_ui.SetActiveProductRemoveAdsPriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductRemoveAdsPriceAndPurchased(true, false);
		}

		if (_item.IsItemUnlocked(ItemManager.UNLOCK_ALL_LEVELS))
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(false, true);
		}
		else if (_cloudOnce.GetLevelStar(lastColor, lastAlphabet, lastMap) >= 0)
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(true, false);
			_ui.SetInteractableProductUnlockAllLevels(false);
		}
		else
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(true, false);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_METAL_A))
		{
			_ui.SetActiveProductBlockMetalAPriceAndPurchased(false, true);
			_ui.SetInteractableBlockMetalA(false);
			_ui.SetActiveBlockMetalATry(false);
		}
		else
		{
			_ui.SetActiveProductBlockMetalAPriceAndPurchased(true, false);
			_ui.SetInteractableBlockMetalA(true);
			_ui.SetActiveBlockMetalATry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_METAL_B))
		{
			_ui.SetActiveProductBlockMetalBPriceAndPurchased(false, true);
			_ui.SetInteractableBlockMetalB(false);
			_ui.SetActiveBlockMetalBTry(false);
			_ui.SetActiveBlockMetalBRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockMetalBPriceAndPurchased(true, false);
			_ui.SetInteractableBlockMetalB(true);
			_ui.SetActiveBlockMetalBTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_WOOD_A))
		{
			_ui.SetActiveProductBlockWoodAPriceAndPurchased(false, true);
			_ui.SetInteractableBlockWoodA(false);
			_ui.SetActiveBlockWoodATry(false);
		}
		else
		{
			_ui.SetActiveProductBlockWoodAPriceAndPurchased(true, false);
			_ui.SetInteractableBlockWoodA(true);
			_ui.SetActiveBlockWoodATry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_WOOD_B))
		{
			_ui.SetActiveProductBlockWoodBPriceAndPurchased(false, true);
			_ui.SetInteractableBlockWoodB(false);
			_ui.SetActiveBlockWoodBTry(false);
			_ui.SetActiveBlockWoodBRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockWoodBPriceAndPurchased(true, false);
			_ui.SetInteractableBlockWoodB(true);
			_ui.SetActiveBlockWoodBTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_GREEN_MARBLE))
		{
			_ui.SetActiveProductBlockGreenMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockGreenMarble(false);
			_ui.SetActiveBlockGreenMarbleTry(false);
		}
		else
		{
			_ui.SetActiveProductBlockGreenMarblePriceAndPurchased(true, false);
			_ui.SetInteractableBlockGreenMarble(true);
			_ui.SetActiveBlockGreenMarbleTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_BLUE_MARBLE))
		{
			_ui.SetActiveProductBlockBlueMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockBlueMarble(false);
			_ui.SetActiveBlockBlueMarbleTry(false);
		}
		else
		{
			_ui.SetActiveProductBlockBlueMarblePriceAndPurchased(true, false);
			_ui.SetInteractableBlockBlueMarble(true);
			_ui.SetActiveBlockBlueMarbleTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_RED_MARBLE))
		{
			_ui.SetActiveProductBlockRedMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockRedMarble(false);
			_ui.SetActiveBlockRedMarbleTry(false);
			_ui.SetActiveBlockRedMarbleRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockRedMarblePriceAndPurchased(true, false);
			_ui.SetInteractableBlockRedMarble(true);
			_ui.SetActiveBlockRedMarbleTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_PURPLE_MARBLE))
		{
			_ui.SetActiveProductBlockPurpleMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockPurpleMarble(false);
			_ui.SetActiveBlockPurpleMarbleTry(false);
		}
		else
		{
			_ui.SetActiveProductBlockPurpleMarblePriceAndPurchased(true, false);
			_ui.SetInteractableBlockPurpleMarble(true);
			_ui.SetActiveBlockPurpleMarbleTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_TILE_A))
		{
			_ui.SetActiveProductBlockTileAPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileA(false);
			_ui.SetActiveBlockTileATry(false);
		}
		else
		{
			_ui.SetActiveProductBlockTileAPriceAndPurchased(true, false);
			_ui.SetInteractableBlockTileA(true);
			_ui.SetActiveBlockTileATry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_TILE_B))
		{
			_ui.SetActiveProductBlockTileBPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileB(false);
			_ui.SetActiveBlockTileBTry(false);
		}
		else
		{
			_ui.SetActiveProductBlockTileBPriceAndPurchased(true, false);
			_ui.SetInteractableBlockTileB(true);
			_ui.SetActiveBlockTileBTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_TILE_C))
		{
			_ui.SetActiveProductBlockTileCPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileC(false);
			_ui.SetActiveBlockTileCTry(false);
			_ui.SetActiveBlockTileCRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockTileCPriceAndPurchased(true, false);
			_ui.SetInteractableBlockTileC(true);
			_ui.SetActiveBlockTileCTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_TILE_D))
		{
			_ui.SetActiveProductBlockTileDPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileD(false);
			_ui.SetActiveBlockTileDTry(false);
		}
		else
		{
			_ui.SetActiveProductBlockTileDPriceAndPurchased(true, false);
			_ui.SetInteractableBlockTileD(true);
			_ui.SetActiveBlockTileDTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_EMBROIDERY))
		{
			_ui.SetActiveProductBlockEmbroideryPriceAndPurchased(false, true);
			_ui.SetInteractableBlockEmbroidery(false);
			_ui.SetActiveBlockEmbroideryTry(false);
		}
		else
		{
			_ui.SetActiveProductBlockEmbroideryPriceAndPurchased(true, false);
			_ui.SetInteractableBlockEmbroidery(true);
			_ui.SetActiveBlockEmbroideryTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_FOOTPRINT))
		{
			_ui.SetActiveProductBlockFootprintPriceAndPurchased(false, true);
			_ui.SetInteractableBlockFootprint(false);
			_ui.SetActiveBlockFootprintTry(false);
			_ui.SetActiveBlockFootprintRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockFootprintPriceAndPurchased(true, false);
			_ui.SetInteractableBlockFootprint(true);
			_ui.SetActiveBlockFootprintTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_LATTE))
		{
			_ui.SetActiveProductBlockLattePriceAndPurchased(false, true);
			_ui.SetInteractableBlockLatte(false);
			_ui.SetActiveBlockLatteTry(false);
			_ui.SetActiveBlockLatteRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockLattePriceAndPurchased(true, false);
			_ui.SetInteractableBlockLatte(true);
			_ui.SetActiveBlockLatteTry(true);
		}

		if (_block.IsBlockSetUnlocked(BlockManager.BLOCK_SET_WAFFLE))
		{
			_ui.SetActiveProductBlockWafflePriceAndPurchased(false, true);
			_ui.SetInteractableBlockWaffle(false);
			_ui.SetActiveBlockWaffleTry(false);
			_ui.SetActiveBlockWaffleRibbon(false);
		}
		else
		{
			_ui.SetActiveProductBlockWafflePriceAndPurchased(true, false);
			_ui.SetInteractableBlockWaffle(true);
			_ui.SetActiveBlockWaffleTry(true);
		}
	}

	public void OnProductHintAdButtonPricePressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableProductButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateProductHintAdPriceButtonPressed
		(
			()=>
			{
				if (_ad.IsRewardedLoaded())
				{
					_ad.ClearRewardStatus();
					_ad.ShowRewarded();
					_state = State.AD;
					return;
				}

				_messageLoadEnterInProgress = true;

				_message.SetActiveLoad(true);
				_message.AnimateLoadEnter
				(
					()=>
					{
						_messageLoadEnterInProgress = false;
					}
				);

				_stateLoadAdStartTime = Time.time;
				_state = State.LOAD_AD;
			}
		);
	}

	private void OnProductPriceButtonPressedCommon()
	{
		_audio.PlayButtonPressed();
		_purchasePending = 1;
	}

	public void OnProductRemoveAdsButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductRemoveAdsPriceButtonPressed(()=>{});
	}

	public void OnProductUnlockAllLevelsButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductUnlockAllLevelsPriceButtonPressed(()=>{});
	}

	public void OnProductHints3ButtonPressedPrice()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductHints3PriceButtonPressed(()=>{});
	}

	public void OnProductHints15p3ButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductHints15p3PriceButtonPressed(()=>{});
	}

	public void OnProductHints30p9ButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductHints30p9PriceButtonPressed(()=>{});
	}

	public void OnProductHints60p24PriceButtonPressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductHints60p24PriceButtonPressed(()=>{});
	}

	public void OnProductBlockMetalAPriceButtonPressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockMetalAPriceButtonPressed(()=>{});
	}

	public void OnProductBlockMetalBPriceButtonPressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockMetalBPriceButtonPressed(()=>{});
	}

	public void OnProductBlockWoodAButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockWoodAPriceButtonPressed(()=>{});
	}

	public void OnProductBlockWoodBButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockWoodBPriceButtonPressed(()=>{});
	}

	public void OnProductBlockGreenMarbleButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockGreenMarblePriceButtonPressed(()=>{});
	}

	public void OnProductBlockBlueMarbleButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockBlueMarblePriceButtonPressed(()=>{});
	}

	public void OnProductBlockRedMarbleButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockRedMarblePriceButtonPressed(()=>{});
	}

	public void OnProductBlockPurpleMarbleButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockPurpleMarblePriceButtonPressed(()=>{});
	}

	public void OnProductBlockTileAButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockTileAPriceButtonPressed(()=>{});
	}

	public void OnProductBlockTileBButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockTileBPriceButtonPressed(()=>{});
	}

	public void OnProductBlockTileCButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockTileCPriceButtonPressed(()=>{});
	}

	public void OnProductBlockTileDButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockTileDPriceButtonPressed(()=>{});
	}

	public void OnProductBlockEmbroideryButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockEmbroideryPriceButtonPressed(()=>{});
	}

	public void OnProductBlockFootprintButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockFootprintPriceButtonPressed(()=>{});
	}

	public void OnProductBlockLatteButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockLattePriceButtonPressed(()=>{});
	}

	public void OnProductBlockWaffleButtonPricePressed()
	{
		OnProductPriceButtonPressedCommon();
		_ui.AnimateProductBlockWafflePriceButtonPressed(()=>{});
	}

	public void OnProductTryButtonPressedCommon()
	{
		_audio.PlayButtonPressed();
		_ui.SetEnableProductButton(false);
		_ui.SetEnableBottomButton(false);
	}

	public void OnProductBlockMetalAButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_METAL_A);
		_ui.AnimateProductBlockMetalAButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockMetalBButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_METAL_B);
		_ui.AnimateProductBlockMetalBButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockWoodAButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_WOOD_A);
		_ui.AnimateProductBlockWoodAButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockWoodBButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_WOOD_B);
		_ui.AnimateProductBlockWoodBButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockGreenMarbleButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_GREEN_MARBLE);
		_ui.AnimateProductBlockGreenMarbleButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockBlueMarbleButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_BLUE_MARBLE);
		_ui.AnimateProductBlockBlueMarbleButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockRedMarbleButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_RED_MARBLE);
		_ui.AnimateProductBlockRedMarbleButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockPurpleMarbleButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_PURPLE_MARBLE);
		_ui.AnimateProductBlockPurpleMarbleButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockTileAButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_TILE_A);
		_ui.AnimateProductBlockTileAButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockTileBButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_TILE_B);
		_ui.AnimateProductBlockTileBButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockTileCButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_TILE_C);
		_ui.AnimateProductBlockTileCButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockTileDButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_TILE_D);
		_ui.AnimateProductBlockTileDButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockEmbroideryButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_EMBROIDERY);
		_ui.AnimateProductBlockEmbroideryButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockFootprintButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_FOOTPRINT);
		_ui.AnimateProductBlockFootprintButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockLatteButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_LATTE);
		_ui.AnimateProductBlockLatteButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	public void OnProductBlockWaffleButtonTryPressed()
	{
		OnProductTryButtonPressedCommon();
		_block.SetBlockPreview(BlockManager.BLOCK_SET_WAFFLE);
		_ui.AnimateProductBlockWaffleButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("DemoScene");
			}
		);
	}

	// IAP

	public void OnPurchaseItemSuccess(int itemNumber)
	{
		if (_purchasePending == 0)
		{
			return;
		}

		_purchasePending = 0;

		if (itemNumber == ItemManager.REMOVE_ADS)
		{
			_ui.SetActiveProductRemoveAdsPriceAndPurchased(false, true);
			_ui.SetActiveRemoveAdsRibbon(false);
		}
		else if (itemNumber == ItemManager.UNLOCK_ALL_LEVELS)
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(false, true);
		}

		_audio.PlayRewardReceived();

		_ui.SetEnableProductButton(false);
		_ui.SetEnableBottomButton(false);

		_message.SetActiveItem(true);
		_message.SetEnableItemBackButton(false);
		_message.SetItemImageAndMessage(itemNumber);

		_message.AnimateItemEnter
		(
			()=>
			{
				_message.SetEnableItemBackButton(true);
			}
		);
	}

	public void OnPurchaseHintSuccess(int numHint)
	{
		if (_purchasePending == 0)
		{
			return;
		}

		_purchasePending = 0;

		_audio.PlayRewardReceived();

		_ui.SetTopHintCount(_cloudOnce.GetHint());

		_ui.SetEnableProductButton(false);
		_ui.SetEnableBottomButton(false);

		_message.SetHintCount(numHint);

		_message.SetActiveHint(true);
		_message.SetEnableHintBackButton(false);
		_message.AnimateHintEnter
		(
			()=>
			{
				_message.SetEnableHintBackButton(true);
			}
		);
	}

	public void OnPurchaseBlockSetSuccess(int setNumber)
	{
		if (_purchasePending == 0)
		{
			return;
		}

		_purchasePending = 0;

		if (setNumber == BlockManager.BLOCK_SET_METAL_A)
		{
			_ui.SetActiveProductBlockMetalAPriceAndPurchased(false, true);
			_ui.SetInteractableBlockMetalA(false);
			_ui.SetActiveBlockMetalATry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_METAL_B)
		{
			_ui.SetActiveProductBlockMetalBPriceAndPurchased(false, true);
			_ui.SetInteractableBlockMetalB(false);
			_ui.SetActiveBlockMetalBTry(false);
			_ui.SetActiveBlockMetalBRibbon(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_WOOD_A)
		{
			_ui.SetActiveProductBlockWoodAPriceAndPurchased(false, true);
			_ui.SetInteractableBlockWoodA(false);
			_ui.SetActiveBlockWoodATry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_WOOD_B)
		{
			_ui.SetActiveProductBlockWoodBPriceAndPurchased(false, true);
			_ui.SetInteractableBlockWoodB(false);
			_ui.SetActiveBlockWoodBTry(false);
			_ui.SetActiveBlockWoodBRibbon(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_GREEN_MARBLE)
		{
			_ui.SetActiveProductBlockGreenMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockGreenMarble(false);
			_ui.SetActiveBlockGreenMarbleTry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_BLUE_MARBLE)
		{
			_ui.SetActiveProductBlockBlueMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockBlueMarble(false);
			_ui.SetActiveBlockBlueMarbleTry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_RED_MARBLE)
		{
			_ui.SetActiveProductBlockRedMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockRedMarble(false);
			_ui.SetActiveBlockRedMarbleTry(false);
			_ui.SetActiveBlockRedMarbleRibbon(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_PURPLE_MARBLE)
		{
			_ui.SetActiveProductBlockPurpleMarblePriceAndPurchased(false, true);
			_ui.SetInteractableBlockPurpleMarble(false);
			_ui.SetActiveBlockPurpleMarbleTry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_TILE_A)
		{
			_ui.SetActiveProductBlockTileAPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileA(false);
			_ui.SetActiveBlockTileATry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_TILE_B)
		{
			_ui.SetActiveProductBlockTileBPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileB(false);
			_ui.SetActiveBlockTileBTry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_TILE_C)
		{
			_ui.SetActiveProductBlockTileCPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileC(false);
			_ui.SetActiveBlockTileCTry(false);
			_ui.SetActiveBlockTileCRibbon(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_TILE_D)
		{
			_ui.SetActiveProductBlockTileDPriceAndPurchased(false, true);
			_ui.SetInteractableBlockTileD(false);
			_ui.SetActiveBlockTileDTry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_EMBROIDERY)
		{
			_ui.SetActiveProductBlockEmbroideryPriceAndPurchased(false, true);
			_ui.SetInteractableBlockEmbroidery(false);
			_ui.SetActiveBlockEmbroideryTry(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_FOOTPRINT)
		{
			_ui.SetActiveProductBlockFootprintPriceAndPurchased(false, true);
			_ui.SetInteractableBlockFootprint(false);
			_ui.SetActiveBlockFootprintTry(false);
			_ui.SetActiveBlockFootprintRibbon(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_LATTE)
		{
			_ui.SetActiveProductBlockLattePriceAndPurchased(false, true);
			_ui.SetInteractableBlockLatte(false);
			_ui.SetActiveBlockLatteTry(false);
			_ui.SetActiveBlockLatteRibbon(false);
		}
		else if (setNumber == BlockManager.BLOCK_SET_WAFFLE)
		{
			_ui.SetActiveProductBlockWafflePriceAndPurchased(false, true);
			_ui.SetInteractableBlockWaffle(false);
			_ui.SetActiveBlockWaffleTry(false);
			_ui.SetActiveBlockWaffleRibbon(false);
		}

		_audio.PlayRewardReceived();

		_ui.SetEnableProductButton(false);
		_ui.SetEnableBottomButton(false);

		_message.SetActiveBlock(true);
		_message.SetEnableBlockBackButton(false);
		_message.SetBlockImageAndMessage(setNumber);

		_message.AnimateBlockEnter
		(
			()=>
			{
				_message.SetEnableBlockBackButton(true);
			}
		);
	}

	public void OnPurchaseFail()
	{
		_purchasePending = 0;
	}

	// UI - Bottom

	public void OnBottomBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableProductButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateBottomBackButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("MainMenuScene");
			}
		);
	}

	private void SetupBottom()
	{
		if (Application.platform != RuntimePlatform.IPhonePlayer)
		{
			_ui.SetActiveBottomRestoreButton(false);
		}

		_ui.SetEnableBottomButton(true);
	}

	// Message - Item

	private void SetupMessageItem()
	{
		_message.SetActiveItem(false);
	}

	public void OnMessageItemBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_message.SetEnableItemBackButton(false);

		_message.AnimateItemBackButtonPressed
		(
			()=>
			{
				_message.AnimateItemExit
				(
					()=>
					{
						_message.SetActiveItem(false);

						_ui.SetEnableProductButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
			}
		);
	}

	// Message - Hint

	private void SetupMessageHint()
	{
		_message.SetActiveHint(false);
	}

	public void OnMessageHintBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_message.SetEnableHintBackButton(false);

		_message.AnimateHintBackButtonPressed
		(
			()=>
			{
				_message.AnimateHintExit
				(
					()=>
					{
						_message.SetActiveHint(false);

						_ui.SetEnableProductButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
			}
		);
	}

	// Message - Block

	private void SetupMessageBlock()
	{
		_message.SetActiveBlock(false);
	}

	public void OnMessageBlockBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_message.SetEnableBlockBackButton(false);

		_message.AnimateBlockBackButtonPressed
		(
			()=>
			{
				_message.AnimateBlockExit
				(
					()=>
					{
						_message.SetActiveBlock(false);

						_ui.SetEnableProductButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
			}
		);
	}

	// Message - Load()

	private bool _messageLoadEnterInProgress;

	private void SetupMessageLoad()
	{
		_message.SetActiveLoad(false);
		_messageLoadEnterInProgress = false;
	}

	// Message - Error

	private void SetupMessageError()
	{
		_message.SetActiveError(false);
	}

	public void OnMessageErrorBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_message.SetEnableErrorBackButton(false);

		_message.AnimateErrorBackButtonPressed
		(
			()=>
			{
				_message.AnimateErrorExit
				(
					()=>
					{
						_message.SetActiveError(false);

						_ui.SetEnableProductButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("StoreUI").GetComponent<StoreUI>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_block = GameObject.Find("BlockManager").GetComponent<BlockManager>();
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_frameRate = GameObject.Find("FrameRateManager").GetComponent<FrameRateManager>();
		_item = GameObject.Find("ItemManager").GetComponent<ItemManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_message = GameObject.Find("MessageManager").GetComponent<MessageManager>();

		_purchasePending = 0;
	}

	private void Start()
	{
		SetupBackground();
		SetupState();
		SetupTop();
		SetupProduct();
		SetupBottom();
		SetupMessageItem();
		SetupMessageHint();
		SetupMessageBlock();
		SetupMessageLoad();
		SetupMessageError();

		_frameRate.setHighFrameRate();

		_ui.SetEnableProductButton(false);
		_ui.AnimateProductEnter
		(
			()=>
			{
				_ui.SetEnableProductButton(true);
			}
		);
	}

	private void Update()
	{
		if (_state == State.NONE)
		{
			DoStateNone();
		}
		else if (_state == State.LOAD_AD)
		{
			DoStateLoadAd();
		}
		else if (_state == State.AD)
		{
			DoStateAd();
		}
	}
}
