using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light light;

    void Start()
    {

        light = GetComponent<Light>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            light.enabled = !light.enabled;
        }
    }


}