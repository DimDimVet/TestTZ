using Zenject;

namespace UI
{
    public class TrashDropInvertory : BaseInvertory
    {
        //[SerializeField] private DropInvertorySettings dropInvertorySettings;
        //private DropInvertoryData dropInvertoryData;

        //protected override void SetSettings()
        //{
        //    dropInvertoryData = new DropInvertoryData
        //    {
        //        ManualObject = dropInvertorySettings.Manual
        //    };
        //}
        //protected override void ScanObject()
        //{
        //    //if (colliderObject == null) { return; }
        //    //else
        //    //{
        //    //    tempHashObject = colliderObject.gameObject.GetHashCode();
        //    //    if (tempHashObject == thisHash) { return; }

        //    //    tempObject = registrator.SetObjectHash(tempHashObject);

        //    //    if (tempObject.TypeObject == TypeObject.Other)
        //    //    {
        //    //        if (isOtherContact == false) { isOtherContact = true; }
        //    //    }

        //    //    if (tempObject.TypeObject == TypeObject.Player)
        //    //    {
        //    //        dropExecutor.SetReturnData(thisHash, tempHashObject, dropData);
        //    //        isOtherContact = false;
        //    //    }

        //    //    if (tempObject.TypeObject == TypeObject.Drop && isOtherContact)
        //    //    {
        //    //        dropExecutor.SetReturnData(thisHash, tempHashObject, dropData);
        //    //        isOtherContact = false;
        //    //    }

        //    //    colliderObject = null;
        //    //}
        //}
        public class Factory : PlaceholderFactory<TrashDropInvertory>
        {
        }
    }
}
