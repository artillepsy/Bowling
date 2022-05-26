using BigBall;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace GiantPins
{
    /// <summary>
    /// Checks for giant pin fall down
    /// </summary>
    public class PinGiantFallDownChecker : MonoBehaviour
    {
        [SerializeField] private float maxUpDeviationAngle = 45f;

        private float _currentTime = 0f;
        private bool _shouldCalculate = false;
        
        public static UnityEvent OnPinFallDown = new UnityEvent();
        private void Start()
        {
            BigBallLauncher.OnBigBallLaunched.AddListener(() => _shouldCalculate = true);
            VictoryCanvas.OnEndLevel.AddListener(() => _shouldCalculate = false);
        }

        private void Update()
        {
            if (!_shouldCalculate) return;
            var deviation = Vector3.Angle(transform.up, Vector3.up);
            if (deviation < maxUpDeviationAngle) return;

            _shouldCalculate = false;
            OnPinFallDown?.Invoke();
        }
    }
}