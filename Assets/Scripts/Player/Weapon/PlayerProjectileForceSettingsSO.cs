using UnityEngine;

namespace ShootTheRagdoll.Player.Weapon
{
    [CreateAssetMenu(fileName = "PlayerProjectileForceSettings", menuName = "Settings/Player/ProjectileForce")]
    public class PlayerProjectileForceSettingsSO : ScriptableObject
    {
        [SerializeField] private float forceOnImpact;

        public float ForceOnImpact => forceOnImpact;
    }
}
