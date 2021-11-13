using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreLogic : MonoBehaviour
{
        private StoreUI _ui;
	private AdManager _ad;
        private AudioManager _audio;
	private CloudOnceManager _cloudOnce;
        private DataManager _data;
        private LevelManager _level;
	private MessageManager _message;

	private int _purchasePending;

	// UI - Background

	private void SetupBackground()
	{
		_ui.SetBackgroundColor(_data.GetBackgroundColor());
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
			_ui.SetEnableProductPriceButton(true);
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

		if (_data.GetRemoveAds() == 1)
		{
			_ui.SetActiveProductRemoveAdsPriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductRemoveAdsPriceAndPurchased(true, false);
		}

		if (_data.GetUnlockAllLevels() == 1)
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(false, true);
		}
		else if (_data.GetLevelLock(lastColor, lastAlphabet, lastMap) == 0)
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(true, false);
			_ui.SetInteractableProductUnlockAllLevels(false);
		}
		else
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(true, false);
		}

		if (_data.GetBlockMetalUnlocked() == 1)
		{
			_ui.SetActiveProductBlockMetalPriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductBlockMetalPriceAndPurchased(true, false);
		}

		if (_data.GetBlockWoodUnlocked() == 1)
		{
			_ui.SetActiveProductBlockWoodPriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductBlockWoodPriceAndPurchased(true, false);
		}

		if (_data.GetBlockGreenMarbleUnlocked() == 1)
		{
			_ui.SetActiveProductBlockGreenMarblePriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductBlockGreenMarblePriceAndPurchased(true, false);
		}

		if (_data.GetBlockBlueMarbleUnlocked() == 1)
		{
			_ui.SetActiveProductBlockBlueMarblePriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductBlockBlueMarblePriceAndPurchased(true, false);
		}

		if (_data.GetBlockRedMarbleUnlocked() == 1)
		{
			_ui.SetActiveProductBlockRedMarblePriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductBlockRedMarblePriceAndPurchased(true, false);
		}

		if (_data.GetBlockPurpleMarbleUnlocked() == 1)
		{
			_ui.SetActiveProductBlockPurpleMarblePriceAndPurchased(false, true);
		}
		else
		{
			_ui.SetActiveProductBlockPurpleMarblePriceAndPurchased(true, false);
		}
	}

	public void OnProductHintAdButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.SetEnableProductPriceButton(false);
		_ui.SetEnableBottomButton(false);

		_ui.AnimateProductHintAdButtonPressed
		(
			()=>
			{
				if (_ad.IsRewardedLoaded())
				{
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

	private void OnProductButtonPressedCommon()
	{
		_audio.PlayButtonPressed();
		_purchasePending = 1;
	}

	public void OnProductRemoveAdsButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductRemoveAdsButtonPressed(()=>{});
	}

	public void OnProductUnlockAllLevelsButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductUnlockAllLevelsButtonPressed(()=>{});
	}

	public void OnProductHints3ButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductHints3ButtonPressed(()=>{});
	}

	public void OnProductHints15p3ButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductHints15p3ButtonPressed(()=>{});
	}

	public void OnProductHints30p9ButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductHints30p9ButtonPressed(()=>{});
	}

	public void OnProductHints60p24ButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductHints60p24ButtonPressed(()=>{});
	}

	public void OnProductBlockMetalButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductBlockMetalButtonPressed(()=>{});
	}

	public void OnProductBlockWoodButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductBlockWoodButtonPressed(()=>{});
	}

	public void OnProductBlockGreenMarbleButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductBlockGreenMarbleButtonPressed(()=>{});
	}

	public void OnProductBlockBlueMarbleButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductBlockBlueMarbleButtonPressed(()=>{});
	}

	public void OnProductBlockRedMarbleButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductBlockRedMarbleButtonPressed(()=>{});
	}

	public void OnProductBlockPurpleMarbleButtonPressed()
	{
		OnProductButtonPressedCommon();
		_ui.AnimateProductBlockPurpleMarbleButtonPressed(()=>{});
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
		}
		else if (itemNumber == ItemManager.UNLOCK_ALL_LEVELS)
		{
			_ui.SetActiveProductUnlockAllLevelsPriceAndPurchased(false, true);
		}

		_audio.PlayRewardReceived();

		_ui.SetEnableProductPriceButton(false);
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

		_ui.SetEnableProductPriceButton(false);
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

		if (setNumber == BlockManager.BLOCK_SET_METAL)
		{
			_ui.SetActiveProductBlockMetalPriceAndPurchased(false, true);
		}
		else if (setNumber == BlockManager.BLOCK_SET_WOOD)
		{
			_ui.SetActiveProductBlockWoodPriceAndPurchased(false, true);
		}
		else if (setNumber == BlockManager.BLOCK_SET_GREEN_MARBLE)
		{
			_ui.SetActiveProductBlockGreenMarblePriceAndPurchased(false, true);
		}
		else if (setNumber == BlockManager.BLOCK_SET_BLUE_MARBLE)
		{
			_ui.SetActiveProductBlockBlueMarblePriceAndPurchased(false, true);
		}
		else if (setNumber == BlockManager.BLOCK_SET_RED_MARBLE)
		{
			_ui.SetActiveProductBlockRedMarblePriceAndPurchased(false, true);
		}
		else if (setNumber == BlockManager.BLOCK_SET_PURPLE_MARBLE)
		{
			_ui.SetActiveProductBlockPurpleMarblePriceAndPurchased(false, true);
		}

		_audio.PlayRewardReceived();

		_ui.SetEnableProductPriceButton(false);
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

		_ui.SetEnableProductPriceButton(false);
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

						_ui.SetEnableProductPriceButton(true);
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

						_ui.SetEnableProductPriceButton(true);
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

						_ui.SetEnableProductPriceButton(true);
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

						_ui.SetEnableProductPriceButton(true);
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
		_cloudOnce = GameObject.Find("CloudOnceManager").GetComponent<CloudOnceManager>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
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

		_ui.SetEnableProductPriceButton(false);
		_ui.AnimateProductEnter
		(
			()=>
			{
				_ui.SetEnableProductPriceButton(true);
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
