using SC.Managers;
using SC.UI.Model.Screens.LoadingScreen;
using SC.UI.View.Screens.LoadingScreen;
using UnityEngine;
using Zenject;

namespace SC.Utils
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GuiManager _guiMnager;
        private SceneManager _sceneManager;

        [Inject]
        private void Construct(GuiManager guiManager, SceneManager sceneManager)
        {
            _guiMnager = guiManager;
            _sceneManager = sceneManager;
        }

        private void Start()
        {
            var screen = _guiMnager.ShowScreen<LoadingScreenView>();
            screen.Init(new LoadingScreenModel(_sceneManager));
        }
    }
}