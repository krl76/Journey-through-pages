using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractActive : MonoBehaviour
{
    public bool interactOnTrigger;

    private void Awake()
    {
        interactOnTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            interactOnTrigger = true;
        Debug.Log("enter");
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            interactOnTrigger = false;
        Debug.Log("exit");
    }
}
