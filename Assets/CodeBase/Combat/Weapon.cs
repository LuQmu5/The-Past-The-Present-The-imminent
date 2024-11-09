using System.Collections;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shotsPerSecond = 1;
    [SerializeField] private float _shotPower = 10;
    [SerializeField] private BulletTypes _bulletType;
    [SerializeField] private Transform _shootPoint;

    private BulletsFactory _bulletsFactory;

    public bool IsCooling { get; private set; }

    [Inject]
    public void Construct(BulletsFactory bulletsFactory)
    {
        _bulletsFactory = bulletsFactory;
    }

    public void Shoot()
    {
        Bullet bullet = _bulletsFactory.Get(_bulletType);

        bullet.transform.position = _shootPoint.position;
        bullet.gameObject.SetActive(true);
        bullet.Launch(_shootPoint.forward, _shotPower);

        StartCoroutine(Cooling());
    }

    private IEnumerator Cooling()
    {
        IsCooling = true;

        yield return new WaitForSeconds(1 / _shotsPerSecond);

        IsCooling = false;
    }
}
