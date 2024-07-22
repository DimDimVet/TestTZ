using UnityEngine;
using Zenject;

namespace UI
{
    public class StreamAssetWrapper : MonoBehaviour
    {
        [SerializeField] private CustomButton saveButton;
        [SerializeField] private CustomButton loadButton;

        private IUIExecutor uiExecutor;

        [Inject]
        public void Init(IUIExecutor _uiExecutor)
        {
            uiExecutor = _uiExecutor;
        }
        private void OnEnable()
        {
            saveButton.OnExecutorButton += SaveButton;
            loadButton.OnExecutorButton += LoadButton;
        }

        private void LoadButton(int _hash, StatusCustomButton _status)
        {
            if (_status == StatusCustomButton.PointDown)
            {
                uiExecutor.LoadData();
            }
        }

        private void SaveButton(int _hash, StatusCustomButton _status)
        {
            if (_status == StatusCustomButton.PointDown)
            {
                uiExecutor.SaveData();
            }
        }


    }
}