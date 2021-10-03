using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [Header("Vida Player")]
    public int hp=100;

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

    public void Start()
    {
        EventManager.Subscribe("SetHP", FunSetHP);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            EventManager.Trigger("UpdateUIhp", 1);
        }

    }

    public void ReceiveDamage(int amoutDamage)
    {
        if(amoutDamage > 0 && hp > 0)
        {
            hp -= amoutDamage;

            if(hp <= 0)
            {
                Debug.Log("murio :c");
                animator.SetTrigger("Die");
            }
            else if(hp > 0)
            {
                Debug.Log("Te pegaron un cachetada uwu");
            }
        }
    }

    public void FunSetHP(object[] paremeters)
    {
        
    }
}
