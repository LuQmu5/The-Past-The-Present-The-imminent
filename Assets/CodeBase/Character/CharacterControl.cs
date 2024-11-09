using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private CharacterCombat _combat;
    [SerializeField] private CharacterMover _mover;

    private void Update()
    {
        _animator.SetFiringParameter(_combat.IsFiring);
        _animator.SetRunningParameter(_mover.IsRunning);

        Vector3 inputVector = GetInputAxis();
        _mover.Move(inputVector, _combat.IsFiring);
    }

    private Vector3 GetInputAxis()
    {
        return new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
    }
}
