using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

namespace SC.UI.View
{
    public abstract class BaseWindow : MonoBehaviour
    {
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private Button _closeButton;

        public virtual WindowBackgroundType BackgroundType => WindowBackgroundType.Default;
        public event Action OnClosed;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }

        public void Open()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, _animationDuration).SetEase(Ease.OutBack);
        }

        public void Close()
        {
            transform.DOScale(Vector3.zero, _animationDuration).SetEase(Ease.InBack).OnComplete(() => OnClosed?.Invoke());
        }
    }
}