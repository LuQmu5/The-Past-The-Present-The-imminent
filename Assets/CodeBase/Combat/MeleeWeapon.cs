using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IMeleeWeapon
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth hittedTarget))
        {
            DealDamage(hittedTarget);
        }
    }

    public void DealDamage(IHealth target)
    {
        target.ApplyDamage(1);
        print(target.CurrentHealth);
    }
}
