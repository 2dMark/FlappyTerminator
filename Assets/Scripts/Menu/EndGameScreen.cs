using System;
using TMPro;
using UnityEngine;

public class EndGameScreen : Window
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _text;

    public event Action RestartButtonClicked;

    private void Awake()
    {
        WindowGroup.alpha = 0f;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        ShowEndGameText();
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick() => RestartButtonClicked?.Invoke();

    private void ShowEndGameText() => _text.text = $"Failed!\n\nBest score: {_scoreCounter.BestScore}";
}