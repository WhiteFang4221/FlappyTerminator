using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlaneShooter))]
    public class PlaneMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f; 
        [SerializeField] private float _liftForce = 5;
        [SerializeField] private float _fallSpeed = 2;
        [SerializeField] private float _rotationSpeedUp;
        [SerializeField] private float _rotationSpeedDown;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;

        private Rigidbody2D _rigidbody;
        private PlaneShooter _shooter;
        private Vector3 _startPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _shooter = GetComponent<PlaneShooter>();
        }

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (Time.timeScale == 1)
            {
                HandleInput();
                AdjustLiftBasedOnRotation();
                Shoot();
            }
        }

        private void HandleInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.rotation = Mathf.Lerp(_rigidbody.rotation, _maxRotationZ, Time.deltaTime * _rotationSpeedUp);
            }
            else
            {
                _rigidbody.rotation = Mathf.Lerp(_rigidbody.rotation, _minRotationZ, Time.deltaTime * _rotationSpeedDown);
            }
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _shooter.TryShoot(_speed);
            }
        }

        private void AdjustLiftBasedOnRotation()
        {
            float tiltFactor;

            if (_rigidbody.rotation > 0) 
            {
                tiltFactor = _rigidbody.rotation / _maxRotationZ;
            }
            else  
            {
                tiltFactor = _rigidbody.rotation / Mathf.Abs(_minRotationZ);
            }

            if (tiltFactor > 0)
            {
                _rigidbody.velocity = new Vector2(_speed, _liftForce * tiltFactor);
            }
            else
            {
                _rigidbody.velocity = new Vector2(_speed, -_fallSpeed * Mathf.Abs(tiltFactor));
            }
        }

        public void Reset()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}