using System;
using ShootTheRagdoll.Input;
using ShootTheRagdoll.Player;
using UnityEngine;

namespace ShootTheRagdoll
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
