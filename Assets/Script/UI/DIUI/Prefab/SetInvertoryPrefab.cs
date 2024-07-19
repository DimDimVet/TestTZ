using UI;
using UnityEngine;
using Zenject;

namespace Drop
{
    [CreateAssetMenu(fileName = "SetInvertoryPrefab", menuName = "Installers/SetInvertoryPrefab")]
    public class SetInvertoryPrefab : ScriptableObjectInstaller<SetInvertoryPrefab>
    {
        public InvertoryPrefab InvertoryPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InvertoryPrefab>().FromInstance(InvertoryPrefab).AsSingle();
        }
    }
}
