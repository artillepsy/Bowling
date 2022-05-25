using Cinemachine;
using UnityEngine;

namespace Attractor
{
    public class CameraTargetSetter : MonoBehaviour
    {
        [SerializeField] private Transform lookTarget;

        private void Start()
        {
            var cam = FindObjectOfType<CinemachineVirtualCamera>();
            cam.Follow = transform;
            cam.LookAt = lookTarget;
        }
    }
}