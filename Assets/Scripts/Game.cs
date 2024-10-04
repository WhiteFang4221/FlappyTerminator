using UnityEngine;

namespace Assets.Scripts.FlappyTerminator
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Plane _plane;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private EndGameScreen _endGameScreen;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private BulletSpawner _playerBulletSpawner;
        [SerializeField] private InputReader _inputReader;

        private void OnEnable()
        {
            _startScreen.ButtonClicked += OnplayButtonClick;
            _endGameScreen.ButtonClicked += OnRestartButtonClick;
            _plane.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _startScreen.ButtonClicked -= OnplayButtonClick;
            _endGameScreen.ButtonClicked -= OnRestartButtonClick;
            _plane.GameOver -= OnGameOver;
        }

        private void Start()
        {
            Time.timeScale = 0;
            _startScreen.Open();
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
            _endGameScreen.Open();
        }

        private void OnplayButtonClick()
        {
            _startScreen.Close();
            StartGame();
        }

        private void OnRestartButtonClick()
        {
            _endGameScreen.Close();
            StartGame();
        }

        private void StartGame()
        {
            _plane.Reset();
            _enemySpawner.Reset();
            _bulletSpawner.Reset();
            _playerBulletSpawner.Reset();
            _inputReader.Reset();
            Time.timeScale = 1;
        }
    }
}