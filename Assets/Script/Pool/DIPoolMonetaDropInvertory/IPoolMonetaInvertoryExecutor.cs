using UnityEngine;

namespace Pools
{
    public interface IPoolMonetaInvertoryExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}