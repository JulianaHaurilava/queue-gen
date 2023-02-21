using Q.Models;
using Q.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Q.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class QueueDetailViewModel : BaseViewModel
    {
        private string itemId;

        private string firstName;
        private string lastName;
        private int labNumber;

        public ObservableCollection<Student> Items { get; }
        public Command LoadItemsCommand { get; }

        public QueueDetailViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Student>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var queue = await QueueDataStore.GetItemAsync(itemId);

                switch (queue.Type)
                {
                    case "По алфавиту": 
                }

                Items.Clear();
                var items = await StudentDataStore.GetItemsAsync(true);
                foreach (var item in items)
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

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //}

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await StudentDataStore.GetItemAsync(itemId);
                Id = item.Id;
                LastName = item.LastName;
                FirstName = item.FirstName;
                LabNumber= item.LabNumber;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Queue");
            }
        }
    }
}
