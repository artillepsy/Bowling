using System.Collections;
using BallManipulation;
using Balls;
using UnityEngine;
using UnityEngine.Events;

namespace Finish
{
    public class BigBallCreator : MonoBehaviour
    {
        [SerializeField] private BigBall bigBallPrefab;
        [SerializeField] private Transform bigBallCreationPos;
        [Space]
        [SerializeField] private float creationSpeed = 3f;
        private BallCountChanger _ballCountChanger;
        private BigBall _bigBall;
        
        public static UnityEvent OnBigBallCreated = new UnityEvent();

        private void Start()
        {
            _ballCountChanger = FindObjectOfType<BallCountChanger>();
            
            FinishLine.OnFinishReached.AddListener(() =>
            {
                _bigBall = Instantiate(bigBallPrefab, bigBallCreationPos.position, Quaternion.identity);
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
                        _bigBall.IncrementScale();
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