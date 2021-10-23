using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PlayerMasion;

public class ConstructorController
{
    MovementConstructor _movement;
    Action changeControls;

    public ConstructorController(MovementConstructor m)
    {
        _movement=m;
        changeControls = NormalControls;

        GameManager.instance.endSwipeX=GetDirX;
        GameManager.instance.endSwipeY = GetDirY;
    }

    public void OnUpdate()
    {
        changeControls();
    }
    public void NormalControls()
    {
        Move();
    }
    
    public void deathControls()
    {
        _movement.Die();
    }

    public void FuncDeath(object[] parameters)
    {
        changeControls = deathControls;
    }

    public void GetDirX()
    {
        if (GameManager.instance.finalPosSwipe.x > (GameManager.instance.initPosSwipe.x + GameManager.instance.distancePixel) || Input.GetKeyDown(KeyCode.D))
        {
            _movement.Right();
        }
        else if (GameManager.instance.initPosSwipe.x > (GameManager.instance.finalPosSwipe.x + GameManager.instance.distancePixel))
        {
            _movement.Left();
        }
    }

    public void GetDirY()
    {
        if (GameManager.instance.initPosSwipe.y > (GameManager.instance.finalPosSwipe.y + GameManager.instance.distancePixel))
        {
            _movement.Down();
            GameManager.instance.platformSwitch();
        }
        else if (GameManager.instance.finalPosSwipe.y > (GameManager.instance.initPosSwipe.y + GameManager.instance.distancePixel))
        {
            _movement.Up();
            GameManager.instance.platformSwitch();
        }
    }

    public void Move()
    {
        _movement.MoveDir(_movement._player.moveDirX);
        _movement.JumpDir(_movement._player.moveDirY);
        _movement.Rotate(_movement._player.positionCamara);
        _movement.Raycast();
    }

}
