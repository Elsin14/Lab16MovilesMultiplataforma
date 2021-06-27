using System;
using Xamarin.Forms;
using Lab16Final.Data;

namespace Lab16Final
{
    public partial class App : Application
    {
        public static StudentManager StudentManager { get; set; }
        public App()
        {
            InitializeComponent();

            StudentManager = new StudentManager(new RestService());

            MainPage = new NavigationPage(new View.StudentPage());
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
