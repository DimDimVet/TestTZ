using UnityEngine;
using Zenject;

namespace RegistratorObject
{

    public class Registrator : MonoBehaviour
    {
        [SerializeField] private TypeObject type= TypeObject.Other;
        [SerializeField] private int thisHash;
        private IRegistrator registrator;
        [Inject]
        public void Init(IRegistrator _registrator)
        {
            registrator = _registrator;
        }

        void Start()
        {
            thisHash = gameObject.GetHashCode();
            Construction element = new Construction
            {
                Hash = thisHash,
                TypeObject = type,
                Object = gameObject,
            };
            registrator.SetData(element);
        }
    }
}

