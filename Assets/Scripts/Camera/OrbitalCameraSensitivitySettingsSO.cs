using UnityEngine;

namespace ShootTheRagdoll.Camera
{
    [CreateAssetMenu(fileName = "CameraSensitivitySettings", menuName = "Settings/Camera/Sensitivity")]
    public class OrbitalCameraSensitivitySettingsSO : ScriptableObject
    {
        [SerializeField, Range(0.5f, 2f)] private float desktopSensitivity = 1f;
        [SerializeField, Range(0.2f, 1f)] private float mobileSensitivity = 0.4f;

        public float DesktopSensitivity => desktopSensitivity;
        public float MobileSensitivity => mobileSensitivity;
    }
}
