﻿using Finish;
using UnityEngine;

namespace Attractor
{
    public class BallAttractorMovement : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [Space]        
        [SerializeField] private float zSpeed = 3f;
        [SerializeField] private float xSpeed = 1f;
        [SerializeField] private float xConstraints = 4f;
        private bool _reachedFinish = false;
        public float ZSpeed => zSpeed;
        
        private void Start()
        {
            FinishLine.OnFinishReached.AddListener(() => _reachedFinish = true);
        }

        private void Update()
        {
            if (_reachedFinish) return;
            
            var x = joystick.Horizontal;
            var velocity = new Vector3(x * xSpeed, 0, zSpeed) * Time.deltaTime;
            transform.Translate(velocity, Space.World);
            
            ClampXPosition();
        }

        private void ClampXPosition()
        {
            if (transform.position.x > xConstraints)
            {
                transform.position = new Vector3(xConstraints, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xConstraints)
            {
                transform.position = new Vector3(-xConstraints, transform.position.y, transform.position.z);
            }
        }
    }
}