using Observerable.Settings;

using Zenject;

namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// Класс, отвечающий за вращение с Limit
    /// </summary>
    public abstract class ActorRotationLimit : ActorInteractableRotationTarget
    {
        protected float Limit { get; set; }

        protected float RotationSpeed { get; set; }

        [Inject]
        public override void Init(RotationInteractSettings settings)
        {
            base.Init(settings);
            Limit = settings.RotationLimitAngle;
            RotationSpeed = settings.RotationValue;
        }

        protected abstract bool IsLimit();
    }

}
