namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// Класс, отвечающий за вращение по по z
    /// </summary>
    public class ActorRotationForward : ActorInteractableRotationTarget
    {
        protected override void Rotate()
        {
            transform.Rotate(0f, 0f, Settings.SpeedValue);
        }
    }
}
