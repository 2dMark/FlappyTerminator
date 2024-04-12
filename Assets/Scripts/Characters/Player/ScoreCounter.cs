using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int _score;
    private int _bestScore;

    public int Score => _score;

    public int BestScore => _bestScore;

    public void Add()
    {
        _score++;

        if (_score > _bestScore)
            _bestScore = _score;

        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;

        ScoreChanged?.Invoke(_score);
    }
}