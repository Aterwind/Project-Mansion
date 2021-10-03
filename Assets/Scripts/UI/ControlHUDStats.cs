using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlHUDStats : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    private void Start()
    {
        EventManager.Subscribe("UpdateUIhp", UpdateHpText);
    }

    void UpdateHpText(object[] parameters)
    {
        hpText.text = "hp:" +parameters;
    }
}
