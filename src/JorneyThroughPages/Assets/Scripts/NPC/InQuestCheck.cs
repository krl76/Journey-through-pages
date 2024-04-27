using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InQuestCheck : MonoBehaviour
{
    public bool _inQuest;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("Quest");
        _inQuest = false;
    }

    public bool StatusQuest()
    {
        return _inQuest;
    }
}
