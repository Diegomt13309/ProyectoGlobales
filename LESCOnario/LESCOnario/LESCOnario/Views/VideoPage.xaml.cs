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
using Xamarin.Essentials;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        private const string ApiKey = "AIzaSyBZ7f5dkD2eLeByza7kSVEwuVdxgREiQJc";
        private const string videoUrlMultiVideo = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "W14Ed-y7JvM,XPyeIOqI6qY,HHmfaLGfx-E,g_sn520GhJA,d5WpSHr0G9k,1r_ugCtCgnM"
            + "&key="
            + ApiKey;
        private const string videoUrlPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PLHsqW3mKZW996RBx_SNSnyiZktx5yBVNY"
            + "&key="
            + ApiKey;

        private readonly HttpClient httpClient = new HttpClient();
        private Snippet _currentItem;

        public ObservableCollection<Snippet> lescoVideos { get; set; } = new ObservableCollection<Snippet>();
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
            lescoVideos.Clear();
            Video x = JsonConvert.DeserializeObject<Video>(videoJson);
            Thumbnail myVideos = new Thumbnail();
            foreach(var v in x.item)
            {
                myVideos = v.snippets.thumbnails;               
                v.snippets.url = v.snippets.thumbnails.high.url;
                v.snippets.id = v.id;
                lescoVideos.Add(v.snippets);
                
            }
        }

        
        private void Button_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("vnd.youtube://www.youtube.com/watch?v=" + _currentItem.id));
        }

        private void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            Snippet previousItem = e.PreviousItem as Snippet;
            _currentItem = e.CurrentItem as Snippet;
        }
    }
}