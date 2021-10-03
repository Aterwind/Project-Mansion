using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMasion;

public class MovementConstructor
{
    public PlayerBehaviour _player;

    public MovementConstructor(PlayerBehaviour p)
    {
        _player = p;
    }

    //Movimiento y Camara//
    public void Right()
    {
        _player.moveDirX = Vector3.right;
        _player.positionCamara = new Vector3(_player.xCam, 0,-_player.zCam);

    }
    public void Left()
    {
        _player.moveDirX = Vector3.left;
        _player.positionCamara = new Vector3(-_player.xCam, 0, -_player.zCam);
    }
    public void Up()
    {
        Debug.Log("arriba");
        _player.moveDirY = Vector3.up;
        _player.Jump = true;
    }
    public void Down()
    {
        Debug.Log("abajo");
        _player.moveDirY = Vector3.down;
        _player.Jump = true;
    }

    public void MoveDir(Vector3 direction)
    {
        if (_player.noWall == true)
            _player.transform.position += direction * (_player.speed * Time.deltaTime);
    }

    public void JumpDir(Vector3 directionY)
    {
        if (_player.Jump == true)
        {
            _player.Jump = false;
            _player.rb.AddForce(directionY * _player.jumpSpeed, ForceMode.Impulse);

        }
    }

    public void Rotate(Vector3 camaraDirection)
    {
        if (camaraDirection != Vector3.zero)
        {
            _player.animator.SetBool("Walking", true);
            Quaternion toRotation = Quaternion.LookRotation(camaraDirection);
            _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, toRotation, _player.rotationSpeed * Time.deltaTime);
        }
    }

    public void Raycast()
    {
        if (Physics.Raycast(_player.transform.position, _player.transform.forward, 1.5f, _player._layerMask))
        {
            _player.noWall = false;
            _player.animator.SetBool("Walking", false);
        }
        else
        {
            _player.noWall = true;
        }
    }
}
