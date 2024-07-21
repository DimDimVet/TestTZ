using System;
using UnityEngine;

namespace StreamAsset
{
    public static class JsonConvert
    {
        public static T[] FromJsonArray<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }
        public static T FromJson<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }
        public static string ToJson<T>(T textStructur, bool prettyPrint)
        {
            return JsonUtility.ToJson(textStructur, prettyPrint);
        }
        public static string ToJsonArray<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

}
