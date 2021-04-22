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
    public partial class EditarProfesorPage : ContentPage
    {
        EditarProfesorViewModel editar = new EditarProfesorViewModel();
        Profesor profe = new Profesor();
        Curso c = new Curso();
        public EditarProfesorPage(EditarProfesorViewModel e)
        {
            InitializeComponent();
            editar = e;
            profe = editar.getProfesor();
            EntryName.Text = profe.nombre;
            EntryAp.Text = profe.apellidos;
            EntryId.Text = profe.id.ToString();
            EntryEmail.Text = profe.email;
            EntryPassword.Text = profe.password;
            EntryPhone.Text = profe.telefono.ToString();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Curso;
            c.nombre = product.nombre;
            c.IsVisible = product.IsVisible;
            var vm = BindingContext as EditarListViewModel;
            vm?.ShowOrHidePoducts(product);
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
                App.DatabaseP.findId(profe.id);

                User user = App.Database.getUser(profe.idU);
                user.UserName = profe.nombre;
                user.Email = profe.email;
                user.Password = profe.password;

                if (await App.Database.SaveNoteAsync(user) == 1)
                {
                    if (await App.DatabaseP.SaveNoteAsync(profe) == 1)
                    {
                        await DisplayAlert("Felicidades", "Profesor Actualizado Correctamente", "Continuar");
                        EntryName.Text = "";
                        EntryAp.Text = "";
                        EntryId.Text = "";
                        EntryEmail.Text = "";
                        EntryPassword.Text = "";
                        EntryPhone.Text = "";
                        await Navigation.PushAsync(new ListProfesores());
                    }
                    else
                        await DisplayAlert("Lo Sentimos", "No se pudo Actualizar el Profesor", "Continuar");
                }
                else
                    await DisplayAlert("Lo Sentimos", "Usuario no Encontrado", "Continuar");
            }
        }
    }
}