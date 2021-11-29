using System.Collections;
using RayFire;
using ShootTheRagdoll.Input;
using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    [RequireComponent(typeof(RayfireGun))]
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerWeaponFireRateSettingsSO fireRateSettings;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform shootPointTransform;
        [SerializeField] private Transform aimTargetTransform;

        private RayfireGun _rayfireGun;

        private WaitForSeconds _waitForShootInterval;
        private bool _isOnCooldown;
        

        private void Start()
        {
            GetRayfireGun();
            SubscribeToShootTriggeredEvent();
            GetShootInterval();
        }


        private void GetRayfireGun()
        {
            _rayfireGun = GetComponent<RayfireGun>();
        }
        

        private void SubscribeToShootTriggeredEvent()
        {
            InputManager.Instance.ShootTriggered += Shoot;
        }


        private void GetShootInterval()
        {
            _waitForShootInterval = new WaitForSeconds(1f / fireRateSettings.ShotsPerSecond);
        }


        private void Shoot()
        {
            if (_isOnCooldown)
            {
                return;
            }
            
            SpawnProjectile();

            StartCooldown();
        }


        private void SpawnProjectile()
        {
            Vector3 directionToAimTarget = (aimTargetTransform.position - shootPointTransform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(directionToAimTarget);
            
            PlayerProjectile projectile = Instantiate(projectilePrefab, shootPointTransform.position, rotation)
                .GetComponent<PlayerProjectile>();
            
            projectile.CollidedWithRock += ShootRock;
        }
        

        private void StartCooldown()
        {
            _isOnCooldown = true;
            StartCoroutine(CoolingDown());
        }


        private IEnumerator CoolingDown()
        {
            yield return _waitForShootInterval;

            _isOnCooldown = false;
        }


        private void ShootRock(Vector3 hitPosition)
        {
            Vector3 direction = -(shootPointTransform.position - hitPosition).normalized;
            _rayfireGun.Shoot(shootPointTransform.position, direction);
        }
    }
}
