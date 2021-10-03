using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField]private int points = 0;

    protected void Start()
    {
        EventManager.Trigger("UpdateUIscore", points);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        var hitCoin = other.gameObject.GetComponent<IDamageable>();
        if (hitCoin != null)
        {
            points += 1;
            EventManager.Trigger("UpdateUIscore", points);
        }
    }
}
