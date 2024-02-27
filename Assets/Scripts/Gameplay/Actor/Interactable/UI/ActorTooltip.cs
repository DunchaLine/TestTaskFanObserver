using Observerable.Interfaces;

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;

namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// �����, ���������� �� ����� Tooltip'a ��� ��������� �� ������
    /// </summary>
    public class ActorTooltip : MonoBehaviour, ITooltipInteractable
    {
        [SerializeField]
        private Canvas _tooltipCanvas;

        [SerializeField]
        private TextMeshProUGUI _textMeshPro;

        public Canvas TooltipCanvas => _tooltipCanvas;

        public TextMeshProUGUI TooltipTextComponent => _textMeshPro;

        [Inject]
        public void Init(Camera camera)
        {
            Debug.Log($"init tooltip");
            TooltipCanvas.worldCamera = camera;
            TooltipCanvas.planeDistance = .5f;
        }

        /// <summary>
        /// ����� ������ � ���������
        /// </summary>
        public void ShowTooltip()
        {
            if (_textMeshPro.isActiveAndEnabled == false)
                _textMeshPro.gameObject.SetActive(true);
        }

        /// <summary>
        /// ���������� ������ � ���������
        /// </summary>
        public void HideTooltip()
        {
            if (_textMeshPro.isActiveAndEnabled)
                _textMeshPro.gameObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // �������� �� ��������� �� �������
            if (eventData.pointerCurrentRaycast.distance < 4f)
                ShowTooltip();
            else
                HideTooltip();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            HideTooltip();
        }

        /// <summary>
        /// ��������� ������ ������ � ��������
        /// </summary>
        /// <param name="newText"></param>
        public void SetTooltipText(string newText)
        {
            TooltipTextComponent.text = newText;
        }

    }
}
