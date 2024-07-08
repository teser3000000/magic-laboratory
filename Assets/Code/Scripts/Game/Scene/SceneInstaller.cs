using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CameraMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RecipeFactory>().AsSingle().NonLazy();
        Container.Bind<MixingContext>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RecipeManager>().AsSingle().NonLazy();
        Container.Bind<TestMixing>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RecipeResults>().FromComponentInHierarchy().AsSingle();
        Container.Bind<TriggerAnimationStrips>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameCompletionTracker>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RecipeUIManagement>().FromComponentInHierarchy().AsSingle();
    }
}
