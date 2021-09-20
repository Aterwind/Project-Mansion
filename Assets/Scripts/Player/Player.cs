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
        [SerializeField]
        private float speedPlayer = 0;
        public Vector3 MoveDirX;
        public int distancePixel;

        void Start()
        {
            control = new ConstructorController(this);
            Right();
        }

        void Update()
        {
            control.OnUpdate();
        }

        public void MoveDir(Vector3 direction)
        {
            transform.position += direction * (speedPlayer * Time.deltaTime);
        }
        public void Right()
        {
            MoveDirX = Vector3.right;
        }
        public void Left()
        {
            MoveDirX = Vector3.left;
        }
    }
}
