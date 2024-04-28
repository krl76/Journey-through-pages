using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoseTimer : MonoBehaviour
{
    private int seconds;
    private int minutes;
    public static int realTime;

    public TextMeshProUGUI Timer;

    private void Start()
    {
        Reset();
        StartTime();
    }

    public void Reset()
    {
        seconds = 59;
        minutes = 6;

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
            realTime = seconds + minutes * 60;

            if (seconds == 0)
            {
                minutes -= 1;
                seconds = 59;
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