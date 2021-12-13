using FawzyApp.Models;
using FawzyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FawzyApp.ViewModels.GalleryPagesVM
{
    public class FormsPageVM : BaseViewModel
    {
        private int cVFormsPosition = 0;
        public int CVFormsPosition
        {
            get { return cVFormsPosition; }
            set { SetProperty(ref cVFormsPosition, value); }
        }
        public List<FormModel> ListFormModel { get; set; } = new List<FormModel>()
        {
                new FormModel { Name = "view1", Position = 0 },
                new FormModel { Name = "view2", Position = 1 },
                new FormModel { Name = "view3", Position = 2 },
        };

        public ICommand NextCommand => new Command(ExecuteNextCommand);
        public ICommand PreviousCommand => new Command(ExecutePreviousCommand);

        // Costructor -------------------------------------------
        public FormsPageVM()
        {

        }

        private void ExecuteNextCommand()
        {
            if (CVFormsPosition >= 2)
                return;
            CVFormsPosition++;
        }

        private void ExecutePreviousCommand()
        {
            if (CVFormsPosition <= 0)
                return;
            CVFormsPosition--;
        }


    }
}
