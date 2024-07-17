using Zenject;

namespace Drop
{
    public class DropInstaller : MonoInstaller
    {
        [Inject] private DropPrefab dropPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IDropExecutor>().To<DropExecutor>().AsSingle().NonLazy();

            Container.BindFactory<MonetaDrop, MonetaDrop.Factory>().FromComponentInNewPrefab(dropPrefab.MonetaDrop);
            Container.BindFactory<TrashDrop, TrashDrop.Factory>().FromComponentInNewPrefab(dropPrefab.TrashDrop);
        }
    }
}
