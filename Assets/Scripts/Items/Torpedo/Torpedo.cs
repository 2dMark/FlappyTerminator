using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Torpedo : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;

    public event Action TargetEngaged;
    public event Action<Torpedo> CollisionDetected;
    public event Action<Torpedo> Invisibled;
    public event Action<Torpedo> Disabled;

    private Vector2 _direction;

    public TargetTypes Target { get; private set; }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
        {
            if (character.TargetType == Target)
            {
                character.TakeDamage();
                TargetEngaged?.Invoke();
            }

            CollisionDetected?.Invoke(this);
        }

        if (collision.TryGetComponent(out IInteractable interactable))
            CollisionDetected?.Invoke(this);
    }

    private void OnBecameInvisible()
    {
        Invisibled?.Invoke(this);
    }

    private void OnDisable()
    {
        Disabled?.Invoke(this);
    }

    public void SetTarget(TargetTypes targetType) => Target = targetType;

    public void SetDirection(Vector2 direction) => _direction = direction;
}