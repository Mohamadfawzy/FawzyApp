using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xct = Xamarin.CommunityToolkit;
namespace FawzyApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           Shell.Current.GoToAsync("FormsPage");
           //Navigation.PushAsync()
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("ShapesPage");

        }
    }
}