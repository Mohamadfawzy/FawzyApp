using FawzyApp.Views.PopupsViews;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FawzyApp.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateStudentPage : ContentPage
    {
        public CreateStudentPage()
        {
            InitializeComponent();
        }
        async void d()
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new BasicPopup());
        }

    }
}