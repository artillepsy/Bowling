using UnityEngine;

namespace Obstacles
{
    public class Pin : Obstacle
    {
        [SerializeField] private GameObject child;
        [SerializeField] private string ignoreBallsLayerName = "Ignore balls";
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float kickImpulse = 4f;
        
        protected void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.transform.parent.CompareTag("Ball")) return;
            Debug.Log("kick");
            base.OnCollisionEnter(collision);
            child.layer = LayerMask.NameToLayer(ignoreBallsLayerName);
            var direction = (collision.contacts[0].point - collision.collider.transform.parent.position).normalized;
            rb.AddForce(direction * kickImpulse, ForceMode.Impulse);
        }
    }
}