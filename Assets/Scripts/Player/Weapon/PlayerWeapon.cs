using System.Collections;
using ShootTheRagdoll.Input;
using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerWeaponFireRateSettingsSO fireRateSettings;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform shootPointTransform;
        [SerializeField] private Transform aimTargetTransform;

        private WaitForSeconds _waitForShootInterval;

        private bool _isOnCooldown;
        

        private void Start()
        {
            SubscribeToShootTriggeredEvent();
            GetShootInterval();
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
            
            Vector3 directionToAimTarget = (aimTargetTransform.position - shootPointTransform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(directionToAimTarget);
            
            Instantiate(projectilePrefab, shootPointTransform.position, rotation);

            _isOnCooldown = true;
            StartCoroutine(CoolingDown());
        }


        private IEnumerator CoolingDown()
        {
            yield return _waitForShootInterval;

            _isOnCooldown = false;
        }
    }
}
