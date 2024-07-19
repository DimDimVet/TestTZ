using UnityEngine;

namespace Pools
{
    public interface IPoolTrashInvertoryExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}