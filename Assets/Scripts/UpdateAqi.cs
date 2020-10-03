//This debugging file helps users to understand that GetAQI.cs and GetGPS.cs are working correctly.
//This file utilises TextMeshPro binary from Unity 3d.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateAqi : MonoBehaviour
{
    private TextMeshProUGUI textMeshAqi;
    private TextMeshProUGUI textMeshCity;
    public Text airquality;
    //public Text coordinates;

    private void Start()
    {
        textMeshAqi = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        airquality.text = "Lat: " + GetGPS.latitude + "    Lon: " + GetGPS.longitude + "    City: " + GetAqi.cityName + "    Aqi: " + GetAqi.currentAqi.ToString();
        //coordinates.text = "Lat: " + GetGPS.latitude.ToString() + "   Long:" + GetGPS.longitude.ToString();
    }
}
