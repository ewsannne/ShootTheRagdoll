using UnityEngine;

namespace ShootTheRagdoll
{
    public class Singleton<T> : MonoBehaviour
        where T : Singleton<T>
    {
        public static T Instance { get; private set; }
        
        
        protected virtual void Awake()
        {
            SetInstance();
        }


        private void SetInstance()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }
    }
}
