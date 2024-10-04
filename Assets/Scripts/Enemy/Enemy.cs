using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(EnemyCollisionHandler), typeof(SpriteRenderer))]
    public class Enemy : PoolableObject<Enemy>, IDeadlable
    {
        [SerializeField] private Explosion _explosion;
        private EnemyShooter _enemyShooter;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider;
        private EnemyCollisionHandler _collisionHandler;
        private bool _isShot = false;

        public event Action Died;

        private void Awake()
        {
            _enemyShooter = GetComponent<EnemyShooter>();
            _boxCollider = GetComponent<BoxCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collisionHandler = GetComponent<EnemyCollisionHandler>();
        }

        private void OnEnable()
        {
            _collisionHandler.CollisionDetected += Destroy;

            if (_isShot)
            {
                _spriteRenderer.enabled = true;
                _boxCollider.enabled = true;
                _isShot = false;
            }
        }

        private void OnDisable()
        {
            _collisionHandler.CollisionDetected -= Destroy;
        }

        public void InitBulletSpawner(BulletSpawner bulletSpawner)
        {
            _enemyShooter.StartShootCoroutine(bulletSpawner);
        }

        private void Destroy()
        {
            _enemyShooter.StopShootCoroutine();
            StartCoroutine(DestroyCoroutine());
        }

        private IEnumerator DestroyCoroutine()
        {
            Died?.Invoke();
            _explosion.gameObject.SetActive(true);
            _spriteRenderer.enabled = false;
            _boxCollider.enabled = false;
            _isShot = true;

            while (_explosion.isActiveAndEnabled)
            {
                yield return null;
            }

            Disable();
        }
    }
}