using Lesconario.Services;
using LESCOnario.Services;
using LESCOnario.ViewModels;
using LESCOnario.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LESCOnario
{
    public partial class App : Application
    {

        static DataBaseStoreUser database;
        static DataBaseStoreCourse database_course;

        public static DataBaseStoreUser Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseStoreUser(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Users.db3"));
                }
                return database;
            }
        }

        public static DataBaseStoreCourse Database_course
        {
            get
            {
                if (database_course == null)
                {
                    database_course = new DataBaseStoreCourse(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Courses.db3"));
                }
                return database_course;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
