using Zenject;

namespace StreamAsset
{
    public class StreamAssetInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStreamAssetExecutor>().To<StreamAssetExecutor>().AsSingle().NonLazy();
        }
    }
}
