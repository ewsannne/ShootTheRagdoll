using System;
using ShootTheRagdoll.Input;
using ShootTheRagdoll.Player.Movement;
using UnityEngine;

namespace ShootTheRagdoll.Tower
{
    public class ShootingZone : MonoBehaviour
    {
        [SerializeField] private Transform leavePositionTransform;
        [SerializeField] private PlayerMovement playerMovement;

        public event Action PlayerEntered;
        
        
        public void MakePlayerLeave()
        {
            playerMovement.LeaveTower(leavePositionTransform.position);
            InputManager.Instance.SwitchToOnGroundActions();
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            OnPlayerEnteredTower();
        }


        private void OnPlayerEnteredTower()
        {
            PlayerEntered?.Invoke();
            InputManager.Instance.SwitchToOnTowerActions();
        }
    }
}
