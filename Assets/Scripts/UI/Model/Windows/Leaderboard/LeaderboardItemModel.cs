using SC.UI.View.Leaderboard;
using UnityEngine;

namespace SC.UI.Model.Windows.Leaderboard
{
    public class LeaderboardItemModel : ILeaderboardItemViewModel
    {
        public bool IsPlayer { get; }

        public int Rank { get; }
        public Sprite RankBadgeSprite { get; }

        public Color AvatarBackgroundColor { get; }
        public Sprite AvatarSprite { get; }

        public Sprite FlagSprite { get; }

        public string PlayerName { get; }

        public int PointsCount { get; }

        public bool IsVip { get; }

        public LeaderboardItemModel(RankDto rankDto, bool isPlayer, Sprite rankBadge, Sprite avatar, Sprite countryFlag)
        {
            IsPlayer = isPlayer;

            Rank = rankDto.ranking;
            RankBadgeSprite = rankBadge;

            AvatarBackgroundColor = GetAvatarBackgroundColor(rankDto.player.characterColor);
            AvatarSprite = avatar;

            FlagSprite = countryFlag;

            PlayerName = rankDto.player.username;

            PointsCount = rankDto.points;

            IsVip = rankDto.player.isVip;
        }

        private Color GetAvatarBackgroundColor(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out Color color))
            {
                return color;
            }
            
            return Color.white;
        }
    }
}