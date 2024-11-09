using System.Collections;
using UnityEngine;
using Zenject;

public class RangeWeapon : MonoBehaviour, IRangeWeapon
{
    [SerializeField] private float _shotsPerSecond = 1;
    [SerializeField] private float _shotPower = 10;
    [SerializeField] private BulletTypes _bulletType;
    [SerializeField] private Transform _shootPoint;

    private BulletsFactory _bulletsFactory;

    [Inject]
    public void Construct(BulletsFactory bulletsFactory)
    {
        _bulletsFactory = bulletsFactory;

        if (gameObject.activeSelf)
            StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _shotsPerSecond);

            Attack();
        }
    }

    public void Attack()
    {
        Bullet bullet = _bulletsFactory.Get(_bulletType);

        bullet.transform.position = _shootPoint.position;
        bullet.gameObject.SetActive(true);
        bullet.Launch(_shootPoint.forward, _shotPower);
    }
}
