using UnityEngine;
using UnityEngine.UI;

namespace SC.UI.View.Screens.LoadingScreen
{
    public class LoadingScreenView : BaseScreen
    {
        [SerializeField] private Button _startGameButton;

        private ILoadingSceenViewModel _model;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(StartGame);
        }

        public void Init(ILoadingSceenViewModel model)
        {
            _model = model;
        }

        private void StartGame()
        {
            _model.StartGame();
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveAllListeners();
        }
    }
}