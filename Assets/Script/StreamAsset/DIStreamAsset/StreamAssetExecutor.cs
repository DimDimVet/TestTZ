using System;
using System.IO;
using UnityEngine;

namespace StreamAsset
{
    public class StreamAssetExecutor : IStreamAssetExecutor
    {
        private string pathManualDirectory = "Manual";
        private string nameManualFile = "Manual";

        private string pathDirectory = "";
        private string nameFile = "";

        private JxonStructur[] listTxtData = new JxonStructur[0];
        private JxonStructur tempStructure;

        //public JxonStructur SetText(JxonStructur _jxonStructur)
        //{
            
        //    //
        //    if (pathDirectory != _jxonStructur.PathDirectory || nameFile != _jxonStructur.NameFile || listTxtData.Length == 0)
        //    {
        //        pathDirectory = _jxonStructur.PathDirectory;
        //        nameFile = _jxonStructur.NameFile;
        //        tempStructure = _jxonStructur;

        //        listTxtData = LoadFile();
        //        if (!listTxtData[0].StatusLoad) { return listTxtData[0]; }
        //    }
        //    else if (listTxtData.Length == 0)
        //    {
        //        pathDirectory = _jxonStructur.PathDirectory;
        //        nameFile = _jxonStructur.NameFile;
        //        tempStructure = _jxonStructur;

        //        listTxtData = LoadFile();
        //        if (!listTxtData[0].StatusLoad) { return listTxtData[0]; }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < listTxtData.Length; i++)
        //        {
        //            if (listTxtData[i].NameObject == _jxonStructur.NameObject)
        //            {
        //                return listTxtData[i];
        //            }
        //        }
        //    }
        //    return _jxonStructur;
        //}
        //
        //private JxonStructur[] LoadManualFile()
        //{
        //    string pathTxtDoc = Application.streamingAssetsPath + $"/{pathManualDirectory}/{nameManualFile}.txtProject";
        //    string temp = "";
        //    try
        //    {
        //        temp = File.ReadAllText(pathTxtDoc);
        //    }
        //    catch (Exception)
        //    {
        //        JxonStructur[] templistTxtData = new JxonStructur[0];
        //        templistTxtData[0].StatusLoad = false;
        //        return templistTxtData;
        //        //listTxtData = Creat(tempStructure, listTxtData);
        //        //FirstSaveFile(listTxtData);//тормоз
        //        //temp = File.ReadAllText(pathTxtDoc);
        //    }
        //    return DeserializeJSON(temp);
        //}
        private JxonStructur[] LoadFile()
        {
            string temp = "";
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.txtProject";
            if (File.Exists(pathTxtDoc)) { temp=File.ReadAllText(pathTxtDoc); }

                JxonStructur[] templistTxtData = new JxonStructur[0];
                templistTxtData[0].StatusLoad = false;
                return templistTxtData;
                //listTxtData = Creat(tempStructure, listTxtData);
                //FirstSaveFile(listTxtData);//тормоз
                //temp = File.ReadAllText(pathTxtDoc);
      
            return DeserializeJSON(temp);
        }
        private JxonStructur[] DeserializeJSON(string _rezultString)
        {
            JxonStructur[] textCollections = JsonConvert.FromJsonArray<JxonStructur>(_rezultString);
            return textCollections;
        }
        //
        public void FirstSaveFile(JxonStructur _jxonStructur)
        {
            pathDirectory = _jxonStructur.PathDirectory;
            nameFile = _jxonStructur.NameFile;

            JxonStructur[] templistTxtData = new JxonStructur[0];
            templistTxtData = Creat(_jxonStructur, templistTxtData);
            string _rezultString = ConvertJSON(templistTxtData);

            Directory.CreateDirectory(Application.streamingAssetsPath + $"/{pathDirectory}/");
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.txtProject";
            File.WriteAllText(pathTxtDoc, _rezultString);
        }
        private void SaveFile(JxonStructur[] _jxonStructur)
        {
            string _rezultString = ConvertJSON(_jxonStructur);

            Directory.CreateDirectory(Application.streamingAssetsPath + $"/{pathDirectory}/");
            string pathTxtDoc = Application.streamingAssetsPath + $"/{pathDirectory}/{nameFile}.txtProject";
            if (File.Exists(pathTxtDoc)) { File.WriteAllText(pathTxtDoc, _rezultString); }
        }
        private string ConvertJSON(JxonStructur[] _jxonStructur)
        {
            string temp = JsonConvert.ToJsonArray(_jxonStructur, true);
            return temp;
        }
        //
        public JxonStructur[] Creat(JxonStructur intObject, JxonStructur[] massivObject)
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
                massivObject = new JxonStructur[] { intObject };
                return massivObject;
            }
        }
    }
}

