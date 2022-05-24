using UnityEngine;

namespace Obstacles
{
    public class Pin : Obstacle
    {
        [SerializeField] private Collider selfCollider;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float kickImpulse = 4f;
        
        private bool _kicked = false;
        protected void OnTriggerEnter(Collider otherCollider)
        {
            if (_kicked) return;
            base.OnTriggerEnter(otherCollider);
            rb.AddForceAtPosition();
        }
    }
}