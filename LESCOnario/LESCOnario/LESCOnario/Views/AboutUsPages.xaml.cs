using System;
using System.Collections.Generic;

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
    }
}
