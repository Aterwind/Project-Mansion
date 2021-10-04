using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGoomba : Unit
{
    public List<Transform> Allwaypoint = new List<Transform>();
    private int currentWaypoint = 0;
    [SerializeField] private GameObject rot = null; 

    void Update()
    {
        Vector3 dir = Allwaypoint[currentWaypoint].transform.position - transform.position;
        dir.y = 0;
        transform.position += dir.normalized * speed * Time.deltaTime;

        if(dir.x >= 0)
        {
            rot.transform.rotation = Quaternion.Euler(0, 145, 0);
        }

        else
        {
            rot.transform.rotation = Quaternion.Euler(0, -145, 0);
        }
          

        if (dir.magnitude < 0.5f)
        {
            currentWaypoint++;

            if(currentWaypoint > Allwaypoint.Count - 1)
                currentWaypoint = 0;
        }
    }
}