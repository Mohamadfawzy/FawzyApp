using FawzyApp.Services.RequestProvider;
using Stud = FawzyShared.Models.Students;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace FawzyApp.ViewModels
{
    public class StudentsPageVM : BaseViewModel
    {
        private readonly IRequestProvider requestProvider;
        public List<Stud> Students { get; set; }
        public StudentsPageVM()
        {
            requestProvider = DependencyService.Get<IRequestProvider>();

            // call defult methonds
            //AllStudents();
        }
        public ICommand DeleteStudentCommand => new Command<Stud>(ExecuteDeleteStudentCommand);
        public ICommand StudentDelailsCommand => new Command<Stud>(ExecuteStudentDelailsCommand);


        public async void AllStudents()
        {
            Students = await requestProvider.GetListAsync<List<Stud>>("Students");
            OnPropertyChanged(nameof(Students));
        }

        private void ExecuteDeleteStudentCommand(Stud student)
        {
            var result = requestProvider.DeleteOneAsync<Stud>(student.ID, "Students/delete");
            AllStudents();
        }
        private void ExecuteStudentDelailsCommand(Stud student)
        {
            Shell.Current.GoToAsync("StudentDetailsPage");
        }


        private async void CreateStudent()
        {
            var student = new Stud() { Name = "Ahemd", Phones = 1234, SSD = 34985735 };

            var result = await requestProvider.PostOneAsync<Stud, Stud>(student, "");
        }

    }
}
