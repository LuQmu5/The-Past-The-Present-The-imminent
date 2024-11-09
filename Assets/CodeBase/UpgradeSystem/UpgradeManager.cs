using System;
using UnityEngine;

public class UpgradeManager
{
    private const int EnemiesCountForUpgrade = 5;

    private int _currentEnemiesKillStreak = 0;

    public event Action UpgradeGoalReached;

    public UpgradeManager()
    {
        Enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        _currentEnemiesKillStreak++;

        if (_currentEnemiesKillStreak >= EnemiesCountForUpgrade)
        {
            _currentEnemiesKillStreak -= EnemiesCountForUpgrade;

            UpgradeGoalReached?.Invoke();
        }
    }
}
