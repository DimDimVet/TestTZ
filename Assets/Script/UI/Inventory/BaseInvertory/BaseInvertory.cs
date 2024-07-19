using Drop;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace UI
{
    public class BaseInvertory : MonoBehaviour
    {
        protected int tempHashObject;
        protected Construction tempObject;
        protected int thisHash;
        private bool isStopClass = false, isRun = false;

        //protected IRegistrator registrator;
        //protected IDropExecutor dropExecutor;
        //[Inject]
        //public void Init(IRegistrator _registrator, IDropExecutor _dropExecutor)
        //{
        //    registrator = _registrator;
        //    dropExecutor = _dropExecutor;
        //}
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
                isRun = true;
            }
        }
        protected virtual void SetSettings()
        {
            //
        }
        void FixedUpdate()
        {
            if (isStopClass) { return; }
            if (!isRun) { SetClass(); }
            ScanObject();
        }
        protected virtual void ScanObject()
        {

        }
    }
}
