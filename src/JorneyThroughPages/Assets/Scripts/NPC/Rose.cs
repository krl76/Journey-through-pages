using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    
    private InteractActive interactActive;
    private PlayerAction playerAction;
    private InQuestCheck questCheck;
    private bool interactOnTrigger;

    private void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.UI.Interact.started += ctx => RoseQuest();

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
                        //действия с розой
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest"); 
                        //Debug.Log("Quest Короля");
                        break;
                    case "Honor":
                        //действия с розой
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Drunk":
                        //действия с розой
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Light":
                        //действия с розой
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Deal":
                        //действия с розой
                        questCheck._inQuest = false;
                        PlayerPrefs.DeleteKey("Quest");
                        break;
                    case "Geo":
                        //действия с розой
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
