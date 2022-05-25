using BigBall;
using UnityEngine;
using UnityEngine.Events;

namespace GiantPins
{
    public class PinGiantFallDownChecker : MonoBehaviour
    {
        [SerializeField] private float maxUpDeviationAngle = 45f;
        [SerializeField] private float checkTime = 2f;

        private float _currentTime = 0f;
        private bool _afterBigBallLaunch = false;
        
        public static UnityEvent OnPinFallDown = new UnityEvent();
        private void Start()
        {
            BigBallLauncher.OnBigBallLaunched.AddListener(() => _afterBigBallLaunch = true);
        }

        private void Update()
        {
            if (!_afterBigBallLaunch) return;
            var deviation = Vector3.Angle(transform.up, Vector3.up);
            if (deviation < maxUpDeviationAngle) _currentTime = 0f;
            _currentTime += Time.deltaTime;
            if (_currentTime >= checkTime) OnPinFallDown?.Invoke();
        }
    }
}