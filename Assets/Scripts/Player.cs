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
        private float speedPlayer;

        private Vector3 MoveDirX;
        [SerializeField]
        private int distancePixel;

        void Start()
        {
            control = new ConstructorController(this);
            Right();
        }

        // Update is called once per frame
        void Update()
        {
            control.OnUpdate();
        }

        public void Movement()
        {

            if (GameManager.instance.finalPosSwipe.x > (GameManager.instance.initPosSwipe.x + distancePixel))
            {
                Right();
            }
            else if (GameManager.instance.initPosSwipe.x > (GameManager.instance.finalPosSwipe.x + distancePixel))
            {
                Left();
            }

            MoveDir(MoveDirX);
        }
        void MoveDir(Vector3 direction)
        {
            transform.position += direction * (speedPlayer * Time.deltaTime);
        }

        void Right()
        {
            MoveDirX = Vector3.right;
        }
        void Left()
        {
            MoveDirX = Vector3.left;
        }
    }
}
