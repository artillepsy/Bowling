using UnityEngine;

namespace Balls
{
    /// <summary>
    /// Controls ball movement
    /// </summary>
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float forceFalloffDistance = 1f;
        private float _forceFalloffSqrDist;

        private void Awake() => _forceFalloffSqrDist = forceFalloffDistance * forceFalloffDistance;

        /// <summary>
        /// Moves ball to a target
        /// </summary>
        public void AddForceToTarget(Vector3 targetPos, float force)
        {
            if (transform.position.y > 0)
            {
                rb.velocity = new Vector3(0, 0, 0);
                return;
            }
            var direction = (targetPos - transform.position);
            direction.y = 0;
            
            if (direction.sqrMagnitude > _forceFalloffSqrDist)
            {
                rb.AddForce(direction.normalized * force, ForceMode.Force);
                return;
            }
            
            var multiplier = direction.sqrMagnitude / _forceFalloffSqrDist;
            rb.velocity = new Vector3(rb.velocity.x * multiplier, rb.velocity.y, rb.velocity.z * multiplier);
        }
        /// <summary>
        /// Tries to move ball to a point in air
        /// </summary>
        public bool FlyToTargetTowards(Vector3 targetPos, float speed)
        {
            if (rb.useGravity) return false;
            
            var pos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if ((pos - targetPos).sqrMagnitude < 0.1f) return true;
            rb.MovePosition(pos);
            return false;
        }
    }
}