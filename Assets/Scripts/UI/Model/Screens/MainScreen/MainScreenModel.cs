using System.Collections.Generic;
using SC.Managers;
using SC.ServerInteraction;
using SC.UI.Model.Windows.Leaderboard;
using SC.UI.View.Leaderboard;
using SC.UI.View.Screens.MainScreen;
using UnityEngine;

namespace SC.UI.Model.Screens.MainScreen
{
    public class MainScreenModel : IMainScreenViewModel
    {
        private GuiManager _guiManager;
        private IServerConnector _serverConnector;
        private SceneManager _sceneManager;

        public MainScreenModel(GuiManager guiManager, IServerConnector serverConnector, SceneManager sceneManager)
        {
            _guiManager = guiManager;
            _serverConnector = serverConnector;
            _sceneManager = sceneManager;
        }

        public void OpenLeaderboardWindow()
        {
            _serverConnector.SendRequest("GetLeaderboardData", HandleLeaderboardDataRequest);
        }

        public void ReloadGame()
        {
            _sceneManager.LoadScene(SceneType.Loading);
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

            var leaderboardModel = new LeaderboardWindowModel(leaderboardItems);
            var window = _guiManager.ShowWindow<LeaderboardWindowView>();
            window.Init(leaderboardModel);
        }
    }
}