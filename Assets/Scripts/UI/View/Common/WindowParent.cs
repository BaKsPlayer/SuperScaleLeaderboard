using UnityEngine;
using UnityEngine.UI;

namespace SC.UI.View
{
    public class WindowParent : MonoBehaviour
    {
        [SerializeField] private Image _background;

        private BaseWindow _window;

        public void SetWindow(BaseWindow window)
        {
            _window = window;
            SetBackground(window.BackgroundType);
            name = $"{window.name}Parent";

            if (_window != null)
            {
                _window.OnClosed += OnWindowClosed;
            }
        }

        private void SetBackground(WindowBackgroundType backgroundType)
        {
            _background.color = backgroundType.GetColor();
        }

        private void OnWindowClosed()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (_window != null)
            {
                _window.OnClosed -= OnWindowClosed;
            }
        }
    }
}