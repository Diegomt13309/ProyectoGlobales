using Newtonsoft.Json;

namespace LESCOnario.Models
{
    public class Localized
    {

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

    }
}