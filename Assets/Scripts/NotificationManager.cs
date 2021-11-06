using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#elif UNITY_IOS
#endif

public class NotificationManager : MonoBehaviour
{
	private NotificationManager _instance;

	// Android

	AndroidNotificationChannel _channel;

	private string[] _titleTime0 = new string[3]
	{
		"Bored?",
		"It's time for a challenge",
		"Incoming puzzles"
	};

	private string[] _textTime0 = new string[3]
	{
		"Why not knock off a few puzzles?",
		"How many levels can you solve today?",
		"When life gives you puzzles, solve them like a boss!"
	};

	private string[] _titleTime1 = new string[3]
	{
		"Breaking news!",
		"Never skip brain day",
		"Help!"
	};

	private string[] _textTime1 = new string[3]
	{
		"Scientist are calling for expert puzzle-solvers to solve this very difficult puzzle.",
		"A puzzle a day keeps your mind sharp and focused.",
		"We cannot solve these puzzles without you. Please help us!"
	};

	private int _fireHour0 = 12;
	private int _fireMinute0 = 15;

	private int _fireHour1 = 20;
	private int _fireMinute1 = 15;

	void SetupNotification()
	{
		_channel = new AndroidNotificationChannel()
		{
			Id = "defaultChannel",
			Name = "Default Channel",
			Description = "This is the default channel",
			Importance = Importance.Default,
		};

		AndroidNotificationCenter.RegisterNotificationChannel(_channel);
	}

	void SendNotification(string title, string text, DateTime fireTime, TimeSpan repeatInterval)
	{
		AndroidNotification notification = new AndroidNotification()
		{
			Title = title,
			Text = text,
			SmallIcon = "default",
			LargeIcon = "default",
			FireTime = fireTime,
			RepeatInterval = repeatInterval,
		};

		AndroidNotificationCenter.SendNotification(notification, "defaultChannel");
	}

	void CancelAllNotification()
	{
		AndroidNotificationCenter.CancelAllNotifications();
	}

	void ScheduleNotification()
	{
		// Cancel all notifications

		CancelAllNotification();

		// Reschedule notifications

		string[] titleTime0 = new string[3];
		string[] textTime0 = new string[3];

		string[] titleTime1 = new string[3];
		string[] textTime1 = new string[3];

		int remainder = System.DateTime.Now.DayOfYear % 3;

		for (int i = 0; i < 3; i++)
		{
			titleTime0[i] = _titleTime0[remainder];
			textTime0[i] = _textTime0[remainder];

			titleTime1[i] = _titleTime1[remainder];
			textTime1[i] = _textTime1[remainder];

			remainder += 1;
			if (remainder >= 3)
			{
				remainder = 0;
			}
		}

		DateTime now = System.DateTime.Now;
		DateTime fireTime0 = new DateTime(now.Year, now.Month, now.Day, _fireHour0, _fireMinute0, 0).AddHours(24);
		DateTime fireTime1 = new DateTime(now.Year, now.Month, now.Day, _fireHour1, _fireMinute1, 0).AddHours(24);
		TimeSpan repeatInterval = new TimeSpan(24 * 3, 0, 0);

		for (int i = 0; i < 3; i++)
		{
			DateTime actualFireTime0 = fireTime0.AddHours(24 * i);
			DateTime actualFireTime1 = fireTime1.AddHours(24 * i);

			SendNotification(titleTime0[i], textTime0[i], actualFireTime0, repeatInterval);
			SendNotification(titleTime1[i], textTime1[i], actualFireTime1, repeatInterval);
		}
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

	void Start()
	{
		SetupNotification();
		CancelAllNotification();
	}

	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus == false)
		{
			CancelAllNotification();
			return;
		}

		ScheduleNotification();
	}

	void OnApplicationQuit()
	{
		ScheduleNotification();
	}
}
