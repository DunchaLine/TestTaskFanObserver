namespace Observerable.Gameplay.Actor
{
    /// <summary>
    ///  ласс, отвечающий за вращение по y с ограничением по Limit
    /// </summary>
    public class ActorRotationLimitUp : ActorRotationLimit
    {
        protected override bool IsLimit()
        {
            if (transform.localEulerAngles.y < 180 && transform.localEulerAngles.y >= Limit)
                return true;
            else if (transform.localEulerAngles.y > 180 && transform.localEulerAngles.y <= 360 - Limit)
                return true;
            return false;
        }

        protected override void Rotate()
        {
            transform.Rotate(0f, RotationSpeed, 0f);

            if (IsLimit())
                RotationSpeed = -RotationSpeed;
        }
    }
}
