using Q.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Q.ViewModels
{

    public class ConfirmLabViewModel : BaseViewModel
    {
        private string itemId;
        private string firstName;
        private string lastName;
        private int labNumber;
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
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
        public Command LoadItemsCommand { get; }
        public Command CancelCommand { get; }

        public ConfirmLabViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(labNumber.ToString())
                && labNumber > 0;
        }
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await StudentDataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Student");
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var studentToChange = await StudentDataStore.GetItemAsync(itemId);
            studentToChange.LabNumber = LabNumber;

            await StudentDataStore.UpdateItemAsync(studentToChange);

            await Shell.Current.GoToAsync("..");
        }

    }
}
