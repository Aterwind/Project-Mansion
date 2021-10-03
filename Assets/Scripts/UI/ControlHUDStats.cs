using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlHUDStats : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI enemyTotalText;

    private void Start()
    {
        EventManager.Subscribe("UpdateUIhp", UpdateHpText);
        EventManager.Subscribe("UpdateUIscore", UpdateScoreText);
        EventManager.Subscribe("UpdateUIenemyTotal", UpdateEnemyTotalText);
    }

    void UpdateHpText(object[] parameters)
    {
        hpText.text = parameters[0].ToString();
    }
    void UpdateScoreText(object[] parameters)
    {
        scoreText.text = parameters[0].ToString();
    }

    void UpdateEnemyTotalText(object[] parameters)
    {
        enemyTotalText.text = parameters[0].ToString();
    }
}
