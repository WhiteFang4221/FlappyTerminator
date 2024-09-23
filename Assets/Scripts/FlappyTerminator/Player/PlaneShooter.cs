﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class PlaneShooter : MonoBehaviour
    {
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _shootDelay = 1;
        private float _delayLeft = 0;
        private bool _isRightDirection = true;

        public void TryShoot(float shooterSpeed)
        {
            if (_delayLeft <= 0)
            {
                _bulletSpawner.SpawnBullet(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation, _isRightDirection, shooterSpeed);
                StartCoroutine(DelayCoroutine());
            }
        }

        private IEnumerator DelayCoroutine()
        {
            _delayLeft = _shootDelay;

            while(_delayLeft > 0)
            {
                _delayLeft -= Time.deltaTime;
                yield return Time.deltaTime;
            }
        }
    }
}