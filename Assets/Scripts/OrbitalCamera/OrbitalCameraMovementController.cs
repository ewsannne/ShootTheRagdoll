using Cinemachine;
using ShootTheRagdoll.Utility;
using UnityEngine;

namespace ShootTheRagdoll.OrbitalCamera
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class OrbitalCameraMovementController : MonoBehaviour
    {
        [SerializeField] private OrbitalCameraSensitivitySettingsSO sensitivitySettings;
        
        private CinemachineOrbitalTransposer _orbitalTransposer;
        private float _sensitivity;

        
        private void Awake()
        {
            GetOrbitalTransposer();
            GetSensitivity();
        }


        private void GetOrbitalTransposer()
        {
            CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _orbitalTransposer = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        }
        
        
        private void GetSensitivity()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            _sensitivity = sensitivitySettings.DesktopSensitivity;
#elif UNITY_ANDROID || UNITY_IOS
            _sensitivity = sensitivitySettings.MobileSensitivity;
#endif
        }


        private void Update()
        {
            SetOrbitalCameraAxisValue();
        }


        private void SetOrbitalCameraAxisValue()
        {
            float adjustedAxisValue = InputManager.Instance.CameraMovementDelta * _sensitivity;
            _orbitalTransposer.m_XAxis.m_InputAxisValue = adjustedAxisValue;
        }
    }
}