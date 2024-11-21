using SC.Managers;
using SC.ServerInteraction;
using SC.ServerInteraction.Fake;
using UnityEngine;
using Zenject;

namespace SC.Utils
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GuiManager _guiManager;

        public override void InstallBindings()
        {
            BindGuiManager();
            BindServerConnection();
            BindSceneManager();
        }

        private void BindGuiManager()
        {
            var guiManagerInstance = Container.InstantiatePrefabForComponent<GuiManager>(_guiManager);
            Container.Bind<GuiManager>().FromInstance(guiManagerInstance);
        }

        private void BindServerConnection()
        {
            Container.Bind<IServerConnector>().To<FakeServerConnector>().AsSingle();
            Container.Bind<FakeServer>().AsSingle();
        }

        private void BindSceneManager()
        {
            Container.Bind<SceneManager>().AsSingle().NonLazy();
        }
    }
}