using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomboscope : MonoBehaviour
{
    // Start is called before the first frame update
    private Light myLight;
    private float timer=0.0f;

    void Start()
    {
        myLight = GetComponent<Light>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3.0f)
        {        
            myLight.intensity = Time.deltaTime;
            if (timer > 3.5f)
            {
                myLight.intensity = 15.0f;
                timer = 0.0f;
            }
        }
    }
}
