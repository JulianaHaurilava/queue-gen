using Q.Models;
using Q.ViewModels;
using Q.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q.Views
{
    public partial class QueuesPage : ContentPage
    {
        QueueViewModel _viewModel;

        public QueuesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new QueueViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}