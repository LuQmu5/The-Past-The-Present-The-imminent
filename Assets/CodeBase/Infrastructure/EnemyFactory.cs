using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    private const string EnemyPrefabPath = "Prefabs/Enemies/Enemy";

    private List<Enemy> _pool;
    private Enemy _enemyPrefab;

    public EnemyFactory()
    {
        _enemyPrefab = Resources.Load<Enemy>(EnemyPrefabPath);
        _pool = new List<Enemy>();
    }

    public Enemy Get()
    {
        Enemy enemy = _pool.Find(i => i.gameObject.activeSelf == false);

        if (enemy == null)
        {
            enemy = Object.Instantiate(_enemyPrefab);
            _pool.Add(enemy);
        }

        return enemy;
    }
}
