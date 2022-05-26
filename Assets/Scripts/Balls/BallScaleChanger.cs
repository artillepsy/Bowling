using System.Collections;
using UnityEngine;

namespace Balls
{
    /// <summary>
    /// Increases the scale of a ball
    /// </summary>
    public class BallScaleChanger : MonoBehaviour
    {
        [SerializeField] private float endScale = 1f;
        [Min(0.001f)]
        [SerializeField] private float scaleTime = 0.3f;
        private float _scaleIncrement;
        
        public void StartGrow()
        {
            transform.localScale = Vector3.zero;
            StartCoroutine(ChangeScaleCO());
        }

        private void Awake() => _scaleIncrement = 1f / scaleTime;

        private IEnumerator ChangeScaleCO() 
        {
            var scale = 0f;

            while (scale < endScale)
            {
                scale += _scaleIncrement * Time.deltaTime;
                transform.localScale = Vector3.one * scale;
                yield return null;
            }
            transform.localScale = Vector3.one * endScale;
        }
    }
}