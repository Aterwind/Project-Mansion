using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGoomba : Unit
{
    [SerializeField] private GameObject meshCollider = null;
    [SerializeField] private GameObject BoxCollider = null;
    [SerializeField] private TargetWaypoints allWaiPoint = null;
    private Vector3 dir;
    private int currentWaypoint = 0;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        dir = allWaiPoint.targets[currentWaypoint].transform.position - transform.position;
        dir.y = 0;
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (dir.x >= 0)
        {
            meshCollider.transform.rotation = Quaternion.Euler(0, 145, 0);
        }
        else
        {
            meshCollider.transform.rotation = Quaternion.Euler(0, -145, 0);
        }

        if (dir.magnitude < 0.5f)
        {
            currentWaypoint++;
            BoxCollider.SetActive(false);

            if (currentWaypoint > allWaiPoint.targets.Count - 1)
            {
                currentWaypoint = 0;
            }
        }
    }
}