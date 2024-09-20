using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Rigidbody2D), typeof(EnemyCollisionHandler), typeof(SpriteRenderer))]
    public class Enemy : PoolableObject<Enemy>, IDeadlable
    {
        [SerializeField] private float _currentSpeed = 5f;
        [SerializeField] private Explosion _explosion;

        private EnemyCollisionHandler _collisionHandler;
        private BulletSpawner _bulletSpawner;
        private BoxCollider2D _boxCollider;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private WaitForSeconds _delayShooting = new WaitForSeconds(1);
        private Coroutine _shootCoroutine;
        private float _xOffset = -2;
        
        private bool _isRightDirection = false;
        private bool _isShot = false;

        public event Action<Vector2, bool> Shooting;
        public event Action Died;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
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
           StopShootCoroutine();
        }

        private void Update()
        {
            _rigidbody.velocity = new Vector2(-_currentSpeed, _rigidbody.velocity.y);
        }

        public void InitBulletSpawner(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
            StartShootCoroutine();
        }

        private IEnumerator ShootCoroutine()
        {
            while (true)
            {
                _bulletSpawner.SpawnBullet(GetBulletSpawnPoint(), transform.rotation, _isRightDirection, _currentSpeed);
                yield return _delayShooting;
            }
        }

        private void StartShootCoroutine()
        {
            if (_shootCoroutine != null)
            {
                _shootCoroutine = null;
            }

            _shootCoroutine = StartCoroutine(ShootCoroutine());
        }

        private void StopShootCoroutine()
        {
            if ( _shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
        }

        private Vector2 GetBulletSpawnPoint()
        {
            Vector2 position = transform.position;
            position.x = transform.position.x + _xOffset;
            return position;
        }

        private void Destroy()
        {
            StopShootCoroutine();
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