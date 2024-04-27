using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    //[SerializedDictionary("NPC", "NPCObject")] 
    //[SerializeField] private SerializedDictionary<Npc, GameObject> _objectsByNpc;
    
    [Header("Dialog")]
    [SerializeField] private GameObject _dialogBox;
    
    [Header("Object")]
    [SerializeField] private GameObject _questObject;

    [Header("Interact")] 
    [SerializeField] private GameObject _questChecker;
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _textInteract;
    [SerializeField] private Npc _npc;

    private InQuestCheck questCheck;
    private InteractActive interactActive;
    private PlayerAction playerAction;
    //private DialogSystem dialogSystem;
    private InteractWithObjects interactWithObj;
    private bool interactOnTrigger;
    private int king, honor, drunk, light, deal, geo = 0;
    
    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.UI.Interact.started += ctx => ActiveDialog();

        questCheck = _questChecker.GetComponent<InQuestCheck>();
        interactWithObj = _questObject.GetComponent<InteractWithObjects>();
        interactActive = GetComponent<InteractActive>();
        //dialogSystem = _dialogBox.GetComponent<DialogSystem>();
        //interactOnTrigger = interactActive.interactOnTrigger;
    }

    private void OnEnable()
    {
        playerAction.Enable();
    }

    private void OnDisable()
    {
        playerAction.Disable();
    }

    private void Update()
    {
        interactOnTrigger = interactActive.interactOnTrigger;
        _interactCanvas.SetActive(interactOnTrigger);
    }

    private void ActiveDialog()
    {
        if (gameObject.tag == "NPC" && interactOnTrigger)
        {
            switch (_npc.ToString())
            {
                case "King":
                    if (king == 1 && interactWithObj.itemToQuest)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), king);
                        PlayerPrefs.SetString("Quest", _npc.ToString());
                        king += 1;
                        break;
                    }
                    else if (questCheck.StatusQuest() && king == 1)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), king);
                        _textInteract.SetActive(true);
                        break;
                    }
                    if (king == 0 && !questCheck.StatusQuest())
                    {
                        _textInteract.SetActive(false);
                        //dialogSystem.StartDialog(_npc.ToString(), king);
                        _textInteract.SetActive(true);
                        questCheck._inQuest = true;
                        interactWithObj.ActiveObject();
                        king += 1;
                        break;
                    }
                    _textInteract.SetActive(false);
                    break;
                case "Honor":
                    if (honor == 1 && interactWithObj.itemToQuest)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), honor);
                        PlayerPrefs.SetString("Quest", _npc.ToString());
                        honor += 1;
                        break;
                    }
                    else if (questCheck.StatusQuest() && honor == 1)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), honor);
                        _textInteract.SetActive(true);
                        break;
                    }
                    if (honor == 0 && !questCheck.StatusQuest())
                    {
                        _textInteract.SetActive(false);
                        //dialogSystem.StartDialog(_npc.ToString(), honor);
                        _textInteract.SetActive(true);
                        questCheck._inQuest = true;
                        interactWithObj.ActiveObject();
                        honor += 1;
                        break;
                    }
                    _textInteract.SetActive(false);
                    break;
                case "Drunk":
                    if (drunk == 1 && interactWithObj.itemToQuest)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), drunk);
                        PlayerPrefs.SetString("Quest", _npc.ToString());
                        drunk += 1;
                        break;
                    }
                    else if (questCheck.StatusQuest() && drunk == 1)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), drunk);
                        _textInteract.SetActive(true);
                        break;
                    }
                    if (drunk == 0 && !questCheck.StatusQuest())
                    {
                        _textInteract.SetActive(false);
                        //dialogSystem.StartDialog(_npc.ToString(), drunk);
                        _textInteract.SetActive(true);
                        questCheck._inQuest = true;
                        interactWithObj.ActiveObject();
                        drunk += 1;
                        break;
                    }
                    _textInteract.SetActive(false);
                    break;
                case "Light":
                    if (light == 1 && interactWithObj.itemToQuest)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), light);
                        PlayerPrefs.SetString("Quest", _npc.ToString());
                        light += 1;
                        break;
                    }
                    else if (questCheck.StatusQuest() && light == 1)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), light);
                        _textInteract.SetActive(true);
                        break;
                    }
                    if (light == 0 && !questCheck.StatusQuest())
                    {
                        _textInteract.SetActive(false);
                        //dialogSystem.StartDialog(_npc.ToString(), light);
                        _textInteract.SetActive(true);
                        questCheck._inQuest = true;
                        interactWithObj.ActiveObject();
                        light += 1;
                        break;
                    }
                    _textInteract.SetActive(false);
                    break;
                case "Deal":
                    if (deal == 1 && interactWithObj.itemToQuest)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), deal);
                        PlayerPrefs.SetString("Quest", _npc.ToString());
                        deal += 1;
                        break;
                    }
                    else if (questCheck.StatusQuest() && deal == 1)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), deal);
                        _textInteract.SetActive(true);
                        break;
                    }
                    if (deal == 0 && !questCheck.StatusQuest())
                    {
                        _textInteract.SetActive(false);
                        //dialogSystem.StartDialog(_npc.ToString(), deal);
                        _textInteract.SetActive(true);
                        questCheck._inQuest = true;
                        interactWithObj.ActiveObject();
                        deal += 1;
                        break;
                    }
                    _textInteract.SetActive(false);
                    break;
                case "Geo":
                    if (geo == 1 && interactWithObj.itemToQuest)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), geo);
                        PlayerPrefs.SetString("Quest", _npc.ToString());
                        geo += 1;
                        break;
                    }
                    else if (questCheck.StatusQuest() && geo == 1)
                    {
                        //dialogSystem.StartDialog(_npc.ToString(), geo);
                        _textInteract.SetActive(true);
                        break;
                    }
                    if (geo == 0 && !questCheck.StatusQuest())
                    {
                        _textInteract.SetActive(false);
                        //dialogSystem.StartDialog(_npc.ToString(), geo);
                        _textInteract.SetActive(true);
                        questCheck._inQuest = true;
                        interactWithObj.ActiveObject();
                        geo += 1;
                        break;
                    }
                    _textInteract.SetActive(false);
                    break;
            }
        }
    }
}

public enum Npc
{
    King,
    Honor,
    Drunk,
    Light,
    Deal,
    Geo
}