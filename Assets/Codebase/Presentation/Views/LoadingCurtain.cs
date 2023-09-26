using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Presentation.Views
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private Image _progressBar;
        [SerializeField] private Image _loadingIndicator;
        [SerializeField] private float _zRotationSpeed;
        
        private Tween _loadingIndicatorTween;

        public void Show()
        {
            _loadingIndicatorTween?.Kill();

            _loadingIndicatorTween = _loadingIndicator.transform
                .DOLocalRotate(new Vector3(0, 0, _zRotationSpeed), 1f, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1)
                .SetUpdate(true);

            _mainCanvas.enabled = true;
        }

        public void Hide()
        {
            _mainCanvas.enabled = false;
            _loadingIndicatorTween?.Kill();
        }

        public void HandleProgress(float progressAsPercentage) => _progressBar.fillAmount = progressAsPercentage;
    }
}