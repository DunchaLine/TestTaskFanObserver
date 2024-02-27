using Observerable.Gameplay;
using Observerable.Gameplay.Actor;
using Observerable.Interfaces;

using UnityEngine;
using UnityEngine.InputSystem;

using Zenject;

namespace Observerable.Controller
{
    public class DesktopObserverableHandler : IObservableActor, ITickable
    {
        private bool _isZoom = false;

        private float _zoomValue = 1f;

        private IObservableSettings _settings;

        private Actor _target;

        private Camera _currentCamera;

        public Observer Observer { get; private set; }

        [Inject]
        public void Init(IObservableSettings settings, Observer observer)
        {
            Debug.Log($"init observable handler");

            _settings = settings;
            Observer = observer;

            _target = observer.ActorTarget;
            _currentCamera = observer.CurrentCamera;
        }

        /// <summary>
        /// Начало вращения
        /// </summary>
        /// <param name="isLook">true - блокируется и скрывается курсор
        /// false - курсор разблокируется и возвращается видимость</param>
        public void StartLook(bool isLook)
        {
            if (isLook == true)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (isLook == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        /// <summary>
        /// Вращение родительского объекта камеры
        /// </summary>
        /// <param name="value">значение вращения</param>
        public void Look(Vector2 value)
        {
            if (Cursor.visible == true)
                return;

            // значение умножаем на сенсу; время на отрисовку фрейма для плавности
            value *= new Vector2(_settings.Sensitivity * Time.fixedDeltaTime, _settings.Sensitivity * Time.fixedDeltaTime);

            // вращаем по двум осям: по y нужно использовать World для избежания вращения по оси z
            Observer.transform.Rotate(0f, value.x, 0f, Space.World);
            Observer.transform.Rotate(value.y, 0f, 0f, Space.Self);
        }

        /// <summary>
        /// Зум камеры
        /// </summary>
        /// <param name="context">нажатие</param>
        public void Zoom(InputAction.CallbackContext context)
        {
            // пока идет вращение колеса, считываем значение и устанавливаем флаг зума в true
            if (context.performed)
            {
                _isZoom = true;
                _zoomValue = context.ReadValue<Vector2>().y;
            }
            // когда вращение колеса заканчивается, флаг меняем на false
            else if (context.canceled)
                _isZoom = false;
        }

        /// <summary>
        /// Смена зума
        /// </summary>
        private void ChangeZoom()
        {
            // получаем значение зума из:
            // текущего положения камеры по z + значение зума,
            // умноженное на сенсу зума и на время для отрисовки фрейма для плавности
            float newZ = _currentCamera.transform.localPosition.z + _zoomValue * _settings.ZoomSensitivity * Time.deltaTime;
            // итоговое значение ограничиваем в диапазоне из настроек
            newZ = Mathf.Clamp(newZ, _settings.MinZoom, _settings.MaxZoom);

            _currentCamera.transform.localPosition = new Vector3(
                _currentCamera.transform.localPosition.x,
                _currentCamera.transform.localPosition.y,
                newZ);
        }

        public void Tick()
        {
            if (_isZoom)
                ChangeZoom();
        }
    }
}
