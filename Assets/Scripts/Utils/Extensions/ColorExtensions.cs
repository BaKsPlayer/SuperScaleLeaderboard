using UnityEngine;

namespace SC.Utils
{
    public static class ColorExtensions
    {
        public static Color HexToColor(this string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Color.white;

            hex = hex.TrimStart('#');

            if (hex.Length == 6)
            {
                if (TryParseHex(hex.Substring(0, 2), out byte r) &&
                    TryParseHex(hex.Substring(2, 2), out byte g) &&
                    TryParseHex(hex.Substring(4, 2), out byte b))
                {
                    return new Color32(r, g, b, 255);
                }
            }
            else if (hex.Length == 8)
            {
                if (TryParseHex(hex.Substring(0, 2), out byte r) &&
                    TryParseHex(hex.Substring(2, 2), out byte g) &&
                    TryParseHex(hex.Substring(4, 2), out byte b) &&
                    TryParseHex(hex.Substring(6, 2), out byte a))
                {
                    return new Color32(r, g, b, a);
                }
            }

            return Color.white;
        }

        private static bool TryParseHex(string hex, out byte value)
        {
            return byte.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out value);
        }
    }
}