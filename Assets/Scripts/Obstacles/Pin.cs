using UnityEngine;

namespace Obstacles
{
    public class Pin : Obstacle
    {
        [SerializeField] private GameObject child;
        [SerializeField] private string ignoreBallsLayerName = "Ignore balls";
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float minKickImpulse = 1.7f;
        [SerializeField] private float maxKickImpulse = 3.4f;
        [SerializeField] private float impulseOffsetZ = 0.5f;
        
        protected void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            
            if (!collision.collider.transform.parent.CompareTag("Ball")) return;
            
            child.layer = LayerMask.NameToLayer(ignoreBallsLayerName);
            
            var kickPoint = transform.position + Vector3.up * impulseOffsetZ;
            var direction = (kickPoint - collision.collider.transform.parent.position).normalized;
            var impulse = Random.Range(minKickImpulse, maxKickImpulse);
            
            rb.AddForce(direction * impulse, ForceMode.Impulse);
        }
    }
}