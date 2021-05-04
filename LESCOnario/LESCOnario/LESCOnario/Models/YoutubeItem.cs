using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class YoutubeItem
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("etag")]
        public string etag { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("snippet")]
        public Snippet snippets { get; set; }
    }
}
