using ShootTheRagdoll.Utility;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private LayerMask walkableLayers;
        
        private NavMeshAgent _agent;
        private PlayerAnimator _playerAnimator;


        private void Start()
        {
            GetComponents();
            SubscribeToMoveTriggeredEvent();
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

        
        private void Move()
        {
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit, 40f, walkableLayers))
            {
                _agent.SetDestination(hit.point);
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
