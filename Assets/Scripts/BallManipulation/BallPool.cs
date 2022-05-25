using System.Collections.Generic;
using Balls;
using UnityEngine;

namespace BallManipulation
{
    public class BallPool : MonoBehaviour
    {
        public static BallPool Inst { get; private set; }
        private List<Ball> _balls = new List<Ball>();

        private void Awake() => Inst = this;

        public void Add(Ball ball) => _balls.Add(ball);

        public bool TryGet(out Ball ball)
        {
            if (_balls.Count == 0)
            {
                ball = null;
                return false;
            }
            ball = _balls[0];
            _balls.Remove(ball);
            return true;
        }
    }
}