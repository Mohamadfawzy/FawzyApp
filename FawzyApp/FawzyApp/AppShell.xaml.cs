using FawzyApp.ViewModels;
using FawzyApp.Views;
using FawzyApp.Views.AppDataTemplate;
using FawzyApp.Views.GalleryPages;
using FawzyApp.Views.Product;
using FawzyApp.Views.Student;
using FawzyApp.Views.XBook;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FawzyApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            // Routing 
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CreateStudentPage), typeof(CreateStudentPage));
            Routing.RegisterRoute(nameof(StudentDetailsPage), typeof(StudentDetailsPage));
            Routing.RegisterRoute(nameof(FormsPage), typeof(FormsPage));
            Routing.RegisterRoute(nameof(ShapesPage), typeof(ShapesPage));
            Routing.RegisterRoute(nameof(CreateProductPage), typeof(CreateProductPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
