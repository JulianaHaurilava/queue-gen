using Q.ViewModels;
using Q.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Q
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QueueDetailPage), typeof(QueueDetailPage));
            Routing.RegisterRoute(nameof(NewQueuePage), typeof(NewQueuePage));
            Routing.RegisterRoute(nameof(NewStudentPage), typeof(NewStudentPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
