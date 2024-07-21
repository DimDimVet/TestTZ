using RegistratorObject;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BaseInvertory : MonoBehaviour
    {
        [SerializeField] private DropInvertorySettings dropInvertorySettings;
        [SerializeField] private Text textPole;
        protected int tempHashObject;
        protected Construction tempObject;
        protected int thisHash;
        private string manual;
        private bool isStopClass = false, isRun = false;

        void Start()
        {
            thisHash = this.gameObject.GetHashCode();
            SetClass();
            SetSettings();
        }
        private void SetClass()
        {
            if (!isRun)
            {
                manual = dropInvertorySettings.Manual;
                isRun = true;
            }
        }
        protected virtual void SetSettings()
        {
            if (textPole != null) { textPole.text = manual; }
        }
        public string GetManual()
        {
            return manual;
        }
        void Update()
        {
            if (isStopClass) { return; }
            if (!isRun) { SetClass(); }
        }
    }
}
