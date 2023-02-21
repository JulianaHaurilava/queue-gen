using Q.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Q.Views
{
    public partial class QueueDetailPage : ContentPage
    {
        public QueueDetailPage()
        {
            InitializeComponent();
            BindingContext = new QueueDetailViewModel();
        }
    }
}