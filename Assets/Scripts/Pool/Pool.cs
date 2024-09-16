using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private Queue<T> _pool = new Queue<T>();

    public T Get(Vector3 transform)
    {
        if (_pool.Count == 0)
        {
            ExpandPool();
        }

        T entity = _pool.Dequeue();
        entity.gameObject.SetActive(true);
        entity.transform.position = transform;

        return entity;
    }

    public void Return(T entity)
    {
        entity.gameObject.SetActive(false);
        _pool.Enqueue(entity);
    }

    public void Reset()
    {
        _pool.Clear();
    }

    private void ExpandPool()
    {
        T entity = Instantiate(_prefab, _container);
        _pool.Enqueue(entity);
    }
}