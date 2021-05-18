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
    public partial class ListProfesoresPage : ContentPage
    {
        ListProfeViewModel lt;
        private Profesor p = new Profesor();
        public ListProfesoresPage()
        {
            InitializeComponent();
            lt = new ListProfeViewModel();
            this.BindingContext = lt;
        }

        protected override void OnAppearing()
        {
            if (lt != null)
                lt.GetProducts();

            base.OnAppearing();
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
            var vm = BindingContext as ListProfeViewModel;
            vm?.ShowOrHidePoducts(product);
        }

    }
}