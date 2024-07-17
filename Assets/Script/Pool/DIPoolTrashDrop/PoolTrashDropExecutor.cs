using Drop;
using UnityEngine;
using Zenject;

namespace Pools
{
    public class PoolTrashDropExecutor : IPoolTrashDropExecutor
    {
        private Pool pool;
        [Inject]
        private TrashDrop.Factory trashDrop;
        private void AddPull(Transform containerTransform)
        {
            BaseDrop rezult = trashDrop.Create();
            pool = new Pool(rezult.gameObject, containerTransform, true);
        }

        public GameObject GetObject(float direction, Transform containerTransform)
        {
            if (pool == null) { AddPull(containerTransform); }
            GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

            if (tempGameObject != null) { return tempGameObject; }
            else
            {
                BaseDrop rezult = trashDrop.Create();
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

