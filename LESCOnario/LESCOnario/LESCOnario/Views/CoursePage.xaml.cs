namespace LESCOnario.Views
{
    using Lesconario.Models;
    using LESCOnario.ViewModels;
    using System;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage : ContentPage
    {
        readonly CoursesViewModel vm;
        public CoursePage()
        {
            InitializeComponent();
            vm = new CoursesViewModel();
            this.BindingContext = vm;
        }


        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetCourses();

            base.OnAppearing();
        }

        private async void BtnAddCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCourse(null));
        }

        private async void ListCourse_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (ListCourse.SelectedItem != null)
                {
                    var product = (Course)ListCourse.SelectedItem;
                    ListCourse.SelectedItem = null;
                    await Navigation.PushAsync(new AddCourse(product));
                }
            }
            catch (Exception)
            {

            }
        }

        private async void BtnDeleteCourse_Clicked(object sender, EventArgs e)
        {
            try
            {
                string ID = (sender as Button).CommandParameter.ToString();
                if (!string.IsNullOrWhiteSpace(ID))
                {
                    var product = vm.ListCourses.Where(x => x.ID.ToString() == ID);
                    var result = await DisplayAlert("Confirmar", "Eliminar el Curso:" + product.FirstOrDefault().Name + "?", "Si", "No");
                    if (result)
                        vm.DeleteCourse(product.FirstOrDefault());
                }


            }
            catch (Exception)
            {

            }
        }
    }
}