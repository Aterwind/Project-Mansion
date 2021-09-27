using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMasion
{
    public class Player : MonoBehaviour
    {
        ConstructorController control;

        [Header("Fisica")]
        [SerializeField]
        private Rigidbody rbPlayer;
        public Animator animator;
        [SerializeField]
        private float speedPlayer = 0;
        [SerializeField]
        private float jumpSpeed = 0;
        [SerializeField]
        private float rotationSpeedPlayer = 0;

        [HideInInspector]
        public Vector3 moveDirX;
        [HideInInspector]
        public Vector3 moveDirY;
        [HideInInspector]
        public Vector3 positionCamara;

        [Header("Punto donde mira Luigi")]
        public int xCam;
        public int zCam;

        [Header("Raycast")]
        public bool noWall = true;
        [SerializeField]
        private LayerMask _layerMask;

        private bool Jump = false;

        void Start()
        {
            control = new ConstructorController(this);
        }

        void Update()
        {
            control.OnUpdate();
        }

        //Movimiento y Camara//
        public void Right()
        {
            moveDirX = Vector3.right;
            positionCamara = new Vector3(xCam, 0, -zCam);

        }
        public void Left()
        {
            moveDirX = Vector3.left;
            positionCamara = new Vector3(-xCam, 0, -zCam);
        }
        public void Up()
        {
            Debug.Log("arriba");
            moveDirY = Vector3.up;
            Jump = true;
        }
        public void Down()
        {
            Debug.Log("abajo");
            moveDirY = Vector3.down;
            Jump = true;
        }

        public void MoveDir(Vector3 direction)
        {
            if (noWall == true)
                transform.position += direction * (speedPlayer * Time.deltaTime);
        }

        public void JumpDir(Vector3 directionY)
        {
            if (Jump == true)
            {
                Jump = false;
                rbPlayer.AddForce(directionY * jumpSpeed, ForceMode.Impulse);

            }
        }

        public void Rotate(Vector3 camaraDirection)
        {
            if (camaraDirection != Vector3.zero)
            {
                animator.SetBool("Walking", true);
                Quaternion toRotation = Quaternion.LookRotation(camaraDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeedPlayer * Time.deltaTime);
            }
        }
        //------------------//

        public void Raycast()
        {
            if (Physics.Raycast(transform.position, transform.forward, 1.5f, _layerMask))
            {
                noWall = false;
                animator.SetBool("Walking", false);
            }
            else
            {
                noWall = true;
            }
        }
    }
}
