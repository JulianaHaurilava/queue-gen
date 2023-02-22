using System;
using Xamarin.Forms;
using Q.Models;
using Q.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Q.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ChooseStudentViewModel : BaseViewModel
    {
        private Student _selectedItem;

        private string itemId;
        public string Id { get; set; }
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
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await QueueDataStore.GetItemAsync(itemId);
                Id = item.Id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Queue");
            }
        }

        public ObservableCollection<Student> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Student> ItemTapped { get; }

        public ChooseStudentViewModel()
        {
            Title = "Формирование очереди";
            Items = new ObservableCollection<Student>();
            ItemTapped = new Command<Student>(OnItemSelected);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Student SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        
        async void OnItemSelected(Student item)
        {
            if (item == null)
                return;

            var itemQ = await QueueDataStore.GetItemAsync(itemId);
            itemQ.SortedStudents.Add(item);
            await QueueDataStore.UpdateItemAsync(itemQ);
            await Shell.Current.GoToAsync("..");

            //await Shell.Current.GoToAsync($"{nameof(ConfirmLabPage)}?{nameof(ConfirmLabViewModel.ItemId)}={item.Id}");
        }
    }
}
