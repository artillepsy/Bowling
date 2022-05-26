using System.Collections;
using BallManipulation;
using BigBall;
using UnityEngine;
using UnityEngine.Events;

namespace Finish
{
    /// <summary>
    /// Attracts all active balls to a point of big ball creation
    /// </summary>
    public class BigBallCreator : MonoBehaviour
    {
        [SerializeField] private BigBallScaleChanger bigBallScaleChangerPrefab;
        [SerializeField] private Transform bigBallCreationPos;
        [Space]
        [SerializeField] private float creationSpeed = 3f;
        private BallCountChanger _ballCountChanger;
        private BigBallScaleChanger _bigBallScaleChanger;
        
        public static UnityEvent OnBigBallCreated = new UnityEvent();

        private void Start()
        {
            _ballCountChanger = FindObjectOfType<BallCountChanger>();
            
            FinishLine.OnFinishReached.AddListener(() =>
            {
                _bigBallScaleChanger = Instantiate(bigBallScaleChangerPrefab, bigBallCreationPos.position, Quaternion.identity);
                StartCoroutine(CreateBigBallCO());
            });
        }

        private IEnumerator CreateBigBallCO()
        {
            var balls = _ballCountChanger.Balls;
            while (true)
            {
                var created = true;
                foreach (var ball in balls)
                {
                    if (!ball.gameObject.activeSelf) continue;
                    
                    var finished = ball.Movement.FlyToTargetTowards(bigBallCreationPos.position, creationSpeed);

                    if (finished)
                    {
                        ball.gameObject.SetActive(false);
                        _bigBallScaleChanger.IncrementScale();
                    }
                    else created = false;
                }
                if (created) break;
                yield return null;
            }
            OnBigBallCreated?.Invoke();
        }
    }
}