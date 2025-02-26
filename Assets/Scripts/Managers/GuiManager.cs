using SC.UI.View;
using SC.Utils;
using UnityEngine;

namespace SC.Managers
{
    public class GuiManager
    {
        public SpriteDatabase SpriteDatabase { get; }

        private readonly Canvas _guiCanvas;
        private readonly WindowParent _windowParentPrefab;
        private readonly GuiDatabase _guiDatabase;
        
        private BaseScreen _currentScreen;

        private GuiManager(Canvas guiCanvas, WindowParent windowParentPrefab)
        {
            _guiCanvas = guiCanvas;
            _windowParentPrefab = windowParentPrefab;

            SpriteDatabase = Resources.Load<SpriteDatabase>($"Databases/{nameof(SC.Utils.SpriteDatabase)}");
            _guiDatabase = Resources.Load<GuiDatabase>($"Databases/{nameof(GuiDatabase)}");
        }

        public T ShowWindow<T>() where T : BaseWindow
        {
            var windowParent = Object.Instantiate(_windowParentPrefab, _currentScreen.transform);
            var window = Object.Instantiate(_guiDatabase.GetWindow<T>(), windowParent.transform);

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
            var screen = Object.Instantiate(screenPrefab, _guiCanvas.transform);
            _currentScreen = screen;

            return screen;
        }
    }
}