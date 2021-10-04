using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [Header("Fisica")]
    public Rigidbody rb;
    public Animator animator;
    public float speed = 0;
    public float jumpSpeed = 0;
    public float rotationSpeed = 0;

    [HideInInspector]
    public Vector3 moveDirX;
    [HideInInspector]
    public Vector3 moveDirY;
    [HideInInspector]
    public Vector3 positionCamara;
}
