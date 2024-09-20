using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class SpawnRemover : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Bullet bullet))
            {
                bullet.Disable();
            }
            else if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.Disable();
            }
        }
    }
}

