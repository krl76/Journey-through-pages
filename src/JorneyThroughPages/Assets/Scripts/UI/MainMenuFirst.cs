using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFirst : MonoBehaviour
{
    [Header("Canvas")] 
    [SerializeField] private GameObject _controlsCanvas;
    [SerializeField] private GameObject _mainMenu;

    private void Start()
    {
        if (FirstPlayLoad())
        {
            _controlsCanvas.SetActive(true);
        }
        else
        {
            _mainMenu.SetActive(true);
        }
    }
    
    public void FirstPlaySave()
    {
        PlayerPrefs.SetInt("FirstPlaySettings", 1);
    }
    
    public bool FirstPlayLoad()
    {
        if (!PlayerPrefs.HasKey("FirstPlaySettings"))
        {
            return true;
        }

        return false;
    }
}
