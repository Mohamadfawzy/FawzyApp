using FawzyApp.ViewModels;
using FawzyApp.Views.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FawzyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        private readonly StudentsPageVM vmModel;
        public StudentsPage()
        { 
            InitializeComponent();
            vmModel = BindingContext as StudentsPageVM;
        }
        protected override void OnAppearing()
        {
            if (vmModel != null)
                vmModel.AllStudents();
            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(CreateStudentPage));
        }
    }
}