using Cysharp.Threading.Tasks;
using System;
using System.IO;
using UnityEngine;

namespace StreamAsset
{
    public class StreamAssetExecutor : IStreamAssetExecutor
    {
        private string pathDirectory = "";
        private string nameFile = "";

        private LoadSaveStructur[] listData = new LoadSaveStructur[0];

        public Action<LoadSaveStructur> OnSetData { get { return onSetData; } set { onSetData = value; } }
        private Action<LoadSaveStructur> onSetData;

        public async UniTask LoadDataObject(LoadSaveStructur _textCollection)
        {
            pathDirectory = _textCollection.PathDirectory;
            nameFile = _textCollection.NameFile;

            bool isContorlSaveTextCollection = true;
            if (listData.Length == 0) { listData = await InitList(); }
            //
            for (int i = 0; i < listData.Length; i++)
            {
                if (listData[i].NameObject == _textCollection.NameObject)
                {
                    isContorlSaveTextCollection = false;//переборка
                    onSetData?.Invoke(listData[i]);
                }
            }
            //
            if (isContorlSaveTextCollection)
            {
                listData = Creat(_textCollection, listData);
                await SaveFile(listData);
            }
        }
        public async UniTask SaveDataObject(LoadSaveStructur _textCollection)
        {
            pathDirectory = _textCollection.PathDirectory;
            nameFile = _textCollection.NameFile;

            bool isContorlSaveTextCollection = true;
            if (listData.Length == 0) { listData =await InitList(); }
            //
            for (int i = 0; i < listData.Length; i++)
            {
                if (listData[i].NameObject == _textCollection.NameObject)
                {
                    isContorlSaveTextCollection = false;//переборка
                    listData[i] = _textCollection;
                    await SaveFile(listData);
                }
            }
            //
            if (isContorlSaveTextCollection)
            {
                listData = Creat(_textCollection, listData);
                await SaveFile(listData);
            }
        }
        private async UniTask<LoadSaveStructur[]> InitList()
        {
            LoadSaveStructur[] templistData;
            templistData = await LoadFile();
            return templistData;
        }
        private async UniTask<LoadSaveStructur[]> LoadFile()
        {
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.jsonProject";
            if (File.Exists(pathTxtDoc))
            {
                string temp = File.ReadAllText(pathTxtDoc);
                await UniTask.Yield();
                return DeserializeJSON(temp);
            }
            return listData;
        }
        private LoadSaveStructur[] DeserializeJSON(string _rezultString)
        {
            LoadSaveStructur[] textCollections = JsonConvert.FromJson<LoadSaveStructur>(_rezultString);
            return textCollections;
        }
        public LoadSaveStructur[] Creat(LoadSaveStructur intObject, LoadSaveStructur[] massivObject)
        {
            if (massivObject != null)
            {
                int newLength = massivObject.Length + 1;
                Array.Resize(ref massivObject, newLength);
                massivObject[newLength - 1] = intObject;
                return massivObject;
            }
            else
            {
                massivObject = new LoadSaveStructur[] { intObject };
                return massivObject;
            }
        }
        //
        private async UniTask SaveFile(LoadSaveStructur[] _textCollections)
        {
            string _rezultString = ConvertJSON(_textCollections);

            Directory.CreateDirectory(Application.streamingAssetsPath + $"/{pathDirectory}/");
            await UniTask.Yield();
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.jsonProject";
            await UniTask.Yield();
            if (File.Exists(pathTxtDoc)) { File.WriteAllText(pathTxtDoc, _rezultString); }
            else
            {
                File.WriteAllText(pathTxtDoc, _rezultString);
                await UniTask.Yield();
            };

        }
        private string ConvertJSON(LoadSaveStructur[] _textCollections)
        {
            string temp = JsonConvert.ToJson(_textCollections, true);
            return temp;
        }
    }
}

