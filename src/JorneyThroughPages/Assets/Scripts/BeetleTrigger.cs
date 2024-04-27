using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;


public class BeetleTrigger : MonoBehaviour
{
    public bool isTimer;
    public bool isReady;
    public static bool isSpawning;
    public bool isPlayerOnPlanet;
    private float timeToSpawn;
    public event Action beetleEvent;
    void Update()
    {
        if (isTimer)
        {
            timeToSpawn -= Time.deltaTime;
        }
        if (timeToSpawn <= 0)
        {
            isTimer = false;
            isReady = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Prince")
        {
            isTimer = true;
            isPlayerOnPlanet = false;
            timeToSpawn = UnityEngine.Random.Range(3f, 5f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Prince") && isReady)
        {
            isSpawning = true;
            isReady = false;
            isPlayerOnPlanet = true;
            beetleEvent();
        }
    }
}
