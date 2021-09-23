using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopLogic : MonoBehaviour
{
        private ShopUI _ui;
        private DataManager _data;
        private LevelManager _level;
        private AudioManager _audio;

	// UI - Product

	public void DoProductNoAdsButtonPressed()
	{
		_audio.PlayButtonPressed();
		_ui.AnimateProductNoAdsButtonPressed(()=>{});
	}

	// UI - Bottom

	public void DoBottomBackButtonPressed()
	{
		_audio.PlayButtonPressed();

		_ui.AnimateBottomBackButtonPressed
		(
			()=>
			{
				SceneManager.LoadScene("MainMenuScene");
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		_ui = GameObject.Find("ShopUI").GetComponent<ShopUI>();
		_data = GameObject.Find("DataManager").GetComponent<DataManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		_audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}
}
