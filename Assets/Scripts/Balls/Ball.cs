using Finish;
using UnityEngine;

namespace Balls
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float minFinishDelay = 0.3f;
        [SerializeField] private float maxFinishDelay = 0.7f;
        [Space]        
        [SerializeField] private Collider coll;
        [SerializeField] private Rigidbody rb;
        [Space]
        [SerializeField] private BallMovement movementComponent;
        [SerializeField] private BallScaleChanger scaleChangerComponent;

        public BallMovement Movement => movementComponent;
        public BallScaleChanger ScaleChanger => scaleChangerComponent;
        
        private void Start()
        {
            FinishLine.OnFinishReached.AddListener(() =>
            {
                var delay = Random.Range(minFinishDelay, maxFinishDelay);
                Invoke(nameof(PrepareToBigBallCreation), delay);
            });
        }

        private void PrepareToBigBallCreation()
        {
            coll.enabled = false;
            rb.useGravity = false;
        }
    }
}