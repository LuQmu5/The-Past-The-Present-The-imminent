using System;
using UnityEngine;
using Zenject;

public class UpgradeMediator : IDisposable
{
    private readonly UpgradeManager _upgradeManager;
    private readonly UpgradesMenuDisplay _upgradesMenuDisplay;

    [Inject]
    public UpgradeMediator(UpgradeManager upgradeManager, UpgradesMenuDisplay upgradesMenuDisplay)
    {
        _upgradeManager = upgradeManager;
        _upgradesMenuDisplay = upgradesMenuDisplay;

        _upgradeManager.UpgradeGoalReached += OnUpgradeGoalReached;
    }

    public void Dispose()
    {
        _upgradeManager.UpgradeGoalReached -= OnUpgradeGoalReached;
    }

    private void OnUpgradeGoalReached()
    {
        _upgradesMenuDisplay.Show();
    }
}
