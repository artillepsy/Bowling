using Literals;
using UnityEngine;

namespace Obstacles
{
    public class Pin : Obstacle
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject childGameObject;
        [Space]
        [SerializeField] private float kickImpulse = 3f;
        [SerializeField] private float torqueImpulse = 0.7f;
        [SerializeField] private float impulseOffsetZ = 0.5f;
        
        protected void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            
            if (!collision.collider.CompareTag(Tags.Ball)) return;
            
            childGameObject.layer = Layers.IgnoreBallsLayer;
            
            var kickPoint = transform.position + Vector3.up * impulseOffsetZ;
            var direction = (kickPoint - collision.collider.transform.parent.position).normalized;
            
            rb.AddForce(direction * kickImpulse, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * torqueImpulse, ForceMode.Impulse);
        }
    }
}