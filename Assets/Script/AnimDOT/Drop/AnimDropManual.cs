using DG.Tweening;
using UI;
using UnityEngine;

namespace Anims
{
    public class AnimDropManual : MonoBehaviour
    {
        [SerializeField] private CustomButton customButton;
        [SerializeField] private Transform manualObject;
        [SerializeField][Range(0, 10)] protected float manualObjectDuration = 1f;

        private float scaleNorm = 0;
        private float scalePoint = 1f;

        private Sequence listTweenCustomButton;
        private int thisHash;
        private Vector3 baseScaleManualObject;
        private float panelScale;
        private void OnEnable()
        {
            customButton.OnExecutorButton += PointEnter;
        }
        void Start()
        {
            SetSettings();
            SetTween();
        }
        private void SetSettings()
        {
            thisHash = this.gameObject.GetHashCode();
            manualObject.localScale= manualObject.localScale * 0;

            panelScale = scaleNorm;
        }
        private void SetTween()
        {
            listTweenCustomButton.Kill();
            listTweenCustomButton = DOTween.Sequence();

            if (customButton != null)
            {
                listTweenCustomButton.Append(manualObject.DOScaleY(baseScaleManualObject.y + panelScale, manualObjectDuration));
                listTweenCustomButton.Join(manualObject.DOScaleX(baseScaleManualObject.x + panelScale, manualObjectDuration));
                listTweenCustomButton.AppendCallback(() => { listTweenCustomButton.Kill(); });
            }
        }

        private void PointEnter(int _hash, StatusCustomButton _status)
        {
            if (thisHash != _hash) { return; }
            switch (_status)
            {
                case StatusCustomButton.PointEnter:
                    listTweenCustomButton.Pause();
                    panelScale = scalePoint;
                    SetTween();
                    break;
                case StatusCustomButton.PointExit:
                    listTweenCustomButton.Pause();
                    panelScale = scaleNorm;
                    SetTween();
                    break;
                case StatusCustomButton.PointDown:

                    break;
                case StatusCustomButton.PointUp:

                    break;

                default:

                    break;
            }
        }
    }
}
