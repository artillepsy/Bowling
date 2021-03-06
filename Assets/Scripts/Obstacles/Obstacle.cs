using Balls;
using Literals;
using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    /// <summary>
    /// Base class for obstacles which destroy balls
    /// </summary>
    public class Obstacle : MonoBehaviour
    {
        public static UnityEvent<Ball> OnBallKicked = new UnityEvent<Ball>();

        protected void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag(Tags.Ball)) return;
            var ball = collision.collider.GetComponentInParent<Ball>();
            if (!ball) return;
            OnBallKicked?.Invoke(ball);
        }
    }
}