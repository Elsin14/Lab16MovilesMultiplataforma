using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab16Final.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab16Final.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ListView.ItemsSource = await App.StudentManager.GetTasksAsync();

        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentPage(true)
            { 
                BindingContext = new Student()
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new StudentPage()
            {
                BindingContext = e.SelectedItem as Student
            });
        }
    }
}