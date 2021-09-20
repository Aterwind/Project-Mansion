﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool startSwipe;
    [HideInInspector]
    public Vector2 initPosSwipe;
    [HideInInspector]
    public Vector2 finalPosSwipe;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        SwipeManager();
    }

    void SwipeManager()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startSwipe = true;
            initPosSwipe = Input.touches[0].position;
        }
        else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            RefreshSwipe();
        }
    }

    void RefreshSwipe()
    {
        finalPosSwipe = Input.touches[0].position;
        startSwipe = false;
        Debug.Log("Start Position: " + initPosSwipe.x + " / End Position: " + finalPosSwipe.x);
    }
}