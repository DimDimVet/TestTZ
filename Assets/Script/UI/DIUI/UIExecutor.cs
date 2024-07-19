using System;

namespace UI
{
    public class UIExecutor : IUIExecutor
    {
        public Action OnInventary { get { return onInventary; } set { onInventary = value; } }
        private Action onInventary;

        //public void SetReturnData(int _thisHash, int _receptionHash, DropData _dropData)
        //{
        //    onSetCollisionHash?.Invoke(_thisHash, _receptionHash, _dropData);
        //}

        public void Inventary(StatusCustomButton _status)
        {
            switch (_status)
            {
                case StatusCustomButton.PointDown:
                    onInventary?.Invoke();
                    break;
                case StatusCustomButton.PointUp:

                    break;

                default:

                    break;
            }
        }
    }
}

