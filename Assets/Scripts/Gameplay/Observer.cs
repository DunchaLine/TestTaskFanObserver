using UnityEngine;

using Zenject;

namespace Observerable.Gameplay
{
    /// <summary>
    /// Класс, который висит на объекте для осмотра
    /// </summary>
    public class Observer : MonoBehaviour
    {
        public Camera CurrentCamera { get; private set; }

        public Actor.Actor ActorTarget { get; private set; }

        [Inject]
        public void Init(Camera camera, Actor.Actor target)
        {
            Debug.Log($"init observer");

            CurrentCamera = camera;
            ActorTarget = target;
        }
    }
}
