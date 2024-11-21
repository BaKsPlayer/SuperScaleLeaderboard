using System;

namespace SC.UI.Model.Windows.Leaderboard
{
    [Serializable]
    public class PlayerDto
    {
        public string uid;
        public string username;
        public bool isVip;
        public string countryCode;
        public string characterColor;
        public int characterIndex;
    }
}