using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private LayerMask _waterMask;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private PlayerShooter _shooter;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _shooter = GetComponent<PlayerShooter>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        Fall();
    }

    public void Jump()
    {
            _rigidbody2D.velocity = new Vector2(_speed, _jumpForce);
        transform.rotation = _maxRotation;
    }

    public void Shoot() => _shooter.Shoot();

    public void Reset()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.identity);

        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Fall() => transform.rotation = Quaternion.Lerp
            (transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
}