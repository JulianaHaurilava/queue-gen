using Q.Models;
using Q.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Q.ViewModels
{
    public class NewQueueViewModel : BaseViewModel
    {
        private string name;
        private string type;

        public NewQueueViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(type);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
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
            Models.Queue newItem = new Models.Queue()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Type = Type
            };

            //switch (newItem.Type)
            //{
            //    case "По алфавиту":
            //        {
            //            newItem.SortedStudents = (await StudentDataStore.GetItemsAsync(true))
            //                .OrderBy(x => x.LastName)
            //                .ThenBy(x => x.FirstName)
            //                .ToList();
            //            break;
            //        }
            //    case "По выполненым ЛР":
            //        {
            //            newItem.SortedStudents = (await StudentDataStore.GetItemsAsync(true))
            //                .OrderBy(x => x.LabNumber)
            //                .ToList();
            //            break;
            //        }
            //    case "Рандомно":
            //        {
            //            newItem.SortedStudents = (await StudentDataStore.GetItemsAsync(true)).ToList();
            //            break;
            //        }
            //}

            

            await QueueDataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");

        }
    }
}
