using Newtonsoft.Json;
using System.Collections.Generic;

namespace LESCOnario.Models
{
    public class Snippet
    {
        [JsonProperty("publishedAT")]
        string publishedAT { get; set; }

        [JsonProperty("channelId")]
        string channelId { get; set; }

        [JsonProperty("title")]
        string title { get; set; }

        [JsonProperty("description")]
        string description { get; set; }

        [JsonProperty("thumbnails")]
        IList<Thumbnail> thumbnails { get; set; }

        [JsonProperty("channelTitle")]
        string channelTitle { get; set; }

        [JsonProperty("tags")]
        IList<string> tags { get; set; }

        [JsonProperty("categoryId")]
        string categoryId { get; set; }

        [JsonProperty("localized")]
        Localized localized { get; set; }

        [JsonProperty("statistics")]
        Statistics statistics { get; set; }

    }
}