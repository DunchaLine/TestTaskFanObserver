using System;

using UnityEngine;

namespace Observerable.Settings
{
    /// <summary>
    /// Класс, в котором происходит настройка обзора
    /// </summary>
    [Serializable]
    public class ObserveSettings : IObservableSettings
    {
        [field: SerializeField, Range(0.1f, 0.5f)]
        public float RotateSpeed { get; private set; } = .1f;

        [field: SerializeField, Range(1f, 5f)]
        public float Sensitivity { get; private set; } = 1f;

        [field: SerializeField, Range(0.1f, 0.3f)]
        public float ZoomSensitivity { get; private set; } = .1f;

        [field: SerializeField, Range(-3f, -15f)]
        public float MinZoom { get; private set; } = -10f;

        [field: SerializeField, Range(-5f, -1f)]
        public float MaxZoom { get; private set; } = -3f;
    }
}
