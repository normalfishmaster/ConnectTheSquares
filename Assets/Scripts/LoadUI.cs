using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUI : MonoBehaviour
{
	public float LOAD_ANIMATE_SQUARE_DURATION;
	public float LOAD_ANIMATE_SQUARE_DELAY;

	private GameObject _load;
	private GameObject[] _loadSquare;

	private void FindLoadGameObject()
	{
		_load = GameObject.Find("/Canvas/Load");

		_loadSquare = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			_loadSquare[i] = GameObject.Find("/Canvas/Load/Board/Square" + i);
		}
	}

	public void SetActiveLoad(bool active)
	{
		_load.SetActive(active);
	}

	private void AnimateLoadSquareStopSingle(int square)
	{
		LeanTween.cancel(_loadSquare[square]);
	}

	private void AnimateLoadSquareStartSingle(int square, Animate.AnimateComplete callback)
	{
		AnimateLoadSquareStopSingle(square);

		_loadSquare[square].transform.localScale = Vector3.one;

		LeanTween.scale(_loadSquare[square], Vector3.one * 1.5f, LOAD_ANIMATE_SQUARE_DURATION).setDelay(LOAD_ANIMATE_SQUARE_DELAY).setEasePunch().setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateLoadSquareStop()
	{
		for (int i = 0; i < 4; i++)
		{
			AnimateLoadSquareStopSingle(i);
		}
	}

	public void AnimateLoadSquareStart()
	{
		AnimateLoadSquareStartSingle(0,
			()=>
			{
				AnimateLoadSquareStartSingle(1,
					()=>
					{
						AnimateLoadSquareStartSingle(2,
							()=>
							{
								AnimateLoadSquareStartSingle(3,
									()=>
									{
										AnimateLoadSquareStart();
									}
								);
							}
						);
					}
				);
			}
		);
	}

	// Unity Lifecycle

	private void Awake()
	{
		FindLoadGameObject();
	}
}
