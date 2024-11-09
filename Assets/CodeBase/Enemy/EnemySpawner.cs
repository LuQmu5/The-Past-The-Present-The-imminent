using System.Collections;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _timeBetweenSpawn = 3;

    private EnemyFactory _enemyFactory;
    private LevelCompleteHandler _levelCompleteHandler;

    private int _enemiesInWave = 1;
    private int _spawnedEnemies = 0;

    [Inject]
    public void Construct(EnemyFactory enemyFactory, LevelCompleteHandler levelCompleteHandler)
    {
        _enemyFactory = enemyFactory;
        _levelCompleteHandler = levelCompleteHandler;

        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        float delay = 0.1f;
        bool isSpawning = true;

        while (isSpawning)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            for (int i = 0; i < _enemiesInWave; i++)
            {
                yield return new WaitForSeconds(delay);

                SpawnEnemy();

                if (_spawnedEnemies == _levelCompleteHandler.EnemiesOnLevel)
                {
                    isSpawning = false;

                    yield break;
                }
            }

            _enemiesInWave++;
        }
    }

    private void SpawnEnemy()
    {
        Enemy spawnedEnemy = _enemyFactory.Get();
        spawnedEnemy.gameObject.SetActive(true);
        Vector3 randomOffset = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        spawnedEnemy.Init(transform.position + randomOffset, _player);
        _spawnedEnemies++;
    }
}

