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
        static DataBaseStoreProfesor databaseP;
        static DataBaseStoreCurso databaseC;

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
        public static DataBaseStoreProfesor DatabaseP
        {
            get
            {
                if (databaseP == null)
                {
                    databaseP = new DataBaseStoreProfesor(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Profesor.db3"));
                }
                return databaseP;
            }
        }
        public static DataBaseStoreCurso DatabaseC
        {
            get
            {
                if (databaseC == null)
                {
                    databaseC = new DataBaseStoreCurso(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CursoxProfe.db3"));
                }
                return databaseC;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            ListProfesoresViewModel aux = new ListProfesoresViewModel();
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
