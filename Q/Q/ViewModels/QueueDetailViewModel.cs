using Q.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Q.Views;

namespace Q.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class QueueDetailViewModel : BaseViewModel
    {
        private string itemId;
        private Queue item;

        private string firstName;
        private string lastName;
        private int labNumber;

        public ObservableCollection<Student> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command ConfirmStudent { get; }

        public QueueDetailViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Student>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ConfirmStudent = new Command(OnAddItem);
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var queue = await QueueDataStore.GetItemAsync(itemId);
                Items.Clear();
                foreach (var item in queue.SortedStudents)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddItem(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(ChooseStudentPage));
            await Shell.Current.GoToAsync($"{nameof(ChooseStudentPage)}?{nameof(ChooseStudentViewModel.ItemId)}={item.Id}");
        }
        public string Id { get; set; }
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

        private Queue _selectedItem;
        public Queue SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        void OnItemSelected(Queue item)
        {
            if (item == null)
                return;
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                item = await QueueDataStore.GetItemAsync(itemId);
                Id = item.Id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Queue");
            }
        }
    }
}
