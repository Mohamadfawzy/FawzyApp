using FawzyApp.Services.RequestProvider;
using FawzyApp.Views.PopupsViews;
using FawzyShared.Models;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using std = FawzyShared.Models.Students;
namespace FawzyApp.ViewModels.StudentVM
{
    public class CreateStudentPageVM : BaseViewModel
    {
        private readonly IRequestProvider requestProvider;

        public std Student { get; set; } //= new std();
        public ICommand SaveNewStudentCommand => new Command(ExecuteSaveNewStudentCommand);


        // Constructor -----------------------------------------------------------
        public CreateStudentPageVM()
        {
            // new instance 
            Student = new std();


            requestProvider = DependencyService.Get<IRequestProvider>();

            // call init methods

        }


        // Methoes for Execute Commands
        private async void ExecuteSaveNewStudentCommand()
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new BasicPopup());
            OnPropertyChanged(nameof(Student));

            // After checking
            ResponseResult<std> s = await requestProvider.PostOneAsync<ResponseResult<std>, std>(Student, "Students/Create");
            if(s.Status)
            {
                await App.Current.MainPage.Navigation.PopPopupAsync();
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}
