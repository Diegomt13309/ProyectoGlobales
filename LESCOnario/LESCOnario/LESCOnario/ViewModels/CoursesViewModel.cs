namespace LESCOnario.ViewModels
{
    using Lesconario.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;
    public class CoursesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Course> listCourses { get; set; }
        private Course _oldProduct;

        public ObservableCollection<Course> ListCourses
        {
            get { return listCourses; }
            set
            {
                listCourses = value;
                OnPropertyChanged();
            }
        }


        public Command btnAddCourse { get; set; }

        private string lblInfo { get; set; }
        public string LblInfo
        {
            get { return lblInfo; }
            set
            {
                lblInfo = value;
                OnPropertyChanged();
            }
        }

        public CoursesViewModel()
        {
            ListCourses = new ObservableCollection<Course>();

        }

        public async void GetCourses()
        {
            try
            {
                var courses = await App.Database_course.NotesAsync;

                if (courses != null && courses.Count > 0)
                {
                    ListCourses = new ObservableCollection<Course>();

                    foreach (var course in courses)
                    {
                        ListCourses.Add(new Course
                        {
                            ID = course.ID,
                            Name = course.Name,
                            Code = course.Code,
                            Quantity = course.Quantity
                        });
                    }

                    LblInfo = "Hay " + courses.Count.ToString() + " registro(s) encontrados";
                }
                else
                    LblInfo = "No se encontro ningun registro. Agregue uno nuevo!";
            }

            catch (Exception ex)
            {
                LblInfo = ex.Message.ToString();
            }
        }

        public async void DeleteCourse(Course course)
        {
            try
            {
                if (await App.Database_course.DeleteNoteAsync(course) == 1)
                    GetCourses();
                else
                    LblInfo = "No se pudo eliminar este Curso!";
            }

            catch (Exception ex)
            {
                LblInfo = ex.Message.ToString();
            }
        }

        public void ShowOrHidePoducts(Course product)
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

        private void UpdateProducts(Course product)
        {
            var index = listCourses.IndexOf(product);
            listCourses.Remove(product);
            listCourses.Insert(index, product);
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}