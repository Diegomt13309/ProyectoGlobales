namespace LESCOnario.ViewModels
{
    using Lesconario.Models;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;
    public class AddCourseViewModel : INotifyPropertyChanged
    {
        private Course courseModel { get; set; }

        public Course CourseModel
        {
            get { return courseModel; }
            set
            {
                courseModel = value;
                OnPropertyChanged();
            }
        }

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

        private string btnSaveLabel { get; set; }
        public string BtnSaveLabel
        {
            get { return btnSaveLabel; }
            set
            {
                btnSaveLabel = value;
                OnPropertyChanged();
            }
        }

        public Command btnSaveCourse { get; set; }
        public Command btnClearCourse { get; set; }
        public AddCourseViewModel(Course obj)
        {
            if (obj == null || obj.ID == 0)
                ClearCourse();
            else
            {
                CourseModel = obj;
                BtnSaveLabel = "Actualizar";
            }
            btnSaveCourse = new Command(SaveCourseAsync);
            btnClearCourse = new Command(ClearCourse);
        }

        public async void SaveCourseAsync()
        {
            try
            {
                CourseModel.IsVisible = false;

                if (await App.Database_course.SaveNoteAsync(CourseModel) == 1)
                {

                    if (BtnSaveLabel.Equals("Agregar"))
                    {
                        ClearCourse();
                        LblInfo = "El Curso se guardo con exito!";
                    }
                    else
                    {
                        ClearCourse();
                        LblInfo = "El Curso se actualizo con exito!";
                    }
                }
                else
                    LblInfo = "La informacion del curso no se pudo guardar!";
            }

            catch (Exception ex)
            {
                LblInfo = ex.Message.ToString();
            }
        }

        public void ClearCourse()
        {
            CourseModel = new Course
            {
                ID = 0,
                Name = "",
                Code = null,
                Quantity = null
            };
            LblInfo = "";
            BtnSaveLabel = "Agregar";
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}