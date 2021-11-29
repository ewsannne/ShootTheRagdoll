using UnityEngine;

namespace ShootTheRagdoll.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class WorldPlacement : MonoBehaviour
    {
        [SerializeField] private RectTransform canvasRectTransform;
        [SerializeField] private Transform worldPositionTransform;
        [SerializeField] private new Camera camera;

        private RectTransform _rectTransform;


        private void Awake()
        {
            GetRectTransform();
        }


        private void GetRectTransform()
        {
            _rectTransform = GetComponent<RectTransform>();
        }


        private void Update()
        {
            Place();
        }


        private void Place()
        {
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(camera, worldPositionTransform.position);
            _rectTransform.anchoredPosition = screenPoint - canvasRectTransform.sizeDelta / 2f;
        }
    }
}
