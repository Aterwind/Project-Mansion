using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTest : EnemiesBase
{
    public float speed;
    float _currentDistance;
    public float maxdistance;

    public void Reset()
    {
        _currentDistance = 0;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        _currentDistance += speed * Time.deltaTime;

        if(_currentDistance >= maxdistance)
        {
            Reset();
            BackStock.Invoke(this);
        }
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
