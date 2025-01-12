using UnityEngine;

namespace k.SaveManager.Configs
{
    public abstract class BaseDataStoreConfig : ScriptableObject
    {
        public abstract void Write<T>(string key, T data);
        public abstract bool TryRead<T>(string key, out T data);
    }
}