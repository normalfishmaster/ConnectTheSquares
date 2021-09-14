using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
	public delegate void AnimateComplete();

	public static void AnimateButtonPressed(GameObject gameObject, float scale, float animateTime, AnimateComplete callback)
	{
		gameObject.transform.localScale = Vector3.one;

		LeanTween.cancel(gameObject);
		LeanTween.scale(gameObject, Vector3.one * scale, animateTime).setEasePunch().setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public static void AnimateBoardEnter(GameObject mainPanel, GameObject board, float duration, AnimateComplete callback)
	{
		RectTransform rectTransform = (RectTransform)board.transform;
		Vector3 pos = rectTransform.anchoredPosition;
		float height = (rectTransform.rect.height / 2) + (((RectTransform)(mainPanel.transform)).rect.height / 2);

		rectTransform.anchoredPosition = new Vector3(pos.x, pos.y + height, pos.z);

		LeanTween.cancel(board);
		LeanTween.moveLocalY(board, 0.0f, duration).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public static void AnimateBoardExit(GameObject mainPanel, GameObject board, float duration, AnimateComplete callback)
	{
		RectTransform rectTransform = (RectTransform)board.transform;
		Vector3 pos = rectTransform.anchoredPosition;

		float height = (rectTransform.rect.height / 2) + (((RectTransform)(mainPanel.transform)).rect.height / 2);

		LeanTween.cancel(board);
		LeanTween.moveLocalY(board, pos.y + height, duration).setEase(LeanTweenType.easeOutQuad).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}
}
