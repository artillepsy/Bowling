using Literals;
using UnityEngine;
using UnityEngine.Events;

namespace Finish
{
    /// <summary>
    /// Checking for reach the finish line
    /// </summary>
    public class FinishLine : MonoBehaviour
    {
        public static UnityEvent OnFinishReached = new UnityEvent();
        private bool _reachedFinish = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if (_reachedFinish) return;
            if (!other.CompareTag(Tags.Ball)) return;

            _reachedFinish = true;
            OnFinishReached?.Invoke();
        }
    }
}