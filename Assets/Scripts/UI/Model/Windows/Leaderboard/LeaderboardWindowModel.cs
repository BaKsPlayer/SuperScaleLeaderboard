using System.Collections.Generic;
using System.Linq;
using SC.Managers;
using SC.ServerInteraction;
using SC.UI.View.Leaderboard;
using SC.Utils;
using UnityEngine;

namespace SC.UI.Model.Windows.Leaderboard
{
    public class LeaderboardWindowModel : ILeaderboardWindowViewModel
    {
        public ReactiveCollection<ILeaderboardItemViewModel> ItemModels { get; }

        private readonly GuiManager _guiManager;
        private readonly IServerConnector _serverConnector;

        public LeaderboardWindowModel(GuiManager guiManager, IServerConnector serverConnector)
        {
            ItemModels = new ReactiveCollection<ILeaderboardItemViewModel>();
            
            _guiManager = guiManager;
            _serverConnector = serverConnector;
            
            _serverConnector.SendRequest(ServerMethods.GET_LEADERBOARD_DATA, HandleLeaderboardDataRequest);
        }
        
        private void HandleLeaderboardDataRequest(string data)
        {
            var leaderboardDto = JsonUtility.FromJson<LeaderboardDto>(data);

            var leaderboardItems = new List<ILeaderboardItemViewModel>();
            foreach (var rankDto in leaderboardDto.ranking)
            {
                var isPlayer = leaderboardDto.playerUID == rankDto.player.uid;

                Sprite rankBadge = null;
                if (rankDto.ranking <= 3)
                {
                    rankBadge = _guiManager.SpriteDatabase.GetRankBadge(rankDto.ranking);
                }

                var avatar = _guiManager.SpriteDatabase.GetCharacterAvatar(rankDto.player.characterIndex);
                var countryFlag = _guiManager.SpriteDatabase.GetCountryFlag(rankDto.player.countryCode);

                var model = new LeaderboardItemModel(rankDto, isPlayer, rankBadge, avatar, countryFlag);
                leaderboardItems.Add(model);
            }

            ItemModels.Clear();
            ItemModels.AddRange(leaderboardItems.OrderBy(item => item.Rank));
        }

        public void Dispose()
        {
            _serverConnector.KillRequest(ServerMethods.GET_LEADERBOARD_DATA);
        }
    }
}