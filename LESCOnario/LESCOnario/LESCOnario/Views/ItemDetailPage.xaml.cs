using LESCOnario.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LESCOnario.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}