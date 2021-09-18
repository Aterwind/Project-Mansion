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
        _player.Movement();

        //Pause PlaceHolder no funciona si esta puesto el UnityRemote hay que crealer un boton
        if (Input.GetKey(KeyCode.P))
        {
            changeControls = PausedControls;
        }
    }

    public void PausedControls()
    {
        if (Input.GetKey(KeyCode.P))
        {
            changeControls = NormalControls;
        }
    }
}
