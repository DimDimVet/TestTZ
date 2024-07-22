using System;

namespace UI
{
    public class UIExecutor : IUIExecutor
    {
        public Action OnLoadData { get { return onLoadData; } set { onLoadData = value; } }
        private Action onLoadData;
        public Action OnSaveData { get { return onSaveData; } set { onSaveData = value; } }
        private Action onSaveData;

        public void LoadData()
        {
            onLoadData?.Invoke();
        }

        public void SaveData()
        {
            onSaveData?.Invoke();
        }
    }
}

