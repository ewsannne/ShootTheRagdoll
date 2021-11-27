using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : Singleton<InputManager>
    {
        private PlayerInput _playerInput;

        private InputAction _moveAction;
        private InputAction _shootAction;
        private InputAction _rotateCameraAction;

        public event Action MovePressed;
        public event Action ShootPressed;

        public float CameraMovementDelta => _rotateCameraAction.ReadValue<float>();


        public void SwitchToOnTowerActions()
        {
            SwitchActionMap("OnTheTower");
        }


        public void SwitchToOnGroundActions()
        {
            SwitchActionMap("OnTheGround");
        }


        private void SwitchActionMap(string newMap)
        {
            _playerInput.SwitchCurrentActionMap(newMap);
            _rotateCameraAction = _playerInput.actions.FindAction("Rotate Camera");
        }


        protected override void Awake()
        {
            base.Awake();
            
            GetPlayerInput();
            GetActions();
            ConnectActionsWithEvents();
        }


        private void GetPlayerInput()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.actions.Enable();
        }


        private void GetActions()
        {
            _moveAction = _playerInput.actions.FindAction("Move");
            _shootAction = _playerInput.actions.FindAction("Shoot");
            _rotateCameraAction = _playerInput.actions.FindAction("Rotate Camera");
        }


        private void ConnectActionsWithEvents()
        {
            _moveAction.performed += OnMovePressed;
            _shootAction.performed += OnShootPressed;
        }


        private void OnMovePressed(InputAction.CallbackContext context)
        {
            MovePressed?.Invoke();
        }
        
        
        private void OnShootPressed(InputAction.CallbackContext context)
        {
            ShootPressed?.Invoke();
        }
    }
}
