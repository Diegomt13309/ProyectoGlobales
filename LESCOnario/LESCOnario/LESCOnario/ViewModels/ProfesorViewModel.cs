using Lesconario.Models;
using LESCOnario.Services;
using LESCOnario.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace LESCOnario.ViewModels
{
    public class ProfesorViewModel : INotifyPropertyChanged
    {
        public Command btnAgregarProfe { get; set; }
        private Profesor _products { get; set; }
        private string _btnSaveLabel { get; set; }
        private ObservableCollection<CursoxProfe> _Cursos { get; set; }
        private CursoxProfe _oldProduct;
        private INavigation Navigation { get; set; }

        public ProfesorViewModel(Profesor obj, INavigation navigation)
        {
            Navigation = navigation;
            Cursos = new ObservableCollection<CursoxProfe>();
            if (obj == null || obj.id == 0)
            {
                ClearProduct();
                btnSaveLabel = "Agregar";
            }
            else
            {
                product = obj;
                btnSaveLabel = "Actualizar";
            }
            btnAgregarProfe = new Command(Agregar);
        }

        public ObservableCollection<CursoxProfe> Cursos
        {
            get { return _Cursos; }
            set
            {
                _Cursos = value;
                OnPropertyChanged();
            }
        }

        public Profesor product
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public string btnSaveLabel
        {
            get { return _btnSaveLabel; }
            set
            {
                _btnSaveLabel = value;
                OnPropertyChanged();
            }
        }

        public async void Agregar()
        {
            try
            {
                var user = new User();
                ProductDataBase productDatabase = new ProductDataBase();
                int i = productDatabase.saveProduct(product).Result;
                user.UserName = product.nombre;
                user.Email = product.email;
                user.Password = product.password;
                product.idU = user.ID;
                Profesor aux = product;
                if (await App.Database.SaveNoteAsync(user) == 1)
                {
                    if (i == 1)
                    {
                        if (btnSaveLabel.Equals("Agregar"))
                        {
                            ClearProduct();
                            await Navigation.PushAsync(new ListCursosPage(aux));
                        }
                        else
                        {
                            ClearProduct();
                            await Navigation.PushAsync(new ListProfesores());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void ClearProduct()
        {
            product = new Profesor();
            product.id = 0;
            product.nombre = "";
            product.apellidos = "";
            product.telefono = 0;
            product.email = "";
            product.password = "";
            //btnSaveLabel = "Agregar";
        }

        public void ShowOrHidePoducts(CursoxProfe product)
        {
            if (_oldProduct == product)
            {
                // click twice on the same item will hide it
                product.IsVisible = !product.IsVisible;
                UpdateProducts(product);
            }
            else
            {
                if (_oldProduct != null)
                {
                    // hide previous selected item
                    _oldProduct.IsVisible = false;
                    UpdateProducts(product);
                }
                // show selected item
                product.IsVisible = true;
                UpdateProducts(product);
            }

            _oldProduct = product;
        }

        public void GetProducts()
        {
            try
            {
                ProductDataBase productDatabase = new ProductDataBase();
                var products = productDatabase.getCursos().Result;

                if (products != null && products.Count > 0)
                {
                    Cursos = new ObservableCollection<CursoxProfe>();

                    foreach (var prod in products)
                    {
                        if (prod.id == product.id)
                        {
                            Cursos.Add(new CursoxProfe
                            {
                                num = prod.num,
                                nombre = prod.nombre,
                                IsVisible = false,
                                id = prod.id
                            });
                        }
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }

        public void DeleteProduct(CursoxProfe product)
        {
            try
            {
                ProductDataBase productDatabase = new ProductDataBase();
                var result = productDatabase.deleteCurso(product).Result;

                if (result == 1)
                    GetProducts();
            }

            catch (Exception ex)
            {
            }
        }

        private void UpdateProducts(CursoxProfe product)
        {
            var index = _Cursos.IndexOf(product);
            _Cursos.Remove(product);
            _Cursos.Insert(index, product);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
