using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BulletsFactory>().AsSingle().NonLazy();
        Container.Bind<EnemyFactory>().AsSingle().NonLazy();
    }
}