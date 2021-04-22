using System;
using Lesconario.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfesorPage : ContentPage
    {
        public ProfesorPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var profe = new Profesor();
            profe.nombre = EntryName.Text;
            profe.apellidos = EntryAp.Text;
            profe.id = Int32.Parse(EntryId.Text);
            profe.email = EntryEmail.Text;
            profe.password = EntryPassword.Text;
            profe.telefono = Int32.Parse(EntryPhone.Text);
            profe.IsVisible = false;
            if (string.IsNullOrEmpty(profe.nombre) || string.IsNullOrEmpty(profe.apellidos) ||
                string.IsNullOrEmpty(EntryId.Text) || string.IsNullOrEmpty(profe.email) ||
                string.IsNullOrEmpty(profe.password) || string.IsNullOrEmpty(EntryPhone.Text))
            {

                await DisplayAlert("Advertencia", "Todos los campos deben completarse", "Ok");

            }
            else
            {
                var user = new User();
                user.UserName = profe.nombre;
                user.Email = profe.email;
                user.Password = profe.password;
                profe.idU = user.ID;

                if (await App.Database.SaveNoteAsync(user) == 1)
                {

                    if (await App.DatabaseP.SaveNoteAsync(profe) == 1)
                    {
                        await DisplayAlert("Felicidades", "Usuario Registrado con Exito", "Continuar");
                        EntryName.Text = "";
                        EntryAp.Text = "";
                        EntryId.Text = "";
                        EntryEmail.Text = "";
                        EntryPassword.Text = "";
                        EntryPhone.Text = "";
                        await Navigation.PushAsync(new ListCursosxProfe(profe));
                    }
                }
            }
        }
    }
}