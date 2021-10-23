using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public List<GameObject> platformActive = new List<GameObject>();
    public float platformCoolDown = 0;

    public int distancePixel;
    [HideInInspector]
    public bool startSwipe;
    [HideInInspector]
    public Vector2 initPosSwipe;
    [HideInInspector]
    public Vector2 finalPosSwipe;
    public Action endSwipeX;
    public Action endSwipeY;

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

        if (initPosSwipe.x > finalPosSwipe.x || initPosSwipe.x < finalPosSwipe.x)
            endSwipeX.Invoke();

        if (initPosSwipe.y > finalPosSwipe.y || initPosSwipe.y < finalPosSwipe.y)
            endSwipeY.Invoke();

        //Debug.Log("Start Position: " + initPosSwipe.x + " / End Position: " + finalPosSwipe.x);
    }

    public void platformSwitch()
    {
        for (int i = 0; i < platformActive.Count; i++)
        {
            platformActive[i].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        StartCoroutine(ActivePlatform());
    }

    IEnumerator ActivePlatform()
    {
        yield return new WaitForSeconds(platformCoolDown);

        for (int i = 0; i < platformActive.Count; i++)
        {
            platformActive[i].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
