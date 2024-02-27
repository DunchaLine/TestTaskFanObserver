namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// �����, ���������� �� �������� �� �� z
    /// </summary>
    public class ActorRotationForward : ActorInteractableRotationTarget
    {
        protected override void Rotate()
        {
            transform.Rotate(0f, 0f, Settings.SpeedValue);
        }
    }
}
