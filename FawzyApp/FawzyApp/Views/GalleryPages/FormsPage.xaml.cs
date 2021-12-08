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

            MessagingCenter.Subscribe<FormView2, bool>(this, "Hi", (sender, arg) =>
            {
                //HiddingElemints(arg);
                shado.IsVisible = arg;
            });

            //cVForms.Position = 0;
        }

        private async void HiddingElemints(bool status)
        {

            if (!status)
            {
                //await header.TranslateTo(0, -header.Height, easing: Easing.SinIn);
                //await footer.TranslateTo(0, footer.Height, easing: Easing.SinIn);

               // header.IsVisible = status;
               // footer.IsVisible = status;

                //Grid.SetRow(cVForms, 0);
                //Grid.SetRowSpan(cVForms, 3);

                cVForms.VerticalOptions = LayoutOptions.FillAndExpand;
                //OnPropertyChanged(nameof(cVForms));
               
            }
            else
            {
               //header.IsVisible = status;
                //footer.IsVisible = status;

                //await header.TranslateTo(0, 0, easing: Easing.SinIn);
                //await footer.TranslateTo(0, 0, easing: Easing.SinIn);

                //Grid.SetRow(cVForms, 1);
                //Grid.SetRowSpan(cVForms, 1);

                cVForms.VerticalOptions = LayoutOptions.Start;
                //OnPropertyChanged(nameof(cVForms));

               
            }
            
        }
    }
}