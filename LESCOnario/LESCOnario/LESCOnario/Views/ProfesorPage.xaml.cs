using Lesconario.Models;
using LESCOnario.Services;
using LESCOnario.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfesorPage : ContentPage
    {
        CursoxProfe p = new CursoxProfe();
        Profesor pf = new Profesor();
        ProfesorViewModel pr;
        public ProfesorPage(Profesor profe)
        {
            try
            {
                InitializeComponent();
                btnMostrar.IsVisible = true;
                btn.Text = "Actualizar";
                pf = profe;
                pr = new ProfesorViewModel(profe,Navigation);
                this.BindingContext = pr;
            }
            catch (Exception ex)
            {

            }
        }

        public ProfesorPage()
        {
            InitializeComponent();
            btnMostrar.IsVisible = false;
            pr = new ProfesorViewModel(null,Navigation);
            this.BindingContext = pr;
            btn.Text = "Agregar";
        }

        protected override void OnAppearing()
        {
            if (pr != null)
                pr.GetProducts();

            base.OnAppearing();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as CursoxProfe;
            p.num = product.num;
            p.nombre = product.nombre;
            p.IsVisible = false;
            p.id = product.id;
            var vm = BindingContext as ProfesorViewModel;
            vm?.ShowOrHidePoducts(product);
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            TLista.IsVisible = true;
            TFormulario.IsVisible = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListCursosPage(pf));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (p.num != 0)
            {
                var result = await DisplayAlert("Confirm", "Seguro que quieres eliminar a: " + p.nombre + "? ", "Si", "No");
                if (result)
                {
                    pr.DeleteProduct(p);
                }
            }
            await Navigation.PushAsync(new ListProfesores());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            TFormulario.IsVisible = true;
            TLista.IsVisible = false;
        }
    }
}