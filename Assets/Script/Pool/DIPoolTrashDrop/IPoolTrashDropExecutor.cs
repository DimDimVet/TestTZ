using UnityEngine;

namespace Pools
{
    public interface IPoolTrashDropExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}