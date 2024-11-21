using SC.UI.View;
using SC.Utils;
using UnityEngine;

namespace SC.Managers
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField] private SpriteDatabase _spriteDatabase;
        [SerializeField] private GuiDatabase _guiDatabase;
        [SerializeField] private WindowParent _windowParentPrefab;
        [SerializeField] private Canvas _guiCanvasPrefab;

        public SpriteDatabase SpriteDatabase => _spriteDatabase;

        private BaseScreen _currentScreen;
        private Canvas _guiCanvas;

        private void Awake()
        {
            _guiCanvas = Instantiate(_guiCanvasPrefab);
            DontDestroyOnLoad(_guiCanvas);
        }

        public T ShowWindow<T>() where T : BaseWindow
        {
            var windowParent = Instantiate(_windowParentPrefab, _currentScreen.transform);
            var window = Instantiate(_guiDatabase.GetWindow<T>(), windowParent.transform);

            windowParent.SetWindow(window);
            window.Open();

            return window;
        }

        public T ShowScreen<T>() where T : BaseScreen
        {
            if (_currentScreen != null && _currentScreen.GetType() == typeof(T))
            {
                return _currentScreen as T;
            }

            if (_currentScreen != null)
            {
                _currentScreen.Close();
            }

            var screenPrefab = _guiDatabase.GetScreen<T>();
            var screen = Instantiate(screenPrefab, _guiCanvas.transform);
            _currentScreen = screen;

            return screen;
        }
    }
}