using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    [CreateAssetMenu(fileName = "PlayerWeaponFireRateSettings", menuName = "Settings/Player/Fire Rate")]
    public class PlayerWeaponFireRateSettingsSO : ScriptableObject
    {
        [SerializeField, Range(2f, 10f)] private float shotsPerSecond = 6f;

        public float ShotsPerSecond => shotsPerSecond;
    }
}
