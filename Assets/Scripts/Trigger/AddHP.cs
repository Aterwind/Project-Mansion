using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHP : MonoBehaviour
{
    [SerializeField] protected int _hp;
    protected virtual void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.ReceiveHP(_hp);
        }
    }
}
