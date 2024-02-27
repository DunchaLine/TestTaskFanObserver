using Observerable.Interfaces;

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;

namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// Класс, отвечающий за показ Tooltip'a при наведении на объект
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
        /// Показ текста с описанием
        /// </summary>
        public void ShowTooltip()
        {
            if (_textMeshPro.isActiveAndEnabled == false)
                _textMeshPro.gameObject.SetActive(true);
        }

        /// <summary>
        /// Выключение текста с описанием
        /// </summary>
        public void HideTooltip()
        {
            if (_textMeshPro.isActiveAndEnabled)
                _textMeshPro.gameObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // проверка на дистанцию до объекта
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
        /// Установка своего текста в описание
        /// </summary>
        /// <param name="newText"></param>
        public void SetTooltipText(string newText)
        {
            TooltipTextComponent.text = newText;
        }

    }
}
