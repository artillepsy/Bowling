using UnityEngine;

namespace Balls
{
    public class BallDisappearEffect : MonoBehaviour
    {
        [SerializeField] private Transform disappearPS;
        
        private void OnDisable()
        {
            var instance = Instantiate(disappearPS, transform.position, Quaternion.identity);
        }
    }
}