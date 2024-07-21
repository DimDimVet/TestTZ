using DG.Tweening;
using UI;
using UnityEngine;

namespace Anims
{
    public class AnimInventaryPanel : MonoBehaviour
    {
        [SerializeField] private AnimInventaryOpenBotton openButton;
        [SerializeField] private AnimInventaryCloseBotton closeButton;
        [Header("Настройки move")]
        [SerializeField] protected Vector2 panelPositionEnd;
        [SerializeField][Range(0, 10)] protected float panelMoveDuration = 1f;
        protected Vector2 panelMoveNorm;

        private Transform thisTransform;
        private Sequence listTweenMovePanel;
        //private int thisHash;
        private Vector3  baseMovePanel;
        private bool isMove=false;
        private void OnEnable()
        {
            openButton.OnExecutorOpenBotton += OpenPointEnter;
            closeButton.OnExecutorCloseBotton += ClosePointEnter;    
        }
        void Start()
        {
            SetSettings();
            SetMoveTween();
        }
        private void SetSettings()
        {
            //thisHash = this.gameObject.GetHashCode();
            thisTransform=this.gameObject.transform;
            //
            panelMoveNorm = thisTransform.transform.position;
            baseMovePanel = panelMoveNorm;
        }
        private void SetMoveTween()
        {
            listTweenMovePanel = DOTween.Sequence();

            if (thisTransform != null)
            {
                listTweenMovePanel.Append(thisTransform.transform.DOMoveX(baseMovePanel.x, panelMoveDuration));
                //listTweenCustomButton.Join(customButton.transform.DOScaleX(baseScaleButton.x * buttonScale, buttonDuration));
                listTweenMovePanel.AppendCallback(() => 
                {
                    listTweenMovePanel.Kill();
                });
            }
        }
        private void OpenPointEnter(bool _isStatus)
        {
            isMove = _isStatus;
            if (isMove) 
            {
                
                baseMovePanel = panelPositionEnd;
                SetMoveTween();
            }
        }
        private void ClosePointEnter( bool _isStatus)
        {
            isMove = _isStatus;
            if (isMove)
            {
                baseMovePanel = panelMoveNorm;
                SetMoveTween();
                openButton.DefaultTween();
                closeButton.DefaultTween();
            }
        }
    }
}
