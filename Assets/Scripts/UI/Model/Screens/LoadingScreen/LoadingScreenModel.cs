using SC.Enums;
using SC.Managers;
using SC.UI.View.Screens.LoadingScreen;

namespace SC.UI.Model.Screens.LoadingScreen
{
    public class LoadingScreenModel : ILoadingSceenViewModel
    {
        private SceneManager _sceneManager;

        public LoadingScreenModel(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        public void StartGame()
        {
            _sceneManager.LoadScene(SceneType.Main);
        }
    }
}