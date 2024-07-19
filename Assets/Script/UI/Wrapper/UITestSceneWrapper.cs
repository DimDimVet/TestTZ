using UnityEngine;
using Zenject;

namespace UI
{
    public class UITestSceneWrapper : MonoBehaviour
    {
        [SerializeField] private CustomButton inventaryButton;
        private bool isStopClass = false, isRun = false;

        private IUIExecutor uiExecutor;
        [Inject]
        public void Init(IUIExecutor _uiExecutor)
        {
            uiExecutor = _uiExecutor;
        }
        private void OnEnable()
        {
            inventaryButton.OnExecutorButton += InventaryButtonExecutor;
        }
        void Start()
        {
            SetClass();
        }
        private void SetClass()
        {
            if (!isRun)
            {
                if(inventaryButton == null) { return; }
                isRun = true;
            }
        }
        private void InventaryButtonExecutor(int _hash, StatusCustomButton _status)
        {
            uiExecutor.Inventary(_status);
        }
        void LateUpdate()
        {
            if (isStopClass) { return; }
            if (!isRun) { SetClass(); }
            RunUpdate();
        }
        private void RunUpdate()
        {

        }
        private void OnDisable()
        {

        }
    }
}
