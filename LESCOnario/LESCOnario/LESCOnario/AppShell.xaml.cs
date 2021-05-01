using LESCOnario.ViewModels;
using LESCOnario.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LESCOnario
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(DiccionaryPage), typeof(DiccionaryPage));
            Routing.RegisterRoute(nameof(VideoPage), typeof(VideoPage));
        }

    }
}
