using System.Collections.Generic;
using Balls;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Attractor
{
    public class BallAttractor : MonoBehaviour
    {
        [SerializeField] private BallMovement ballPrefab;
        [SerializeField] private List<BallMovement> balls;
        [SerializeField] private int debug_spawnCount;
        [SerializeField] private float attractForce = 300f;

        void FixedUpdate()
        {
            foreach (var ball in balls)
            {
                ball.AddForceToPosition(transform.position, attractForce);
            }
        }

        public void OnClickSpawn()
        {
            for (var i = 0; i < debug_spawnCount; i++)
            {
                SpawnBall();
            }
        }

        private void SpawnBall()
        {
            var spawnPos = new Vector3(transform.position.x, 0, transform.position.z);

            var spawnOffsetXZ = Random.insideUnitSphere;
            spawnOffsetXZ.y = 0;
            spawnPos += spawnOffsetXZ;
            
            var ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
            balls.Add(ball);
            ball.transform.SetParent(transform);
        }
    }
}
