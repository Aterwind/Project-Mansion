using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMasion
{
    public class Player : MonoBehaviour
    {
        ConstructorController control;

        [SerializeField]
        private Rigidbody rbPlayer;
        public Animator animator;
        [SerializeField]
        private float speedPlayer = 0;
        public float rotationSpeedPlayer;

        [HideInInspector]
        public Vector3 MoveDirX;
        public int distancePixel;

        void Start()
        {
            control = new ConstructorController(this);
        }

        void Update()
        {
            control.OnUpdate();
        }

        public void MoveDir(Vector3 direction)
        {
            animator.SetBool("Walking", true);
            transform.position += direction * (speedPlayer * Time.deltaTime);
        }
        public void Right()
        {
            MoveDirX = new Vector3(90, 0, 0);
            Rotate();
        }
        public void Left()
        {
            MoveDirX = new Vector3(270,0,0);
            Rotate();
        }

        public void Rotate()
        {
            Quaternion toRotation = Quaternion.Euler(MoveDirX);
            /*if(MoveDirX == Vector3.left)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0) * Time.deltaTime);
            }
            else if (MoveDirX == Vector3.right)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0) * Time.deltaTime);
            }*/
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeedPlayer * Time.deltaTime);
        }
    }
}
