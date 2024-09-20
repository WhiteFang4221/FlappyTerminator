using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class BulletSpawner : Spawner<Bullet>
    {
        public void SpawnBullet(Vector2 position,Quaternion rotation, bool isRight, float shooterSpeed)
        {
            Bullet bullet = GetObject(position); 
            bullet.SetRotation(rotation);
            bullet.StartBulletCoroutine(rotation, isRight, shooterSpeed);
        }
    }
}