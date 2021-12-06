using FawzyApp.Services.RequestProvider;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FawzyApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        //private IRequestProvider requestProvider;
        
        public AboutViewModel()
        {
            //requestProvider = DependencyService.Get<IRequestProvider>();
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}