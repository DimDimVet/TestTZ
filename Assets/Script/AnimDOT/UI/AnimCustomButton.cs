using DG.Tweening;
using UI;
using UnityEngine;

namespace Anims
{
    public class AnimCustomButton : MonoBehaviour
    {
        [SerializeField] private CustomButton customButton;
        [SerializeField][Range(1, 5)] protected float buttonScaleNorm = 1.1f;
        [SerializeField][Range(1, 5)] protected float buttonScalePoint = 1.5f;
        [SerializeField][Range(0, 10)] protected float buttonDuration = 1f;
        private Sequence listTweenCustomButton;
        private int thisHash;
        private Vector3 baseScaleButton;
        private float buttonScale;
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
            baseScaleButton = customButton.transform.localScale;
            buttonScale = buttonScaleNorm;
        }
        private void SetTween()
        {
            listTweenCustomButton.Kill();
            listTweenCustomButton = DOTween.Sequence();

            if (customButton != null)
            {
                listTweenCustomButton.Append(customButton.transform.DOScaleY(baseScaleButton.y * buttonScale, buttonDuration));
                listTweenCustomButton.Join(customButton.transform.DOScaleX(baseScaleButton.x * buttonScale, buttonDuration));
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
                    buttonScale = buttonScalePoint;
                    SetTween();
                    break;
                case StatusCustomButton.PointExit:
                    listTweenCustomButton.Pause();
                    buttonScale = buttonScaleNorm;
                    SetTween();
                    break;

                default:

                    break;
            }
        }
    }
}
