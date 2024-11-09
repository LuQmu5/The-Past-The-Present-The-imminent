using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string IsFiring = nameof(IsFiring);
    private const string IsRunning = nameof(IsRunning);

    [SerializeField] private Animator _animator;

    public void SetFiringParameter(bool state)
    {
        _animator.SetBool(IsFiring, state);
    }

    public void SetRunningParameter(bool state)
    {
        _animator.SetBool(IsRunning, state);
    }
}
