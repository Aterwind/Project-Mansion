using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMasion
{
    public class PlayerBehaviour : Unit
    {
        ConstructorController control;
        MovementConstructor movement;

        public CapsuleCollider playerCollider = null;

        [Header("Punto donde mira Luigi")]
        public int xCam;
        public int zCam;

        public GameObject Lantern = null;
        public Transform PositionOne = null;
        public Transform PositionTwo = null;

        [Header("Raycast")]
        public bool noWall = true;
        public LayerMask _layerMask;
        [HideInInspector]
        public bool jumpSwipe = false;

        void Start()
        {
            movement = new MovementConstructor(this);
            control = new ConstructorController(movement);
            EventManager.Subscribe("Death", control.FuncDeath);
        }

        void Update()
        {
            control.OnUpdate();
        }
    }
}
