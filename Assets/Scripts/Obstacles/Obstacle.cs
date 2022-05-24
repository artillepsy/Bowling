using UnityEngine;
using UnityEngine.Events;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        public static UnityEvent OnBallTouched = new UnityEvent();

        protected void OnTriggerEnter(Collider otherCollider)
        {
            if (!otherCollider.transform.parent.CompareTag("Ball")) return;
            OnBallTouched?.Invoke();
        }
    }
}