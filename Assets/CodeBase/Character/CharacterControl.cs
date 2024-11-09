using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private CharacterCombat _combat;
    [SerializeField] private CharacterMover _mover;

    private void Update()
    {
        Vector3 inputVector = GetInputAxis();
        bool isFiringKeyPressing = Input.GetKey(KeyCode.Mouse0);

        if (isFiringKeyPressing)
            _combat.TryShoot();

        _mover.Move(inputVector, isFiringKeyPressing);

        _animator.SetRunningParameter(inputVector.sqrMagnitude > 0);
        _animator.SetFiringParameter(isFiringKeyPressing);
    }

    private Vector3 GetInputAxis()
    {
        return new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
    }
}
