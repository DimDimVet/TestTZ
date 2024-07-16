using DG.Tweening;
using RegistratorObject;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Input
{
    public class AnimCiclePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject body;
        [SerializeField] private GameObject hayer;
        [SerializeField] private GameObject eye;
        [SerializeField] private GameObject armUp;
        [SerializeField] private GameObject mouth;

        [SerializeField][Range(1, 2)] private float bodyScale = 1.1f;
        [SerializeField][Range(0, 10)] private float bodyDuration = 1f;

        [SerializeField][Range(1, 2)] private float hayerScale = 1.1f;
        [SerializeField][Range(0, 10)] private float hayerDuration = 1f;

        [SerializeField][Range(1, 2)] private float eyeScale = 1.1f;
        [SerializeField][Range(0, 10)] private float eyeDuration = 1f;

        [SerializeField][Range(1, 2)] private float armUpScale = 1.1f;
        [SerializeField][Range(0, 10)] private float armUpDuration = 1f;

        [SerializeField][Range(1, 3)] private float mouthUpScale = 1.1f;
        [SerializeField][Range(0, 10)] private float mouthUpDuration = 1f;

        Sequence listHayer,listMouth;

        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        [Inject]
        public void Init(IInput _inputData)
        {
            inputData = _inputData;
        }
        private void OnEnable()
        {
            inputData.OnStartJamp += StartJamp;
            inputData.OnEndJamp += EndJamp;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {

            listHayer = DOTween.Sequence();
            listMouth = DOTween.Sequence(); 

            if (body != null)
            {
                //sequence.Append(body.transform.DOScaleX(3 , bodyDuration));
                listHayer.Append(hayer.transform.DOScale(hayer.transform.localScale * hayerScale, hayerDuration)).SetEase(Ease.Linear);
                listHayer.Append(hayer.transform.DOScale(hayer.transform.localScale, hayerDuration).SetEase(Ease.Linear));
                //listHayer.Join(eye.transform.DOScale(eye.transform.localScale * eyeScale, eyeDuration));
                //listHayer.Join(armUp.transform.DOScale(armUp.transform.localScale * armUpScale, armUpDuration));
                //listHayer.Join(mouth.transform.DOScale(mouth.transform.localScale * mouthUpScale, mouthUpDuration));
                listHayer.AppendCallback(() => 
                {
                    if (body == null)
                    { listHayer.Kill(); }
                });
                listHayer.SetLoops(-1, LoopType.Restart);
                //
                listMouth.Pause();
                listMouth.Append(mouth.transform.DOScaleX(mouth.transform.localScale.x * mouthUpScale, mouthUpDuration).SetEase(Ease.Linear));
                listMouth.Join(eye.transform.DOScale(eye.transform.localScale * eyeScale, eyeDuration));
                listMouth.Join(body.transform.DOScaleY(body.transform.localScale.y * bodyScale, bodyDuration));

                listMouth.Append(mouth.transform.DOScaleX(mouth.transform.localScale.x, mouthUpDuration).SetEase(Ease.Linear));
                listMouth.Join(eye.transform.DOScale(eye.transform.localScale, eyeDuration));
                listMouth.Join(body.transform.DOScaleY(body.transform.localScale.y, bodyDuration));

                listMouth.AppendCallback(() =>
                {
                    listMouth.Pause();
                });
                listMouth.SetLoops(-1, LoopType.Restart);
                //
            }
        }

        private void StartJamp(InputData _inputData) 
        {
            listMouth.Play();
        }
        private void EndJamp(InputData _inputData)
        {
            //listMouth.PlayBackwards();
        }
        private void PauseButton()
        {
            listHayer.Pause();
        }
        private void PlayButton()
        {
            listHayer.Play();
        }
        private void KillButton()
        {
            listHayer.Kill();
        }
        private void PlayForwardButton()
        {
            listHayer.PlayForward();
        }
        private void PlayBackwardsButton()
        {
            listHayer.PlayBackwards();
        }
        private void GetRun()
        {
            if (!isRun)
            {
                isRun = true;
            }
        }
    }
}
