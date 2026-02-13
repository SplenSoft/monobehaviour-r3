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

        protected static async Task<T> GetInstanceAsync()
        {
            while (Instance == null)
            {
                await Task.Yield();

                if (!Application.isPlaying)
                {
                    throw new TaskCanceledException();
                }
            }

            return Instance;
        }
    }
}