using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_UI : MonoBehaviour
{
    Light2D light2D;
    [SerializeField] float minDelayTime;
    [SerializeField] float maxdDelayTime;

    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;

    float count = 0;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        count += Time.deltaTime;
        if(count >= Random.Range(minDelayTime, maxdDelayTime))
        {
            light2D.intensity = Random.Range(minIntensity, maxIntensity);
            count = 0;
        }
    }
}
