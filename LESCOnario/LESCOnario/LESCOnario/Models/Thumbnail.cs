using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LESCOnario.Models
{
    public class Thumbnail
    {

        [JsonProperty("default")]
        public DefaultVideo[] _default {get;set;}

    }
    

}