using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> Changed;

    private void OnEnable()
    {
        Debug.Log(gameObject.GetHashCode());
    }

    public void Add()
    {
        _score++;
        Debug.Log(gameObject.GetHashCode());
        Changed?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }
}
