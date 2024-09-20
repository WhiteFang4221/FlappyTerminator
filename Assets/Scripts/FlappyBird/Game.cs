using UnityEngine;

namespace FlappyBird
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private PipeGenerator _pipeGenerator;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private EndGameScreen _endGameScreen;

        private void OnEnable()
        {
            _startScreen.PlayButtonClicked += OnplayButtonClick;
            _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
            _bird.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _startScreen.PlayButtonClicked -= OnplayButtonClick;
            _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
            _bird.GameOver -= OnGameOver;
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
            Time.timeScale = 1;
            _bird.Reset();
            _pipeGenerator.DeletePipes();
        }
    }
}

