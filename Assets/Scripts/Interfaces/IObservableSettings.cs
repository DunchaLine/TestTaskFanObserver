/// <summary>
/// Интерфейс для настроек просмотра
/// </summary>
public interface IObservableSettings
{
    public float RotateSpeed { get; }

    public float Sensitivity { get; }

    public float ZoomSensitivity { get; }

    public float MinZoom { get; }

    public float MaxZoom { get; }
}
