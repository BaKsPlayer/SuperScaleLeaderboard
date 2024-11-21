using UnityEngine;

namespace SC.UI.View
{
    public static class WindowBackgroundTypeExtensions
    {
        private static readonly Color WindowBackgroundTransparent = new Color(0, 0, 0, 0);
        private static readonly Color WindowBackgroundLight = new Color(0, 0, 0, 0.3f);    
        private static readonly Color WindowBackgroundDefault = new Color(0, 0, 0, 0.6f);  
        private static readonly Color WindowBackgroundDark = new Color(0, 0, 0, 0.8f); 

        public static Color GetColor(this WindowBackgroundType backgroundType)
        {
            switch (backgroundType)
            {
                case WindowBackgroundType.Transparent:
                    return WindowBackgroundTransparent;
                case WindowBackgroundType.Light:
                    return WindowBackgroundLight;
                case WindowBackgroundType.Default:
                    return WindowBackgroundDefault;
                case WindowBackgroundType.Dark:
                    return WindowBackgroundDark;
                default:
                    Debug.LogError("Unexpected background type");
                    return WindowBackgroundDefault;
            }
        }
    }
}