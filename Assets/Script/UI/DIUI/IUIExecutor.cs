using System;

namespace UI
{
    public interface IUIExecutor
    {
        Action OnLoadData { get; set; }
        Action OnSaveData { get; set; }
        void LoadData();
        void SaveData();
    }
}

