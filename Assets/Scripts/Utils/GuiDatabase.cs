using System.Collections.Generic;
using System.Linq;
using SC.UI.View;
using UnityEngine;

namespace SC.Utils
{
    [CreateAssetMenu(fileName = "GuiDatabase", menuName = "Database/GuiDatabase")]
    public class GuiDatabase : ScriptableObject
    {
        [SerializeField] private List<BaseWindow> _windows;
        [SerializeField] private List<BaseScreen> _screens;

        public T GetWindow<T>() where T : BaseWindow
        {
            var window = _windows.First(x => x.GetType() == typeof(T));
            if (window ==null)
            {
                Debug.LogError($"Window of type {typeof(T)} not found in the database.");
                return null;
            }

            return window as T;
        }

        public T GetScreen<T>() where T : BaseScreen
        {
            var screen = _screens.First(x => x.GetType() == typeof(T));
            if (screen == null)
            {
                Debug.LogError($"Screen of type {typeof(T)} not found in the database.");
                return null;
            }

            return screen as T;
        }
    }
}