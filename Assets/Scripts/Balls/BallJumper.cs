using System.Collections;
using UnityEngine;

namespace Balls
{
    public class BallJumper : MonoBehaviour
    {
        public void Jump(AnimationCurve yCurve, float time, float curveLength)
        {
            StartCoroutine(JumpCO(yCurve, time, curveLength));
        }
        
        private IEnumerator JumpCO(AnimationCurve yCurve, float time, float curveLength)
        {
            var currentTime = 0f;
            var step = curveLength / time;
            while (currentTime < time)
            {
                var y = yCurve.Evaluate(currentTime * step);
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
                currentTime += Time.deltaTime;
                yield return null;
            }
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}