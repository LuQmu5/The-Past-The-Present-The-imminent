using System;
using UnityEngine;
using Zenject;

public class UpgradeMediator : IDisposable
{
    private readonly UpgradeManager _upgradeManager;
    private readonly UpgradesMenuDisplay _upgradesMenuDisplay;
    private readonly CharacterStats _characterStats;

    [Inject]
    public UpgradeMediator(UpgradeManager upgradeManager, UpgradesMenuDisplay upgradesMenuDisplay, CharacterStats characterStats)
    {
        _upgradeManager = upgradeManager;
        _upgradesMenuDisplay = upgradesMenuDisplay;
        _characterStats = characterStats;

        _upgradeManager.UpgradeGoalReached += OnUpgradeGoalReached;
        _upgradesMenuDisplay.UpgradeChosen += OnUpgradeChosen;
    }

    public void Dispose()
    {
        _upgradeManager.UpgradeGoalReached -= OnUpgradeGoalReached;
        _upgradesMenuDisplay.UpgradeChosen -= OnUpgradeChosen;
    }

    private void OnUpgradeChosen(UpgradeData data)
    {
        Debug.Log(data.StatName + " increased!");
        _characterStats.Increase(data.StatName, data.StatIncreaseAmount);
    }

    private void OnUpgradeGoalReached()
    {
        _upgradesMenuDisplay.Show();
    }
}
