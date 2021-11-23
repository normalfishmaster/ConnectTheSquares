using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoBehaviour
{
	private BlockManager _blk;
	private ItemManager _itm;
	private LevelManager _level;

	// Achievement

	public float ACHIEVEMENT_ANIMATE_ENTER_DURATION;

	public float ACHIEVEMENT_ANIMATE_SUNBURST_ENTER_DURATION;
	public float ACHIEVEMENT_ANIMATE_SUNBURST_ROTATE_DURATION;

	public float ACHIEVEMENT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float ACHIEVEMENT_ANIMATE_BUTTON_PRESSED_DURATION;

	public float ACHIEVEMENT_ANIMATE_EXIT_DURATION;

	private GameObject _achievement;
	private GameObject _achievementSunburstWide;
	private GameObject _achievementSunburstNarrow;
	private GameObject _achievementMedalSilver;
	private GameObject _achievementMedalSilverGold;
	private GameObject _achievementMedalGold;
	private GameObject _achievementGeneric;
	private GameObject _achievementName;
	private GameObject _achievementBack;
	private GameObject _achievementBackButton;

	private void FindAchievementGameObject()
	{
		_achievement = GameObject.Find("/Canvas/MessageAchievement");
		_achievementSunburstWide = GameObject.Find("/Canvas/MessageAchievement/Board/SunburstWide");
		_achievementSunburstNarrow = GameObject.Find("/Canvas/MessageAchievement/Board/SunburstNarrow");
		_achievementMedalSilver = GameObject.Find("/Canvas/MessageAchievement/Board/MedalSilver");
		_achievementMedalSilverGold = GameObject.Find("/Canvas/MessageAchievement/Board/MedalSilverGold");
		_achievementMedalGold = GameObject.Find("/Canvas/MessageAchievement/Board/MedalGold");
		_achievementGeneric = GameObject.Find("/Canvas/MessageAchievement/Board/Generic");
		_achievementName = GameObject.Find("/Canvas/MessageAchievement/Board/Name");
		_achievementBack = GameObject.Find("/Canvas/MessageAchievement/Board/Back");
		_achievementBackButton = GameObject.Find("/Canvas/MessageAchievement/Board/Back/Button");
	}

	public void SetActiveAchievement(bool active)
	{
		_achievement.SetActive(active);
	}

	public void SetEnableAchievementBackButton(bool enable)
	{
		_achievementBackButton.GetComponent<Button>().enabled = enable;
	}

	public void SetActiveAchievementMedalSiver(bool active)
	{
		_achievementMedalSilver.SetActive(active);
	}

	public void SetActiveAchievementMedalSiverGold(bool active)
	{
		_achievementMedalSilverGold.SetActive(active);
	}

	public void SetActiveAchievementMedalGold(bool active)
	{
		_achievementMedalGold.SetActive(active);
	}

	public void SetAchievementMessage(int color, int alphabet, bool fullClear, bool perfectionist)
	{
		string str = _level.GetColorString(color) + " - " + _level.GetAlphabetString(alphabet);

		if (perfectionist)
		{
			str = "Perfectionist";
		}
		else if (fullClear)
		{
			str += " Full Clear";
		}
		else
		{
			str += " Clear";
		}

		_achievementName.GetComponent<TextMeshProUGUI>().SetText(str);
	}

	private void AnimateAchievementSunburstWideRotate()
	{
		LeanTween.rotateAround(_achievementSunburstWide, Vector3.forward, -360.0f, ACHIEVEMENT_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateAchievementSunburstWideRotate();
			}
		);
	}

	public void AnimateAchievementEnter(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		LeanTween.cancel(_achievementSunburstWide);

		_achievementSunburstWide.transform.localScale = Vector3.zero;

		LeanTween.scale(_achievementSunburstWide, Vector3.one, ACHIEVEMENT_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		LeanTween.value(_achievementSunburstWide, 0.0f, 1, ACHIEVEMENT_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				_achievementSunburstWide.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
			}
		);

		AnimateAchievementSunburstWideRotate();

		// Animate Sunburst Narrow

		LeanTween.cancel(_achievementSunburstNarrow);

		_achievementSunburstNarrow.transform.localScale = Vector3.zero;

		LeanTween.scale(_achievementSunburstNarrow, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Medal

		LeanTween.cancel(_achievementMedalSilver);
		LeanTween.cancel(_achievementMedalSilverGold);
		LeanTween.cancel(_achievementMedalGold);

		_achievementMedalSilver.transform.localScale = Vector3.zero;
		_achievementMedalSilverGold.transform.localScale = Vector3.zero;
		_achievementMedalGold.transform.localScale = Vector3.zero;

		LeanTween.scale(_achievementMedalSilver, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.scale(_achievementMedalSilverGold, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.scale(_achievementMedalGold, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Message

		LeanTween.cancel(_achievementGeneric);
		LeanTween.cancel(_achievementName);

		_achievementGeneric.transform.localScale = Vector3.zero;
		_achievementName.transform.localScale = Vector3.zero;

		LeanTween.scale(_achievementGeneric, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.scale(_achievementName, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Back

		LeanTween.cancel(_achievementBack);

		_achievementBack.transform.localScale = Vector3.zero;
		_achievementBack.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_achievementBack, Vector3.one, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_achievementBack, Vector3.forward, -20.0f, ACHIEVEMENT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateAchievementExit(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		_achievementSunburstWide.transform.localScale = Vector3.one;
		LeanTween.scale(_achievementSunburstWide, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Sunburst Narrow

		_achievementSunburstNarrow.transform.localScale = Vector3.one;
		LeanTween.scale(_achievementSunburstNarrow, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Medal

		_achievementMedalSilver.transform.localScale = Vector3.one;
		_achievementMedalSilverGold.transform.localScale = Vector3.one;
		_achievementMedalGold.transform.localScale = Vector3.one;
		LeanTween.scale(_achievementMedalSilver, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);
		LeanTween.scale(_achievementMedalSilverGold, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);
		LeanTween.scale(_achievementMedalGold, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Message

		_achievementGeneric.transform.localScale = Vector3.one;
		_achievementName.transform.localScale = Vector3.one;
		LeanTween.scale(_achievementGeneric, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);
		LeanTween.scale(_achievementName, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Back

		_achievementBack.transform.localScale = Vector3.one;
		LeanTween.scale(_achievementBack, Vector3.zero, ACHIEVEMENT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateAchievementBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_achievementBackButton, ACHIEVEMENT_ANIMATE_BUTTON_PRESSED_SCALE, ACHIEVEMENT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Item

	public float ITEM_ANIMATE_ENTER_DURATION;

	public float ITEM_ANIMATE_SUNBURST_ENTER_DURATION;
	public float ITEM_ANIMATE_SUNBURST_ROTATE_DURATION;

	public float ITEM_ANIMATE_BUTTON_PRESSED_SCALE;
	public float ITEM_ANIMATE_BUTTON_PRESSED_DURATION;

	public float ITEM_ANIMATE_EXIT_DURATION;

	private GameObject _item;
	private GameObject _itemSunburstWide;
	private GameObject _itemSunburstNarrow;
	private GameObject _itemItem;
	private GameObject _itemMessage;
	private GameObject _itemBack;
	private GameObject _itemBackButton;

	private void FindItemGameObject()
	{
		_item = GameObject.Find("/Canvas/MessageItem");
		_itemSunburstWide = GameObject.Find("/Canvas/MessageItem/Board/SunburstWide");
		_itemSunburstNarrow = GameObject.Find("/Canvas/MessageItem/Board/SunburstNarrow");
		_itemItem = GameObject.Find("/Canvas/MessageItem/Board/Item");
		_itemMessage = GameObject.Find("/Canvas/MessageItem/Board/Message");
		_itemBack = GameObject.Find("/Canvas/MessageItem/Board/Back");
		_itemBackButton = GameObject.Find("/Canvas/MessageItem/Board/Back/Button");
	}

	public void SetActiveItem(bool active)
	{
		_item.SetActive(active);
	}

	public void SetEnableItemBackButton(bool enable)
	{
		_itemBackButton.GetComponent<Button>().enabled = enable;
	}

	public void SetItemImageAndMessage(int itemNumber)
	{
		string str;

		if (itemNumber == ItemManager.REMOVE_ADS)
		{
			str = "<color=#00BD96><b>Removed All ADs</b></color>!";
		}
		else
		{
			str = "<color=#00BD96><b>Unlocked All Levels</b></color>!";
		}

		_itemMessage.GetComponent<TextMeshProUGUI>().SetText(str);
		_itemItem.GetComponent<Image>().sprite = _itm.GetItemSprite(itemNumber);
	}

	private void AnimateItemSunburstWideRotate()
	{
		LeanTween.rotateAround(_itemSunburstWide, Vector3.forward, -360.0f, ITEM_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateItemSunburstWideRotate();
			}
		);
	}

	public void AnimateItemEnter(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		LeanTween.cancel(_itemSunburstWide);

		_itemSunburstWide.transform.localScale = Vector3.zero;

		LeanTween.scale(_itemSunburstWide, Vector3.one, ITEM_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		LeanTween.value(_itemSunburstWide, 0.0f, 1, ITEM_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				_itemSunburstWide.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
			}
		);

		AnimateItemSunburstWideRotate();

		// Animate Sunburst Narrow

		LeanTween.cancel(_itemSunburstNarrow);

		_itemSunburstNarrow.transform.localScale = Vector3.zero;

		LeanTween.scale(_itemSunburstNarrow, Vector3.one, ITEM_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Item

		LeanTween.cancel(_itemItem);

		_itemItem.transform.localScale = Vector3.zero;

		LeanTween.scale(_itemItem, Vector3.one, ITEM_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Message

		LeanTween.cancel(_itemMessage);

		_itemMessage.transform.localScale = Vector3.zero;
		_itemMessage.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_itemMessage, Vector3.one, ITEM_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_itemMessage, Vector3.forward, -20.0f, ITEM_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Back

		LeanTween.cancel(_itemBack);

		_itemBack.transform.localScale = Vector3.zero;
		_itemBack.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_itemBack, Vector3.one, ITEM_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_itemBack, Vector3.forward, -20.0f, ITEM_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateItemExit(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		_itemSunburstWide.transform.localScale = Vector3.one;
		LeanTween.scale(_itemSunburstWide, Vector3.zero, ITEM_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Sunburst Narrow

		_itemSunburstNarrow.transform.localScale = Vector3.one;
		LeanTween.scale(_itemSunburstNarrow, Vector3.zero, ITEM_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Item

		_itemItem.transform.localScale = Vector3.one;
		LeanTween.scale(_itemItem, Vector3.zero, ITEM_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Message

		_itemMessage.transform.localScale = Vector3.one;
		LeanTween.scale(_itemMessage, Vector3.zero, ITEM_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Back

		_itemBack.transform.localScale = Vector3.one;
		LeanTween.scale(_itemBack, Vector3.zero, ITEM_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateItemBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_itemBackButton, ITEM_ANIMATE_BUTTON_PRESSED_SCALE, ITEM_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Hint

	public float HINT_ANIMATE_ENTER_DURATION;

	public float HINT_ANIMATE_SUNBURST_ENTER_DURATION;
	public float HINT_ANIMATE_SUNBURST_ROTATE_DURATION;

	public float HINT_ANIMATE_BUTTON_PRESSED_SCALE;
	public float HINT_ANIMATE_BUTTON_PRESSED_DURATION;

	public float HINT_ANIMATE_EXIT_DURATION;

	private GameObject _hint;
	private GameObject _hintSunburstWide;
	private GameObject _hintSunburstNarrow;
	private GameObject _hintHint;
	private GameObject _hintCount;
	private GameObject _hintMessage;
	private GameObject _hintBack;
	private GameObject _hintBackButton;

	private void FindHintGameObject()
	{
		_hint = GameObject.Find("/Canvas/MessageHint");
		_hintSunburstWide = GameObject.Find("/Canvas/MessageHint/Board/SunburstWide");
		_hintSunburstNarrow = GameObject.Find("/Canvas/MessageHint/Board/SunburstNarrow");
		_hintHint = GameObject.Find("/Canvas/MessageHint/Board/Hint");
		_hintCount = GameObject.Find("/Canvas/MessageHint/Board/Count");
		_hintMessage = GameObject.Find("/Canvas/MessageHint/Board/Message");
		_hintBack = GameObject.Find("/Canvas/MessageHint/Board/Back");
		_hintBackButton = GameObject.Find("/Canvas/MessageHint/Board/Back/Button");
	}

	public void SetActiveHint(bool active)
	{
		_hint.SetActive(active);
	}

	public void SetEnableHintBackButton(bool enable)
	{
		_hintBackButton.GetComponent<Button>().enabled = enable;
	}

	public void SetHintCount(int count)
	{
		string str;

		if (count == 1)
		{
			str = "You get <color=#00BD96><b>" + count + " Hint</b></color>!";
		}
		else
		{
			str = "You get <color=#00BD96><b>" + count + " Hints</b></color>!";
		}

		_hintMessage.GetComponent<TextMeshProUGUI>().SetText(str);
		_hintCount.GetComponent<TextMeshProUGUI>().SetText("+" + count);
	}

	private void AnimateHintSunburstWideRotate()
	{
		LeanTween.rotateAround(_hintSunburstWide, Vector3.forward, -360.0f, HINT_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateHintSunburstWideRotate();
			}
		);
	}

	public void AnimateHintEnter(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		LeanTween.cancel(_hintSunburstWide);

		_hintSunburstWide.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintSunburstWide, Vector3.one, HINT_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		LeanTween.value(_hintSunburstWide, 0.0f, 1, HINT_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				_hintSunburstWide.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
			}
		);

		AnimateHintSunburstWideRotate();

		// Animate Sunburst Narrow

		LeanTween.cancel(_hintSunburstNarrow);

		_hintSunburstNarrow.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintSunburstNarrow, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Count

		LeanTween.cancel(_hintCount);

		_hintCount.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintCount, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Hint

		LeanTween.cancel(_hintHint);

		_hintHint.transform.localScale = Vector3.zero;

		LeanTween.scale(_hintHint, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Message

		LeanTween.cancel(_hintMessage);

		_hintMessage.transform.localScale = Vector3.zero;
		_hintMessage.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_hintMessage, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_hintMessage, Vector3.forward, -20.0f, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Back

		LeanTween.cancel(_hintBack);

		_hintBack.transform.localScale = Vector3.zero;
		_hintBack.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_hintBack, Vector3.one, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_hintBack, Vector3.forward, -20.0f, HINT_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateHintExit(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		_hintSunburstWide.transform.localScale = Vector3.one;
		LeanTween.scale(_hintSunburstWide, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Sunburst Narrow

		_hintSunburstNarrow.transform.localScale = Vector3.one;
		LeanTween.scale(_hintSunburstNarrow, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Count

		_hintCount.transform.localScale = Vector3.one;
		LeanTween.scale(_hintCount, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Hint

		_hintHint.transform.localScale = Vector3.one;
		LeanTween.scale(_hintHint, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Message

		_hintMessage.transform.localScale = Vector3.one;
		LeanTween.scale(_hintMessage, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Back

		_hintBack.transform.localScale = Vector3.one;
		LeanTween.scale(_hintBack, Vector3.zero, HINT_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateHintBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_hintBackButton, HINT_ANIMATE_BUTTON_PRESSED_SCALE, HINT_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Block

	public float BLOCK_ANIMATE_ENTER_DURATION;

	public float BLOCK_ANIMATE_SUNBURST_ENTER_DURATION;
	public float BLOCK_ANIMATE_SUNBURST_ROTATE_DURATION;

	public float BLOCK_ANIMATE_BUTTON_PRESSED_SCALE;
	public float BLOCK_ANIMATE_BUTTON_PRESSED_DURATION;

	public float BLOCK_ANIMATE_EXIT_DURATION;

	public Sprite[,] BLOCK_SPRITE;

	private GameObject _block;
	private GameObject _blockSunburstWide;
	private GameObject _blockSunburstNarrow;
	private GameObject _blockBlock;
	private GameObject _blockBlock0;
	private GameObject _blockBlock1;
	private GameObject _blockBlock2;
	private GameObject _blockBlock3;
	private GameObject _blockMessageGeneric;
	private GameObject _blockMessageBlock;
	private GameObject _blockBack;
	private GameObject _blockBackButton;

	private void FindBlockGameObject()
	{
		_block = GameObject.Find("/Canvas/MessageBlock");
		_blockSunburstWide = GameObject.Find("/Canvas/MessageBlock/Board/SunburstWide");
		_blockSunburstNarrow = GameObject.Find("/Canvas/MessageBlock/Board/SunburstNarrow");
		_blockBlock = GameObject.Find("/Canvas/MessageBlock/Board/Block");
		_blockBlock0 = GameObject.Find("/Canvas/MessageBlock/Board/Block/Block0");
		_blockBlock1 = GameObject.Find("/Canvas/MessageBlock/Board/Block/Block1");
		_blockBlock2 = GameObject.Find("/Canvas/MessageBlock/Board/Block/Block2");
		_blockBlock3 = GameObject.Find("/Canvas/MessageBlock/Board/Block/Block3");
		_blockMessageGeneric = GameObject.Find("/Canvas/MessageBlock/Board/MessageGeneric");
		_blockMessageBlock = GameObject.Find("/Canvas/MessageBlock/Board/MessageBlock");
		_blockBack = GameObject.Find("/Canvas/MessageBlock/Board/Back");
		_blockBackButton = GameObject.Find("/Canvas/MessageBlock/Board/Back/Button");
	}

	public void SetActiveBlock(bool active)
	{
		_block.SetActive(active);
	}

	public void SetEnableBlockBackButton(bool enable)
	{
		_blockBackButton.GetComponent<Button>().enabled = enable;
	}

	public void SetBlockImageAndMessage(int setNumber)
	{
		_blockMessageBlock.GetComponent<TextMeshProUGUI>().SetText("<color=#00BD96><b>" + BlockManager.BLOCK_SET_STRING[setNumber] + "</b></color>");
		_blockBlock0.GetComponent<Image>().sprite = _blk.GetBlockSprite(setNumber, 0);
		_blockBlock1.GetComponent<Image>().sprite = _blk.GetBlockSprite(setNumber, 1);
		_blockBlock2.GetComponent<Image>().sprite = _blk.GetBlockSprite(setNumber, 2);
		_blockBlock3.GetComponent<Image>().sprite = _blk.GetBlockSprite(setNumber, 3);
	}

	private void AnimateBlockSunburstWideRotate()
	{
		LeanTween.rotateAround(_blockSunburstWide, Vector3.forward, -360.0f, BLOCK_ANIMATE_SUNBURST_ROTATE_DURATION).setOnComplete
		(
			()=>
			{
				AnimateBlockSunburstWideRotate();
			}
		);
	}

	public void AnimateBlockEnter(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		LeanTween.cancel(_blockSunburstWide);

		_blockSunburstWide.transform.localScale = Vector3.zero;

		LeanTween.scale(_blockSunburstWide, Vector3.one, BLOCK_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutQuad);

		LeanTween.value(_blockSunburstWide, 0.0f, 1, BLOCK_ANIMATE_SUNBURST_ENTER_DURATION).setEase(LeanTweenType.easeOutSine).setOnUpdate
		(
			(float val) =>
			{
				_blockSunburstWide.GetComponent<Image>().color = new Color(1f, 1f, 1f, val);
			}
		);

		AnimateBlockSunburstWideRotate();

		// Animate Sunburst Narrow

		LeanTween.cancel(_blockSunburstNarrow);

		_blockSunburstNarrow.transform.localScale = Vector3.zero;

		LeanTween.scale(_blockSunburstNarrow, Vector3.one, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Block

		LeanTween.cancel(_blockBlock);

		_blockBlock.transform.localScale = Vector3.zero;

		LeanTween.scale(_blockBlock, Vector3.one, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Message

		LeanTween.cancel(_blockMessageGeneric);
		LeanTween.cancel(_blockMessageBlock);

		_blockMessageGeneric.transform.localScale = Vector3.zero;
		_blockMessageBlock.transform.localScale = Vector3.zero;

		_blockMessageGeneric.transform.eulerAngles = new Vector3(0, 0, 20);
		_blockMessageBlock.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_blockMessageGeneric, Vector3.one, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.scale(_blockMessageBlock, Vector3.one, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		LeanTween.rotateAround(_blockMessageGeneric, Vector3.forward, -20.0f, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_blockMessageBlock, Vector3.forward, -20.0f, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Back

		LeanTween.cancel(_blockBack);

		_blockBack.transform.localScale = Vector3.zero;
		_blockBack.transform.eulerAngles = new Vector3(0, 0, 20);

		LeanTween.scale(_blockBack, Vector3.one, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.rotateAround(_blockBack, Vector3.forward, -20.0f, BLOCK_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateBlockExit(Animate.AnimateComplete callback)
	{
		// Animate Sunburst Wide

		_blockSunburstWide.transform.localScale = Vector3.one;
		LeanTween.scale(_blockSunburstWide, Vector3.zero, BLOCK_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Sunburst Narrow

		_blockSunburstNarrow.transform.localScale = Vector3.one;
		LeanTween.scale(_blockSunburstNarrow, Vector3.zero, BLOCK_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Block

		_blockBlock.transform.localScale = Vector3.one;
		LeanTween.scale(_blockBlock, Vector3.zero, BLOCK_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Message

		_blockMessageGeneric.transform.localScale = Vector3.one;
		_blockMessageBlock.transform.localScale = Vector3.one;
		LeanTween.scale(_blockMessageGeneric, Vector3.zero, BLOCK_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);
		LeanTween.scale(_blockMessageBlock, Vector3.zero, BLOCK_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Back

		_blockBack.transform.localScale = Vector3.one;
		LeanTween.scale(_blockBack, Vector3.zero, BLOCK_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateBlockBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_blockBackButton, BLOCK_ANIMATE_BUTTON_PRESSED_SCALE, BLOCK_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Load

	public float LOAD_ANIMATE_ENTER_DURATION;
	public float LOAD_ANIMATE_EXIT_DURATION;

	private GameObject _load;
	private GameObject _loadMessageLoad;
	private GameObject _loadMessageWait;

	private void FindLoadGameObject()
	{
		_load = GameObject.Find("/Canvas/MessageLoad");
		_loadMessageLoad = GameObject.Find("/Canvas/MessageLoad/Board/MessageLoad");
		_loadMessageWait = GameObject.Find("/Canvas/MessageLoad/Board/MessageWait");
	}

	public void SetActiveLoad(bool active)
	{
		_load.SetActive(active);
	}

	public void AnimateLoadEnter(Animate.AnimateComplete callback)
	{
		// Animate Message

		LeanTween.cancel(_loadMessageLoad);
		LeanTween.cancel(_loadMessageWait);

		_loadMessageLoad.transform.localScale = Vector3.zero;
		_loadMessageWait.transform.localScale = Vector3.zero;

		LeanTween.scale(_loadMessageLoad, Vector3.one, LOAD_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.scale(_loadMessageWait, Vector3.one, LOAD_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateLoadExit(Animate.AnimateComplete callback)
	{
		// Animate Message

		LeanTween.cancel(_loadMessageLoad);
		LeanTween.cancel(_loadMessageWait);

		_loadMessageLoad.transform.localScale = Vector3.one;
		_loadMessageWait.transform.localScale = Vector3.one;
		LeanTween.scale(_loadMessageLoad, Vector3.zero, LOAD_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);
		LeanTween.scale(_loadMessageWait, Vector3.zero, LOAD_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	// Error

	public float ERROR_ANIMATE_ENTER_DURATION;

	public float ERROR_ANIMATE_BUTTON_PRESSED_SCALE;
	public float ERROR_ANIMATE_BUTTON_PRESSED_DURATION;

	public float ERROR_ANIMATE_EXIT_DURATION;

	private GameObject _error;
	private GameObject _errorMessageError;
	private GameObject _errorMessageCheck;
	private GameObject _errorBack;
	private GameObject _errorBackButton;

	private void FindErrorGameObject()
	{
		_error = GameObject.Find("/Canvas/MessageError");
		_errorMessageError = GameObject.Find("/Canvas/MessageError/Board/MessageError");
		_errorMessageCheck = GameObject.Find("/Canvas/MessageError/Board/MessageCheck");
		_errorBack = GameObject.Find("/Canvas/MessageError/Board/Back");
		_errorBackButton = GameObject.Find("/Canvas/MessageError/Board/Back/Button");
	}

	public void SetActiveError(bool active)
	{
		_error.SetActive(active);
	}

	public void SetEnableErrorBackButton(bool enable)
	{
		_errorBackButton.GetComponent<Button>().enabled = enable;
	}

	public void AnimateErrorEnter(Animate.AnimateComplete callback)
	{
		// Animate Message

		LeanTween.cancel(_errorMessageError);
		LeanTween.cancel(_errorMessageCheck);

		_errorMessageError.transform.localScale = Vector3.zero;
		_errorMessageCheck.transform.localScale = Vector3.zero;

		LeanTween.scale(_errorMessageError, Vector3.one, ERROR_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);
		LeanTween.scale(_errorMessageCheck, Vector3.one, ERROR_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic);

		// Animate Back

		LeanTween.cancel(_errorBack);

		_errorBack.transform.localScale = Vector3.zero;

		LeanTween.scale(_errorBack, Vector3.one, ERROR_ANIMATE_ENTER_DURATION).setEase(LeanTweenType.easeInOutElastic).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateErrorExit(Animate.AnimateComplete callback)
	{
		// Animate Message

		LeanTween.cancel(_errorMessageError);
		LeanTween.cancel(_errorMessageCheck);

		_errorMessageError.transform.localScale = Vector3.one;
		_errorMessageCheck.transform.localScale = Vector3.one;

		LeanTween.scale(_errorMessageError, Vector3.zero, ERROR_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);
		LeanTween.scale(_errorMessageCheck, Vector3.zero, ERROR_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack);

		// Animate Back

		_errorBack.transform.localScale = Vector3.one;
		LeanTween.scale(_errorBack, Vector3.zero, ERROR_ANIMATE_EXIT_DURATION).setEase(LeanTweenType.easeInBack).setOnComplete
		(
			()=>
			{
				callback();
			}
		);
	}

	public void AnimateErrorBackButtonPressed(Animate.AnimateComplete callback)
	{
		Animate.AnimateButtonPressed(_errorBackButton, ERROR_ANIMATE_BUTTON_PRESSED_SCALE, ERROR_ANIMATE_BUTTON_PRESSED_DURATION, callback);
	}

	// Unity Lifecycle

	void Awake()
	{
		_blk = GameObject.Find("BlockManager").GetComponent<BlockManager>();
		_itm = GameObject.Find("ItemManager").GetComponent<ItemManager>();
		_level = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		FindAchievementGameObject();
		FindItemGameObject();
		FindHintGameObject();
		FindBlockGameObject();
		FindLoadGameObject();
		FindErrorGameObject();
	}
}
