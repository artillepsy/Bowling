using System;
using System.Collections.Generic;
using Attractor;
using Balls;
using Obstacles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BallManipulation
{
    public class BallCountChanger : MonoBehaviour
    {
        [SerializeField] private int debug_spawnCount;
        [SerializeField] private BallAttractor ballAttractor;
        [SerializeField] private Ball ballPrefab;
        
        private List<Ball> _ballsPool = new List<Ball>();
        
        public void OnClickSpawn()
        {
            for (var i = 0; i < debug_spawnCount; i++)
            {
                SpawnBall();
            }
        }

        private void Start()
        {
            Obstacle.OnBallKicked.AddListener(OnBallKicked);
        }

        private void OnBallKicked(Ball ball)
        {
            ball.gameObject.SetActive(false);
            _ballsPool.Add(ball);
            ballAttractor.Balls.Remove(ball.Movement);
        }

        private bool TryGetBallFromPool(out Ball ball)
        {
            if (_ballsPool.Count == 0)
            {
                ball = null;
                return false;
            }
            ball = _ballsPool[0];
            _ballsPool.Remove(ball);
            return true;
        }
        
        private void SpawnBall()
        {
            var spawnPos = new Vector3(transform.position.x, 0, transform.position.z);

            var spawnOffsetXZ = Random.insideUnitSphere;
            spawnOffsetXZ.y = 0;
            spawnPos += spawnOffsetXZ;
            
            var ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
            //balls.Add(ball);
            ball.transform.SetParent(transform);
        }
    }
}