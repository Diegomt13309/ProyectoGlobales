using Lesconario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LESCOnario.ViewModels
{
    class ListProfesoresViewModel
    {
        private Profesor _oldProduct;

        public ObservableCollection<Profesor> Products { get; set; }

        public ListProfesoresViewModel()
        {
            List<Profesor> list = App.DatabaseP.getList();
            Products = new ObservableCollection<Profesor> { };
            for (int i = 0; i < list.Count; i++)
            {
                Profesor p = new Profesor();
                p.nombre = list[i].nombre;
                p.apellidos = list[i].apellidos;
                p.email = list[i].email;
                p.id = list[i].id;
                p.IsVisible = list[i].IsVisible;
                p.password = list[i].password;
                p.telefono = list[i].telefono;
                p.idU = list[i].idU;
                Products.Add(p);
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
                    UpdateProducts(_oldProduct);
                }
                // show selected item
                product.IsVisible = true;
                UpdateProducts(product);
            }

            _oldProduct = product;
        }

        private void UpdateProducts(Profesor product)
        {
            var index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(index, product);
        }

    }
}