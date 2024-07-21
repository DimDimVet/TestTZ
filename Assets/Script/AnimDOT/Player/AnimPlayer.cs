using DG.Tweening;
using Input;
using UnityEngine;
using Zenject;

namespace Anims
{
    public class AnimPlayer : MonoBehaviour
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

        [SerializeField][Range(1, 3)] private float mouthUpScale = 1.1f;
        [SerializeField][Range(0, 10)] private float mouthUpDuration = 1f;

        Sequence listTweenHayer, listTweenMouth;

        private IInput inputData;
        [Inject]
        public void Init(IInput _inputData)
        {
            inputData = _inputData;
        }
        private void OnEnable()
        {
            inputData.OnStartPressButton += StartJamp;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            if (listTweenHayer == null) { listTweenHayer = DOTween.Sequence(); }
            if (listTweenMouth == null) { listTweenMouth = DOTween.Sequence(); }

            if (body != null)
            {
                listTweenHayer.Append(hayer.transform.DOScale(hayer.transform.localScale * hayerScale, hayerDuration)).SetEase(Ease.Linear);
                listTweenHayer.Append(hayer.transform.DOScale(hayer.transform.localScale, hayerDuration).SetEase(Ease.Linear));

                listTweenHayer.AppendCallback(() =>
                {
                    if (body == null)
                    { listTweenHayer.Kill(); }
                });
                listTweenHayer.SetLoops(-1, LoopType.Restart);
                //
                listTweenMouth.Pause();
                listTweenMouth.Append(mouth.transform.DOScaleX(mouth.transform.localScale.x * mouthUpScale, mouthUpDuration).SetEase(Ease.Linear));
                listTweenMouth.Join(eye.transform.DOScale(eye.transform.localScale * eyeScale, eyeDuration));
                listTweenMouth.Join(body.transform.DOScaleY(body.transform.localScale.y * bodyScale, bodyDuration));

                listTweenMouth.Append(mouth.transform.DOScaleX(mouth.transform.localScale.x, mouthUpDuration).SetEase(Ease.Linear));
                listTweenMouth.Join(eye.transform.DOScale(eye.transform.localScale, eyeDuration));
                listTweenMouth.Join(body.transform.DOScaleY(body.transform.localScale.y, bodyDuration));

                listTweenMouth.AppendCallback(() =>
                {
                    listTweenMouth.Pause();
                });
                listTweenMouth.SetLoops(-1, LoopType.Restart);
            }
        }

        private void StartJamp(InputData _inputData)
        {
            listTweenMouth.Play();
        }
    }
}
