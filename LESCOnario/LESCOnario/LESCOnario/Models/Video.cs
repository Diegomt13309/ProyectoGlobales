using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class Video
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("etag")]
        public string etag { get; set; }

        [JsonProperty("items")]
        public IList<YoutubeItem> item { get; set; }

    }

}
