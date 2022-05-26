using System;
using System.Collections.Generic;
using Attractor;
using Balls;
using Gates;
using Obstacles;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace BallManipulation
{
    /// <summary>
    /// Adds and removes balls in a scene
    /// </summary>
    public class BallCountChanger : MonoBehaviour
    {
        [SerializeField] private Ball ballPrefab;
        private List<Ball> _balls = new List<Ball>();
        private Transform _attractor;
        public List<Ball> Balls => _balls;

        public static UnityEvent<Ball> OnBallSpawned = new UnityEvent<Ball>();
        public static UnityEvent<Ball> OnBallRemoved = new UnityEvent<Ball>();
        public static UnityEvent OnGameOver = new UnityEvent();

        private void Start()
        {
            _attractor = FindObjectOfType<BallAttractor>().transform;
            _balls.AddRange(FindObjectsOfType<Ball>());
            Obstacle.OnBallKicked.AddListener(DeactivateBall);
            Gate.OnGateActivated.AddListener(DoMathOperation);
        }

        private void DeactivateBall(Ball ball)
        {
            ball.gameObject.SetActive(false);
            _balls.Remove(ball);
            BallPool.Inst.Add(ball);
            if (_balls.Count != 0) return;
            OnGameOver?.Invoke();
        }

        private void DoMathOperation(Func<int, int, int> operation, int secondArg)
        {
            var result = operation(_balls.Count, secondArg);
            var difference = Mathf.Abs(result - _balls.Count);
            if(result > _balls.Count) AddBalls(difference);
            else RemoveBalls(difference);
        }

        private void AddBalls(int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (!BallPool.Inst.TryGet(out var ball))
                {
                    ball = Instantiate(ballPrefab);
                }
                UpdateBallPosition(ball);
                ball.gameObject.SetActive(true);
                ball.ScaleChanger.StartGrow();
                _balls.Add(ball);
                OnBallSpawned?.Invoke(ball);
            }
        }

        private void RemoveBalls(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var ball = _balls[Random.Range(0, _balls.Count)];
                ball.gameObject.SetActive(false);
                _balls.Remove(ball);
                BallPool.Inst.Add(ball);
                OnBallRemoved?.Invoke(ball);

                if (_balls.Count != 0) continue;
                
                OnGameOver?.Invoke();
                return;
            }
        }
        
        private void UpdateBallPosition(Ball ball)
        {
            var spawnPos = new Vector3(_attractor.position.x, 0, _attractor.position.z);
            var spawnOffsetXZ = Random.insideUnitSphere * 0.2f;

            spawnOffsetXZ.y = 0;
            spawnPos += spawnOffsetXZ;
            ball.transform.position = spawnPos;
            ball.transform.SetParent(_attractor);
        }
    }
}