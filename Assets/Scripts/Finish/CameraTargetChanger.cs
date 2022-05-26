using BigBall;
using Cinemachine;
using Literals;
using UI;
using UnityEngine;

namespace Finish
{
    /// <summary>
    /// Changes cinemachine camera's targets 
    /// </summary>
    public class CameraTargetChanger : MonoBehaviour
    {
        [SerializeField] private Transform bigBallCreationTarget;
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
                _cam.GetComponent<Animator>().SetTrigger(Parameters.BigBallCreated);
            }); 
            VictoryCanvas.OnEndLevel.AddListener(() =>
            {
                _cam.LookAt = bigBallCreationTarget;
                _cam.GetComponent<Animator>().SetTrigger(Parameters.OnEndLevel);
            });
        }
    }
}