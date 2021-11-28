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
            InputManager.Instance.ShootPressed += Shoot;
        }


        private void Shoot()
        {
            Quaternion rotation = Quaternion.LookRotation((aimTargetTransform.position - shootPointTransform.position).normalized);
            GameObject proj = Instantiate(projectilePrefab, shootPointTransform.position, rotation);
        }
    }
}
