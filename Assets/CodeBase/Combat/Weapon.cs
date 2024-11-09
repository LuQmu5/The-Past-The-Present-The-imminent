using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletTypes _bulletType;
    [SerializeField] private Transform _shootPoint;

    private BulletsFactory _bulletsFactory;

    public bool IsCooling { get; private set; }

    [Inject]
    public void Construct(BulletsFactory bulletsFactory)
    {
        _bulletsFactory = bulletsFactory;
    }

    public void Shoot(float damage, float attackSpeed)
    {
        Bullet bullet = _bulletsFactory.Get(_bulletType);

        bullet.transform.position = _shootPoint.position;
        bullet.gameObject.SetActive(true);
        bullet.Launch(_shootPoint.forward, damage);

        StartCoroutine(Cooling(attackSpeed));
    }

    private IEnumerator Cooling(float attackSpeed)
    {
        IsCooling = true;

        yield return new WaitForSeconds(1 / attackSpeed);

        IsCooling = false;
    }
}
