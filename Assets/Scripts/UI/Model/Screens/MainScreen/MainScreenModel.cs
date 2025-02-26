using SC.Enums;
using SC.Managers;
using SC.ServerInteraction;
using SC.UI.Model.Windows.Leaderboard;
using SC.UI.View.Leaderboard;
using SC.UI.View.Screens.MainScreen;

namespace SC.UI.Model.Screens.MainScreen
{
    public class MainScreenModel : IMainScreenViewModel
    {
        private readonly GuiManager _guiManager;
        private readonly IServerConnector _serverConnector;
        private readonly SceneManager _sceneManager;

        public MainScreenModel(GuiManager guiManager, IServerConnector serverConnector, SceneManager sceneManager)
        {
            _guiManager = guiManager;
            _serverConnector = serverConnector;
            _sceneManager = sceneManager;
        }

        public void OpenLeaderboardWindow()
        {
            var leaderboardModel = new LeaderboardWindowModel(_guiManager, _serverConnector);
            var window = _guiManager.ShowWindow<LeaderboardWindowView>();
            window.Init(leaderboardModel);
        }

        public void ReloadGame()
        {
            _sceneManager.LoadScene(SceneType.Loading);
        }
    }
}