using UnityEngine;
using UnityEngine.EventSystems;

namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// �����, ������������� ������� �� ������, ����� ������� ����� ��������� ��������
    /// </summary>
    public class ActorInteractablePart : MonoBehaviour, IPointerClickHandler
    {
        // �������� �� ��������� ����� Zenject (IRotateInteractable)
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
