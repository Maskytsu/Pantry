using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Notifications.Android;

public class SetAlarmController : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputField;
    const string ACTION_SET_ALARM = "android.intent.action.SET_ALARM";
    const string EXTRA_HOUR = "android.intent.extra.alarm.HOUR";
    const string EXTRA_MINUTES = "android.intent.extra.alarm.MINUTES";

    private void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notification Channel",
            Importance = Importance.Default,
            Description = "Notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }


    public void SetAlarm()
    {
        int minutesToSkip = 0;
        int hourAlarm = 0;
        int minutesAlarm = 0;


        //Set up right time for alarm
        if (_inputField.text != "") minutesToSkip = Convert.ToInt32(_inputField.text);
        else minutesToSkip = 0;


        hourAlarm = Convert.ToInt32(System.DateTime.Now.AddMinutes(minutesToSkip).ToString("HH"));
        minutesAlarm = Convert.ToInt32(System.DateTime.Now.AddMinutes(minutesToSkip).ToString("mm"));
        Debug.Log("H: " + hourAlarm);
        Debug.Log("M: " + minutesAlarm);

        //Request sending notification
        SendNotification(minutesToSkip);

        //Earase input field text
        _inputField.text = "";

        //Set alarm
        var intentAJO = new AndroidJavaObject("android.content.Intent", ACTION_SET_ALARM);
        intentAJO
            .Call<AndroidJavaObject>("putExtra", EXTRA_HOUR, hourAlarm)
            .Call<AndroidJavaObject>("putExtra", EXTRA_MINUTES, minutesAlarm);

        GetUnityActivity().Call("startActivity", intentAJO);
    }


    public void SendNotification(int minutesToSkip)
    {
        var notification = new AndroidNotification();
        notification.Title = "Uwaga!";
        notification.Text = "Zaraz nadejdzie pora na pójœcie do kuchni!";
        notification.FireTime = System.DateTime.Now.AddMinutes(minutesToSkip - 1);
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    //Something for AndroidJavaObject
    AndroidJavaObject GetUnityActivity()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
}
