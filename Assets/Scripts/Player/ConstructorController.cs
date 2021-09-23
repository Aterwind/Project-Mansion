using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PlayerMasion;

public class ConstructorController
{
    Player _player;
    Action changeControls;

    public ConstructorController(Player p)
    {
        _player = p;
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
        if (GameManager.instance.finalPosSwipe.x > (GameManager.instance.initPosSwipe.x + GameManager.instance.distancePixel))
        {
            _player.Right();
        }
        else if (GameManager.instance.initPosSwipe.x > (GameManager.instance.finalPosSwipe.x + GameManager.instance.distancePixel))
        {
            _player.Left();
        }
    }

    public void Move()
    {
        _player.MoveDir(_player.moveDirX);
        _player.Rotate(_player.positionCamara);
    }

}
