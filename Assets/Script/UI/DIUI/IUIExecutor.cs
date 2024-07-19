using Drop;
using System;

namespace UI
{
    public interface IUIExecutor
    {
        Action OnInventary { get; set; }
        void Inventary(StatusCustomButton _status);
        //Action<int, int, DropData> OnSetCollisionHash { get; set; }
        //void SetReturnData(int _thisHash, int _receptionHash, DropData _dropData);
    }
}

