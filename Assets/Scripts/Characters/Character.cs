using UnityEngine;

public abstract class Character : MonoBehaviour, IInteractable
{
    [SerializeField] private TargetTypes _targetType;

    public TargetTypes TargetType => _targetType;

    public abstract void TakeDamage();
}