using System.Collections;
using ShootTheRagdoll.Input;
using ShootTheRagdoll.Player.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace ShootTheRagdoll.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerMoveSpeedSettingsSO moveSpeedSettings;
        [SerializeField] private LayerMask walkableLayers;
        
        private NavMeshAgent _agent;
        private PlayerAnimator _playerAnimator;


        public void LeaveTower(Vector3 destination)
        {
            _agent.SetDestination(destination);
            InputManager.Instance.DeactivatePointerInput();
            
            StartCoroutine(LeavingTowerRoutine());
        }


        private IEnumerator LeavingTowerRoutine()
        {
            yield return new WaitUntil(() => _agent.isStopped);
            
            InputManager.Instance.ActivatePointerInput();
        }
        
        
        private void Start()
        {
            GetComponents();
            SubscribeToMoveTriggeredEvent();
            SetMovementSpeed();
        }


        private void GetComponents()
        {
            _agent = GetComponent<NavMeshAgent>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }


        private void SubscribeToMoveTriggeredEvent()
        {
            InputManager.Instance.MoveTriggered += Move;
        }


        private void SetMovementSpeed()
        {
            _agent.speed = moveSpeedSettings.MovementSpeed;
        }

        
        private void Move()
        {
            PointerWorldPosition pointerWorldPosition = PointerWorldPositionCalculator.Instance.GetPosition(walkableLayers);

            if (pointerWorldPosition.HasPosition)
            {
                _agent.SetDestination(pointerWorldPosition.Position);
            }
        }


        private void Update()
        {
            AdjustAnimation();
        }


        private void AdjustAnimation()
        {
            float speedRatio = _agent.velocity.magnitude / _agent.speed;
            _playerAnimator.AdjustMovementAnimation(speedRatio);
        }
    }
}
