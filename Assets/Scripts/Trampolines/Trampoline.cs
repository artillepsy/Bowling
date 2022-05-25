using Attractor;
using Balls;
using Literals;
using UnityEngine;

namespace Trampolines
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] private AnimationCurve animCurve;
        [SerializeField] private float trampolineLength = 10f;
        
        private float _attractorSpeed;
        private float _jumpTime;

        private void Start()
        {
            _attractorSpeed = FindObjectOfType<BallAttractorMovement>().ZSpeed;
            _jumpTime = trampolineLength / _attractorSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Ball)) return;
            var comp = other.GetComponentInParent<Ball>();
            if (!comp) return;
            comp.Jumper.Jump(animCurve, _jumpTime, trampolineLength);
        }
    }
}