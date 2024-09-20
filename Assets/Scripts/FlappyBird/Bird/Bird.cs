using System;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(BirdMover), typeof(CollisionHandler), typeof(ScoreCounter))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _birdMover;
        private CollisionHandler _collisionHandler;
        private ScoreCounter _scoreCounter;

        public event Action GameOver;

        private void Awake()
        {
            _birdMover = GetComponent<BirdMover>();
            _collisionHandler = GetComponent<CollisionHandler>();
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

        private void ProcessCollision(IInteractable interactable)
        {
            if (interactable is Pipe || interactable is Ground)
            {
                GameOver?.Invoke();
            }
            else if (interactable is ScoreZone)
            {
                _scoreCounter.Add();
            }
        }

        public void Reset()
        {
            _scoreCounter.Reset();
            _birdMover.Reset();
        }
    }
}

