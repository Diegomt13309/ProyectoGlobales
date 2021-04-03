using Lesconario.Models;
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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var user = new User();
            user.UserName = EntryUserName.Text;
            user.Email = EntryUserEmail.Text;
            user.Password = EntryUserPassword.Text;
            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                if (await App.Database.SaveNoteAsync(user)==1)
                {
                    await this.DisplayAlert("Felicidades", "Usuario Registrado con Exito", "Continuar");
                    await Navigation.PushAsync(new WelcomePage());
                }
            }
            else
            {
                await this.DisplayAlert("Advertencia", "Complete todo el formulario", "OK");
            }
        }
    }
}