using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class BulletSpawner : Spawner<Bullet>
    {
        public void SpawnBullet(Vector2 position,Vector3 rotation)
        {
            Bullet bullet = GetObject(position);
            bullet.SetRotation(rotation);
            bullet.BulletCoroutine();
        }
    }
}