using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [SerializeField] private GameObject _texts;
    
    [Header("NPC Task Object")]
    [SerializeField] private TextMeshProUGUI _king;
    [SerializeField] private TextMeshProUGUI _honor;
    [SerializeField] private TextMeshProUGUI _drunk;
    [SerializeField] private TextMeshProUGUI _light;
    [SerializeField] private TextMeshProUGUI _deal;
    [SerializeField] private TextMeshProUGUI _geo;

    [Header("NPC Task Text")] 
    [SerializeField] private string[] king;
    [SerializeField] private string[] honor;
    [SerializeField] private string[] drunk;
    [SerializeField] private string[] light;
    [SerializeField] private string[] deal;
    [SerializeField] private string[] geo;
    
    public void ActiveTask()
    {
        _texts.SetActive(true);
    }
    
    public void ChangeTask(string nameNPC, int iter)
    {
        switch (nameNPC)
        {
            case "King":
                if (iter == 0)
                {
                    _king.text = king[0];
                    _king.color = Color.yellow;
                }
                if (iter == 1)
                {
                    _king.text = king[1];
                }

                if (iter == 2)
                {
                    _king.text = king[2];
                }

                if (iter == 3)
                {
                    _king.text = king[3];
                    _king.color = Color.green;
                    _king.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case "Honor":
                if (iter == 0)
                {
                    _honor.text = honor[0];
                    _honor.color = Color.yellow;
                }
                if (iter == 1)
                {
                    _honor.text = honor[1];
                }

                if (iter == 2)
                {
                    _honor.text = honor[2];
                }
                if (iter == 3)
                {
                    _honor.text = honor[3];
                    _honor.color = Color.green;
                    _honor.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case "Drunk":
                if (iter == 0)
                {
                    _drunk.text = drunk[0];
                    _drunk.color = Color.yellow;
                }
                if (iter == 1)
                {
                    _drunk.text = drunk[1];
                }

                if (iter == 2)
                {
                    _drunk.text = drunk[2];
                }
                if (iter == 3)
                {
                    _drunk.text = drunk[3];
                    _drunk.color = Color.green;
                    _drunk.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case "Light":
                if (iter == 0)
                {
                    _light.text = light[0];
                    _light.color = Color.yellow;
                }
                if (iter == 1)
                {
                    _light.text = light[1];
                }

                if (iter == 2)
                {
                    _light.text = light[2];
                }
                if (iter == 3)
                {
                    _light.text = light[3];
                    _light.color = Color.green;
                    _light.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case "Deal":
                if (iter == 0)
                {
                    _deal.text = deal[0];
                    _deal.color = Color.yellow;
                }
                if (iter == 1)
                {
                    _deal.text = deal[1];
                }

                if (iter == 2)
                {
                    _deal.text = deal[2];
                }
                if (iter == 3)
                {
                    _deal.text = deal[3];
                    _deal.color = Color.green;
                    _deal.fontStyle = FontStyles.Strikethrough;
                }
                break;
            case "Geo":
                if (iter == 0)
                {
                    _geo.text = geo[0];
                    _geo.color = Color.yellow;
                }
                if (iter == 1)
                {
                    _geo.text = geo[1];
                }

                if (iter == 2)
                {
                    _geo.text = geo[2];
                }
                if (iter == 3)
                {
                    _geo.text = geo[3];
                    _geo.color = Color.green;
                    _geo.fontStyle = FontStyles.Strikethrough;
                }
                break;
        }
    }
}
