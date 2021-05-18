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
        Course c = new Course();
        CursoxProfe cx = new CursoxProfe();
        Profesor aux = new Profesor();
        CoursesViewModel vm;
        public ListCursosPage(Profesor a)
        {
            InitializeComponent();
            aux = a;
            vm = new CoursesViewModel();
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetCourses();

            base.OnAppearing();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Course;
            c.ID = product.ID;
            c.Name = product.Name;
            c.Code = product.Code;
            c.Quantity = product.Quantity;
            c.IsVisible = false;
            cx.IsVisible = false;
            vm = BindingContext as CoursesViewModel;
            vm?.ShowOrHidePoducts(product);
        }

        private async void Button_ClickedAsync(object sender, System.EventArgs e)
        {
            cx.id = aux.id;
            cx.nombre = c.Name;
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