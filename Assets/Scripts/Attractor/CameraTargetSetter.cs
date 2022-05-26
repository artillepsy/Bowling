using Cinemachine;
using UnityEngine;

namespace Attractor
{
    /// <summary>
    /// Sets following and look targets to a cinemachine camera at start of the level
    /// </summary>
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