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
        private string tagGnd;
        private RaycastHit2D hit;
        private Vector3 scale;
        private bool isMoveTrigger;
        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        [Inject]
        public void Init(IInput x)
        {
            inputData = x;
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
            tagGnd = settings.TagGnd;
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
                if (inputData.Updata().Jamp > 0)
                {
                    rbThisObject.velocity = transform.up * jampSpeed;
                }
                else
                {
                    if (inputData.Updata().Move.x > 0)
                    {
                        if (scale.x == -1 && inputData.Updata().Move.x > 0) { Flip(); }
                        rbThisObject.velocity = transform.right * moveSpeed;
                    }
                    if (inputData.Updata().Move.x < 0)
                    {
                        if (scale.x == 1 && inputData.Updata().Move.x < 0) { Flip(); }
                        rbThisObject.velocity = -transform.right * moveSpeed;
                    }
                }

            }
            else
            {
                if (inputData.Updata().Move.x > 0 && isMoveTrigger )
                {
                    isMoveTrigger = false;
                    if (scale.x == -1 && inputData.Updata().Move.x > 0) { Flip(); }
                    rbThisObject.velocity = transform.right * jampSpeed;
                }
                if (inputData.Updata().Move.x < 0 && isMoveTrigger )
                {
                    isMoveTrigger = false;
                    if (scale.x == 1 && inputData.Updata().Move.x < 0) { Flip(); }
                    rbThisObject.velocity = -transform.right * jampSpeed;
                }

            }

            if (inputData.Updata().Move.x > 0 && isMoveTrigger && inputData.Updata().Jamp > 0)
            {
                isMoveTrigger = false;
                if (scale.x == -1 && inputData.Updata().Move.x > 0) { Flip(); }
                rbThisObject.velocity = new Vector2(1, 1) * jampSpeed;
            }
            if (inputData.Updata().Move.x < 0 && isMoveTrigger && inputData.Updata().Jamp > 0)
            {
                isMoveTrigger = false;
                if (scale.x == 1 && inputData.Updata().Move.x < 0) { Flip(); }
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
            else if (hit.collider.gameObject.tag == tagGnd) { return true; }
            else { return false; }
        }
    }
}

