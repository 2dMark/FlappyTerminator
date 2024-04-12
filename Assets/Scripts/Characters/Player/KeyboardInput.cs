using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _playerMovement.Jump();

        if (Input.GetKeyDown(KeyCode.E))
            _playerMovement.Shoot();
    }
}