using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private Npc _npc;

    private InteractActive interactActive;
    private PlayerAction playerAction;
    private bool interactOnTrigger;
    private int king, honor, drunk, light, deal, geo = 0;
    public bool inQuest;
    
    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.UI.Interact.started += ctx => ActiveDialog();

        interactActive = GetComponent<InteractActive>();
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
                    if (king == 1)
                    {
                        king += 1;
                        break;
                    }
                    if (king == 0 && !inQuest)
                    {
                        inQuest = true;
                        king += 1;
                        break;
                    }
                    break;
                case "Honor":
                    break;
                case "Drunk":
                    break;
                case "Light":
                    break;
                case "Deal":
                    break;
                case "Geo":
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