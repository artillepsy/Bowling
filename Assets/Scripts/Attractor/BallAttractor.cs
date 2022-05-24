using System.Collections.Generic;
using Balls;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attractor
{
    public class BallAttractor : MonoBehaviour
    {
        [SerializeField] private List<BallMovement> balls;
        [SerializeField] private float attractForce = 50f;

        public List<BallMovement> Balls => balls;
        
        private void FixedUpdate()
        {
            foreach (var ball in balls)
            {
                ball.AddForceToTarget(transform.position, attractForce);
            }
        }
    }
}
