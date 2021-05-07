using Lesconario.Models;
using LESCOnario.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LESCOnario.ViewModels
{
    public class ListProfeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Profesor> _lstProducts { get; set; }
        private Profesor _oldProduct;
        public ListProfeViewModel()
        {
            lstProducts = new ObservableCollection<Profesor>();

        }

        public ObservableCollection<Profesor> lstProducts
        {
            get { return _lstProducts; }
            set
            {
                _lstProducts = value;
                OnPropertyChanged();
            }
        }

        public void ShowOrHidePoducts(Profesor product)
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
                var products = productDatabase.getProfesor().Result;

                if (products != null && products.Count > 0)
                {
                    lstProducts = new ObservableCollection<Profesor>();

                    foreach (var prod in products)
                    {
                        lstProducts.Add(new Profesor
                        {
                            id = prod.id,
                            nombre = prod.nombre,
                            apellidos = prod.apellidos,
                            telefono = prod.telefono,
                            email = prod.email,
                            password = prod.password
                        });
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }

        public void DeleteProduct(Profesor product)
        {
            try
            {
                ProductDataBase productDatabase = new ProductDataBase();
                var result = productDatabase.deleteProduct(product).Result;

                if (result == 1)
                    GetProducts();
            }

            catch (Exception ex)
            {
            }
        }

        private void UpdateProducts(Profesor product)
        {
            var index = _lstProducts.IndexOf(product);
            _lstProducts.Remove(product);
            _lstProducts.Insert(index, product);
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
