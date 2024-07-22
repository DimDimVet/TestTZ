using Drop;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StreamAsset
{
    [Serializable]
    public struct LoadSaveStructur
    {
        public bool StatusLoad;
        public string PathDirectory;
        public string NameFile;
        //
        public string NameObject;
        public GameObject GameObject;
        public GameObject ParentGameObject;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        //Drop
        public TypeDrop[] DropDatas;
    }
}