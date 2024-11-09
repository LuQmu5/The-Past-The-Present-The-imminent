using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UpgradesMenuDisplay _upgradesMenuDisplay;

    public override void InstallBindings()
    {
        Container.Bind<BulletsFactory>().AsSingle().NonLazy();
        Container.Bind<EnemyFactory>().AsSingle().NonLazy();

        Container.BindInstance(_upgradesMenuDisplay).AsSingle().NonLazy();
        Container.BindInstance(new UpgradeManager()).AsSingle().NonLazy();
        Container.Bind<UpgradeMediator>().AsSingle().NonLazy();
    }
}