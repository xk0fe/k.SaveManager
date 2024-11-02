using Newtonsoft.Json;
using UnityEngine;

namespace Source.k.SaveManager.Configs.DataStores
{
    [CreateAssetMenu(menuName = "k/Misc/Save/DataStore/" + nameof(PlayerPrefsDataStore), fileName = nameof(PlayerPrefsDataStore), order = 0)]
    public class PlayerPrefsDataStore : BaseDataStoreConfig
    {
        public override void Write<T>(string key, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(key, json);
        }

        public override bool TryRead<T>(string key, out T data)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                data = default;
                return false;
            }
        
            var json = PlayerPrefs.GetString(key);
            data = JsonConvert.DeserializeObject<T>(json);
            return data != null;
        }
    }
}