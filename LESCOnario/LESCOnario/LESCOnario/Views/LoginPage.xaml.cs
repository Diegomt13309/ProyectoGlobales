using Lesconario.Models;
using LESCOnario.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var user = new User();
            var name = EntryUserEmail.Text;
            var pass = EntryUserPassword.Text;
            user = await App.Database.GetNoteAsync(EntryUserEmail.Text, EntryUserPassword.Text);
            App.Database.setCurrentUser(user);
            if (user!=null) {
                await Shell.Current.GoToAsync("//yes");
            }
        }

        private async void signup_page(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}