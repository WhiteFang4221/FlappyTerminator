using System;
using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    [RequireComponent(typeof(PlaneMover), typeof(PlayerCollisionHandler), typeof(ScoreCounter))]
    public class Plane : MonoBehaviour
    {
        private PlaneMover _planeMover;
        private PlayerCollisionHandler _collisionHandler;
        private ScoreCounter _scoreCounter;

        public event Action GameOver;

        private void Awake()
        {
            _planeMover = GetComponent<PlaneMover>();
            _collisionHandler = GetComponent<PlayerCollisionHandler>();
            _scoreCounter = GetComponent<ScoreCounter>();
        }

        private void OnEnable()
        {
            _collisionHandler.CollisionDetected += ProcessCollision;
        }

        private void OnDisable()
        {
            _collisionHandler.CollisionDetected -= ProcessCollision;
        }

        private void ProcessCollision()
        {
            GameOver?.Invoke();
        }

        public void Reset()
        {
            _scoreCounter.Reset();
            _planeMover.Reset();
        }
    }
}

