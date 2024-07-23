using Drop;
using Pools;
using RegistratorObject;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI
{
    public class RespawnInventory : MonoBehaviour
    {
        [SerializeField] private Transform inventaryUIObject;
        private GameObject tempObject;
        private Construction player;
        private DropData[] collectionInventary=new DropData[0];
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
            uiExecutor.OnGetCollectionInventary += GetCollectionInventary;
            uiExecutor.OnSetLoadDrop += RespawnLoadDrop;
        }

        private void RespawnLoadDrop(TypeDrop[] _drop)
        {
            if (collectionInventary != null)
            {
                for(int i = 0; i < collectionInventary.Length; i++)
                {
                    switch (collectionInventary[i].TypeDrop)
                    {
                        case TypeDrop.Trash:
                            poolTrashInvertoryExecutor.ReternObject(collectionInventary[i].HashInventory);
                            break;
                        case TypeDrop.Moneta:
                            poolTrashInvertoryExecutor.ReternObject(collectionInventary[i].HashInventory);
                            break;

                        default:

                            break;
                    }
                }
                Array.Clear(collectionInventary,0, collectionInventary.Length); 
            }
            //
            DropData drop = new DropData();
            for (int i = 0; i < _drop.Length; i++)
            {
                switch (_drop[i])
                {
                    case TypeDrop.Trash:
                        tempObject = poolTrashInvertoryExecutor.GetObject(gameObject.transform.localScale.x, inventaryUIObject);
                        drop.TypeDrop = _drop[i];
                        collectionInventary = CreatDropData(drop, collectionInventary);
                        tempObject.transform.SetParent(inventaryUIObject);
                        break;
                    case TypeDrop.Moneta:
                        tempObject = poolMonetaInvertoryExecutor.GetObject(gameObject.transform.localScale.x, inventaryUIObject);
                        drop.TypeDrop = _drop[i];
                        collectionInventary = CreatDropData(drop, collectionInventary);
                        tempObject.transform.SetParent(inventaryUIObject);
                        break;

                    default:

                        break;
                }
            }
        }

        void Start()
        {
            
        }
        private void RespawnInvertoryObject(int _thisHash, int _receptionHash, DropData _dropData)
        {
            if (player.Hash == 0) { SetPlayer(); }
            else if (player.Hash != _receptionHash) { return; }

            switch (_dropData.TypeDrop)
            {
                case TypeDrop.Trash:
                    tempObject = poolTrashInvertoryExecutor.GetObject(gameObject.transform.localScale.x, inventaryUIObject);
                    _dropData.HashInventory = tempObject.GetHashCode();
                    collectionInventary = CreatDropData(_dropData, collectionInventary);
                    tempObject.transform.SetParent(inventaryUIObject);
                    break;
                case TypeDrop.Moneta:
                    tempObject = poolMonetaInvertoryExecutor.GetObject(gameObject.transform.localScale.x, inventaryUIObject);
                    _dropData.HashInventory = tempObject.GetHashCode();
                    collectionInventary = CreatDropData(_dropData, collectionInventary);
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
        private TypeDrop[] GetCollectionInventary()
        {
            TypeDrop[] temp=new TypeDrop[collectionInventary.Length];
            for (int i = 0; i < collectionInventary.Length; i++)
            {
                temp[i] = collectionInventary[i].TypeDrop;
            }
            return temp;
        }
        public DropData[] CreatDropData(DropData intObject, DropData[] massivObject)
        {
            if (massivObject != null)
            {
                int newLength = massivObject.Length + 1;
                Array.Resize(ref massivObject, newLength);
                massivObject[newLength - 1] = intObject;
                return massivObject;
            }
            else
            {
                massivObject = new DropData[] { intObject };
                return massivObject;
            }
        }
    }
}
