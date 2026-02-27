using Cysharp.Threading.Tasks;
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