using BigBall;
using GiantPins;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class VictoryCanvas : MonoBehaviour
    {
        [SerializeField] private float showCanvasDelay = 4f;
        
        [SerializeField] private GameObject canvas;
        [SerializeField] private TextMeshProUGUI pinCountLabel;
        
        private int _pinsFallen = 0;
        
        public static UnityEvent OnEndLevel = new UnityEvent();

        private void Start()
        {
            canvas.SetActive(false);
            PinGiantFallDownChecker.OnPinFallDown.AddListener(() => _pinsFallen++);           
            BigBallLauncher.OnBigBallLaunched.AddListener(() => Invoke(nameof(ShowCanvas), showCanvasDelay));
        }

        private void ShowCanvas()
        {
            
        }
    }
}