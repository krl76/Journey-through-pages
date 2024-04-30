using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoseTimer : MonoBehaviour
{
    private int seconds;
    private int minutes;
    public int realTime;
    public bool isLost = false;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject _canvasMessage;
    public TextMeshProUGUI Timer;
    [SerializeField] public Fading fade;

    private void Start()
    {
        Time.timeScale = 1.0f;
        Reset();
        StartTime();
    }
    private void Update()
    {
        if (isLost)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            canvas.SetActive(true);
            _canvasMessage.SetActive(false);
        }
    }
    public void Reset()
    {
        seconds = 59;
        minutes = 9;

        Timer.text = "09:59";
    }

    public void StartTime()
    {
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            if (seconds == 0)
            {
                minutes -= 1;
                seconds = 59;
            }
            realTime = seconds + minutes * 60;

            if (realTime <= 0)
            {
                isLost = true;
            }

            if (seconds > 9)
            {
                Timer.text = "0" + minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                Timer.text = "0" + minutes.ToString() + ":" + "0" + seconds.ToString();
            }
        }
    }
}