using System;
using k.SaveManager.Configs;
using UnityEngine;

namespace k.SaveManager
{
    public static class SaveManager
    {
        private static BaseDataStoreConfig _dataStore;

        [RuntimeInitializeOnLoadMethod]
        private static void OnGameLoad()
        {
            var config = Resources.Load<SaveManagerConfig>(nameof(SaveManagerConfig));
            if (config == null)
            {
                Debug.LogWarning($"{nameof(SaveManager)}: config is not found in Resources folder");
            }
            else
            {
                SetDataStore(config.DataStore);
            }
        }
        
        public static void SetDataStore(BaseDataStoreConfig dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        
        public static void Write<T>(T data) where T : SaveData
        {
            if (!IsDataStoreValid()) return;
            var key = typeof(T).Name;
            _dataStore.Write(key, data);
        }

        public static bool TryRead<T>(out T data) where T : SaveData, new()
        {
            data = null;
            if (!IsDataStoreValid()) return false;
            var key = typeof(T).Name;
            return _dataStore.TryRead(key, out data);
        }

        private static bool IsDataStoreValid()
        {
            if (_dataStore != null) return true;
            Debug.LogError($"{nameof(SaveManager)}.{nameof(Write)} failed: data store is not set.");
            return false;
        }
    }
}