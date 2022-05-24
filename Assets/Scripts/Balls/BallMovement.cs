using System;
using UnityEngine;

namespace Balls
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float groundOffset = 0f;
        
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float forceFalloffDistance = 1f;
        [SerializeField] private float forceFalloffOffsetY = 0.1f;
        private float _forceFalloffSqrDist;

        private void Awake()
        {
            _forceFalloffSqrDist = forceFalloffDistance * forceFalloffDistance;
        }

        public void AddForceToTarget(Vector3 targetPos, float force)
        {
            var direction = (targetPos - transform.position);
            direction.y = 0;

            if (direction.sqrMagnitude <= _forceFalloffSqrDist) return;
            if (transform.position.y > groundOffset + forceFalloffOffsetY) return;
            
            rb.AddForce(direction.normalized * force, ForceMode.Force);
        }
    }
}