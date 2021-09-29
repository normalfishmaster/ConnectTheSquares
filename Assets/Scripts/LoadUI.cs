using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUI : MonoBehaviour
{
	public float LOAD_ANIMATE_BLOCK_DURATION;
	public float LOAD_ANIMATE_BLOCK_DELAY;

	private GameObject _load;
	private GameObject[] _loadBlock;

	private void FindLoadGameObject()
	{
		_load = GameObject.Find("/Canvas/Load");

		_loadBlock = new GameObject[4];

		for (int i = 0; i < 4; i++)
		{
			_loadBlock[i] = GameObject.Find("/Canvas/Load/Board/Block" + i);
		}
	}

	public void SetActiveLoad(bool active)
	{
		_load.SetActive(active);
	}

	private void AnimateLoadBlockStopSingle(int block)
	{
		LeanTween.cancel(_loadBlock[block]);
	}

	private void AnimateLoadBlockStartSingle(int block, Animate.AnimateComplete callback)
	{
		AnimateLoadBlockStopSingle(block);

		_loadBlock[block].transform.localScale = Vector3.one;

		LeanTween.scale(_loadBlock[block], Vector3.one * 1.5f, LOAD_ANIMATE_BLOCK_DURATION).setDelay(LOAD_ANIMATE_BLOCK_DELAY).setEasePunch().setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateLoadBlockStop()
	{
		for (int i = 0; i < 4; i++)
		{
			AnimateLoadBlockStopSingle(i);
		}
	}

	public void AnimateLoadBlockStart()
	{
		AnimateLoadBlockStartSingle(0,
			()=>
			{
				AnimateLoadBlockStartSingle(1,
					()=>
					{
						AnimateLoadBlockStartSingle(2,
							()=>
							{
								AnimateLoadBlockStartSingle(3,
									()=>
									{
										AnimateLoadBlockStart();
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
