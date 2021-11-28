using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll.Utility
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : Singleton<InputManager>
    {
        private const string MOVE_ACTION_NAME = "Move";
        private const string SHOOT_ACTION_NAME = "Shoot";
        private const string ROTATE_CAMERA_ACTION_NAME = "Rotate Camera";
        
        private PlayerInput _playerInput;

        private InputAction _moveAction;
        private InputAction _shootAction;
        private InputAction _rotateCameraAction;

        public event Action MoveTriggered;
        public event Action ShootTriggered;

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
            _rotateCameraAction = _playerInput.actions.FindAction(ROTATE_CAMERA_ACTION_NAME);
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
        }


        private void GetActions()
        {
            _moveAction = _playerInput.actions.FindAction(MOVE_ACTION_NAME);
            _shootAction = _playerInput.actions.FindAction(SHOOT_ACTION_NAME);
            _rotateCameraAction = _playerInput.actions.FindAction(ROTATE_CAMERA_ACTION_NAME);
        }


        private void ConnectActionsWithEvents()
        {
            _moveAction.performed += OnMoveTriggered;
            _shootAction.performed += OnShootTriggered;
        }


        private void OnMoveTriggered(InputAction.CallbackContext context)
        {
            MoveTriggered?.Invoke();
        }
        
        
        private void OnShootTriggered(InputAction.CallbackContext context)
        {
            ShootTriggered?.Invoke();
        }
    }
}
