using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Drop
{
    public class TrashDrop : BaseDrop
    {
        [SerializeField] private DropSettings dropSettings;
        private DropData dropData;
        private Collider2D colliderObject;
        private bool isOtherContact=false;
        protected override void SetSettings()
        {
            dropData = new DropData
            {
                Trash = dropSettings.Trash,
                Price = dropSettings.Price,
                TypeObject = TypeObject.Drop,
                TypeDrop = dropSettings.TypeDrop,
            };
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            colliderObject = collision;
        }
        protected override void ScanObject()
        {
            if (colliderObject == null) { return; }
            else
            {
                tempHashObject = colliderObject.gameObject.GetHashCode();
                if (tempHashObject == thisHash) { return; }

                tempObject = registrator.SetObjectHash(tempHashObject);

                if (tempObject.TypeObject == TypeObject.Other)
                {
                    if (isOtherContact == false) { isOtherContact=true; }
                }

                if (tempObject.TypeObject == TypeObject.Player)
                {
                    dropExecutor.SetReturnData(thisHash, tempHashObject, dropData);
                    isOtherContact = false;
                }

                if (tempObject.TypeObject == TypeObject.Drop && isOtherContact)
                {
                    dropExecutor.SetReturnData(thisHash, tempHashObject, dropData);
                    isOtherContact = false;
                }

                colliderObject = null;
            }
        }
        public class Factory : PlaceholderFactory<TrashDrop>
        {
        }
    }
}
