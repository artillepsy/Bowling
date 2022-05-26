using Finish;
using UnityEngine;

namespace Balls
{
    /// <summary>
    /// Contains info about ball components
    /// </summary>
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float minBigBallCreationDelay = 0.3f;
        [SerializeField] private float maxBigBallCreationDelay = 0.7f;
        [Space]        
        [SerializeField] private Collider coll;
        [SerializeField] private Rigidbody rb;
        [Space]
        [SerializeField] private BallMovement movementComponent;
        [SerializeField] private BallScaleChanger scaleChangerComponent;
        [SerializeField] private BallJumper jumperComponent;

        public BallMovement Movement => movementComponent;
        public BallScaleChanger ScaleChanger => scaleChangerComponent;
        public BallJumper Jumper => jumperComponent;
        
        private void Start()
        {
            FinishLine.OnFinishReached.AddListener(() =>
            {
                var delay = Random.Range(minBigBallCreationDelay, maxBigBallCreationDelay);
                Invoke(nameof(PrepareToBigBallCreation), delay);
            });
        }

        private void PrepareToBigBallCreation()
        {
            coll.enabled = false;
            rb.useGravity = false;
            rb.mass = 0f;
        }
    }
}