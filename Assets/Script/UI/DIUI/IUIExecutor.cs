using Cysharp.Threading.Tasks;
using Drop;
using System;

namespace UI
{
    public interface IUIExecutor
    {
        Action OnLoadData { get; set; }
        Action OnSaveData { get; set; }
        void LoadData();
        void SaveData();
        Func<TypeDrop[]> OnGetCollectionInventary { get; set; }
        TypeDrop[] GetCollectionInventary();
        void SetLoadDrop(TypeDrop[] dropDates);
        Action<TypeDrop[]> OnSetLoadDrop { get; set; }
        Action OnReBootScene { get; set; }
        void ReBoot(int _currentScene);
    }
}

