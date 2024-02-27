using Observerable.Gameplay;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Observerable.Interfaces
{
    /// <summary>
    /// Интерфейс для просмотра актора
    /// </summary>
    public interface IObservableActor
    {
        public Observer Observer { get; }

        public void Zoom(InputAction.CallbackContext context);

        public void Look(Vector2 value);

        public void StartLook(bool isLook);
    }
}
