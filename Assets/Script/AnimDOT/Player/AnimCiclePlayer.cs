using DG.Tweening;
using UnityEngine;

namespace Input
{
    public class AnimCiclePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject body;
        [SerializeField][Range(0, 10)] private float bodyScale=5f;
        [SerializeField][Range(0,10)] private float bodyDuration=5f;
        //[SerializeField] private GameObject hayer;
        private bool isRun = false, isStopRun = false;

        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            TweenParams tParms = new TweenParams().SetLoops(-1).SetEase(Ease.OutElastic);
            var tempScale = body.transform.localScale * bodyScale;
            body.transform.DOScale(tempScale, bodyDuration).SetAs(tParms); ;
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
