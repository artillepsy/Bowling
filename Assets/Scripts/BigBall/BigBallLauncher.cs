using Finish;
using UnityEngine;
using UnityEngine.Events;

namespace BigBall
{
    public class BigBallLauncher : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float impulse = 100f;
        
        private bool _inputEnabled = false;

        public static UnityEvent OnBigBallLaunched = new UnityEvent();
        private void Start()
        {
            BigBallCreator.OnBigBallCreated.AddListener(() => _inputEnabled = true);
        }

        private void Update()
        {
            if (!_inputEnabled) return;
            if (Input.touchCount == 0) return;
            if (Input.touches[0].phase != TouchPhase.Began) return;
            Debug.Log("touch");
            LaunchBigBall();
        }

        private void LaunchBigBall()
        {
            var direction = FindObjectOfType<BigBallDirectionArrow>().Direction;

            rb.useGravity = true;
            rb.AddForce(direction * impulse, ForceMode.Impulse);
            _inputEnabled = false;
            OnBigBallLaunched?.Invoke();
        }
    }
}