using DG.Tweening;
using ShootTheRagdoll.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace ShootTheRagdoll.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class TowerPanel : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 0.4f;
        [SerializeField] private AnimationCurve easeCurve;
        [SerializeField] private ShootingZone shootingZone;

        private RectTransform _rectTransform;
        private Image _image;

        private float _defaultAlpha;

        
        public void Disappear()
        {
            _image.DOFade(0f, fadeDuration);
            _rectTransform.DOScale(Vector3.zero, fadeDuration).SetEase(easeCurve);
        }


        private void Appear()
        {
            _image.DOFade(_defaultAlpha, fadeDuration);
            _rectTransform.DOScale(Vector3.one, fadeDuration).SetEase(easeCurve);
        }
        

        private void Awake()
        {
            GetComponents();
            SubscribeAppearOnPlayerEnterTower();
            SetDefaultAlpha();
        }


        private void GetComponents()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
        }

        
        private void SubscribeAppearOnPlayerEnterTower()
        {
            shootingZone.PlayerEntered += Appear;
        }


        private void SetDefaultAlpha()
        {
            _defaultAlpha = _image.color.a;
        }
    }
}
