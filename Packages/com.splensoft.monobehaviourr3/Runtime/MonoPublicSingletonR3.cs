using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SplenSoft.Unity
{
    public class MonoPublicSingletonR3<T> : MonoBehaviourR3 where T : Component
    {
        public static T Instance { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();
            Instance = GetComponent<T>();
        }

        protected static async UniTask<T> GetInstanceAsync(
            CancellationToken? cancellationToken = null)
        {
            CancellationToken linkedToken = cancellationToken.HasValue
                ? CancellationTokenSource.CreateLinkedTokenSource(cancellationToken.Value, Application.exitCancellationToken).Token
                : Application.exitCancellationToken;

            while (Instance == null)
            {
                await UniTask.Yield(linkedToken);
            }

            return Instance;
        }
    }
}