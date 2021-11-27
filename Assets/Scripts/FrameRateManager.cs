using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FrameRateManager : MonoBehaviour
{
	private static FrameRateManager _instance;

	// Frame Rate
	// Low    - 20 FPS
	// Medium - 30 FPS
	// High   - 120 FPS

	private static int FRAME_RATE_LOW_RENDER_FRAME_INTERVAL = 6;
	private static int FRAME_RATE_MEDIUM_RENDER_FRAME_INTERVAL = 4;
	private static int FRAME_RATE_HIGH_RENDER_FRAME_INTERVAL = 1;

	private bool _frameRateChangeInProgress;
	private float _frameRateChangeStartTime;
	private float _frameRateChangeDelay;
	private int _frameRateRenderFrameInterval;

	public void setLowFrameRate()
	{
		_frameRateChangeInProgress = false;
		OnDemandRendering.renderFrameInterval = FRAME_RATE_LOW_RENDER_FRAME_INTERVAL;
	}

	public void setLowFrameRate(float delay)
	{
		_frameRateChangeInProgress = true;
		_frameRateChangeStartTime = Time.time;
		_frameRateChangeDelay = delay;
		_frameRateRenderFrameInterval = FRAME_RATE_LOW_RENDER_FRAME_INTERVAL;
	}

	public void setMediumFrameRate()
	{
		_frameRateChangeInProgress = false;
		OnDemandRendering.renderFrameInterval = FRAME_RATE_MEDIUM_RENDER_FRAME_INTERVAL;
	}

	public void setMediumFrameRate(float delay)
	{
		_frameRateChangeInProgress = true;
		_frameRateChangeStartTime = Time.time;
		_frameRateChangeDelay = delay;
		_frameRateRenderFrameInterval = FRAME_RATE_MEDIUM_RENDER_FRAME_INTERVAL;
	}

	public void setHighFrameRate()
	{
		_frameRateChangeInProgress = false;
		OnDemandRendering.renderFrameInterval = FRAME_RATE_HIGH_RENDER_FRAME_INTERVAL;
	}

	public void setHighFrameRate(float delay)
	{
		_frameRateChangeInProgress = true;
		_frameRateChangeStartTime = Time.time;
		_frameRateChangeDelay = delay;
		_frameRateRenderFrameInterval = FRAME_RATE_HIGH_RENDER_FRAME_INTERVAL;
	}

	// Unity Lifecyle

	private void Awake()
	{
		// Singleton implementation

		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	private void Start()
	{
		Application.targetFrameRate = 120;

		_frameRateChangeInProgress = false;
		OnDemandRendering.renderFrameInterval = FRAME_RATE_HIGH_RENDER_FRAME_INTERVAL;
	}

	private void Update()
	{
		if (_frameRateChangeInProgress)
		{
			if (Time.time - _frameRateChangeStartTime > _frameRateChangeDelay)
			{
				OnDemandRendering.renderFrameInterval = _frameRateRenderFrameInterval;
				_frameRateChangeInProgress = false;
			}
		}
	}
}
