using UnityEngine;

namespace Literals
{
    public static class Parameters
    {
        public static readonly int EnterDamping = Animator.StringToHash("OnEnterDampingZone");
        public static readonly int ExitDamping = Animator.StringToHash("OnExitDampingZone");
        public static readonly int BigBallCreated = Animator.StringToHash("OnBigBallCreated");
        public static readonly int OnEndLevel = Animator.StringToHash("OnEndLevel");
    }
}