using BigBall;
using GiantPins;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class VictoryCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private float showCanvasDelay = 4f;
        [SerializeField] private string fallenPinsMessage = " pins fallen";
        [SerializeField] private TextMeshProUGUI fallenPinsLabel;
        private int _fallenPins = 0;
        public static UnityEvent OnEndLevel = new UnityEvent();
        
        private void Start()
        {
            canvas.SetActive(false);
            PinGiantFallDownChecker.OnPinFallDown.AddListener(() => _fallenPins++);           
            BigBallLauncher.OnBigBallLaunched.AddListener(() => Invoke(nameof(ShowCanvas), showCanvasDelay));
        }

        private void ShowCanvas()
        {
            var pinCount = FindObjectsOfType<PinGiantFallDownChecker>().Length;
            fallenPinsLabel.text = _fallenPins + "/" + pinCount + fallenPinsMessage;
            canvas.SetActive(true);
            OnEndLevel?.Invoke();
        }
    }
}