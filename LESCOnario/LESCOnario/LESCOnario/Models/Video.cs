using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class Video
    {
       [JsonProperty("Name")]
       public string name { get; set; }

    }
}
