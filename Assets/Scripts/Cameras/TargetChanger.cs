using Cinemachine;
using Finish;
using UnityEngine;

namespace Cameras
{
    public class TargetChanger : MonoBehaviour
    {
        [SerializeField] private Transform finishedFollowTarget;
        [SerializeField] private Transform finishedLookTarget;
        [SerializeField] private float yOffsetAfterCreation = 4f;
        
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
                Debug.Log("Created");
                finishedFollowTarget.transform.Translate(Vector3.up * yOffsetAfterCreation);
            });
        }
    }
}