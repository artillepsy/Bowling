using Finish;
using UnityEngine;

namespace BigBall
{
    public class BigBallDirectionArrow : MonoBehaviour
    {
        [SerializeField] private GameObject arrowQuad;
        [SerializeField] private float rotationSpeed = 40f;
        [SerializeField] private float rotationTime = 1f;
        private float _time;
        private bool _inputEnabled = false;

        private void Start()
        {
            _time = rotationTime / 2f;
            arrowQuad.SetActive(false);
                
            BigBallCreator.OnBigBallCreated.AddListener(() =>
            {
                _inputEnabled = true;
                arrowQuad.SetActive(true);
            });
        }

        private void Update()
        {
            if (!_inputEnabled) return;
            arrowQuad.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            _time += Time.deltaTime;

            if (_time < rotationTime) return;

            _time = 0f;
            rotationSpeed = -rotationSpeed;
        }
    }
}