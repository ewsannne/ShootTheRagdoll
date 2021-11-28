using UnityEngine;

namespace ShootTheRagdoll.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private const string ANIMATOR_SPEED_PARAMETER = "Speed";
        private readonly int _animatorSpeedParameterHash = Animator.StringToHash(ANIMATOR_SPEED_PARAMETER);
        
        private Animator _animator;


        public void AdjustMovementAnimation(float speedRatio)
        {
            _animator.SetFloat(_animatorSpeedParameterHash, speedRatio);
        }
        

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
