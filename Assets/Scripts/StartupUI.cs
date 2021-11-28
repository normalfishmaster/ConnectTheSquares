using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupUI : MonoBehaviour
{
	// Loading

	public float LOADING_ANIMATE_SLIDER_DURATION;

	GameObject _loading;

	private void GetLoadingGameObject()
	{
		_loading = GameObject.Find("/Canvas/Loading");
	}

	public void ResetLoadingSlider()
	{
		_loading.GetComponent<Slider>().value = 0.0f;
	}

	public void AnimateLoadingSlider(float val, Animate.AnimateComplete callback)
	{
		float currentVal = _loading.GetComponent<Slider>().value;

		LeanTween.cancel(_loading);

		LeanTween.value(_loading, currentVal, val, LOADING_ANIMATE_SLIDER_DURATION).setEase(LeanTweenType.easeInSine).setOnUpdate
		(
			(float val) =>
			{
				_loading.GetComponent<Slider>().value = val;
			}
		)
		.setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	// Unity Lifecycle

	void Awake()
	{
		GetLoadingGameObject();
	}
}
