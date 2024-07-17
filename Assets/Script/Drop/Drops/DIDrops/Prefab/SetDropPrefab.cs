using UnityEngine;
using Zenject;

namespace Drop
{
    [CreateAssetMenu(fileName = "SetDropPrefab", menuName = "Installers/SetDropPrefab")]
    public class SetDropPrefab : ScriptableObjectInstaller<SetDropPrefab>
    {
        public DropPrefab DropPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DropPrefab>().FromInstance(DropPrefab).AsSingle();
        }
    }
}
