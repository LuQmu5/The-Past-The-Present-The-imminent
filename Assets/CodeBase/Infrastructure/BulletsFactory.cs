using System.Collections.Generic;
using UnityEngine;

public class BulletsFactory
{
    private const string BulletsDataPath = "StaticData/Bullets";

    private Dictionary<BulletTypes, BulletData> _bulletsMap;
    private List<Bullet> _pool;

    public BulletsFactory()
    {
        _pool = new List<Bullet>();

        BulletData[] bulletsData = Resources.LoadAll<BulletData>(BulletsDataPath);
        _bulletsMap = new Dictionary<BulletTypes, BulletData>();

        foreach (BulletData data in bulletsData)
            _bulletsMap.Add(data.Type, data);
    }

    public Bullet Get(BulletTypes type)
    {
        Bullet bullet = _pool.Find(i => i.Type == type && i.gameObject.activeSelf == false);

        if (bullet == null)
        {
            Bullet bulletPrefab = _bulletsMap[type].Prefab;
            bullet = Object.Instantiate(bulletPrefab);
            _pool.Add(bullet);
        }

        return bullet;
    }
}
