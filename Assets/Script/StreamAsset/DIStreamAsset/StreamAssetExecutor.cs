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

        public void LoadDataObject(LoadSaveStructur _textCollection)
        {
            pathDirectory = _textCollection.PathDirectory;
            nameFile = _textCollection.NameFile;

            bool isContorlSaveTextCollection = true;
            if (listData.Length == 0) { listData = InitList(); }
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
                SaveFile(listData);
            }
        }
        public void SaveDataObject(LoadSaveStructur _textCollection)
        {
            pathDirectory = _textCollection.PathDirectory;
            nameFile = _textCollection.NameFile;

            bool isContorlSaveTextCollection = true;
            if (listData.Length == 0) { listData = InitList(); }
            //
            for (int i = 0; i < listData.Length; i++)
            {
                if (listData[i].NameObject == _textCollection.NameObject)
                {
                    isContorlSaveTextCollection = false;//переборка
                    //onSetData?.Invoke(listData[i]);
                    listData[i] = _textCollection;
                    SaveFile(listData);
                }
            }
            //
            if (isContorlSaveTextCollection)
            {
                listData = Creat(_textCollection, listData);
                SaveFile(listData);
            }
        }
        private LoadSaveStructur[] InitList()
        {
            LoadSaveStructur[] templistData;
            templistData = LoadFile();
            return templistData;
        }
        private LoadSaveStructur[] LoadFile()
        {
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.jsonProject";
            if (File.Exists(pathTxtDoc)) 
            {
                string temp = File.ReadAllText(pathTxtDoc);
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
        private void SaveFile(LoadSaveStructur[] _textCollections)
        {
            string _rezultString = ConvertJSON(_textCollections);

            Directory.CreateDirectory(Application.streamingAssetsPath + $"/{pathDirectory}/");
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.jsonProject";
            if (File.Exists(pathTxtDoc)) { File.WriteAllText(pathTxtDoc, _rezultString); }
            else 
            {
                File.WriteAllText(pathTxtDoc, _rezultString);
            };
            
        }
        private string ConvertJSON(LoadSaveStructur[] _textCollections)
        {
            string temp = JsonConvert.ToJson(_textCollections, true);
            return temp;
        }
    }
}

