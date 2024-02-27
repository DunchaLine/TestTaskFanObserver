using Observerable.Interfaces;

using UnityEngine;
using UnityEngine.InputSystem;

using Zenject;

namespace Observerable.Controller
{
    /// <summary>
    /// Методы из этого класса вызываются через события, которые находятся в PlayerInput 
    /// </summary>
    public class DesktopObservable : MonoBehaviour
    {
        private IObservableActor _observerable;

        [Inject]
        public void Init(IObservableActor observable)
        {
            _observerable = observable;
        }

        /// <summary>
        /// Метод начала просмотра вызывается при нажатии ПКМ
        /// </summary>
        /// <param name="context"></param>
        public void StartLook(InputAction.CallbackContext context)
        {
            if (context.started)
                _observerable?.StartLook(true);
            else if (context.canceled)
                _observerable?.StartLook(false);
        }

        /// <summary>
        /// Метод просмотра вызывается при зажатии ПКМ
        /// </summary>
        /// <param name="context"></param>
        public void Look(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            _observerable?.Look(value);
        }

        /// <summary>
        /// Метод зума вызывается при скролле колеса
        /// </summary>
        /// <param name="context"></param>
        public void Zoom(InputAction.CallbackContext context)
        {
            _observerable?.Zoom(context);
        }
    }
}
