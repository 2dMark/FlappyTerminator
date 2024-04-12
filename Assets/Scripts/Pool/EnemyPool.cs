using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private TorpedoPool _torpedoPool;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(_prefab, _container);
    }

    public void Reset()
    {
        Enemy[] enemies = _container.GetComponentsInChildren<Enemy>();

        foreach (Enemy enemy in enemies)
            if (enemy.gameObject.activeSelf == true)
                Put(enemy);
    }

    public Enemy Get()
    {
        Enemy enemy = _pool.GetObject();

        enemy.SetTorpedoPool(_torpedoPool);
        enemy.Damaged += Put;
        enemy.DroppedOutOfSide += Put;

        return enemy;
    }

    public void Put(Enemy enemy)
    {
        enemy.Damaged -= Put;
        enemy.DroppedOutOfSide -= Put;

        _pool.PutObject(enemy);
    }
}