using Cysharp.Threading.Tasks;
using Observerable.Interfaces;
using Observerable.Settings;

using System.Threading;

using UnityEngine;

using Zenject;

namespace Observerable.Gameplay.Actor
{
    /// <summary>
    /// Класс, отвечающий за интерактивное вращение
    /// </summary>
    public abstract class ActorInteractableRotationTarget : MonoBehaviour, IRotateInteractable
    {
        public RotationInteractSettings Settings { get; private set; }

        private void Start()
        {
            RotateTask(this.GetCancellationTokenOnDestroy()).Forget();
        }

        public bool IsOn { get; protected set; }

        [Inject]

        public virtual void Init(RotationInteractSettings settings)
        {
            Settings = settings;
        }

        public void Interact(bool isOn)
        {
            IsOn = isOn;
        }

        public async virtual UniTaskVoid RotateTask(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                    return;

                if (IsOn)
                    Rotate();

                await UniTask.NextFrame();
            }
        }

        protected abstract void Rotate();
    }
}
