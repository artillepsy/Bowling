﻿using System;
using System.Collections.Generic;
using Balls;
using Gates;
using Obstacles;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace BallManipulation
{
    public class BallCountChanger : MonoBehaviour
    {
        [SerializeField] private Transform attractor;
        [SerializeField] private Ball ballPrefab;
        private List<Ball> _balls = new List<Ball>();
        private int _ballCount => _balls.Count;

        public static UnityEvent<Ball> OnBallSpawned = new UnityEvent<Ball>();
        public static UnityEvent<Ball> OnBallRemoved = new UnityEvent<Ball>();

        private void Start()
        {
            _balls.AddRange(FindObjectsOfType<Ball>());
            Obstacle.OnBallKicked.AddListener(DeactivateBall);
            Gate.OnGateActivated.AddListener(DoMathOperation);
        }

        private void DeactivateBall(Ball ball)
        {
            ball.gameObject.SetActive(false);
            BallPool.Inst.Add(ball);
        }

        private void DoMathOperation(Func<int, int, int> operation, int secondArg)
        {
            var result = operation(_ballCount, secondArg);
            var difference = Mathf.Abs(result - _ballCount);
            
            if(result > _ballCount) AddBalls(difference);
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
                UpdatePosition(ball);
                ball.Scaler.StartGrow();
                ball.gameObject.SetActive(true);
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
                
                if (_balls.Count == 0)
                {
                    Debug.Log("Game over");
                    return;
                }
            }
        }
        
        private void UpdatePosition(Ball ball)
        {
            var spawnPos = new Vector3(transform.position.x, 0, transform.position.z);
            var spawnOffsetXZ = Random.insideUnitSphere;

            spawnOffsetXZ.y = 0;
            spawnPos += spawnOffsetXZ;
            ball.transform.position = spawnPos;
            ball.transform.SetParent(attractor);
        }
    }
}