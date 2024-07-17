using DG.Tweening;
using Input;
using UnityEngine;
using Zenject;

namespace Anims
{
    public class AnimDropBase : MonoBehaviour
    {
        [SerializeField][Range(1, 2)] protected float dropScale = 1.1f;
        [SerializeField][Range(0, 10)] protected float dropDuration = 1f;
        protected GameObject drop;
        protected Sequence listTweenDrop;

        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        [Inject]
        public void Init(IInput _inputData)
        {
            inputData = _inputData;
        }
        private void OnEnable()
        {
            //inputData.OnStartPressButton += StartJamp;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            drop = this.gameObject;

            listTweenDrop = DOTween.Sequence();

            if (drop != null)
            {
                //
                listTweenDrop.Pause();
                listTweenDrop.Append(drop.transform.DOScaleX(drop.transform.localScale.x * dropScale, dropDuration).SetEase(Ease.Linear));
                listTweenDrop.Append(drop.transform.DOScaleX(drop.transform.localScale.x, dropDuration).SetEase(Ease.Linear));

                listTweenDrop.AppendCallback(() =>
                {
                    listTweenDrop.Pause();
                });
                listTweenDrop.SetLoops(-1, LoopType.Restart);
                //
            }
        }

        //private void StartJamp(InputData _inputData)
        //{
        //    listMouth.Play();
        //}
        //private void EndJamp(InputData _inputData)
        //{
        //    //listMouth.PlayBackwards();
        //}
        //private void PauseButton()
        //{
        //    listHayer.Pause();
        //}
        //private void PlayButton()
        //{
        //    listHayer.Play();
        //}
        //private void KillButton()
        //{
        //    listHayer.Kill();
        //}
        //private void PlayForwardButton()
        //{
        //    listHayer.PlayForward();
        //}
        //private void PlayBackwardsButton()
        //{
        //    listHayer.PlayBackwards();
        //}
        private void GetRun()
        {
            if (!isRun)
            {
                isRun = true;
            }
        }
    }
}
