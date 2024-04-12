using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] EnemyPool _enemyPool;
    [SerializeField] TorpedoPool _torpedoPool;

    public void Reset()
    {
        _enemyPool.Reset();
        _torpedoPool.Reset();
    }
}