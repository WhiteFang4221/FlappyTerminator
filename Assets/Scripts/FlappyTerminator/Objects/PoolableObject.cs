using System;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class PoolableObject<T> : MonoBehaviour where T : PoolableObject<T>
    {
        public event Action<T> Disabled;

        public void Disable()
        {
            Disabled.Invoke((T)this);
        }
    }
}