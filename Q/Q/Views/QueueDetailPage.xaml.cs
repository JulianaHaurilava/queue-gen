using Q.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Q.Views
{
    public partial class QueueDetailPage : ContentPage
    {
        QueueDetailViewModel _viewModel;
        public QueueDetailPage()
        {
            InitializeComponent();
            BindingContext = new QueueDetailViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _viewModel.OnAppearing();
        //}
    }
}