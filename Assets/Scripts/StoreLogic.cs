using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreLogic : MonoBehaviour
{
        private StoreUI _ui;
	private LoadUI _loadUi;
	private AdUI _adUi;
        private DataManager _data;
        private LevelManager _level;
        private AudioManager _audio;
	private AdManager _ad;

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
		_ad.ClearRewardStatus();

		if (_ad.ShowRewarded() == 0)
		{
			_loadUi.AnimateLoadSquareStop();
			_loadUi.SetActiveLoad(false);
			_state = State.AD;
		}
		else if (Time.time - _stateLoadAdStartTime > MAX_AD_LOAD_TIME)
		{
			_loadUi.AnimateLoadSquareStop();
			_loadUi.SetActiveLoad(false);
			_adUi.SetActiveAdFail(true);
			_adUi.SetEnableAdFailButton(false);
			_adUi.AnimateAdFailBoardEnter
			(
				()=>
				{
					_adUi.SetEnableAdFailButton(true);
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
			_data.SetHint(_data.GetHint() + 1);
			_adUi.SetActiveAdSuccess(true);
			_adUi.SetActiveAdSuccessHint(false);
			_adUi.SetEnableAdSuccessButton(false);
			_adUi.AnimateAdSuccessBoardEnter
			(
				()=>
				{
					_audio.PlayRewardReceived();
					_adUi.SetActiveAdSuccessHint(true);
					_adUi.AnimateAdSuccessHintEnter
					(
						()=>
						{
							_adUi.SetEnableAdSuccessButton(true);
						}
					);
				}
			);
			_state = State.NONE;
		}
		else if (status == AdManager.RewardStatus.FAIL)
		{
			_adUi.SetActiveAdAbort(true);
			_adUi.SetEnableAdAbortButton(false);
			_adUi.AnimateAdAbortBoardEnter
			(
				()=>
				{
					_adUi.SetEnableAdAbortButton(true);
				}
			);
			_state = State.NONE;
		}
	}

	// UI - Product

	public void OnProductHintAdButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductHintAdButtonPressed
		(
			()=>
			{
				_ui.SetEnableProductButton(false);
				_ui.SetEnableBottomButton(false);
				_loadUi.SetActiveLoad(true);
				_loadUi.AnimateLoadSquareStart();
				_stateLoadAdStartTime = Time.time;
				_state = State.LOAD_AD;
			}
		);
	}

	public void OnProductRemoveAdsButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductRemoveAdsButtonPressed(()=>{});
	}

	public void OnProductBlockMetalButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductBlockMetalButtonPressed(()=>{});
	}

	public void OnProductBlockWoodButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductBlockWoodButtonPressed(()=>{});
	}

	public void OnProductBlockGreenMarbleButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductBlockGreenMarbleButtonPressed(()=>{});
	}

	public void OnProductBlockBlueMarbleButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductBlockBlueMarbleButtonPressed(()=>{});
	}

	public void OnProductBlockRedMarbleButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductBlockRedMarbleButtonPressed(()=>{});
	}

	public void OnProductBlockRareMarbleButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductBlockRareMarbleButtonPressed(()=>{});
	}

	public void OnProductHints3ButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductHints3ButtonPressed(()=>{});
	}

	public void OnProductHints15p3ButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductHints15p3ButtonPressed(()=>{});
	}

	public void OnProductHints30p9ButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductHints30p9ButtonPressed(()=>{});
	}

	public void OnProductHints60p24ButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductHints60p24ButtonPressed(()=>{});
	}

	private void SetupProduct()
	{
		_ui.SetEnableProductButton(false);
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

	// LoadUI

	private void SetupLoad()
	{
		_loadUi.SetActiveLoad(false);
	}

	// AdUI - Success

	private void SetupAdSuccess()
	{
		_adUi.SetActiveAdSuccess(false);
	}

	public void OnAdSuccessCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdSuccessButton(false);
		_adUi.AnimateAdSuccessCloseButtonPressed
		(
			()=>
			{
				_adUi.AnimateAdSuccessBoardExit
				(
					()=>
					{
						_adUi.SetActiveAdSuccess(false);
						_ui.SetEnableProductButton(true);
						_ui.SetEnableBottomButton(true);
					}
				);
			}
		);
	}

	// AdUI - Abort

	private void SetupAdAbort()
	{
		_adUi.SetActiveAdAbort(false);
	}

	public void OnAdAbortCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdAbortButton(false);
		_adUi.AnimateAdAbortBoardExit
		(
			()=>
			{
				_adUi.SetActiveAdAbort(false);
				_ui.SetEnableProductButton(true);
				_ui.SetEnableBottomButton(true);
			}
		);
	}

	// AdUI - Fail

	private void SetupAdFail()
	{
		_adUi.SetActiveAdFail(false);
	}

	public void OnAdFailCloseButtonPressed()
	{
		_audio.PlayButtonPressed();

		_adUi.SetEnableAdFailButton(false);
		_adUi.AnimateAdFailBoardExit
		(
			()=>
			{
				_adUi.SetActiveAdFail(false);
				_ui.SetEnableProductButton(true);
				_ui.SetEnableBottomButton(true);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("StoreUI").GetComponent<StoreUI>();
		_loadUi = GameObject.Find("LoadUI").GetComponent<LoadUI>();
		_adUi = GameObject.Find("AdUI").GetComponent<AdUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		_ad = GameObject.Find("AdManager").GetComponent<AdManager>();
	}

	private void Start()
	{
		SetupState();
		SetupProduct();
		SetupBottom();
		SetupLoad();
		SetupAdSuccess();
		SetupAdAbort();
		SetupAdFail();

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
