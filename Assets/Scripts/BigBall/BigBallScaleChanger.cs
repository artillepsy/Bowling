using UnityEngine;

namespace BigBall
{
    public class BigBallScaleChanger : MonoBehaviour
    {
        [SerializeField] private float scaleIncrement = 0.3f;
        [SerializeField] private float startScale = 0f;
        [SerializeField] private float maxScale = 4f;
        private float _totalScale = 1f;
        private int _usedBallsCount = 0;
        public int UsedBallsCount => _usedBallsCount;

        private void Awake()
        {
            transform.localScale = Vector3.one * startScale;
        }

        public void IncrementScale()
        {
            _usedBallsCount++;
            if (_totalScale > maxScale) return;
            _totalScale += scaleIncrement;
            transform.localScale = Vector3.one * _totalScale; 
        }
        
    }
}