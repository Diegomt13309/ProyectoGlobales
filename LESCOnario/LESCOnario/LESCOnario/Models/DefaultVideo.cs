using Newtonsoft.Json;
using System;

namespace LESCOnario.Models
{
    public class DefaultVideo
    {
        [JsonProperty("url")]
        public Uri url { get; set; }

        [JsonProperty("width")]
        public string width { get; set; }

        [JsonProperty("height")]
        public string height { get; set; }
        
    }
}