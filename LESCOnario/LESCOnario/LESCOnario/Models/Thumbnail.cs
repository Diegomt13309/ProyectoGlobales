using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LESCOnario.Models
{
    public class Thumbnail
    {

        [JsonProperty("default")]
        public DefaultVideo _default {get;set;}

        [JsonProperty("medium")]
        public DefaultVideo medium { get; set; }

        [JsonProperty("high")]
        public DefaultVideo high { get; set; }

        [JsonProperty("standard")]
        public DefaultVideo standard { get; set; }

        [JsonProperty("maxres")]
        public DefaultVideo maxres { get; set; }
    }
    

}