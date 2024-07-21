using Drop;
using UI;
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
                NameObject = gameObject.name,
                TypeObject = type,
                Object = gameObject,
                //Manual= Manual(),
            };
            registrator.SetData(element);
        }
        //private string Manual()
        //{
        //    BaseTextRegistrator baseTextRegistrator=this.gameObject.GetComponent<BaseTextRegistrator>();
        //    if(baseTextRegistrator!=null)
        //    { return baseTextRegistrator.GetTxt(); }
        //    return "";
        //}
    }
}

