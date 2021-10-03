using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour,IDamageable
{
    [Header("Vida Player")]
    public int hP = 100;

    public void Start()
    {
        EventManager.Subscribe("SetHP", FunSetHP);
    }

    private void Update()
    {
        EventManager.Trigger("UpdateUIhp", hP);
    }

    public void ReceiveDamage(int amoutDamage)
    {
        if(amoutDamage > 0 && hP > 0)
        {
            hP -= amoutDamage;

            if(hP <= 0)
            {
                Debug.Log("murio :c");
            }
            else if(hP > 0)
            {
                Debug.Log("Te pegaron un cachetada uwu");
            }
        }
    }

    public void FunSetHP(object[] paremeters)
    {
        EventManager.Trigger("UpdateUIhp", hP);
    }
}
