using Cysharp.Threading.Tasks;
using System;

namespace StreamAsset
{
    public interface IStreamAssetExecutor
    {
        UniTask LoadDataObject(LoadSaveStructur _textCollection);
        UniTask SaveDataObject(LoadSaveStructur _textCollection);
        Action<LoadSaveStructur> OnSetData { get; set; }
    }
}

