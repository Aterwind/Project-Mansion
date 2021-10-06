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
        GameManager.instance.endSwipe=GetDir;
    }

    public void OnUpdate()
    {
        changeControls();
    }
    public void NormalControls()
    {
        Move();
    }

    public void GetDir()
    {
        if (GameManager.instance.finalPosSwipe.x > (GameManager.instance.initPosSwipe.x + GameManager.instance.distancePixel) || Input.GetKeyDown(KeyCode.D))
        {
            _movement.Right();
        }
        else if (GameManager.instance.initPosSwipe.x > (GameManager.instance.finalPosSwipe.x + GameManager.instance.distancePixel))
        {
            _movement.Left();
        }

        if (GameManager.instance.initPosSwipe.y > (GameManager.instance.finalPosSwipe.y + GameManager.instance.distancePixel))
        {
            _movement.Down();
        }
        else if(GameManager.instance.finalPosSwipe.y > (GameManager.instance.initPosSwipe.y + GameManager.instance.distancePixel))
        {
            _movement.Up();
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
