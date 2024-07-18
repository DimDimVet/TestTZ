using System;

namespace Drop
{
    public interface IDropExecutor
    {
        Action<int, int, DropData> OnSetCollisionHash { get; set; }
        void SetReturnData(int _thisHash, int _receptionHash, DropData _dropData);
    }
}

