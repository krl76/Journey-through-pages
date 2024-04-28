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
    
    private InteractActive interactActive;
    private PlayerAction playerAction;
    private InQuestCheck questCheck;
    private bool interactOnTrigger;

    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.UI.Interact.started += ctx => RoseQuest();
        
        _modelRose.SetColor("_BaseColor", Color.white);
        
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
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest"); 
                        break;
                    case "Honor":
                        _glass.SetActive(true);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Drunk":
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Light":
                        _light.SetActive(true);
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Deal":
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Geo":
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                }
            }
            else
            {
                //мб диалоги сюда(мол, вы еще ничего не выполнили)
                Debug.Log("Вы ничего не собрали еще");
            }
        }
    }
}
