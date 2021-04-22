using Lesconario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LESCOnario.ViewModels
{
    class EditarListViewModel
    {
        private Curso _oldProduct;

        public ObservableCollection<Curso> Products { get; set; }

        public EditarListViewModel()
        {
            List<CursoxProfe> list = App.DatabaseC.getList();
            Products = new ObservableCollection<Curso> { };
            for (int i = 0; i < list.Count; i++)
            {
                Curso p = new Curso();
                p.nombre = list[i].nombre;
                p.IsVisible = list[i].IsVisible;
                Products.Add(p);
            }
        }

        public void ShowOrHidePoducts(Curso product)
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

        private void UpdateProducts(Curso product)
        {
            var index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(index, product);
        }
    }
}
