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
    public partial class PerfilPage : ContentPage
    {
        private User user;
        public PerfilPage()
        {
            InitializeComponent();
            loadCurrentUserInfo();
        }


        private void loadCurrentUserInfo()
        {
            user = App.Database.getCurrentUser();
            EmailEntry.Text = user.Email;
            UsernameEntry.Text = user.UserName;
            PasswordEntry.Text = user.Password;
            CedulaEntry.Text = user.Cedula;
        }

        private void editarUsuario(object sender, EventArgs e)
        {
            CedulaEntry.IsReadOnly = false;
            EmailEntry.IsReadOnly = false;
            PasswordEntry.IsReadOnly = false;
            UsernameEntry.IsReadOnly = false;
            editButton.IsVisible = false;
            cancelarButton.IsVisible = true;
            aceptarButton.IsVisible = true;

        }

        private async void editAceptar(object sender, EventArgs e)
        {
            CedulaEntry.IsReadOnly = true;
            EmailEntry.IsReadOnly = true;
            PasswordEntry.IsReadOnly = true;
            UsernameEntry.IsReadOnly = true;
            editButton.IsVisible = true;
            cancelarButton.IsVisible = false;
            aceptarButton.IsVisible = false;

            var user = new User();
            user.UserName = UsernameEntry.Text;
            user.Email = EmailEntry.Text;
            user.Password = PasswordEntry.Text;
            user.Cedula = CedulaEntry.Text;
            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                if (await App.Database.SaveUserAsync(user) == 1)
                {
                    await this.DisplayAlert("Felicidades", "Usuario Editado con Exito", "Continuar");
                    //await Navigation.PushAsync(new WelcomePage());
                }
            }
        }

        private void editCancelar(object sender, EventArgs e)
        {
            CedulaEntry.IsReadOnly = true;
            EmailEntry.IsReadOnly = true;
            PasswordEntry.IsReadOnly = true;
            UsernameEntry.IsReadOnly = true;
            editButton.IsVisible = true;
            cancelarButton.IsVisible = false;
            aceptarButton.IsVisible = false;

        }
    }
}