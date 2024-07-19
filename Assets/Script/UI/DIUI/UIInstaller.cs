using Zenject;

namespace UI
{
    public class UIInstaller : MonoInstaller
    {
        [Inject] private InvertoryPrefab invertoryPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IUIExecutor>().To<UIExecutor>().AsSingle().NonLazy();

            Container.BindFactory<MonetaDropInvertory, MonetaDropInvertory.Factory>().FromComponentInNewPrefab(invertoryPrefab.MonetaDropInvertory);
            Container.BindFactory<TrashDropInvertory, TrashDropInvertory.Factory>().FromComponentInNewPrefab(invertoryPrefab.TrashDropInvertory);
        }
    }
}
