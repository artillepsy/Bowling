using BallManipulation;
using UnityEngine;

namespace Balls
{
    public class BallVerticalPosFreezer : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        public void UnfreezePosY()
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
        private void Start()
        {
            BallCountChanger.OnAllSpawned.AddListener(FreezePosY);
        }

        private void FreezePosY(float delay)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation |
                             RigidbodyConstraints.FreezePositionY;
            Invoke(nameof(UnfreezePosY), delay);
        }
    }
}