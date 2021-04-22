using Lesconario.Models;
using LESCOnario.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProfesores : ContentPage
    {
        Profesor p = new Profesor();
        User u = new User();
        public ListProfesores()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Profesor;
            p.nombre = product.nombre;
            p.apellidos = product.apellidos;
            p.id = product.id;
            p.email = product.email;
            p.password = product.password;
            p.telefono = product.telefono;
            p.IsVisible = product.IsVisible;
            p.idU = product.idU;
            var vm = BindingContext as ListProfesoresViewModel;
            vm?.ShowOrHidePoducts(product);
        }

        private async void Button_ClickedAsync(object sender, System.EventArgs e)
        {
            EditarProfesorViewModel editar = new EditarProfesorViewModel();
            editar.EditarProfesor(p.nombre, p.apellidos, p.id, p.email, p.password, p.telefono, p.idU);
            await Navigation.PushAsync(new EditarProfesorPage(editar));
        }

        private async void Button_ClickedAsync_1(object sender, System.EventArgs e)
        {
            u = App.Database.getUser(p.idU);
            await App.DatabaseP.DeleteNoteAsync(p);
            await App.Database.DeleteNoteAsync(u);
            await Navigation.PushAsync(new ListProfesores());
        }
    }
}