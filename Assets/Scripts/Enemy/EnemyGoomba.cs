using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGoomba : UnitEnemy
{
    IEnemyAdvance _enemyCurrentStrategy = null;
    IEnemyAdvance[] _currentStrategy = new IEnemyAdvance[1];

    void Start()
    {
        _currentStrategy[0] = new NormalAdvance(speed,_transform, currentWaypoint, dir, allWaiPoint, meshCollider, BoxCollider);
        _enemyCurrentStrategy = _currentStrategy[0];
    }

    void Update()
    {
        if (_enemyCurrentStrategy != null)
        {
            _enemyCurrentStrategy.EnemyAdvance();
        }
    }
}