using System;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        public event Action CollisionDetected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDeadlable deadlable))
            {
                CollisionDetected?.Invoke();
            }
        }
    }
}