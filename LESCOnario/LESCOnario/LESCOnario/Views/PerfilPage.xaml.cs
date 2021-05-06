using Lesconario.Models;
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
    public partial class PerfilPage : ContentPage
    {
        private User user;
        public PerfilPage()
        {
            InitializeComponent();            
        }

        private async void UserLoader()
        {

            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(LoginPage));
            Entry EntryUserEmail = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "EntryUserEmail");
            Entry EntryUserPassword = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "EntryUserPassword");
            
            user = new User();
            user = await App.Database.GetNoteAsync(EntryUserEmail.Text, EntryUserPassword.Text);
        }

    }
}