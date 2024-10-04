using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class EnemyShooter : MonoBehaviour
    {
        
        private Vector3 _projectileRotationAngle = new Vector3(0, 180, 0);
        private Coroutine _shootCoroutine;
        private WaitForSeconds _delayShooting = new WaitForSeconds(1);
        private float _xOffset = -2;

        public void StopShootCoroutine()
        {
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
        }

        public void StartShootCoroutine(BulletSpawner bulletSpawner)
        {
            StopShootCoroutine();
            _shootCoroutine = StartCoroutine(ShootCoroutine(bulletSpawner));
        }

        private IEnumerator ShootCoroutine(BulletSpawner bulletSpawner)
        {
            while (true)
            {
                bulletSpawner.SpawnBullet(GetBulletSpawnPoint(), _projectileRotationAngle);
                yield return _delayShooting;
            }
        }

        private Vector2 GetBulletSpawnPoint()
        {
            Vector2 position = transform.position;
            position.x = transform.position.x + _xOffset;
            return position;
        }
    }
}