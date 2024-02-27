using Observerable.Controller;
using Observerable.Interfaces;

using UnityEngine;

using Zenject;

namespace Observerable.Gameplay
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField]
        private IObservableSettings _settings;

        public override void InstallBindings()
        {
            // заменить на подгрузку по Adressables
            Container.Bind<Actor.Actor>().FromComponentInHierarchy().AsSingle();
            ///////////////////////////////////////////

            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle().NonLazy();
            Container.Bind<Observer>().FromComponentInHierarchy().AsCached();

            IObservableActor obsHandler = new DesktopObserverableHandler();
            Container.BindInterfacesAndSelfTo<DesktopObserverableHandler>().FromInstance(obsHandler);
        }

        public override void Start()
        {
            Container.Inject(Container.Resolve<IObservableActor>());
        }
    }
}
