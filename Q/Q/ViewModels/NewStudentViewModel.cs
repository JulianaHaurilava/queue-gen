using Q.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Q.ViewModels
{
    public class NewStudentViewModel : BaseViewModel
    {
        private string firstName;
        private string lastName;
        private int labNumber;

        public NewStudentViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(firstName)
                && !String.IsNullOrWhiteSpace(lastName)
                && !String.IsNullOrWhiteSpace(labNumber.ToString());
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        public int LabNumber
        {
            get => labNumber;
            set => SetProperty(ref labNumber, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Student newItem = new Student()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = FirstName,
                LastName = LastName,
                LabNumber = LabNumber
            };

            await StudentDataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
