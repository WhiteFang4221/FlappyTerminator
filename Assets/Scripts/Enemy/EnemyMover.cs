using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _currentSpeed = 5f;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            SetVelocity();
        }

        private void SetVelocity()
        {
            _rigidbody.velocity = new Vector2(-_currentSpeed, _rigidbody.velocity.y);
        }
    }
}