using System;
using UnityEngine;

public class LevelCompleteHandler : IDisposable
{
    public int EnemiesOnLevel { get; private set; }
    public int DiedEnemies { get; private set; }

    public event Action LevelCompleted;

    public LevelCompleteHandler(int enemiesOnLevel)
    {
        EnemiesOnLevel = enemiesOnLevel;

        Enemy.Died += OnEnemyDied;
    }

    public void Dispose()
    {
        Enemy.Died -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        DiedEnemies++;

        if (DiedEnemies >= EnemiesOnLevel)
        {
            LevelCompleted?.Invoke();

            Time.timeScale = 0; // bad practice
        }
    }
}
