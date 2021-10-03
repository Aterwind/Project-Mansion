using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMasion
{
    public class Player : Unit
    {
        ConstructorController control;
        MovementConstructor movement;

        [Header("Punto donde mira Luigi")]
        public int xCam;
        public int zCam;

        [Header("Raycast")]
        public bool noWall = true;
        public LayerMask _layerMask;
        [HideInInspector]
        public bool Jump = false;

        new void Start()
        {
            movement = new MovementConstructor(this);
            control = new ConstructorController(movement);
        }

        void Update()
        {
            control.OnUpdate();
        }
    }
}
