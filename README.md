# clevertapsdk

Weather App
This project is a weather app built with Unity that displays the current temperature based on the user's location using the Open-Meteo API. It also includes a ToastController Unity package that can be used to display toast messages on Android devices.
1. How to Use
1.1. Clone the repository to your local machine
1.2. Open the project in Unity.
1.3. To use the ToastController package:
   - Attach the `ToastController` script to a game object in your scene.
   - Call the `ToastController.ShowMessage` method and pass the desired message as a parameter to display a toast message on Android devices.
1.4. To use the Weather App:
   - Attach the `WeatherController` script to a game object in your scene.
   -Request GetWeather() to automatically retrieve the latitude and longitude values from the user (if permission is granted) in order to fetch acurate weather data for the corresponding location.
   - Run the scene in the Unity editor or build the project for Android or iOS devices to see the weather details.
2.Architecture
The Weather App follows a simple architecture:
- The `WeatherController` script is a Unity package responsible for fetching weather data from the Open-Meteo API and displaying it in the scene.
- The `ToastController` script is a Unity package that provides a convenient way to display toast messages on Android devices.
3. Testing
The project includes unit tests for the `GetWeatherData` method using the NUnit test framework. There are overall two tests for positive/negative response of the URL request for weather information. Controller/used scripts are duplicated in the TestPlayMode folder and re-ajudsted to have public variables in order to parse and check returned results.
To run the tests:
1. Open the project in Unity.
2. Open the Test Runner window (Window > General > Test Runner).
3. Click on the "PlayMode" tab in the Test Runner window.
4. Click the "Run All" button to run all the unit tests in play mode.
Please note that the tests require an internet connection to fetch weather data and may take some time to complete.

