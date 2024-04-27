using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampLight : MonoBehaviour
{
    public Light lightLamp;
    float timer;
    float interval;
    public float maxWait = 10;
    public float maxFlicker = 8;
    void Start()
    {
        if (lightLamp)
            lightLamp.enabled = true;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            ToggleLight();
        }
    }
    void ToggleLight()
    {
        lightLamp.enabled = !lightLamp.enabled;
        if (lightLamp.enabled)
        {
            interval = Random.Range(5, maxWait);
        }
        else
        {
            interval = Random.Range(5, maxFlicker);
        }

        timer = 0;
    }
}
