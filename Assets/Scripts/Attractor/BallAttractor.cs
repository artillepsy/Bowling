using System;
using System.Collections.Generic;
using BallManipulation;
using Balls;
using Finish;
using Obstacles;
using UnityEngine;

namespace Attractor
{
    public class BallAttractor : MonoBehaviour
    {
        [SerializeField] private List<BallMovement> balls;
        [SerializeField] private float attractForce = 50f;
        private bool _shouldAttract = true;

        private void Start()
        {
            Obstacle.OnBallKicked.AddListener((ball) => balls.Remove(ball.Movement));
            BallCountChanger.OnBallSpawned.AddListener((ball) => balls.Add(ball.Movement));
            FinishLine.OnFinishReached.AddListener(Deactivate);
        }

        private void FixedUpdate()
        {
            if (!_shouldAttract) return;
            
            foreach (var ball in balls)
            {
                ball.AddForceToTarget(transform.position, attractForce);
            }
        }

        private void Deactivate() => _shouldAttract = false;
    }
}
