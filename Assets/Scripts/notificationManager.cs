using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;
using Assets.Scripts;


//cannot refer mygod in methods. has to check that
public class notificationManager
{
    God myGod;

    private void Start()
    {
        createChannel();
        GameManager.createGods();
        if (GameManager.getGroupID() > 0)
        {
            myGod = GameManager.getGodInfo(GameManager.getGroupID());
        }
    }

    private void createChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "Notifier",
            Name = "myNotify",
            Description = "just trying",
            Importance = Importance.High,
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    void SendNotification(string title, string text)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Color = new Color(197, 132, 34, 255);
        notification.Text = text;
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";
        notification.FireTime = System.DateTime.Now;

        AndroidNotificationCenter.SendNotification(notification, "Notifier");
    }

    void SendtimedNotification(string title,string text,DateTime sendingTime)
    {
        if (sendingTime >= System.DateTime.Now)
        {
            SendNotification(title, text);
        }
    }

    public void sendWelcomeNotification()
    {
        SendNotification("Welcome to the Journey", "try to complete the errand you have started and get to know where you belong");
    }

    public void sendCompleteNotification()
    {
        SendNotification("You belong to "  + " followers", "Be there to witness a miracle happenning through the power of gods");
    }

    public void sendRemindNotification(DateTime time)
    {
        if (GameManager.getGroupID() > 0)
        {
            SendtimedNotification("Your attendance is needed", "Be there on ##### at ###### in " , time);
        }
    }
}
