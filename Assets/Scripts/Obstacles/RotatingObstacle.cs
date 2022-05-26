using UnityEngine;

namespace Obstacles
{
    /// <summary>
    /// Rotating obstacle
    /// </summary>
    public class RotatingObstacle : Obstacle
    {
        [SerializeField] private float rotationSpeed = 60f;
        [SerializeField] private bool clockwiseRotation = true;

        private void Awake() => rotationSpeed *= clockwiseRotation ? 1 : -1;

        private void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}