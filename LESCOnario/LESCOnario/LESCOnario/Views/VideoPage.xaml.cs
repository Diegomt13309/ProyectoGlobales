﻿using LESCOnario.Models;
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
        private const string videoUrlMultiVideo = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "s9sXsDKqPoo,6O6hjVRFR4o,Ta4T7mlzP4M"
            + "&key="
            + ApiKey;
        private const string videoUrlPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PLHsqW3mKZW996RBx_SNSnyiZktx5yBVNY"
            + "&key="
            + ApiKey;

        private readonly HttpClient httpClient = new HttpClient();

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
                if (myVideos.standard.height != null)
                    v.snippets.url = v.snippets.thumbnails.high.url;
                    lescoVideos.Add(v.snippets);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("vnd.youtube://www.youtube.com/"));
        }
    }
}