using System;

namespace SC.UI.Model.Windows.Leaderboard
{
    [Serializable]
    public class RankDto
    {
        public PlayerDto player;
        public int ranking;
        public int points;
    }
}