//this cript utilises textMeshPro library of Unity3D to interact with the applicaiton and publish user location using weather.io API

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityTextScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshCity;

    // Start is called before the first frame update
    void Start()
    {
        textMeshCity = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        textMeshCity.text = GetAqi.cityName + ", India";
    }
}
