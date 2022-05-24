using UnityEngine;

namespace Balls
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        public void AddForceToTarget(Vector3 targetPos, float force)
        {
            var direction = (targetPos - transform.position);
            direction.y = 0;
            rb.AddForce(direction.normalized * force, ForceMode.Force);
        }

    }
}