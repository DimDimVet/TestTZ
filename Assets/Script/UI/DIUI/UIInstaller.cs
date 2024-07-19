using Zenject;

namespace UI
{
    public class UIInstaller : MonoInstaller
    {
        //[Inject] private DropPrefab dropPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IUIExecutor>().To<UIExecutor>().AsSingle().NonLazy();

            //Container.BindFactory<MonetaDrop, MonetaDrop.Factory>().FromComponentInNewPrefab(dropPrefab.MonetaDrop);
            //Container.BindFactory<TrashDrop, TrashDrop.Factory>().FromComponentInNewPrefab(dropPrefab.TrashDrop);
        }
    }
}
