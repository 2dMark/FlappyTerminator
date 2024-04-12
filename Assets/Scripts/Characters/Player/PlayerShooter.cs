using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private TorpedoPool _torpedoPool;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private ScoreCounter _scoreCounter;

    public void Shoot()
    {
        Torpedo torpedo = _torpedoPool.Get();
        torpedo.transform.position = _muzzle.position;

        AddListener(torpedo);

        torpedo.SetTarget(TargetTypes.Enemy);
        torpedo.SetDirection(transform.right);
        torpedo.gameObject.SetActive(true);
    }

    private void AddScore() => _scoreCounter.Add();

    private void AddListener(Torpedo torpedo)
    {
        torpedo.TargetEngaged += AddScore;
        torpedo.Invisibled += RemoveListener;
        torpedo.Disabled += RemoveListener;
    }

    private void RemoveListener(Torpedo torpedo)
    {
        torpedo.TargetEngaged -= AddScore;
        torpedo.Invisibled -= RemoveListener;
        torpedo.Disabled -= RemoveListener;
    }
}