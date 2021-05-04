using Newtonsoft.Json;

namespace LESCOnario.Models
{
    public class Localized
    {

        [JsonProperty("title")]
        string title { get; set; }

        [JsonProperty("description")]
        string description { get; set; }

    }
}