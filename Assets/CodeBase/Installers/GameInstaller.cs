using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UpgradesMenuDisplay _upgradesMenuDisplay;

    public override void InstallBindings()
    {
        Container.BindInstance(_upgradesMenuDisplay).AsSingle().NonLazy();

        Container.Bind<BulletsFactory>().AsSingle().NonLazy();
        Container.Bind<EnemyFactory>().AsSingle().NonLazy();
        Container.Bind<UpgradeManager>().AsSingle().NonLazy();
        Container.Bind<CharacterStats>().AsSingle().NonLazy();
        Container.Bind<UpgradeMediator>().AsSingle().NonLazy();
    }
}