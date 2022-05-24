using UnityEngine;

namespace Balls
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        public void AddForceToPosition(Vector3 pos, float force)
        {
            var direction = (pos - transform.position);
            direction.y = 0;
            rb.AddForce(direction.normalized * force, ForceMode.Force);
        }

    }
}