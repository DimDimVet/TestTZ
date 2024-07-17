using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Drop
{
    public class TrashDrop : BaseDrop
    {
        [SerializeField] private DropSettings dropSettings;
        private DropData dropData;
        protected override void SetSettings()
        {
            dropData = new DropData
            {
                Trash = dropSettings.Trash,
                Price = dropSettings.Price,
                TypeObject = TypeObject.Drop,
            };
        }
        protected override void ScanObject()
        {
            Collider2D collider2D;
            collider2D = Physics2D.OverlapCircle(this.transform.position, radiusRayCast);

            if (collider2D == null) { return; }
            else
            {
                tempHashObject = collider2D.gameObject.GetHashCode();
                if (tempHashObject == thisHash) { return; }

                tempObject = registrator.SetObjectHash(tempHashObject);

                if (tempObject.TypeObject == TypeObject.Player)
                {
                    dropExecutor.SetReturnData(thisHash, tempHashObject, dropData);
                }
                if (tempObject.TypeObject == TypeObject.Drop)
                {
                    dropExecutor.SetReturnData(thisHash, tempHashObject, dropData);
                }
            }
        }
        public class Factory : PlaceholderFactory<TrashDrop>
        {
        }
    }
}
