﻿using System.Collections;
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

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public void StartBulletCoroutine(Quaternion rotation,bool isRight, float ShooterSpeed)
        {
            StartCoroutine(BulletCoroutine(rotation, isRight, ShooterSpeed));
        }

        private IEnumerator BulletCoroutine(Quaternion rotation, bool isRightDirection, float shooterSpeed)
        {
            if (isRightDirection)
            {
                _direction = transform.right;
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
            else
            {
                _direction = -transform.right;
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }

            while (true)
            {
                _rigidbody.velocity = _direction * (_speed + shooterSpeed);
                yield return Time.deltaTime;
            }
        }
    }
}