using System;
using System.Collections.Generic;
using Balls;
using Obstacles;
using UnityEngine;

namespace Attractor
{
    public class BallAttractor : MonoBehaviour
    {
        [SerializeField] private List<BallMovement> balls;
        [SerializeField] private float attractForce = 50f;

        private void Start()
        {
            Obstacle.OnBallKicked.AddListener((ball) => balls.Remove(ball.Movement));
        }

        private void FixedUpdate()
        {
            foreach (var ball in balls)
            {
                ball.AddForceToTarget(transform.position, attractForce);
            }
        }
    }
}
