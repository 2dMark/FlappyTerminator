using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private TMP_Text _score;

    private void Awake()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += RefreshScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= RefreshScore;
    }

    private void RefreshScore(int score) => _score.text = $"Score: {score}";
}