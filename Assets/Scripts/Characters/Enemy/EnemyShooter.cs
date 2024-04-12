using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _shootSpeed;
    [SerializeField] private Transform _muzzle;

    private TorpedoPool _torpedoPool;
    private float _startDelay = .1f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(ShooterWork());
    }

    public void SetTorpedoPool(TorpedoPool pool) => _torpedoPool = pool;

    private IEnumerator ShooterWork()
    {
        WaitForSeconds shootSpeed = new(_shootSpeed);

        yield return new WaitForSeconds(_startDelay);

        while (enabled)
        {
            Torpedo torpedo = _torpedoPool.Get();
            torpedo.transform.position = _muzzle.position;

            torpedo.SetTarget(TargetTypes.Player);
            torpedo.SetDirection(-transform.right);
            torpedo.gameObject.SetActive(true);

            yield return shootSpeed;
        }
    }
}