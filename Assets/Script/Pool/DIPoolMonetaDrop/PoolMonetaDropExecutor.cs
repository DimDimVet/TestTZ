using Drop;
using UnityEngine;
using Zenject;

namespace Pools
{
    public class PoolMonetaDropExecutor : IPoolMonetaDropExecutor
    {
        private Pool pool;
        [Inject]
        private MonetaDrop.Factory monetaDrop;
        private void AddPull(Transform containerTransform)
        {
            BaseDrop rezult = monetaDrop.Create();
            pool = new Pool(rezult.gameObject, containerTransform, true);
        }

        public GameObject GetObject(float direction, Transform containerTransform)
        {
            if (pool == null) { AddPull(containerTransform); }
            GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

            if (tempGameObject != null) { return tempGameObject; }
            else
            {
                BaseDrop rezult = monetaDrop.Create();
                pool.NewObjectQueue(rezult.gameObject);
                return pool.GetObjectFabric(containerTransform);
            }
        }

        public void ReternObject(int _hash)
        {
            if (pool != null) { pool.ReternObject(_hash); }
        }
    }
}

