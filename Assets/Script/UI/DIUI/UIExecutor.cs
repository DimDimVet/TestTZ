using Cysharp.Threading.Tasks;
using Drop;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIExecutor : IUIExecutor
    {
        public Action OnLoadData { get { return onLoadData; } set { onLoadData = value; } }
        private Action onLoadData;
        public Action OnSaveData { get { return onSaveData; } set { onSaveData = value; } }
        private Action onSaveData;
        public Func<TypeDrop[]> OnGetCollectionInventary { get { return onGetCollectionInventary; } set { onGetCollectionInventary = value; } }
        private Func<TypeDrop[]> onGetCollectionInventary;
        public Action<TypeDrop[]> OnSetLoadDrop { get { return onSetLoadDrop; } set { onSetLoadDrop = value; } }
        private Action<TypeDrop[]> onSetLoadDrop;
        public Action OnReBootScene { get { return onReBootScene; } set { onReBootScene = value; } }
        private Action onReBootScene;

        public void LoadData()
        {
            onLoadData?.Invoke();
        }
        public void SaveData()
        {
            onSaveData?.Invoke();
        }
        public TypeDrop[] GetCollectionInventary()
        {
            return onGetCollectionInventary?.Invoke();
        }
        public void SetLoadDrop(TypeDrop[] dropDates)
        {
            onSetLoadDrop?.Invoke(dropDates);
        }
        public void ReBoot(int _currentScene)
        {
            SceneManager.LoadSceneAsync(_currentScene);
            LoadData();
        }
    }
}

