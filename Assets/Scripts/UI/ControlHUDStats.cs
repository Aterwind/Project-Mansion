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
    public Image Victory;

    public int maxEnemySpawn;
    public int maxItem;

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
        maxItem += (int)parameters[0];
        scoreText.text = maxItem.ToString();
    }

    void UpdateEnemyTotalText(object[] parameters)
    {
        maxEnemySpawn += (int)parameters[0]; 
        enemyTotalText.text = "x " + maxEnemySpawn;

        if(maxEnemySpawn <= 0)
        {
            EventManager.UnSubscribe("UpdateUIenemyTotal", UpdateEnemyTotalText);

            Victory.transform.gameObject.SetActive(true);

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
        }
    }
}
