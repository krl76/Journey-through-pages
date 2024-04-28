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
    public TextMeshProUGUI Timer;
    [SerializeField] public Fading fade;

    private void Start()
    {
        Reset();
        StartTime();
    }
    private void Update()
    {
        if (isLost)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void Reset()
    {
        seconds = 3;
        minutes = 0;

        Timer.text = "06:59";
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