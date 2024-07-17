using UnityEngine;

namespace Pools
{
    public interface IPoolMonetaDropExecutor
    {
        GameObject GetObject(float direction, Transform containerTransform);
        void ReternObject(int _hash);
    }
}