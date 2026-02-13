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