using Q.Models;
using Q.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Q.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        private Student _selectedItem;

        public ObservableCollection<Student> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Student> ItemTapped { get; }

        public StudentsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Student>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Student>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
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

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewStudentPage));
        }

        async void OnItemSelected(Student item)
        {
            if (item == null)
                return;

            // This will push the QueueDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(QueueDetailPage)}?{nameof(QueueDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
