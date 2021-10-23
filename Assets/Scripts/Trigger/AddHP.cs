using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHP : UnitItem
{
    [SerializeField] protected int _hp;

    protected virtual void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IReceiveHP>();
        if (hit != null)
        {
            BackStock.Invoke(this);
            hit.ReceiveHP(_hp);
        }
    }

    public override void TurnOff(UnitItem b)
    {
        b.gameObject.SetActive(false);
    }

    public override void TurnOn(UnitItem b)
    {
        b.gameObject.SetActive(true);
    }
}
