using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class PlaneShooter : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _shootDelay = 1;
        private float _delayLeft = 0;

        private void OnEnable()
        {
            _inputReader.LeftMousePressed += Shoot;
        }

        private void OnDisable()
        {
            _inputReader.LeftMousePressed -= Shoot;
        }

        private void Shoot()
        {
            if (_delayLeft <= 0)
            {
                _bulletSpawner.SpawnBullet(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation.eulerAngles);
                StartCoroutine(DelayCoroutine());
            }
        }

        private IEnumerator DelayCoroutine()
        {
            _delayLeft = _shootDelay;

            while(_delayLeft > 0)
            {
                _delayLeft -= Time.deltaTime;
                yield return null;
            }
        }
    }
}