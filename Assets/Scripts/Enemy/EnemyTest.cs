using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTest : MonoBehaviour
{
    public float speed;
    float _currentDistance;
    public float maxdistance;
    public Action<EnemyTest> BackStock;

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
            BackStock.Invoke(this);
        }
    }

    public void TurnOff(EnemyTest b)
    {
        b.Reset();
        b.gameObject.SetActive(false);
    }

    public void TurnOn(EnemyTest b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }
}
