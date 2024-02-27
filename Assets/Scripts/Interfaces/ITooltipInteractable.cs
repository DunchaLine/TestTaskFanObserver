using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Observerable.Interfaces
{
    /// <summary>
    /// Интерфейс для вывода Tooltip'a с описанием
    /// </summary>
    public interface ITooltipInteractable : IPointerEnterHandler, IPointerExitHandler
    {
        public Canvas TooltipCanvas { get; }

        public TextMeshProUGUI TooltipTextComponent { get; }

        public void SetTooltipText(string newText);

        public void ShowTooltip();

        public void HideTooltip();
    }
}
