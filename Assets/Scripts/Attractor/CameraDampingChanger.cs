using Cinemachine;
using Literals;
using UnityEngine;

namespace Attractor
{
    /// <summary>
    /// Changes cinemachine camera damping by setting values in camera animator
    /// </summary>
    public class CameraDampingChanger : MonoBehaviour
    {
        private Animator _animator;
        private int _zoneCount = 0;

        private void Start()
        {
            _animator = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.HighDampingZone)) return;
            _zoneCount++;
            if (_zoneCount > 1) return;
            _animator.SetTrigger(Parameters.EnterDamping);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.HighDampingZone)) return;
            _zoneCount--;
            if (_zoneCount > 0) return;
            _animator.SetTrigger(Parameters.ExitDamping);
        }
    }
}