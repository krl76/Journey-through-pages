using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;
    
    [Header("King Dialogs")]
    [SerializeField] private string[] king1;
    [SerializeField] private string[] king2;
    [SerializeField] private AudioClip[] _king1Audio;
    [SerializeField] private AudioClip[] _king2Audio;
    
    [Header("Honor Dialogs")]
    [SerializeField] private string[] honor1;
    [SerializeField] private string[] honor2;
    [SerializeField] private AudioClip[] _honor1Audio;
    [SerializeField] private AudioClip[] _honor2Audio;
    
    [Header("Drunk Dialogs")]
    [SerializeField] private string[] drunk1;
    [SerializeField] private string[] drunk2;
    [SerializeField] private AudioClip[] _drunk1Audio;
    [SerializeField] private AudioClip[] _drunk2Audio;
    
    [Header("Light Dialogs")]
    [SerializeField] private string[] light1;
    [SerializeField] private string[] light2;
    [SerializeField] private AudioClip[] _light1Audio;
    [SerializeField] private AudioClip[] _light2Audio;
    
    [Header("Deal Dialogs")]
    [SerializeField] private string[] deal1;
    [SerializeField] private string[] deal2;
    [SerializeField] private AudioClip[] _deal1Audio;
    [SerializeField] private AudioClip[] _deal2Audio;
    
    [Header("Geo Dialogs")]
    [SerializeField] private string[] geo1;
    [SerializeField] private string[] geo2;
    [SerializeField] private AudioClip[] _geo1Audio;
    [SerializeField] private AudioClip[] _geo2Audio;

    [Header("Rose")] 
    [SerializeField] private string[] rose1;
    [SerializeField] private string[] rose2;
    [SerializeField] private string[] rose3;
    [SerializeField] private string[] rose4;
    [SerializeField] private string[] rose5;
    [SerializeField] private string[] rose6;
    [SerializeField] private AudioClip[] _rose1Audio;
    [SerializeField] private AudioClip[] _rose2Audio;
    [SerializeField] private AudioClip[] _rose3Audio;
    [SerializeField] private AudioClip[] _rose4Audio;
    [SerializeField] private AudioClip[] _rose5Audio;
    [SerializeField] private AudioClip[] _rose6Audio;
    
    [Header("Universal")] 
    [SerializeField] private string[] _forNpc;
    [SerializeField] private string[] _forRose;
    [SerializeField] private AudioClip[] _forNpcAudio;
    [SerializeField] private AudioClip[] _forRoseAudio;
    
    [Header("Dialog Manager")]
    [SerializeField] private GameObject _dialogManager;
    
    private int index;
    
    private PlayerAction playerAction;
    private string[] lineNow;

    private AudioSource audio;
    private AudioClip[] _audioClipIter;
    private int i;

    public bool inDialog;

    private void Awake()
    {
        playerAction = new PlayerAction();

        playerAction.Dialogs.ScrollDialog.started += ctx => ScrollDia();
        
        textComponent.text = string.Empty;
        
        audio = _dialogManager.GetComponent<AudioSource>();

        i = 0;
    }

    private void OnEnable()
    {
        playerAction.Enable();
        textComponent.text = string.Empty;
        i = 0;
        index = 0;
    }

    private void OnDisable()
    {
        playerAction.Disable();
    }

    private void ScrollDia()
    {
        if (textComponent.text == lineNow[index])
        {
            audio.Stop();
            NextLine(lineNow);
        }
        else
        {
            StopAllCoroutines();
            audio.Stop();
            textComponent.text = lineNow[index];
        }
    }

    public void StartDialog(string name, int iter)
    {
        i = 0;
        inDialog = true;
        switch (name)
        {
            case "King":
                if (iter == 1)
                {
                    _audioClipIter = _king2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(king2));
                }
                if (iter == 0)
                {
                    _audioClipIter = _king1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(king1));
                }
                break;
            case "Honor":
                if (iter == 1)
                {
                    _audioClipIter = _honor2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(honor2));
                }
                if (iter == 0)
                {
                    _audioClipIter = _honor1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(honor1));
                }
                break;
            case "Drunk":
                if (iter == 1)
                {
                    _audioClipIter = _drunk2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(drunk2));
                }
                if (iter == 0)
                {
                    _audioClipIter = _drunk1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(drunk1));
                }
                break;
            case "Light":
                if (iter == 1)
                {
                    _audioClipIter = _light2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(light2));
                }
                if (iter == 0)
                {
                    _audioClipIter = _light1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(light1));
                }
                break;
            case "Deal":
                if (iter == 1)
                {
                    _audioClipIter = _deal2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(deal2));
                }
                if (iter == 0)
                {
                    _audioClipIter = _deal1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(deal1));
                }
                break;
            case "Geo":
                if (iter == 1)
                {
                    _audioClipIter = _geo2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(geo2));
                }
                if (iter == 0)
                {
                    _audioClipIter = _geo1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(geo1));
                }
                break;
            case "UniversalNPC":
                _audioClipIter = _forNpcAudio;
                audio.clip = _audioClipIter[i];
                audio.Play();
                StartCoroutine(TypeLine(_forNpc));
                break;
            case "UniversalRose":
                _audioClipIter = _forRoseAudio;
                audio.clip = _audioClipIter[i];
                audio.Play();
                StartCoroutine(TypeLine(_forRose));
                break;
            case "Rose":
                if (iter == 0)
                {
                    _audioClipIter = _rose1Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(rose1));
                }
                if (iter == 1)
                {
                    _audioClipIter = _rose2Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(rose2));
                }
                if (iter == 2)
                {
                    _audioClipIter = _rose3Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(rose3));
                }
                if (iter == 3)
                {
                    _audioClipIter = _rose4Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(rose4));
                }
                if (iter == 4)
                {
                    _audioClipIter = _rose5Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(rose5));
                }
                if (iter == 5)
                {
                    _audioClipIter = _rose6Audio;
                    audio.clip = _audioClipIter[i];
                    audio.Play();
                    StartCoroutine(TypeLine(rose6));
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
            i++;
            audio.clip = _audioClipIter[i];
            audio.Play();
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(line));
        }
        else
        {
            inDialog = false;
            gameObject.SetActive(false);
        }
    }
}