using BigBall;
using Cinemachine;
using UnityEngine;

namespace Cam
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float amplitude = 1f;
        [SerializeField] private float time = 1f;
        
        [SerializeField] private CinemachineVirtualCamera cam;
        private CinemachineBasicMultiChannelPerlin _noise;

        private void Start()
        {
            _noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            BigBallLauncher.OnBigBallLaunched.AddListener(() =>
            {
                _noise.m_AmplitudeGain = amplitude;
                Invoke(nameof(EndShake), time);
                
            });
        }

        private void EndShake() => _noise.m_AmplitudeGain = 0f;
    }
}