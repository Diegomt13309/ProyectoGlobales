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
    public partial class ListCursosxProfe : ContentPage
    {
        Curso c = new Curso();
        CursoxProfe cx = new CursoxProfe();
        Profesor aux = new Profesor();
        public ListCursosxProfe(Profesor a)
        {
            InitializeComponent();
            aux = a;
        }
        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Curso;
            c.nombre = product.nombre;
            c.IsVisible = false;
            cx.nombre = product.nombre;
            cx.IsVisible = false;
            var vm = BindingContext as ListCursosxProfeViewModel;
            vm?.ShowOrHidePoducts(product);
        }

        private async void Button_ClickedAsync(object sender, System.EventArgs e)
        {
            cx.id = aux.id;
            if (await App.DatabaseC.SaveNoteAsync(cx) == 1)
            {
                await DisplayAlert("Correcto", "Curso Asignado con Exito", "Continuar");
                await Navigation.PushAsync(new ListCursosxProfe(aux));
            }
        }
    }
}