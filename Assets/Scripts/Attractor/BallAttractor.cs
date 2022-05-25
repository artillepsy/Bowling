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
        [SerializeField] private float attractForce = 70f;
        private bool _attractionActive = true;

        private void Start()
        {
            FinishLine.OnFinishReached.AddListener(() => _attractionActive = false);
            Obstacle.OnBallKicked.AddListener((ball) => balls.Remove(ball.Movement));
            BallCountChanger.OnBallSpawned.AddListener((ball) => balls.Add(ball.Movement));
        }

        private void FixedUpdate()
        {
            if (!_attractionActive) return;
            foreach (var ball in balls)
            {
                ball.AddForceToTarget(transform.position, attractForce);
            }
        }
    }
}
