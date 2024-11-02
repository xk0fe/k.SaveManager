using Newtonsoft.Json;

namespace Source.k.SaveManager.Samples_.BasicExample
{
    [JsonObject]
    public class PlayerSaveData : SaveData
    {
        [JsonProperty] public int Coins { get; set; }
        [JsonProperty] public int Level { get; set; }
    }
}