using System;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action CollisionDetected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerBullet bullet))
            {
                bullet.Disable();
                CollisionDetected?.Invoke();
            }
        }
    }
}