using BigBall;
using Cinemachine;
using UnityEngine;

namespace Finish
{
    public class CameraTargetChanger : MonoBehaviour
    {
        [SerializeField] private Transform finishedFollowTarget;
        [SerializeField] private Transform finishedLookTarget;
        private CinemachineVirtualCamera _cam;

        private void Start()
        {
            _cam = FindObjectOfType<CinemachineVirtualCamera>();
            
            FinishLine.OnFinishReached.AddListener(() =>
            {
                _cam.Follow = finishedFollowTarget;
                _cam.LookAt = finishedLookTarget;
            });
            BigBallCreator.OnBigBallCreated.AddListener(() =>
            {
                _cam.LookAt = FindObjectOfType<BigBallScaleChanger>().transform;
                _cam.GetComponent<Animation>().Play();
            });
        }
    }
}