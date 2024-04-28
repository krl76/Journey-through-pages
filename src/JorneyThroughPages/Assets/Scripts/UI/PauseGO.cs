using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGO : MonoBehaviour
{
    [SerializeField] private GameObject _pauseGO;

    private PlayerAction playerAction;
    private bool inPause = false;

    private void Awake()
    {
        playerAction = new PlayerAction();

        playerAction.UI.Pause.started += ctx => Pause();
    }

    private void OnEnable()
    {
        playerAction.Enable();
    }

    private void OnDisable()
    {
        playerAction.Disable();
    }

    private void Pause()
    {
        if (!inPause)
        {
            Cursor.lockState = CursorLockMode.None;
            inPause = true;
            _pauseGO.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            inPause = false;
            _pauseGO.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ToGameBtn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inPause = false;
        _pauseGO.SetActive(false);
        Time.timeScale = 1f;
    }
}
