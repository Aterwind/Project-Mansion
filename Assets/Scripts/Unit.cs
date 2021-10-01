using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [Header("Vida Player")]
    [SerializeField]
    protected int Life = 100;
    public int currentHitLife;

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

    virtual protected void Awake()
    {
        currentHitLife = Life;
    }
    public void ReceiveDamage(int amoutDamage)
    {
        if(amoutDamage > 0 && currentHitLife > 0)
        {
            currentHitLife -= amoutDamage;

            if(currentHitLife <= 0)
            {
                Debug.Log("murio :c");
                animator.SetTrigger("Die");
            }
            else if( currentHitLife > 0)
            {
                Debug.Log("Te pegaron un cachetada uwu");
            }
        }
    }
}
