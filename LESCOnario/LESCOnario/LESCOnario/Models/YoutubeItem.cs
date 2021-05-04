using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class YoutubeItem
    {
        [JsonProperty("kind")]
        string kind { get; set; }

        [JsonProperty("etag")]
        string etag { get; set; }

        [JsonProperty("id")]
        string id { get; set; }

        [JsonProperty("snippets")]
        IList<Snippet> snippets { get; set; }



    }
}
