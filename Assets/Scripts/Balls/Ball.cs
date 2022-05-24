using UnityEngine;

namespace Balls
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallMovement movementComponent;
        [SerializeField] private BallScaler scalerComponent;
        
        public BallMovement Movement => movementComponent;
        public BallScaler Scaler => scalerComponent;
    }
}