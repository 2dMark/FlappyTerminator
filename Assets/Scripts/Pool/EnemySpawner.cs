using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _upperOffset;
    [SerializeField] private float _lowerOffset;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _startSpawnDelay;
    [SerializeField] private float _spawnTime;
    [SerializeField] private EnemyPool _enemyPool;

    private Coroutine _coroutine;
    private Vector2 _upperCoordinats;
    private Vector2 _lowerCoordinats;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(SpawnerWork());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void Spawn()
    {
        float randomYCoordinate = Random.Range(_upperCoordinats.y, _lowerCoordinats.y);
        Vector2 spawnPoint = new(_upperCoordinats.x, randomYCoordinate);

        Enemy enemy = _enemyPool.Get();

        enemy.transform.position = spawnPoint;
        enemy.gameObject.SetActive(true);
    }

    private void RefreshSpawnerCoordinats()
    {
        _upperCoordinats = _camera.ScreenToWorldPoint
    (new Vector2(_camera.pixelWidth + _xOffset, _camera.pixelHeight - _upperOffset));

        _lowerCoordinats = _camera.ScreenToWorldPoint
            (new Vector2(_camera.pixelWidth + _xOffset, _lowerOffset));
    }

    private IEnumerator SpawnerWork()
    {
        WaitForSeconds spawnTime = new(_spawnTime);

        yield return new WaitForSeconds(_startSpawnDelay);

        while (enabled)
        {
            RefreshSpawnerCoordinats();
            Spawn();

            yield return spawnTime;
        }
    }
}