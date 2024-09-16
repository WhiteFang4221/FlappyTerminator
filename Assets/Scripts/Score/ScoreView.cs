using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scoreCounter.Changed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged(int count)
    {
        _scoreText.text = count.ToString();
    }
}
