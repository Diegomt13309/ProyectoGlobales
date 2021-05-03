using System;
using System.Collections.Generic;
using System.Text;

namespace LESCOnario.Models
{
    public class YoutubeItem
    {
        string kind { get; set; }
        string etag { get; set; }
        string id { get; set; }
        IList<Snippet> snippets { get; set; }



    }
}
