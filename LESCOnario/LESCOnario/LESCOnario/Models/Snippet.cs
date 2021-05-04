using Newtonsoft.Json;
using System.Collections.Generic;

namespace LESCOnario.Models
{
    public class Snippet
    {
        [JsonProperty("publishedAT")]
        public string publishedAT { get; set; }

        [JsonProperty("channelId")]
        public string channelId { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnail thumbnails { get; set; }

        [JsonProperty("channelTitle")]
        public string channelTitle { get; set; }

        [JsonProperty("tags")]
        public IList<string> tags { get; set; }

        [JsonProperty("categoryId")]
        public string categoryId { get; set; }

        [JsonProperty("localized")]
        public Localized localized { get; set; }

        [JsonProperty("statistics")]
        public Statistics statistics { get; set; }

    }
}