using Zenject;

namespace Pools
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPoolMonetaDropExecutor>().To<PoolMonetaDropExecutor>().AsSingle().NonLazy();
            Container.Bind<IPoolTrashDropExecutor>().To<PoolTrashDropExecutor>().AsSingle().NonLazy();

            Container.Bind<IPoolMonetaInvertoryExecutor>().To<PoolMonetaInvertoryExecutor>().AsSingle().NonLazy();
            Container.Bind<IPoolTrashInvertoryExecutor>().To<PoolTrashInvertoryExecutor>().AsSingle().NonLazy();
        }
    }
}
