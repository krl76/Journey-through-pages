using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OstTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerRose;
    [SerializeField] private TextMeshProUGUI _textWin;

    private void Awake()
    {
        _textWin.text = "У тебя оставалось: " + _timerRose.text;
    }


}
