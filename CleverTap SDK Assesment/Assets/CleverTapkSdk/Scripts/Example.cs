using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Example : MonoBehaviour
{

    private WeatherController weatherController;

    public InputField inputField;

    private void Start()
    {
        weatherController = GetComponent<WeatherController>();
    }

    public void CallGetWeather()
    {
        if(weatherController != null)
        {
            weatherController.GetWeather();
        }
      
    }

    public void CallToastMessage()
    {
        if(inputField != null)
        {
            ToastController.ShowMessage(inputField.text);
        }
    }

    public void CallDetails()
    {
        if (inputField != null)
        {
            weatherController.GetDetails();
        }
    }
}
