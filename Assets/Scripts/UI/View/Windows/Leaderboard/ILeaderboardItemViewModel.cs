using UnityEngine;

namespace SC.UI.View.Leaderboard
{
    public interface ILeaderboardItemViewModel
    {
        bool IsPlayer { get; }
        int Rank { get; }
        Sprite RankBadgeSprite { get; }
        Color AvatarBackgroundColor { get; }
        Sprite AvatarSprite { get; }
        Sprite FlagSprite { get; }
        string PlayerName { get; }
        int PointsCount { get; }
        bool IsVip { get; }
    }
}