using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UpgradeManager
{
    private const int EnemiesCountForUpgrade = 5;
    private const int BaseRandomUpgradesCount = 3;
    private const string UpgradesPath = "StaticData/Upgrades";

    private int _currentEnemiesKillStreak = 0;
    private UpgradeData[] _upgrades;

    public event Action UpgradeGoalReached;

    public UpgradeManager()
    {
        _upgrades = Resources.LoadAll<UpgradeData>(UpgradesPath);

        Enemy.Died += OnEnemyDied;
    }

    public IEnumerable GetRandomUpgrades()
    {
        List<UpgradeData> upgradesList = new List<UpgradeData>();
        List<UpgradeData> result = new List<UpgradeData>();
        upgradesList.AddRange(_upgrades);

        for (int i = 0; i < BaseRandomUpgradesCount; i++)
        {
            int randomIndex = Random.Range(0, upgradesList.Count);
            UpgradeData randomUpgrade = upgradesList[randomIndex];
            upgradesList.Remove(randomUpgrade);
            result.Add(randomUpgrade);
        }

        return result;
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
