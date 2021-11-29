using UnityEngine;

namespace ShootTheRagdoll.Player.Movement
{
    [CreateAssetMenu(fileName = "PlayerMoveSpeedSettings", menuName = "Settings/Player/Movement Speed")]
    public class PlayerMoveSpeedSettingsSO : ScriptableObject
    {
        [SerializeField, Range(4f, 8f)] private float movementSpeed = 6f;

        public float MovementSpeed => movementSpeed;
    }
}
