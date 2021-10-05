using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWaypoints : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if(targets.Count <= 2)
        {
            targets.Add(other.transform);
        }
    }
}
