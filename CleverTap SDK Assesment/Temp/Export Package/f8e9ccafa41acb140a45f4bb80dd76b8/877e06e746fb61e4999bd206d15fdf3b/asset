using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour
{
    // API endpoint parts
    private const string weatherBaseUrl = "https://api.open-meteo.com/v1/forecast?";
    private const string latitudeParam = "latitude=";
    private const string longitudeParam = "&longitude=";
    private const string timezoneParam = "&timezone=IST";
    private const string dailyParam = "&daily=temperature_2m_max";

    // Public Fields
    public bool ExampleTextOutput = true;
    public Text ExampleTextObj;
    public bool ResponsePositive = false;
    public float Latitude = 0f;
    public float Longitude = 0f;

    // Public property for accessing weatherData
    public WeatherData weatherData { get; private set; }

    // Defined Classes
    [Serializable]
    public class WeatherData
    {
        public DailyData daily;
    }

    [Serializable]
    public class DailyData
    {
        public string[] time;
        public float[] temperature_2m_max;
    }

    void Start()
    {
        InitializeData();
        GetWeather();
    }

    private void InitializeData()
    {
        ShowExampleHelpText("Loading...");
        Input.location.Start();
        UpdateUserLatAndLong();
    }

    public void GetWeather()
    {
        if (Latitude != 0 && Longitude != 0)
        {
            StartCoroutine(GetWeatherData());
        }
        else
        {
            UpdateUserLatAndLong();
        }
    }

    public IEnumerator GetWeatherData()
    {
        ResponsePositive = false;

        if (Latitude != 0 && Longitude != 0)
        {
            string requestUrl = weatherBaseUrl + latitudeParam + Latitude + longitudeParam + Longitude + timezoneParam + dailyParam;

            using (UnityWebRequest webRequest = UnityWebRequest.Get(requestUrl))
            {
                ShowExampleHelpText("Loading...");
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to fetch weather data: " + webRequest.error);
                    yield break;
                }

                try
                {
                    string jsonResult = webRequest.downloadHandler.text;
                    weatherData = JsonUtility.FromJson<WeatherData>(jsonResult);

                    // Access the current temperature from the weatherData object
                    float currentTemperature = weatherData.daily.temperature_2m_max[0];
                    string predefinedMessage = "Current Temperature: " + currentTemperature + "°C";
                    ToastController.ShowMessage(predefinedMessage);
                    ShowExampleHelpText(predefinedMessage);
                    ResponsePositive = true;
                }
                catch (Exception e)
                {
                    string message = "Failed to parse weather data: " + e.Message;
                    Debug.LogError(message);
                    ShowExampleHelpText(message);
                }
            }
        }
    }

    public void UpdateUserLatAndLong()
    {
        Input.location.Start();
        Latitude = 0f;
        Longitude = 0f;

        if (CheckForPermission())
        {
            ShowExampleHelpText("Requesting...");
            Latitude = Input.location.lastData.latitude; // Retrieve actual latitude
            Longitude = Input.location.lastData.longitude; // Retrieve actual longitude
            StartCoroutine(GetWeatherData());
        }
        else
        {
            ShowExampleHelpText("Please check location permissions and try again!");
        }
    }

    public bool CheckForPermission()
    {
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.CoarseLocation))
        {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.CoarseLocation);
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ShowExampleHelpText(string message)
    {
        if (ExampleTextOutput && ExampleTextObj != null)
        {
            ExampleTextObj.text = message;
        }
    }

    public void GetDetails()
    {
        string details = "";

        if (weatherData != null && weatherData.daily != null)
        {
            DailyData dailyData = weatherData.daily;

            // Access the time and temperature values
            if (dailyData.time.Length == dailyData.temperature_2m_max.Length)
            {
                for (int i = 0; i < dailyData.time.Length; i++)
                {
                    string date = dailyData.time[i];
                    float temperature = dailyData.temperature_2m_max[i];
                    details += "Date: " + date + ", Temperature: " + temperature + "°C\n";
                }
            }
        }
        else
        {
            details = "No weather data available";
        }

        ShowExampleHelpText(details);
    }
}
