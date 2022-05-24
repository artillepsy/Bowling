using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Attractor
{
    public class CameraDampingChanger : MonoBehaviour
    {
        [SerializeField] private float startDampingZ = 1f;
        [SerializeField] private float inZoneDampingZ = 3f;
        [SerializeField] private float changeTime = 1f;
        
        [SerializeField] private CinemachineVirtualCamera cam;
        private CinemachineTransposer _transposer;
        private int _zoneCount = 0;
        private void Start()
        {
            _transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("HignDampingZone")) return;
            
            _zoneCount++;
            if (_zoneCount > 1) return;
            
            StartCoroutine(ChangeDampingCO(startDampingZ, inZoneDampingZ));
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("HignDampingZone")) return;
            
            _zoneCount--;
            if (_zoneCount > 0) return;

            StartCoroutine(ChangeDampingCO(inZoneDampingZ, startDampingZ));
        }

        private IEnumerator ChangeDampingCO(float startValue, float endValue)
        {
            var time = 0f;
            var difference = endValue - startValue;
            var koeff = difference / changeTime;
            
            while (time < changeTime)
            {
                _transposer.m_ZDamping += koeff * Time.deltaTime;
                time += Time.deltaTime;
                yield return null;
            }
            _transposer.m_ZDamping = endValue;
        }
    }
}