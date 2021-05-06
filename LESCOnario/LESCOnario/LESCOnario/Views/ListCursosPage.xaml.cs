using Lesconario.Models;
using LESCOnario.Services;
using LESCOnario.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCursosPage : ContentPage
    {
        Curso c = new Curso();
        CursoxProfe cx = new CursoxProfe();
        Profesor aux = new Profesor();
        public ListCursosPage(Profesor a)
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
            var vm = BindingContext as ListCursoViewModel;
            vm?.ShowOrHidePoducts(product);
        }

        private async void Button_ClickedAsync(object sender, System.EventArgs e)
        {
            cx.id = aux.id;
            try
            {
                ProductDataBase productDatabase = new ProductDataBase();
                int i = productDatabase.saveCurso(cx);

                if (i == 1)
                {
                    await DisplayAlert("Correcto", "Curso Asignado con Exito", "Continuar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Lo Sentimos", "Curso no Asignado o Ya Existe", "OK");
            }
            await Navigation.PushAsync(new ListCursosPage(aux));
        }

        private async void SalirClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProfesorPage(null));
        }

        private async void ListaClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ListProfesores());
        }
    }
}