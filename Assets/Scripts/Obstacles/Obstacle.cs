using Balls;
using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        public static UnityEvent<Ball> OnBallKicked = new UnityEvent<Ball>();

        protected void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.transform.parent.CompareTag("Ball")) return;
            var ball = collision.collider.transform.GetComponentInParent<Ball>();
            OnBallKicked?.Invoke(ball);
        }
    }
}