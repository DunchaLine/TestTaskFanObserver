using UnityEngine;

using Zenject;

namespace Observerable.Settings
{
    /// <summary>
    /// Инсталлер, который биндит настройки, переданные ему
    /// </summary>
    [CreateAssetMenu(fileName = "New ObserverableSettings", menuName = "ObserverableSettings/New Desktop Settings", order = 0)]
    public class DesktopObservableSettings : ScriptableObjectInstaller<DesktopObservableSettings>
    {
        [SerializeField]
        private ObserveSettings _observeSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IObservableSettings>().FromInstance(_observeSettings).AsSingle();
        }
    }
}
