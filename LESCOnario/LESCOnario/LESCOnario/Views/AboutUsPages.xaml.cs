using System;
using System.Collections.Generic;
using LESCOnario.ViewModels;
using Xamarin.Forms;

using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;

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
            var pr = new LescoHistoryPage();
            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            pr.Animation = scaleAnimation;
            await PopupNavigation.PushAsync(pr);
        }


        private async void whatis_button(object sender, EventArgs e)
        {
            var pr = new WhatIsPage();
            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            pr.Animation = scaleAnimation;
            await PopupNavigation.PushAsync(pr);
        }

        private async void ley_button(object sender, EventArgs e)
        {
            DependencyService.Get<IPdfViewer>().Open("https://aka.ms/xamebook");
        }
    }
}
