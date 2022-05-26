using UnityEngine;

namespace Balls
{
    /// <summary>
    /// Instantiates particle effect after disabling ball
    /// </summary>
    public class BallDisappearEffect : MonoBehaviour
    {
        [SerializeField] private Transform disappearPS;
        
        private void OnDisable()
        {
            var instance = Instantiate(disappearPS, transform.position, Quaternion.identity);
        }
    }
}