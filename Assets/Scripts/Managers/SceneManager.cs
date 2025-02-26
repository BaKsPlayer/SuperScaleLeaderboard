using SC.Enums;
using SC.ServerInteraction;
using SC.UI.Model.Screens.LoadingScreen;
using SC.UI.Model.Screens.MainScreen;
using SC.UI.View.Screens.LoadingScreen;
using SC.UI.View.Screens.MainScreen;
using UnityEngine;

namespace SC.Managers
{
    public class SceneManager 
    {
        private readonly GuiManager _guiManager;
        private readonly IServerConnector _serverConnector; 

        public SceneManager(GuiManager guiManager, IServerConnector serverConnector)
        {
            _guiManager = guiManager;
            _serverConnector = serverConnector;
        }

        public void LoadScene(SceneType sceneType)
        {
            switch (sceneType)
            {
                case SceneType.Loading:
                    var loadingScreen = _guiManager.ShowScreen<LoadingScreenView>();
                    loadingScreen.Init(new LoadingScreenModel(this));
                    break;
                case SceneType.Main:
                    var mainScreen = _guiManager.ShowScreen<MainScreenView>();
                    mainScreen.Init(new MainScreenModel(_guiManager, _serverConnector, this));
                    break;
                default:
                    Debug.LogError($"Unexpected scene type {sceneType}");
                    break;
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneType.ToString());
        }
    }
}