using LESCOnario.Models;
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
        private const string videoUrl = "https://montemagno.com/monkeys.json";
        private readonly HttpClient httpClient = new HttpClient();

        public ObservableCollection<Video> Videos {get;set;} = new ObservableCollection<Video>();
        public VideoPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}