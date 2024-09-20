using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public abstract class Spawner<T> : MonoBehaviour where T : PoolableObject<T>
    {
        [SerializeField] private Pool<T> _pool;

        public void Reset()
        {
            _pool.Reset();
        }

        public virtual T GetObject(Vector3 vector)
        {
            T createdObject = _pool.Get(vector);
            createdObject.Disabled += DestroyObject;
            return createdObject;

        }

        protected virtual void DestroyObject(T spawnableObject)
        {
            _pool.Return(spawnableObject);
            spawnableObject.Disabled -= DestroyObject;
        }
    }
}