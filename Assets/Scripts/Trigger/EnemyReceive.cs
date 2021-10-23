using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceive : EnemiesBase, IDamageable
{
    [SerializeField] int hP;

    public void ReceiveDamage(int amoutDamage)
    {
        hP -= amoutDamage;

        if(hP <= 0)
        {
            Reset();
            BackStock.Invoke(this);
            EventManager.Trigger("UpdateUIenemyTotal", -1);
        }

    }

    public void Reset()
    {
        transform.position = Vector3.zero;
    }

    public override void TurnOff(EnemiesBase b)
    {
        b.gameObject.SetActive(false);
    }

    public override void TurnOn(EnemiesBase b)
    {
        b.gameObject.SetActive(true);
    }
}
