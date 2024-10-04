using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : PoolableObject<Bullet>, IDeadlable
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetRotation(Vector3 rotation)
        {
            transform.rotation = Quaternion.Euler(rotation);
        }

        public void BulletCoroutine()
        {
            _direction = transform.right;
            _rigidbody.velocity = _direction * _speed;
        }
    }
}