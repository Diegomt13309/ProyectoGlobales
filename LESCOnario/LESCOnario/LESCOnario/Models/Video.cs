using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class Video
    {
        public string kind { get; set; }
        public string etag { get; set; }

        [JsonProperty("items")]
        public IList<YoutubeItem> item { get; set; }
    }

}
