using System;

namespace StreamAsset
{
    public interface IStreamAssetExecutor
    {
        void LoadDataObject(LoadSaveStructur _textCollection);
        void SaveDataObject(LoadSaveStructur _textCollection);
        Action<LoadSaveStructur> OnSetData { get; set; }
        //JxonStructur SetText(JxonStructur _jxonStructur);
        //void FirstSaveFile(JxonStructur _jxonStructur);

        //void Inventary(StatusCustomButton _status);
        //Action<int, int, DropData> OnSetCollisionHash { get; set; }
        //void SetReturnData(int _thisHash, int _receptionHash, DropData _dropData);
    }
}

