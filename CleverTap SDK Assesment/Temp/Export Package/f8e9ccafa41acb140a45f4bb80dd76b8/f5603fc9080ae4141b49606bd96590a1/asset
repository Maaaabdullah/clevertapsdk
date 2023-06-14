using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTest
{
  

    [UnityTest]
    public IEnumerator GetWeatherData_SuccessfulRequest()  //Test to check if valid response can occur
    {
        // Create a new GameObject and add the WeatherController component
        GameObject gameObject = new GameObject();
        WeatherController weatherController = gameObject.AddComponent<WeatherController>();

        // Set mock values for latitude and longitude
        weatherController.Latitude = 40.0f;
        weatherController.Longitude = -80.0f;
        weatherController.ResponsePositive = false;

        // Call the GetWeatherData method
        IEnumerator enumerator = weatherController.GetWeatherData();
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }

        // Access the current temperature from the WeatherController instance
        WeatherController.WeatherData weatherData = weatherController.weatherData;

        // Access the temperature value
        float currentTemperature = weatherData.daily.temperature_2m_max[0];

        // Assert that the temperature is valid & response was positive
        Assert.IsTrue(weatherController.ResponsePositive);
        Assert.LessOrEqual(currentTemperature, 35.0f);
        Assert.GreaterOrEqual(currentTemperature, -35.0f);

        // Clean up the created GameObject
        Object.Destroy(gameObject);
    }


    [UnityTest]
    public IEnumerator GetWeatherData_NegativeRequest()  //Test to check if valid negative can occur
    {
        // Create a new GameObject and add the WeatherController component
        GameObject gameObject = new GameObject();
        WeatherController weatherController = gameObject.AddComponent<WeatherController>();

        // Set mock values for latitude and longitude
        weatherController.Latitude = 0f;
        weatherController.Longitude = 0f;

        // Call the GetWeatherData method
        IEnumerator enumerator = weatherController.GetWeatherData();
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }

        // Access the current temperature from the WeatherController instance
        WeatherController.WeatherData weatherData = weatherController.weatherData;

        // Assert that the response was negative
        Assert.IsFalse(weatherController.ResponsePositive);

        // Clean up the created GameObject
        Object.Destroy(gameObject);
    }

}
