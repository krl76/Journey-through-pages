using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    [Header("For Rose")] 
    [SerializeField] private GameObject _glass;
    [SerializeField] private GameObject _light;
    [SerializeField] private Material _modelRose;
    
    [Header("Canvases")]
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private GameObject _tasks;

    [Header("Text")]
    [SerializeField] private GameObject _textInteraction;
    
    private InteractActive interactActive;
    private PlayerAction playerAction;
    private InQuestCheck questCheck;
    private DialogSystem dialogSystem;
    private Tasks task;
    private bool interactOnTrigger;
    private bool firstTrigger;
    private bool inDialog;
    private AudioSource audio;

    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.UI.Interact.started += ctx => RoseQuest();
        
        _modelRose.SetColor("_BaseColor", Color.white);
        firstTrigger = true;
        
        task = _tasks.GetComponent<Tasks>();
        audio = GetComponent<AudioSource>();
        dialogSystem = _dialogBox.GetComponent<DialogSystem>();
        questCheck = FindObjectOfType<InQuestCheck>();
        interactActive = GetComponent<InteractActive>();
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
        if (interactOnTrigger && firstTrigger)
        {
            task.ActiveTask();
            audio.Play();
            firstTrigger = false;
        }
        if(dialogSystem.inDialog)
        {
            _textInteraction.SetActive(false);
        }
        else
        {
            _textInteraction.SetActive(true);
        }
        _interactCanvas.SetActive(interactOnTrigger);
    }

    private void RoseQuest()
    {
        if (gameObject.tag == "Rose" && interactOnTrigger)
        {
            if (PlayerPrefs.HasKey("Quest"))
            {
                string nameOfQuest = PlayerPrefs.GetString("Quest");
                switch (nameOfQuest)
                {
                    case "King":
                        _modelRose.SetColor("_BaseColor", new Color(1f, 0.59f, 0.59f));
                        _dialogBox.SetActive(true);
                        dialogSystem.StartDialog("Rose", 0);
                        task.ChangeTask(nameOfQuest, 3);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest"); 
                        break;
                    case "Honor":
                        _glass.SetActive(true);
                        _dialogBox.SetActive(true);
                        dialogSystem.StartDialog("Rose", 1);
                        task.ChangeTask(nameOfQuest, 3);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Drunk":
                        _dialogBox.SetActive(true);
                        dialogSystem.StartDialog("Rose", 2);
                        task.ChangeTask(nameOfQuest, 3);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Light":
                        _dialogBox.SetActive(true);
                        _light.SetActive(true);
                        dialogSystem.StartDialog("Rose", 3);
                        task.ChangeTask(nameOfQuest, 3);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Deal":
                        _dialogBox.SetActive(true);
                        dialogSystem.StartDialog("Rose", 4);
                        task.ChangeTask(nameOfQuest, 3);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Geo":
                        _dialogBox.SetActive(true);
                        dialogSystem.StartDialog("Rose", 5);
                        task.ChangeTask(nameOfQuest, 3);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                }
            }
            else
            {
                if (!firstTrigger)
                {
                    _dialogBox.SetActive(true);
                    dialogSystem.StartDialog("UniversalRose", 0);
                }
            }
        }
    }
}
