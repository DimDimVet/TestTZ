using Drop;
using Pools;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace UI
{
    public class RespawnInventory : MonoBehaviour
    {
        [SerializeField] private Transform inventaryUIObject;
        private GameObject tempObject;
        private Construction player;
        //
        private IRegistrator registrator;
        private IDropExecutor dropExecutor;
        private IUIExecutor uiExecutor;
        private IPoolMonetaInvertoryExecutor poolMonetaInvertoryExecutor;
        private IPoolTrashInvertoryExecutor poolTrashInvertoryExecutor;

        [Inject]
        public void Init(IRegistrator _registrator,IDropExecutor _dropExecutor,IUIExecutor _uiExecutor, 
                         IPoolMonetaInvertoryExecutor _poolMonetaInvertoryExecutor,
                         IPoolTrashInvertoryExecutor _poolTrashInvertoryExecutor)
        {
            registrator = _registrator;
            dropExecutor = _dropExecutor;
            uiExecutor = _uiExecutor;
            poolMonetaInvertoryExecutor = _poolMonetaInvertoryExecutor;
            poolTrashInvertoryExecutor = _poolTrashInvertoryExecutor;
        }
        private void OnEnable()
        {
            dropExecutor.OnSetCollisionHash += RespawnInvertoryObject;
        }
        void Start()
        {
            
        }
        //private void SetCollisionHash(int _thisHash, int _receptionHash, DropData _dropData)
        //{
        //    poolMonetaDrop.ReternObject(_thisHash);
        //    poolTrashDrop.ReternObject(_thisHash);
        //}
        private void RespawnInvertoryObject(int _thisHash, int _receptionHash, DropData _dropData)
        {
            if (player.Hash == 0) { SetPlayer(); }
            else if (player.Hash != _receptionHash) { return; }

            switch (_dropData.TypeDrop)
            {
                case TypeDrop.Trash:
                    tempObject = poolTrashInvertoryExecutor.GetObject(gameObject.transform.localScale.x, inventaryUIObject);
                    tempObject.transform.SetParent(inventaryUIObject);
                    break;
                case TypeDrop.Moneta:
                    tempObject = poolMonetaInvertoryExecutor.GetObject(gameObject.transform.localScale.x, inventaryUIObject);
                    tempObject.transform.SetParent(inventaryUIObject);
                    break;

                default:

                    break;
            }
        }
        private void SetPlayer()
        {
            player = registrator.SetPlayer();
        }
    }
}
