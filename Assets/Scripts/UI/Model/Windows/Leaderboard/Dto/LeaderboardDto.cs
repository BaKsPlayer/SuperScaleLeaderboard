using System;

namespace SC.UI.Model.Windows.Leaderboard
{
    [Serializable]
    public class LeaderboardDto
    {
        public RankDto[] ranking;
        public string playerUID;
    }
}