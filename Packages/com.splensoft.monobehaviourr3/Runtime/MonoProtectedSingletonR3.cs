using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace SplenSoft.Unity
{
    public class MonoProtectedSingletonR3<T> : MonoBehaviourR3 where T : Component
    {
        protected static T Instance { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();
            Instance = GetComponent<T>();
        }

        protected static async UniTask<T> GetInstanceAsync()
        {
            while (Instance == null)
            {
                await UniTask.Yield(Application.exitCancellationToken);
            }

            return Instance;
        }
    }
}