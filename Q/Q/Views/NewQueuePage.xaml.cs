using Q.Models;
using Q.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q.Views
{
    public partial class NewQueuePage : ContentPage
    {
        public Queue Item { get; set; }

        public NewQueuePage()
        {
            InitializeComponent();
            BindingContext = new NewQueueViewModel();
        }
    }
}