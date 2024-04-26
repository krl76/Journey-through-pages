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

    private void TakeObject()
    {
        if (gameObject.tag == "Interact" && interactOnTrigger)
        {
            switch (_npcObjects.ToString())
            {
                case "King":
                    gameObject.SetActive(false);
                    break;
                case "Honor":
                    gameObject.SetActive(false);
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

public enum NpcObjects
{
    King,
    Honor,
    Drunk,
    Light,
    Deal,
    Geo
}
