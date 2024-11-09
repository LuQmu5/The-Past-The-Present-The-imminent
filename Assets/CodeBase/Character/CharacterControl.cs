using UnityEngine;
using Zenject;



public class CharacterControl : MonoBehaviour, IHealth
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private CharacterCombat _combat;
    [SerializeField] private CharacterMover _mover;

    private CharacterStats _stats;

    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    [Inject]
    public void Construct(CharacterStats stats)
    {
        _stats = stats;

        MaxHealth = _stats.Get(StatNames.MaxHealth);
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        Vector3 inputVector = GetInputAxis();
        bool isFiringKeyPressing = Input.GetKey(KeyCode.Mouse0);

        if (isFiringKeyPressing)
            _combat.TryShoot(_stats.Get(StatNames.Damage), _stats.Get(StatNames.AttackSpeed));

        _mover.Move(inputVector, isFiringKeyPressing, _stats.Get(StatNames.MovementSpeed));

        _animator.SetRunningParameter(inputVector.sqrMagnitude > 0);
        _animator.SetFiringParameter(isFiringKeyPressing);
    }

    public void ApplyDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        if (CurrentHealth == 0)
            gameObject.SetActive(false);
    }

    private Vector3 GetInputAxis()
    {
        return new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
    }
}
