using Source.SaveManager._Samples.BasicExample;
using UnityEngine;

namespace Source.k.SaveManager.Samples_.BasicExample
{
    public class PlayerDataMonoBehaviour : MonoBehaviour
    {
        public void GameStart()
        {
            if (SaveManager.TryRead(out PlayerSaveData data))
            {
                Debug.Log($"Loaded player data: Coins={data.Coins}, Level={data.Level}");
            }
            else
            {
                Debug.Log("No player data found, creating new data");
                data = new PlayerSaveData {Coins = 0, Level = 1};
                SaveManager.Write(data);
            }
        }

        public void GameSave()
        {
            SaveManager.Write(new PlayerSaveData {Coins = 100, Level = 2});
        }
    }
}