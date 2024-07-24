using DG.Tweening;
using Drop;
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
        private int thisHash;

        protected IDropExecutor dropExecutor;
        [Inject]
        public void Init(IDropExecutor _dropExecutor)
        {
            dropExecutor = _dropExecutor;
        }
        private void OnEnable()
        {
            listTweenDrop.Play();
            dropExecutor.OnSetCollisionHash += ConnectObject;
        }
        void Start()
        {
            SetSettings();
            SetTween();
        }
        private void SetSettings()
        {
            thisHash = this.gameObject.GetHashCode();
            drop = this.gameObject;
        }
        private void SetTween()
        {
            listTweenDrop = DOTween.Sequence();

            if (drop != null)
            {
                listTweenDrop.Append(drop.transform.DOScaleY(drop.transform.localScale.y * dropScale, dropDuration).SetEase(Ease.Linear));
                listTweenDrop.Join(drop.transform.DOScaleX(drop.transform.localScale.x * dropScale, dropDuration).SetEase(Ease.Linear));

                listTweenDrop.Append(drop.transform.DOScaleY(drop.transform.localScale.y, dropDuration).SetEase(Ease.Linear));
                listTweenDrop.Join(drop.transform.DOScaleX(drop.transform.localScale.x, dropDuration).SetEase(Ease.Linear));

                listTweenDrop.AppendCallback(() => { });
                listTweenDrop.SetLoops(-1, LoopType.Restart);
            }
        }

        private void ConnectObject(int _thisHash, int _receptionHash, DropData _dropData)
        {
            if (_thisHash == thisHash)
            {
                listTweenDrop.Pause();
            }
        }
        
    }
}
