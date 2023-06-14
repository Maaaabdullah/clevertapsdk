using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastController : MonoBehaviour
{
    static bool DebugLogOutput = true;
    public static void ShowMessage(string Message)
    {
        //Try to call a toast
        try
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass toastCell = new AndroidJavaClass("android.widget.Toast"); //Initialize the Toast Cell

                AndroidJavaObject currentActivityConetxt = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"); //Get Current Context

                AndroidJavaObject toastMessage = toastCell.CallStatic<AndroidJavaObject>("makeText", currentActivityConetxt, Message, 1); // Form the Toast Message

                toastMessage.Call("show"); //Execute and Show Toast Message

                if (DebugLogOutput)
                {
                    Debug.Log(Message); // For Debugging Purposes
                }
            }
            else
            {
                //FUTURE: Implement for IOS
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error has occured, please check details: " + e.Message);
        }

    }
}
       
    
