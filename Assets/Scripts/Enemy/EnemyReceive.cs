using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceive : EnemiesBase
{
    public void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<GeneralAttack>();
        if (hit != null)
        {
            Reset();
            BackStock.Invoke(this);
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
