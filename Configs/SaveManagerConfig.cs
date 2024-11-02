using UnityEngine;

namespace Source.k.SaveManager.Configs
{
    [CreateAssetMenu(menuName = "k/Misc/Save/" + nameof(SaveManagerConfig), fileName = nameof(SaveManagerConfig), order = 0)]
    public class SaveManagerConfig : ScriptableObject
    {
        [SerializeField] private BaseDataStoreConfig _dataStore;
        
        public BaseDataStoreConfig DataStore => _dataStore;
    }
}