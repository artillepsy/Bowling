using Finish;
using UnityEngine;

namespace BigBall
{
    /// <summary>
    /// Controls direction arrow of a big ball at the end of a level
    /// </summary>
    public class BigBallDirectionArrow : MonoBehaviour
    {
        [SerializeField] private GameObject arrowQuad;
        [SerializeField] private float rotationSpeed = 40f;
        [SerializeField] private float rotationTime = 1f;
        private float _time;
        private bool _rotationEnabled = false;
        public Vector3 Direction => arrowQuad.transform.forward;
        private void Start()
        {
            _time = rotationTime / 2f;
            ChangeRotationStatus(false);
            BigBallCreator.OnBigBallCreated.AddListener(() => ChangeRotationStatus(true));
            BigBallLauncher.OnBigBallLaunched.AddListener(() => ChangeRotationStatus(false));
        }

        private void ChangeRotationStatus(bool status)
        {
            _rotationEnabled = status;
            arrowQuad.SetActive(status);
        }
        private void Update()
        {
            if (!_rotationEnabled) return;
            arrowQuad.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            _time += Time.deltaTime;

            if (_time < rotationTime) return;

            _time = 0f;
            rotationSpeed = -rotationSpeed;
        }
    }
}