using UnityEngine;
using Zenject;

namespace Input
{
    public class RotatePlayer : MonoBehaviour
    {
        [SerializeField] private RotatseSetting settings;
        [SerializeField] private Camera cameraComponent;
        [SerializeField] private GameObject childGameObject;
        private float anglePlus, angleMinus, angle;
        private Vector2 currentMousePosition, direction;
        private Vector3 worldMousePosition, scale, pos;
        private InputData inputs;
        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        [Inject]
        public void Init(IInput _inputData)
        {
            inputData = _inputData;
        }
        private void OnEnable()
        {
            inputData.OnMoveMouse += SetInput;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            anglePlus = settings.AnglePlus;
            angleMinus = settings.AngleMinus;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                isRun = true;
            }
        }
        private void SetInput(InputData _inputData)
        {
            inputs = _inputData;
        }
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Rotate();
        }
        private void Rotate()
        {
            scale = transform.localScale;
            pos = cameraComponent.WorldToScreenPoint(gameObject.transform.position);
            if (inputs.MousePosition.x > pos.x && scale.x <= -0) { Flip(); }
            if (inputs.MousePosition.x < pos.x && scale.x >= 0) { Flip(); }

            currentMousePosition = (Vector2)inputs.MousePosition;
            worldMousePosition = cameraComponent.ScreenToWorldPoint(currentMousePosition);
            direction = worldMousePosition - gameObject.transform.position;
            angle = Vector2.SignedAngle(Vector2.right, direction);

            if (scale.x <= -0)
            {
                if (angle >= 90 && angle <= 180) { angle = 180 - angle; }
                if (angle <= -90 && angle >= -180) { angle = -180 - angle; }

                if (angle <= angleMinus) { angle = angleMinus; }
                if (angle >= anglePlus) { angle = anglePlus; }
                childGameObject.transform.eulerAngles = new Vector3(0, 0, -angle);

            }
            if (scale.x >= 0)
            {
                if (angle >= anglePlus) { angle = anglePlus; }
                if (angle <= angleMinus) { angle = angleMinus; }
                childGameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
        private void Flip()
        {
            scale = gameObject.transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
        }
    }
}

