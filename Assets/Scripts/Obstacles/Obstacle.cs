using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        public static UnityEvent OnBallTouched = new UnityEvent();

        protected void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.transform.parent.CompareTag("Ball")) return;
            OnBallTouched?.Invoke();
        }
    }
}