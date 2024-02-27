using UnityEngine;

using Zenject;

namespace Observerable.Settings
{
    /// <summary>
    /// Инсталлер, отвечающий за подгрузку настроек для вращения вентилятора
    /// </summary>
    [CreateAssetMenu(fileName = "FanInteractableSettingsInstaller", menuName = "Installers/FanInteractableSettingsInstaller")]
    public class FanInteractableSettingsInstaller : ScriptableObjectInstaller<FanInteractableSettingsInstaller>
    {
        [SerializeField]
        private RotationInteractSettings _settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RotationInteractSettings>().FromInstance(_settings).AsSingle();
        }
    }
}