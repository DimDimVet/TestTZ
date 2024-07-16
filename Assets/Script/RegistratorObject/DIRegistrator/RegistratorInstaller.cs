using Zenject;

namespace RegistratorObject
{
    public class RegistratorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IRegistrator>().To<ListDataExecutor>().AsSingle().NonLazy();
        }
    }
}

