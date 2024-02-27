using UnityEngine;
using UnityEngine.EventSystems;

namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// Класс, отслеживающий нажатие на объект, через который можно запустить действие
    /// </summary>
    public class ActorInteractablePart : MonoBehaviour, IPointerClickHandler
    {
        // Заменить на внедрение через Zenject (IRotateInteractable)
        [SerializeField]
        private ActorInteractableRotationTarget _interactable;

        private bool isOn = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"you interact with object: {name}");
            isOn = !isOn;
            _interactable?.Interact(isOn);
        }
    }
}
