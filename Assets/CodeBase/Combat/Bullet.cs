using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [field: SerializeField] public BulletTypes Type { get; private set; }
    
    public void Launch(Vector3 direction, float shotPower)
    {
        transform.forward = direction.normalized;
        _rigidbody.velocity = direction * shotPower;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth hittedTarget))
        {
            hittedTarget.ApplyDamage(1);
            print(hittedTarget.CurrentHealth);

            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
