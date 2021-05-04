using Newtonsoft.Json;
using System.Collections.Generic;

namespace LESCOnario.Models
{
    public class Thumbnail
    {

        [JsonProperty("default")]
        IList<string> _default {get;set;}
    }
}