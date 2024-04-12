using UnityEngine;

public class TorpedoPool : MonoBehaviour
{
    [SerializeField] private Torpedo _prefab;
    [SerializeField] private Transform _container;

    private ObjectPool<Torpedo> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Torpedo>(_prefab, _container);
    }

    public void Reset()
    {
        Torpedo[] torpedoes = _container.GetComponentsInChildren<Torpedo>();

        foreach (Torpedo torpedo in torpedoes)
            if (torpedo.gameObject.activeSelf == true)
                Put(torpedo);
    }

    public Torpedo Get()
    {
        Torpedo torpedo = _pool.GetObject();
        torpedo.CollisionDetected += Put;
        torpedo.Invisibled += Put;

        return torpedo;
    }

    public void Put(Torpedo torpedo)
    {
        torpedo.CollisionDetected -= Put;
        torpedo.Invisibled -= Put;

        _pool.PutObject(torpedo);
    }
}