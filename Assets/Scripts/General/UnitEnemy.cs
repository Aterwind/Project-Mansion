using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitEnemy : Unit
{
    [Header("Modelos y target")]
    [SerializeField] protected GameObject meshCollider = null;
    [SerializeField] protected GameObject BoxCollider = null;
    [SerializeField] protected Transform _transform;
    [SerializeField] protected TargetWaypoints allWaiPoint = null;

    protected Vector3 dir;
    protected int currentWaypoint = 0;

}
