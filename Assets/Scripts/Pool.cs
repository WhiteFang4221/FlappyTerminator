using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Container _container;

    private Queue<T> _pool = new Queue<T>();

    public T Get(Vector2 position)
    {
        if (_pool.Count == 0)
        {
            ExpandPool();
        }

        T entity = _pool.Dequeue();
        entity.gameObject.SetActive(true);
        entity.transform.position = position;

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
        _container.ClearContainer();
    }

    private void ExpandPool()
    {
        T entity = Instantiate(_prefab, _container.gameObject.transform);
        _pool.Enqueue(entity);
    }
}