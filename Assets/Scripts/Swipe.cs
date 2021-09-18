using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool startSwipe;
    private Vector2 initPosSwipe;
    private Vector2 finalPosSwipe;

    public Rigidbody rbPlayer;
    public float speedPlayer;
    public int jumpForce;
    public ForceMode modeJumpForce;

    private Vector3 MoveDirX;
    [SerializeField]
    private int distancePixel;

    private void Start()
    {
        MoveDirX = Vector3.right;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startSwipe = true;
            initPosSwipe= Input.touches[0].position;
        }
        else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            RefreshSwipe();
        }
        Movement();
    }

    void RefreshSwipe()
    {
        finalPosSwipe = Input.touches[0].position;
        startSwipe = false;
        Debug.Log("Start Position: " + initPosSwipe.x + " / End Position: " + finalPosSwipe.x);
    }

    ///Movimiento///
    void Movement()
    {
        if (finalPosSwipe.x > (initPosSwipe.x + distancePixel))
        {
            MoveDirX = Vector3.right;
        }
        else if (initPosSwipe.x >(finalPosSwipe.x + distancePixel))
        {
            MoveDirX = Vector3.left;
        } 
        MoveDir(MoveDirX);
    }

    void MoveDir(Vector3 direction)
    {
        transform.position += direction * (speedPlayer * Time.deltaTime);
    }
    void Jumping()
    {
        rbPlayer.AddForce(Vector3.up * jumpForce, modeJumpForce);
    }
}
