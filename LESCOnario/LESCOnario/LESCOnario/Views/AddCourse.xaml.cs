namespace LESCOnario.Views
{
    using Lesconario.Models;
    using LESCOnario.Models;
    using LESCOnario.ViewModels;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCourse : ContentPage
    {
        public AddCourse(Course course)
        {
            try
            {
                InitializeComponent();
                AddCourseViewModel vm = new AddCourseViewModel(course);
                this.BindingContext = vm;
            }
            catch (Exception)
            {

            }

        }
    }
}