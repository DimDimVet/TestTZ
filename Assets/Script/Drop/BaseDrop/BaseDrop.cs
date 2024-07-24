using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Drop
{
    public class BaseDrop : MonoBehaviour
    {
        [SerializeField][Range(1, 10)] protected float radiusRayCast = 5f;
        private Rigidbody2D rbThisObject;
        protected RaycastHit2D hit;
        protected int tempHashObject;
        protected Construction tempObject;
        protected int thisHash;
        private bool isStopClass = false, isRun = false;

        protected IRegistrator registrator;
        protected IDropExecutor dropExecutor;
        [Inject]
        public void Init(IRegistrator _registrator, IDropExecutor _dropExecutor)
        {
            registrator = _registrator;
            dropExecutor = _dropExecutor;
        }
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
                rbThisObject = GetComponent<Rigidbody2D>();
                if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }
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
            hit = Physics2D.CircleCast(this.transform.position, radiusRayCast, this.transform.position);

            if (hit.collider == null) { return; }
            else
            {
                tempHashObject = hit.collider.gameObject.GetHashCode();
                tempObject = registrator.SetObjectHash(tempHashObject);

                if (tempObject.TypeObject == TypeObject.Player)
                {
                    //
                }
                if (tempObject.TypeObject == TypeObject.Drop)
                {
                    //
                }
            }

        }
    }
}
