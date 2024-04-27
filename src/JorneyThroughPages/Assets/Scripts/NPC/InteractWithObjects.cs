using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private NpcObjects _npcObjects;
    
    private InteractActive interactActive;
    private PlayerAction playerAction;
    private bool interactOnTrigger;

    public bool itemToQuest;
    
    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.UI.Interact.started += ctx => TakeObject();
        interactActive = GetComponent<InteractActive>();
        
        interactOnTrigger = interactActive.interactOnTrigger;
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

    public void ActiveObject()
    {
        gameObject.SetActive(true);
    }

    private void TakeObject()
    {
        if (gameObject.tag == "Interact" && interactOnTrigger)
        {
            switch (_npcObjects.ToString())
            {
                case "King":
                    itemToQuest = true;
                    gameObject.SetActive(false);
                    break;
                case "Honor":
                    itemToQuest = true;
                    gameObject.SetActive(false);
                    break;
                case "Drunk":
                    itemToQuest = true;
                    gameObject.SetActive(false);
                    break;
                case "Light":
                    itemToQuest = true;
                    gameObject.SetActive(false);
                    break;
                case "Deal":
                    itemToQuest = true;
                    gameObject.SetActive(false);
                    break;
                case "Geo":
                    itemToQuest = true;
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
    
}

public enum NpcObjects
{
    King,
    Honor,
    Drunk,
    Light,
    Deal,
    Geo
}
