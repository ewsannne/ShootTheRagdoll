using ShootTheRagdoll.Input;
using ShootTheRagdoll.Utility;
using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform shootPointTransform;
        [SerializeField] private Transform aimTargetTransform;


        private void Start()
        {
            SubscribeToShootTriggeredEvent();
        }


        private void SubscribeToShootTriggeredEvent()
        {
            InputManager.Instance.ShootTriggered += Shoot;
        }


        private void Shoot()
        {
            Vector3 directionToAimTarget = (aimTargetTransform.position - shootPointTransform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(directionToAimTarget);
            
            Instantiate(projectilePrefab, shootPointTransform.position, rotation);
        }
    }
}
