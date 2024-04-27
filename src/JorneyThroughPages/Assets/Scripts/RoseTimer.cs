using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseTimer : MonoBehaviour
{
    public float timeRemaining = 420;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}
