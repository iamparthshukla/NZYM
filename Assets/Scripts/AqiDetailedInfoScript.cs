//this script utilizes textMeshPro library of Unity 3d to print the API information stored from getAQI script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AqiDetailedInfoScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "AQI : " + GetAqi.currentAqi.ToString() + "\n"
            + "O3 : " + GetAqi.o3Dat.ToString() + "\n"
            + "SO2 : " + GetAqi.so2Dat.ToString() + "\n"
            + "NO2 : " + GetAqi.no2Dat.ToString() + "\n"
            + "CO : " + GetAqi.coDat.ToString() + "\n"
            + "PM10 : " + GetAqi.pm10Dat.ToString() + "\n"
            + "PM2.5 : " + GetAqi.pm25Dat.ToString() + "\n";
    }
}
