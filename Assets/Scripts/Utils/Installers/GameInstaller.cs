using SC.Managers;
using SC.ServerInteraction;
using SC.ServerInteraction.Fake;
using SC.UI.View;
using UnityEngine;
using Zenject;

namespace SC.Utils
{
    public class GameInstaller : MonoInstaller
    { 
        [SerializeField] private Canvas _guiCanvasPrefab;
        [SerializeField] private WindowParent _windowParentPrefab;

        public override void InstallBindings()
        {
            BindGuiManager();
            BindServerConnection();
            BindSceneManager();
        }

        private void BindGuiManager()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(_guiCanvasPrefab);
            Container.Bind<GuiManager>().AsSingle().WithArguments(canvasInstance, _windowParentPrefab);
        }

        private void BindServerConnection()
        {
            Container.Bind<FakeServer>().To<FakeServer>().AsSingle();
            Container.Bind<IServerConnector>().To<FakeServerConnector>().AsTransient();
        }

        private void BindSceneManager()
        {
            Container.Bind<SceneManager>().AsTransient();
        }
    }
}