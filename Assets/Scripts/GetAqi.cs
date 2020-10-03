//GetAQI Script interacts with the API to get the desired information
//please add your own API key from weatherbit.io
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class GetAqi : MonoBehaviour
{
    private readonly float timer;
    public float minutesBetweenUpdate;
    public static double userLatitude;
    public static double userLongitude;
    public static string cityName;
    public static double currentAqi;
    public static double o3Dat;
    public static double so2Dat;
    public static double no2Dat;
    public static double coDat;
    public static double pm10Dat;
    public static double pm25Dat;

    private readonly string baseWeatherbitURL = "https://api.weatherbit.io/v2.0/current/airquality?";
    private readonly string key = "insert_API_key";    //The user is requested to add a personal Weatherbit.io API from their website.

    Coroutine current;
    
    //
    void Update()
    {

        if (current == null)
        {
            current = StartCoroutine(GetAqiInfo());
        }
    }

    int requests = 0;
    private IEnumerator GetAqiInfo()
    {
        if (requests >= 500)
        {
            yield return requests;
        }

        userLatitude = GetGPS.latitude;
        userLongitude = GetGPS.longitude;
        string weatherbitURL = baseWeatherbitURL + "lat=" + userLatitude + "&lon=" + userLongitude + "&key=" + key;
        UnityWebRequest aqiInfoRequest = UnityWebRequest.Get(weatherbitURL);

        yield return aqiInfoRequest.SendWebRequest();

        //error
        if (aqiInfoRequest.isNetworkError || aqiInfoRequest.isHttpError)
        {
            Debug.LogError(aqiInfoRequest.error);
            yield break;
        }

        JSONNode aqiInfo = JSON.Parse(aqiInfoRequest.downloadHandler.text);

        cityName = aqiInfo["city_name"];
        currentAqi = aqiInfo["data"][0]["aqi"].AsInt;
        o3Dat = aqiInfo["data"][0]["o3"].AsDouble;
        so2Dat = aqiInfo["data"][0]["so2"].AsDouble;
        no2Dat = aqiInfo["data"][0]["no2"].AsDouble;
        coDat = aqiInfo["data"][0]["co"].AsDouble;
        pm10Dat = aqiInfo["data"][0]["pm10"].AsDouble;
        pm25Dat = aqiInfo["data"][0]["pm25"].AsDouble;
        Debug.Log($"New data available: ${currentAqi}");

        requests++;

        yield return new WaitForSeconds(5f);

        current = null;
    }
}
