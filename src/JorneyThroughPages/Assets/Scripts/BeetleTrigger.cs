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
    public bool isTimer = false;
    public bool isTimerOut = false;
    public bool isReady = false;
    public bool isSpawning = false;
    public bool isPlayerOnPlanet = false;
    [SerializeField] private int timeToSpawn = 10000;

    void Update()
    {
        if (timeToSpawn <= 0)
        {
            isTimer = false;
            isReady = true;
        }
    }
    private IEnumerator RunTimer(float time)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            timeToSpawn--;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Prince")
        {
            isTimer = true;
            isPlayerOnPlanet = false;
            timeToSpawn = UnityEngine.Random.Range(3, 5);
            isTimerOut = false;
            RunTimer(timeToSpawn);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Prince") && isReady)
        {
            isSpawning = true;
            isReady = false;
            isPlayerOnPlanet = true;
            isTimer = false;
        }
    }
}
