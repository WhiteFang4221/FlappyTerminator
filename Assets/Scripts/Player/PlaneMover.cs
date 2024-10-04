using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlaneShooter))]
    public class PlaneMover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
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
        private bool _isMoveUp = false;
 
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _shooter = GetComponent<PlaneShooter>();
        }

        private void OnEnable()
        {
            _inputReader.SpacePressed += OnJumpButtonPressed;
            _inputReader.SpaceUnpressed += OnJumpButtonUnpressed;
        }

        private void OnDisable()
        {
            _inputReader.SpacePressed -= OnJumpButtonPressed;
            _inputReader.SpaceUnpressed -= OnJumpButtonUnpressed;
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
            }
        }

        public void Reset()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector2.zero;
        }

        private void HandleInput()
        {
            if (_isMoveUp)
            {
                Move(_maxRotationZ, _rotationSpeedUp);
            }
            else
            {
                Move(_minRotationZ, _rotationSpeedDown);
            }
        } 

        private void Move(float rotation, float rotationSpeed)
        {
            _rigidbody.rotation = Mathf.Lerp(_rigidbody.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        private void OnJumpButtonPressed()
        {
            _isMoveUp = true;
        } 
        
        private void OnJumpButtonUnpressed()
        {
            _isMoveUp = false;
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
    }
}