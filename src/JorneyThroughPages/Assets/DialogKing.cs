using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogKing : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;
    
    [Header("King Dialogs")]
    [SerializeField] private string[] king1;
    [SerializeField] private string[] king2;
    
    [Header("Honor Dialogs")]
    [SerializeField] private string[] honor1;
    [SerializeField] private string[] honor2;
    
    [Header("Drunk Dialogs")]
    [SerializeField] private string[] drunk1;
    [SerializeField] private string[] drunk2;
    
    [Header("Light Dialogs")]
    [SerializeField] private string[] light1;
    [SerializeField] private string[] light2;
    
    [Header("Deal Dialogs")]
    [SerializeField] private string[] deal1;
    [SerializeField] private string[] deal2;
    
    [Header("Geo Dialogs")]
    [SerializeField] private string[] geo1;
    [SerializeField] private string[] geo2;

    
    private int index;
    
    private PlayerAction playerAction;
    private string[] lineNow;

    private void Awake()
    {
        playerAction = new PlayerAction();

        playerAction.Dialogs.ScrollDialog.started += ctx => ScrollDia();
    }

    private void OnEnable()
    {
        playerAction.Enable();
    }

    private void OnDisable()
    {
        playerAction.Disable();
    }

    private void ScrollDia()
    {
        if(textComponent.text == lineNow[index])
            NextLine(lineNow);
        else
        {
            StopAllCoroutines();
            textComponent.text = lineNow[index];
        }
    }

    /*void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }*/

    public void StartDialog(string name, int iter)
    {
        switch (name)
        {
            case "King":
                if (iter == 1)
                {
                    StartCoroutine(TypeLine(king2));
                }
                if (iter == 0)
                {
                    StartCoroutine(TypeLine(king1));
                }
                break;
            case "Honor":
                if (iter == 1)
                {
                    StartCoroutine(TypeLine(honor2));
                }
                if (iter == 0)
                {
                    StartCoroutine(TypeLine(honor1));
                }
                break;
            case "Drunk":
                if (iter == 1)
                {
                    StartCoroutine(TypeLine(drunk2));
                }
                if (iter == 0)
                {
                    StartCoroutine(TypeLine(drunk1));
                }
                break;
            case "Light":
                if (iter == 1)
                {
                    StartCoroutine(TypeLine(light2));
                }
                if (iter == 0)
                {
                    StartCoroutine(TypeLine(light1));
                }
                break;
            case "Deal":
                if (iter == 1)
                {
                    StartCoroutine(TypeLine(deal2));
                }
                if (iter == 0)
                {
                    StartCoroutine(TypeLine(deal1));
                }
                break;
            case "Geo":
                if (iter == 1)
                {
                    StartCoroutine(TypeLine(geo2));
                }
                if (iter == 0)
                {
                    StartCoroutine(TypeLine(geo1));
                }
                break;
        }
        index = 0;
    }

    IEnumerator TypeLine(string[] line)
    {
        lineNow = line;
        foreach(char c in line[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine(string[] line)
    {
        if (index < line.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(king1));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}