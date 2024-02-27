using Observerable.Settings;

namespace Observerable.Interfaces
{
    /// <summary>
    /// Интерфейс для взаимодействия с объектами
    /// </summary>
    public interface IRotateInteractable
    {
        public RotationInteractSettings Settings { get; }

        public bool IsOn { get; }

        public void Interact(bool isOn);
    }
}
