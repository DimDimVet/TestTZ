using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class CustomButton : Button
    {
        public Action<int, StatusCustomButton> OnExecutorButton { get { return onExecutorButton; } set { onExecutorButton = value; } }
        private Action<int, StatusCustomButton> onExecutorButton;

        private int thisHash;
        protected override void Start()
        {
            thisHash = this.gameObject.GetHashCode();
        }
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            onExecutorButton?.Invoke(thisHash, StatusCustomButton.PointEnter);
        }
        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            onExecutorButton?.Invoke(thisHash, StatusCustomButton.PointExit);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            onExecutorButton?.Invoke(thisHash, StatusCustomButton.PointDown);
        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            onExecutorButton?.Invoke(thisHash, StatusCustomButton.PointUp);
        }
    }
}

