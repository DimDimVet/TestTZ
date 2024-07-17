using System;

namespace Drop
{
    public class DropExecutor : IDropExecutor
    {
        public Action<int, int, DropData> OnSetCollisionHash { get { return onSetCollisionHash; } set { onSetCollisionHash = value; } }
        private Action<int, int, DropData> onSetCollisionHash;

        public void SetReturnData(int _thisHash, int _receptionHash, DropData _dropData)
        {
            onSetCollisionHash?.Invoke(_thisHash, _receptionHash, _dropData);
        }
    }
}

