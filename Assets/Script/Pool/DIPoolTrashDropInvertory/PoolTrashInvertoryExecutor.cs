using UI;
using UnityEngine;
using Zenject;

namespace Pools
{
    public class PoolTrashInvertoryExecutor : IPoolTrashInvertoryExecutor
    {
        private Pool pool;
        [Inject]
        private TrashDropInvertory.Factory trashDropInvertory;
        private void AddPull(Transform containerTransform)
        {
            BaseInvertory rezult = trashDropInvertory.Create();
            pool = new Pool(rezult.gameObject, containerTransform, true);
        }

        public GameObject GetObject(float direction, Transform containerTransform)
        {
            if (pool == null) { AddPull(containerTransform); }
            GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

            if (tempGameObject != null) { return tempGameObject; }
            else
            {
                BaseInvertory rezult = trashDropInvertory.Create();
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

