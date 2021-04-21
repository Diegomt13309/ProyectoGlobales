using System;
using System.Collections.Generic;
using LESCOnario.ViewModels;
using Xamarin.Forms;

namespace LESCOnario.Views
{
    public partial class AboutUsPages : ContentPage
    {
        public AboutUsPages()
        {
            InitializeComponent();
        }

        private async void history_button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LescoHistoryPage());
        }

        private async void ley_button(object sender, EventArgs e)
        {
            DependencyService.Get<IPdfViewer>().Open("https://aka.ms/xamebook");
        }
    }
}
