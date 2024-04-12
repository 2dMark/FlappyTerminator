using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(KeyboardInput))]

public class Player : Character
{
    public event Action GameOver;

    private PlayerMovement _playerMovement;
    private CollisionHandler _collisionHandler;
    private ScoreCounter _scoreCounter;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public override void TakeDamage() => GameOver?.Invoke();

    public void Reset()
    {
        _scoreCounter.Reset();
        _playerMovement.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground || interactable is Character)
            TakeDamage();
    }
}