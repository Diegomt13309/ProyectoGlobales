using Newtonsoft.Json;

namespace LESCOnario.Models
{
    public class Statistics
    {
        [JsonProperty("viewCount")]
        string viewCount { get; set; }

        [JsonProperty("likeCount")]
        string likeCount { get; set; }

        [JsonProperty("dislikeCount")]
        string dislikeCount { get; set; }

        [JsonProperty("favoriteCount")]
        string favoriteCount { get; set; }

        [JsonProperty("commentCount")]
        string commentCount { get; set; }
    }
}