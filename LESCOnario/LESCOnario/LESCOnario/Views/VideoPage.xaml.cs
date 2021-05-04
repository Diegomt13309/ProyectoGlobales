using LESCOnario.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        private const string ApiKey = "AIzaSyBZ7f5dkD2eLeByza7kSVEwuVdxgREiQJc";
        private const string videoUrl = "https://montemagno.com/monkeys.json";
        private const string videoUrlMultiVideo = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "s9sXsDKqPoo,6O6hjVRFR4o,Ta4T7mlzP4M"
            + "&key="
            + ApiKey;
        private const string videoUrlPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PLHsqW3mKZW996RBx_SNSnyiZktx5yBVNY"
            + "&key="
            + ApiKey;

        private readonly HttpClient httpClient = new HttpClient();

        public ObservableCollection<Video> Videos { get; set; } = new ObservableCollection<Video>();
        public VideoPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var httpClient = new HttpClient();

            var videoJson = await httpClient.GetStringAsync(videoUrlMultiVideo);


            Videos.Clear();

            Video x = JsonConvert.DeserializeObject<Video>(videoJson);

            var p = x.etag;
               

          

 
        }
    }
}