using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [field: SerializeField] public BulletTypes Type { get; private set; }

    private float _damage;
    
    public void Launch(Vector3 direction, float shotPower)
    {
        float baseLaunchSpeed = 10;

        _damage = shotPower;
        transform.forward = direction.normalized;
        _rigidbody.velocity = direction * shotPower * baseLaunchSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth hittedTarget))
        {
            hittedTarget.ApplyDamage(_damage);

            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
