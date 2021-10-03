using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAttack : MonoBehaviour
{
    [SerializeField] protected int _damage;

    protected virtual void  OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if(hit != null)
        {
            hit.ReceiveDamage(_damage);
        }
    }
}
