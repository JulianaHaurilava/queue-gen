using Q.Models;
using Q.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Q.ViewModels
{
    public class QueueViewModel : BaseViewModel
    {
        private Queue _selectedItem;

        public ObservableCollection<Queue> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Queue> ItemTapped { get; }

        public QueueViewModel()
        {
            Title = "Очереди";
            Items = new ObservableCollection<Queue>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Queue>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await QueueDataStore.GetItemsAsync(true);
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

        public Queue SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewQueuePage));
        }

        async void OnItemSelected(Queue item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(QueueDetailPage)}?{nameof(QueueDetailViewModel.ItemId)}={item.Id}");
        }
    }
}