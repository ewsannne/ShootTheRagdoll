using UnityEngine;
using UnityEngine.UI;

namespace ShootTheRagdoll.UI
{
    [RequireComponent(typeof(CanvasScaler))]
    public class ReferenceResolutionSetter : MonoBehaviour
    {
        private void Awake()
        {
            SetReferenceResolution();
        }


        private void SetReferenceResolution()
        {
            Vector2 screenResolution = new Vector2(Screen.width, Screen.height);
            GetComponent<CanvasScaler>().referenceResolution = screenResolution;
        }
    }
}
