using Cinemachine;
using UnityEngine;

namespace Attractor
{
    public class CameraTargetSetter : MonoBehaviour
    {
        [SerializeField] private Transform lookTarget;
        private CinemachineVirtualCamera _cam;

        private void Start()
        {
            _cam = FindObjectOfType<CinemachineVirtualCamera>();
            _cam.Follow = transform;
            _cam.LookAt = lookTarget;
        }
    }
}