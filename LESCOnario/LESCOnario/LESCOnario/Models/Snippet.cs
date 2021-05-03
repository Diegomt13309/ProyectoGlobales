using System.Collections.Generic;

namespace LESCOnario.Models
{
    public class Snippet
    {
        string publishedAT { get; set; }
        string channelId { get; set; }
        string title { get; set; }
        string description { get; set; }
        IList<Thumbnail> thumbnails { get; set; }
        string channelTitle { get; set; }
        IList<string> tags { get; set; }
    }
}