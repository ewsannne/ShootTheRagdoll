using UnityEngine;
using UnityEngine.UI;

namespace ShootTheRagdoll.Utility
{
    public class ScreenSetup : MonoBehaviour
    {
        [SerializeField] private CanvasScaler canvasScaler;
        
        
        private void Awake()
        {
            SetReferenceResolution();
            SetTargetFps();
            PreventSleepForMobiles();
        }


        private void SetReferenceResolution()
        {
            Vector2 screenResolution = new Vector2(Screen.width, Screen.height);
            canvasScaler.referenceResolution = screenResolution;
        }


        private void SetTargetFps()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
#elif UNITY_ANDROID || UNITY_IOS
            Application.targetFrameRate = 60;
#endif
        }


        private void PreventSleepForMobiles()
        {
#if UNITY_ANDROID || UNITY_IOS
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
        }
    }
}
