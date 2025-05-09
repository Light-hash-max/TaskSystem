namespace TaskSystem.Installers
{
    using FunnyBaloons.Timer;
    using UnityEditor;
    using UnityEngine;
    using Zenject;

    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Timer>().ToSelf().AsSingle();
        }
    }
}