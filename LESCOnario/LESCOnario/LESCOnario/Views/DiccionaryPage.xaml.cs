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
    public partial class DiccionaryPage : ContentPage
    {
        public DiccionaryPage()
        {
            InitializeComponent();
            BindingContext = new CardViewModel();
        }
    }
}