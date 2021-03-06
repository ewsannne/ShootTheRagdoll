using System;
using ShootTheRagdoll.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ShootTheRagdoll.Input
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

        private bool ShootButtonHold => Mathf.Approximately(_shootAction.ReadValue<float>(), 1f);
        

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
            _rotateCameraAction = _playerInput.currentActionMap.FindAction(ROTATE_CAMERA_ACTION_NAME);
        }
        
        
        public void ActivatePointerInput()
        {
            _moveAction.Enable();
            _shootAction.Enable();
        }
        
        
        public void DeactivatePointerInput()
        {
            _moveAction.Disable();
            _shootAction.Disable();
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
            _rotateCameraAction = _playerInput.currentActionMap.FindAction(ROTATE_CAMERA_ACTION_NAME);
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
            OnShootTriggered();
        }
        
        
        private void OnShootTriggered()
        {
            ShootTriggered?.Invoke();
        }
        
        
        private void Update()
        {
            if (ShootButtonHold)
            {
                OnShootTriggered();
            }
        }
    }
}
