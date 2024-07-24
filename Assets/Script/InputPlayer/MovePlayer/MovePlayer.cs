using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Input
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private MoveSettings settings;
        [SerializeField] private Transform pointOutRay;
        private float moveSpeed, jampSpeed, gndDistance;
        private Rigidbody2D rbThisObject;
        private int tempHashObject;
        private Construction tempObject;
        private RaycastHit2D hit;
        private Vector3 scale;
        private InputData inputs;
        private bool isMoveTrigger;
        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        private IRegistrator registrator;
        [Inject]
        public void Init(IInput _inputData, IRegistrator _registrator)
        {
            inputData = _inputData;
            registrator = _registrator;
        }
        private void OnEnable()
        {
            inputData.Enable();
            inputData.OnMoveButton += SetInput;
            inputData.OnStartPressButton += SetInput;
            inputData.OnEndPressButton += SetInput;
        }
        void Start()
        {
            inputData.Enable();
            SetSettings();
        }
        private void SetSettings()
        {
            moveSpeed = settings.MoveSpeed;
            jampSpeed = settings.JampSpeed;
            gndDistance = settings.GndDistance;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                rbThisObject = GetComponent<Rigidbody2D>();
                if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }
                isRun = true;
            }
        }
        private void SetInput(InputData _inputData)
        {
            inputs = _inputData;
        }
        void FixedUpdate()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); return; }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Move();
        }
        private void Move()
        {
            scale = transform.localScale;
            if (ScanGND())
            {
                isMoveTrigger = true;
                if (inputs.Jamp > 0)
                {
                    rbThisObject.velocity = transform.up * jampSpeed;
                }
                else
                {
                    if (inputs.Move.x > 0)
                    {
                        if (scale.x == -1 && inputs.Move.x > 0) { Flip(); }
                        rbThisObject.velocity = transform.right * moveSpeed;
                    }
                    else if (inputs.Move.x < 0)
                    {
                        if (scale.x == 1 && inputs.Move.x < 0) { Flip(); }
                        rbThisObject.velocity = -transform.right * moveSpeed;
                    }
                    else { rbThisObject.velocity = new Vector2 {x=0,y= rbThisObject.velocity.y }; }
                }
            }
            else
            {
                if (inputs.Move.x > 0 && isMoveTrigger)
                {
                    isMoveTrigger = false;
                    if (scale.x == -1 && inputs.Move.x > 0) { Flip(); }
                    rbThisObject.velocity = transform.right * jampSpeed;
                }
                else if (inputs.Move.x < 0 && isMoveTrigger)
                {
                    isMoveTrigger = false;
                    if (scale.x == 1 && inputs.Move.x < 0) { Flip(); }
                    rbThisObject.velocity = -transform.right * jampSpeed;
                }
            }

            if (inputs.Move.x > 0 && isMoveTrigger && inputs.Jamp > 0)
            {
                isMoveTrigger = false;
                if (scale.x == -1 && inputs.Move.x > 0) { Flip(); }
                rbThisObject.velocity = new Vector2(1, 1) * jampSpeed;
            }
            else if (inputs.Move.x < 0 && isMoveTrigger && inputs.Jamp > 0)
            {
                isMoveTrigger = false;
                if (scale.x == 1 && inputs.Move.x < 0) { Flip(); }
                rbThisObject.velocity = -new Vector2(1, -1) * jampSpeed;
            }
        }
        private void Flip()
        {
            scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        private bool ScanGND()
        {
            hit = Physics2D.Raycast(pointOutRay.position, Vector2.down, gndDistance);

            if (hit.collider == null) { return false; }
            else
            {
                if (tempHashObject != hit.collider.gameObject.GetHashCode())
                {
                    tempHashObject = hit.collider.gameObject.GetHashCode();
                    tempObject = registrator.SetObjectHash(tempHashObject);
                }
                else
                {
                    if (tempObject.TypeObject == TypeObject.Other)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
