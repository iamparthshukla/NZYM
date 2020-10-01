//this script uses TextMeshPro library of Unity3D to render the required AQI information on the home screen of the application
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AqiTextScript : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "AQI : " + GetAqi.currentAqi.ToString();
    }
}
