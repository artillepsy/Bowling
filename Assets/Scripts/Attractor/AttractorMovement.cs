using UnityEngine;

namespace Attractor
{
    public class AttractorMovement : MonoBehaviour
    {
        [SerializeField] private float zSpeed = 3f;
        [SerializeField] private float xSpeed = 1f;
        [SerializeField] private Joystick joystick;
    // add x constraints
        private void Update()
        {
            var x = joystick.Horizontal;
            var velocity = new Vector3(x * xSpeed, 0, zSpeed) * Time.deltaTime;
            transform.Translate(velocity, Space.World);
        }
    }
}