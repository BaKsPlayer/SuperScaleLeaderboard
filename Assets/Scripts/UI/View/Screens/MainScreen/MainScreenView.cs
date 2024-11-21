using UnityEngine;
using UnityEngine.UI;

namespace SC.UI.View.Screens.MainScreen
{
    public class MainScreenView : BaseScreen
    {
        [SerializeField] private Button _reloadGameButton;

        private IMainScreenViewModel _model;

        private void Awake()
        {
            _reloadGameButton.onClick.AddListener(ReloadGame);
        }

        public void Init(IMainScreenViewModel model)
        {
            _model = model;
            OpenLeaderboardWindow();
        }

        private void OpenLeaderboardWindow()
        {
            _model.OpenLeaderboardWindow();
        }

        private void ReloadGame()
        {
            _model.ReloadGame();
        }

        private void OnDestroy()
        {
            _reloadGameButton.onClick.RemoveAllListeners();
        }
    }
}