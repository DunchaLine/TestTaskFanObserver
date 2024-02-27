using System;

using UnityEngine;

namespace Observerable.Settings
{
    /// <summary>
    /// Настройки вращения
    /// </summary>
    [Serializable]
    public class RotationInteractSettings
    {
        [field: SerializeField, Range(0.1f, 1)]
        public float RotationValue { get; private set; } = .3f;

        [field: SerializeField, Range(3, 7)]
        public int SpeedValue { get; private set; } = 5;

        [field: SerializeField, Range(30f, 50f)]
        public float RotationLimitAngle { get; private set; } = 45f;
    }
}
