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
    }

    public void OnUpdate()
    {
        changeControls();
    }

    public void NormalControls()
    {
        //Pause PlaceHolder no funciona si esta puesto el UnityRemote, hay que crealer un boton
        if (Input.GetKey(KeyCode.P))
        {
            changeControls = PausedControls;
        }

        if (GameManager.instance.finalPosSwipe.x > (GameManager.instance.initPosSwipe.x + _player.distancePixel))
        {
            _player.Right();
        }
        else if (GameManager.instance.initPosSwipe.x > (GameManager.instance.finalPosSwipe.x + _player.distancePixel))
        {
            _player.Left();
        }

        Move();
    }

    public void PausedControls()
    {
        if (Input.GetKey(KeyCode.P))
        {
            changeControls = NormalControls;
        }
    }

    public void Move()
    {
        _player.MoveDir(_player.moveDirX);
        _player.Rotate(_player.positionCamara);
    }
}
