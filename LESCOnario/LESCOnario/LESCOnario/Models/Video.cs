using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class Video
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("snippet")]
        public string snippet { get; set; }

        public IList<YoutubeItem> item { get; set; }

        [JsonProperty("url")]
        public Uri url { get; set; }


    }

}
