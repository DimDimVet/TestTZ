using DG.Tweening;
using DG.Tweening.Core.Easing;
using System;
using UI;
using UnityEngine;

namespace Anims
{
    public class AnimInventaryOpenBotton : MonoBehaviour
    {
        public Action<bool> OnExecutorOpenBotton { get { return onExecutorOpenBotton; } set { onExecutorOpenBotton = value; } }
        private Action<bool> onExecutorOpenBotton;

        [SerializeField] private CustomButton customButton;
        [Header("��������� scale")]
        [SerializeField][Range(1, 5)] protected float buttonScaleNorm = 1.1f;
        [SerializeField][Range(1, 5)] protected float buttonScalePoint = 1.5f;
        [SerializeField][Range(0, 10)] protected float buttonScaleDuration = 1f;
        [Header("��������� move")]
        [SerializeField][Range(-3, 3)] protected float buttonMovePoint = -1f;
        [SerializeField][Range(0, 10)] protected float buttonMoveDuration = 1f;
        protected float buttonMoveNorm = 1f;

        private Sequence listTweenScaleButton;
        private Sequence listTweenMoveButton;
        //private int thisHash;
        private Vector3 baseScaleButton, baseMoveButton;
        private float buttonScale, buttonMove;
        private bool isMove = false;
        private bool isBreak = false;
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
            baseScaleButton = customButton.transform.localScale;
            buttonScale = buttonScaleNorm;
            //
            baseMoveButton = customButton.transform.position;
            buttonMove = buttonMoveNorm;
        }
        private void SetTween()
        {
            listTweenScaleButton.Kill();
            listTweenScaleButton = DOTween.Sequence();

            if (customButton != null)
            {
                listTweenScaleButton.Append(customButton.transform.DOScaleY(baseScaleButton.y * buttonScale, buttonScaleDuration));
                listTweenScaleButton.Join(customButton.transform.DOScaleX(baseScaleButton.x * buttonScale, buttonScaleDuration));
                listTweenScaleButton.AppendCallback(() => { listTweenScaleButton.Kill(); });
            }
        }
        private void SetMoveTween()
        {
            listTweenMoveButton.Kill();
            listTweenMoveButton = DOTween.Sequence();

            if (customButton != null)
            {
                listTweenMoveButton.Append(customButton.transform.DOMoveY(baseMoveButton.y * buttonMove, buttonMoveDuration));
                //listTweenCustomButton.Join(customButton.transform.DOScaleX(baseScaleButton.x * buttonScale, buttonDuration));
                listTweenMoveButton.AppendCallback(() =>
                {
                    listTweenMoveButton.Kill();
                    onExecutorOpenBotton?.Invoke(isMove);
                });
            }
        }
        public void DefaultTween()
        {
            PointEnter(0, StatusCustomButton.PointDown);
        }
        private void PointEnter(int _hash, StatusCustomButton _status)
        {
            switch (_status)
            {
                case StatusCustomButton.PointEnter:
                    listTweenScaleButton.Pause();
                    buttonScale = buttonScalePoint;
                    SetTween();
                    break;
                case StatusCustomButton.PointExit:
                    listTweenScaleButton.Pause();
                    buttonScale = buttonScaleNorm;
                    SetTween();
                    break;
                case StatusCustomButton.PointDown:
                    if (!isMove) { isMove = true; buttonMove = buttonMovePoint; }
                    else { isMove = false; buttonMove = buttonMoveNorm; }

                    SetMoveTween();
                    break;
                case StatusCustomButton.PointUp:

                    break;

                default:

                    break;
            }

        }
    }
}