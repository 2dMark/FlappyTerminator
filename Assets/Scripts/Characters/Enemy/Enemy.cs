using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : Character
{
    public event Action<Enemy> Damaged;
    public event Action<Enemy> DroppedOutOfSide;

    private EnemyShooter _enemyShooter;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Awake()
    {
        _enemyShooter = GetComponent<EnemyShooter>();
    }

    private void OnBecameInvisible()
    {
        DroppedOutOfSide?.Invoke(this);
    }

    public void SetTorpedoPool(TorpedoPool pool) => _enemyShooter.SetTorpedoPool(pool);

    public override void TakeDamage() => Damaged?.Invoke(this);
}