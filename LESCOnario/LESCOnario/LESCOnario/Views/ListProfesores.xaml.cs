using Lesconario.Models;
using LESCOnario.Services;
using LESCOnario.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProfesores : ContentPage
    {
        ListProfeViewModel lt;
        private Profesor p = new Profesor();
        private User u;
        public ListProfesores()
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

        private async void Button_ClickedAsync(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProfesorPage(p));
        }

        private async void Button_ClickedAsync_1(object sender, System.EventArgs e)
        {
            u = App.Database.getUser(p.idU);
            await App.Database.DeleteUserAsync(u);
            try
            {
                if (p.id != 0)
                {
                    var result = await DisplayAlert("Confirm", "Seguro que quieres eliminar a: " + p.nombre + "? ", "Si", "No");
                    if (result)
                    {
                        lt.DeleteProduct(p);
                        ProductDataBase dataBase = new ProductDataBase();
                        var list = dataBase.getCursos().Result;
                        foreach (var prod in list)
                        {
                            if (prod.id == p.id)
                            {
                                CursoxProfe aux = new CursoxProfe();
                                aux.num = prod.num;
                                aux.nombre = prod.nombre;
                                aux.IsVisible = prod.IsVisible;
                                aux.id = prod.id;
                                _ = dataBase.deleteCurso(aux);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            await Navigation.PushAsync(new ListProfesores());
        }

    }
}