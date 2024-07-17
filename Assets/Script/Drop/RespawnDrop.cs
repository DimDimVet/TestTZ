using Pools;
using UnityEngine;
using Zenject;

namespace Drop
{
    public class RespawnDrop : MonoBehaviour
    {
        [SerializeField] private Transform poolTransform;
        [SerializeField][Range(3, 15)] private float currentTime = 5f;
        private float defaultTime;
        private int nomerDrop;
        //
        private IDropExecutor dropExecutor;
        private IPoolMonetaDropExecutor poolMonetaDrop;
        private IPoolTrashDropExecutor poolTrashDrop;

        [Inject]
        public void Init(IDropExecutor _dropExecutor, IPoolMonetaDropExecutor _poolMonetaDrop, IPoolTrashDropExecutor _poolTrashDrop)
        {
            dropExecutor = _dropExecutor;
            poolMonetaDrop = _poolMonetaDrop;
            poolTrashDrop = _poolTrashDrop;
        }
        private void OnEnable()
        {
            dropExecutor.OnSetCollisionHash += SetCollisionHash;
        }
        void Start()
        {
            defaultTime = currentTime;
        }
        private void SetCollisionHash(int _thisHash, int _receptionHash, DropData _dropData)
        {
            poolMonetaDrop.ReternObject(_thisHash);
            poolTrashDrop.ReternObject(_thisHash);
        }
        private void RespawnObject()
        {
            nomerDrop = Random.Range(0, 2);
            if (nomerDrop == 0) { poolMonetaDrop.GetObject(gameObject.transform.localScale.x, poolTransform); }
            if (nomerDrop == 1) { poolTrashDrop.GetObject(gameObject.transform.localScale.x, poolTransform); }
        }
        void Update()
        {
            LoadRespawn();
        }
        private void LoadRespawn()
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = defaultTime; RespawnObject();
            }
        }
    }
}
