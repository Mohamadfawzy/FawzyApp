using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FawzyApp.Views.GalleryPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormsPage : ContentPage
    {
        public int CVCount = 2;
        public FormsPage()
        {
            InitializeComponent();
            //BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            buttonPrevious.IsEnabled = false;
            //cVForms.Position = 0;
        }
    }
}