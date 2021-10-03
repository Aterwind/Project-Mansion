using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour,IDamageable
{
    [Header("Vida Player")]
    public int hP = 20;
    public int currentHP;

    public void Start()
    {
        currentHP = hP;
        EventManager.Subscribe("SetHP",FuncSetHP);
        EventManager.Trigger("UpdateUIhp", hP);
    }

    public void ReceiveDamage(int amoutDamage)
    {
        if(amoutDamage > 0 && hP > 0)
        {
            hP -= amoutDamage;
            Debug.Log("xd");
            EventManager.Trigger("SetHP", hP);

            if (hP <= 0)
            {
                Debug.Log("murio :c");
            }
            else if(hP > 0)
            {
                Debug.Log("Te pegaron un cachetada uwu");
            }
        }
    }

    public void ReceiveHP(int amoutHP)
    {
        if(amoutHP < hP && hP < currentHP)
        {
            hP += amoutHP;
            EventManager.Trigger("SetHP", hP);
        }
    }

    public void FuncSetHP(object[] parameters)
    {
        hP = (int)parameters[0];
        EventManager.Trigger("UpdateUIhp", hP);
    }
}
