using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private EnemyFactory _enemyFactory;
    private float _timer = 3;

    [Inject]
    public void Construct(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = 3;

            Enemy spawnedEnemy = _enemyFactory.Get();
            spawnedEnemy.gameObject.SetActive(true);
            spawnedEnemy.Init(transform.position, _player);
        }
    }
}

