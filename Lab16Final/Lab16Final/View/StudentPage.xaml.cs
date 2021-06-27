using System;
using Lab16Final.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab16Final.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        private bool _isNew;

        public StudentPage(bool isNew = false)
        {
            InitializeComponent();
            _isNew = isNew;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var student = (Student)BindingContext;
            await App.StudentManager.SaveTaskAsync(student, _isNew);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (Student)BindingContext;
            await App.StudentManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}