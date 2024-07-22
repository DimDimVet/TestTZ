using RegistratorObject;
using UI;
using UnityEngine;
using Zenject;

namespace StreamAsset
{
    public class RegistratorStreamAsset : MonoBehaviour
    {
        [SerializeField] private string pathDirectory = "StreamAsset";
        [SerializeField] private string nameFile = "SaveFile";

        private Construction thisObject;
        private LoadSaveStructur loadSaveStructur;
        private bool isStopClass = false, isRun = false;

        private IStreamAssetExecutor streamAssetExecutor;
        private IUIExecutor uiExecutor;

        [Inject]
        public void Init(IStreamAssetExecutor _streamAssetExecutor, IUIExecutor _uiExecutor)
        {
            streamAssetExecutor = _streamAssetExecutor;
            uiExecutor = _uiExecutor;
        }
        private void OnEnable()
        {
            uiExecutor.OnSaveData += SaveData;
            uiExecutor.OnLoadData += LoadData;
            streamAssetExecutor.OnSetData += SetData;
        }
        void Start()
        {
            SetClass();
        }
        private void SetClass()
        {
            if (!isRun)
            {
                if (thisObject.Hash != 0) { isRun = true; }
                else { isRun = false; }
            }
        }
        private void SaveData()
        {
            loadSaveStructur = new LoadSaveStructur
            {
                PathDirectory= pathDirectory,
                NameFile= nameFile, 
                NameObject = this.gameObject.name,
                GameObject = this.gameObject,
                Position = this.gameObject.transform.position,
                Rotation = this.gameObject.transform.rotation,
                Scale = this.gameObject.transform.localScale
            };
            streamAssetExecutor.SaveDataObject(loadSaveStructur);
        }
        private void LoadData()
        {
            loadSaveStructur = new LoadSaveStructur
            {
                PathDirectory = pathDirectory,
                NameFile = nameFile,
                NameObject = this.gameObject.name,
            };
            streamAssetExecutor.LoadDataObject(loadSaveStructur);
        }
        private void SetData(LoadSaveStructur saveStructur)
        {
            Vector3 savePosition = saveStructur.Position;
            Quaternion saveRotate=saveStructur.Rotation;
            Vector3 saveScale=saveStructur.Scale;
            this.gameObject.transform.position = savePosition;
            Debug.Log(saveStructur.NameObject);
        }
        void Update()
        {
            if (isStopClass) { return; }
            if (!isRun) { SetClass(); }
            RunUpdate();
        }
        private void RunUpdate()
        {

        }
        private void OnDisable()
        {

        }
    }
}